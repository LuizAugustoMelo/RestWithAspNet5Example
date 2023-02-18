using Microsoft.IdentityModel.JsonWebTokens;
using RestWithAspNet5Example.Configurations;
using RestWithAspNet5Example.Data.DTO;
using RestWithAspNet5Example.Repository.Users;
using RestWithAspNet5Example.Services;
using System.Security.Claims;

namespace RestWithAspNet5Example.Business.Implemantations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;
        private IUserRepository _userRepository;
        private ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository userRepository, ITokenService tokenService)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public bool RevokeToken(string userName)
        {
            return _userRepository.RevokeToken(userName);
        }

        public TokenDTO ValidateCredentials(UserDTO userCredentials)
        {
            var user = _userRepository.ValidateCredatials(userCredentials);
            if (user == null) return new TokenDTO(false, String.Empty, String.Empty, String.Empty, String.Empty);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _userRepository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDTO(true, createDate.ToString(DATE_FORMAT), expirationDate.ToString(DATE_FORMAT), accessToken, refreshToken);
        }

        public TokenDTO ValidateCredentials(TokenDTO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpireToken(accessToken);

            var userName = principal.Identity.Name;

            var user = _userRepository.ValidateCredatials(userName);

            if (user == null ||
                user.RefreshToken != refreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now) 
                return new TokenDTO(false, String.Empty, String.Empty, String.Empty, String.Empty);

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();
            
            user.RefreshToken = refreshToken;

            _userRepository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDTO(true, createDate.ToString(DATE_FORMAT), expirationDate.ToString(DATE_FORMAT), accessToken, refreshToken);
        }
    }
}
