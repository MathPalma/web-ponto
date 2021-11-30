using System.Collections.Generic;
using System.Security.Claims;

namespace Application.Interfaces
{
    public interface ITokenService
    {
        string GerarAcessToken(IEnumerable<Claim> claims);
        string GerarRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
