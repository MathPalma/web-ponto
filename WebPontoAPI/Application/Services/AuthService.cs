using Application.Interfaces;
using DataAccessMySql.Interfaces;
using Domain.Configurations;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;
        private readonly TokenConfiguration _tokenConfiguration;

        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public AuthService(IAuthRepository authRepository, ITokenService tokenService, TokenConfiguration tokenConfiguration)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
            _tokenConfiguration = tokenConfiguration;
        }

        public async Task<TokenModel> ValidarCredenciais(AuthUserModel userCredentials)
        {
            try
            {
                string senha = ComputeHash(userCredentials.Senha, new SHA256CryptoServiceProvider());
                UsuarioModel user = await _authRepository.ValidarCredenciais(userCredentials.Usuario, senha);

                if (user == null) return null;

                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Usuario)
                };

                var accesToken =  _tokenService.GerarAcessToken(claims);
                var refreshToken = _tokenService.GerarRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenTempoExpiracao = DateTime.Now.AddDays(_tokenConfiguration.DaysToExpire);

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate.AddMinutes(_tokenConfiguration.Minutes);

                return new TokenModel(true, createDate.ToString(DATE_FORMAT), expirationDate.ToString(DATE_FORMAT), accesToken, refreshToken);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TokenModel> ValidarCredenciais(TokenModel token)
        {
            string accesToken = token.AccessToken;
            string refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accesToken);

            var username = principal.Identity.Name;

            var user = await _authRepository.ValidarCredenciais(username);

            if (user == null ||
                user.RefreshToken != refreshToken ||
                user.RefreshTokenTempoExpiracao <= DateTime.Now) return null;

            accesToken = _tokenService.GerarAcessToken(principal.Claims);
            refreshToken = _tokenService.GerarRefreshToken();

            user.RefreshToken = refreshToken;

            await _authRepository.AtualizarInfoUsuario(user.ID, user.RefreshToken);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_tokenConfiguration.Minutes);

            return new TokenModel(true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accesToken,
                refreshToken);
        }

        public async Task<bool> RevovarToken(string usuario)
        {
            return await _authRepository.RevogarToken(usuario);
        }

        private string ComputeHash(string password, SHA256CryptoServiceProvider sHA256CryptoServiceProvider)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashedBytes = sHA256CryptoServiceProvider.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
