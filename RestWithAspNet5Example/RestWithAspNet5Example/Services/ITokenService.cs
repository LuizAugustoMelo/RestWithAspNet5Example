using System.Security.Claims;

namespace RestWithAspNet5Example.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpireToken(string token);
    }
}
