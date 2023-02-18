using RestWithAspNet5Example.Data.DTO;
using RestWithAspNet5Example.Model;

namespace RestWithAspNet5Example.Repository.Users
{
    public interface IUserRepository
    {
        User? ValidateCredatials(UserDTO user);
        User? ValidateCredatials(string userName);
        Boolean RevokeToken(string userName);
        User RefreshUserInfo(User item);
    }
}
