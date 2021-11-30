using Domain.Models;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<TokenModel> ValidarCredenciais(AuthUserModel userCredentials);
        Task<TokenModel> ValidarCredenciais(TokenModel token);
        Task<bool> RevovarToken(string usuario);
    }
}
