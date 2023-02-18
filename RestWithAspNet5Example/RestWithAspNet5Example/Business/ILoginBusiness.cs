using RestWithAspNet5Example.Data.DTO;

namespace RestWithAspNet5Example.Business
{
    public interface ILoginBusiness
    {
        TokenDTO ValidateCredentials(UserDTO user);
        TokenDTO ValidateCredentials(TokenDTO token);
        Boolean RevokeToken(string userName);
    }
}
