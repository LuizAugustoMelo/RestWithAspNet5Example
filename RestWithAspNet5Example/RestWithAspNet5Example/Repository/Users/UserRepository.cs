using RestWithAspNet5Example.Data.DTO;
using RestWithAspNet5Example.Model;
using RestWithAspNet5Example.Model.Context;
using System.Security.Cryptography;
using System.Text;

namespace RestWithAspNet5Example.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User? ValidateCredatials(UserDTO user)
        {
            var pass = ComputeHash(user.Password);
            return _context.Users.FirstOrDefault(u => u.UserName.Equals(user.UserName) && u.Password.Equals(pass));
        }

        public User? ValidateCredatials(string userName)
        {
            return _context.Users.SingleOrDefault(u => u.UserName.Equals(userName));
        }

        public bool RevokeToken(string userName)
        {
            var user = ValidateCredatials(userName);
            if (user == null) return false;

            user.RefreshToken = "0";
            _context.SaveChanges();

            return true;
        }

        public User? FindById(long id)
        {
            return _context.Users.SingleOrDefault(x => x.Id.Equals(id));
        }

        public User RefreshUserInfo(User item)
        {
            var result = FindById(item.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return new User();
        }

        private string ComputeHash(string input)
        {
            var sha = SHA256.Create();

            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = sha.ComputeHash(inputBytes);

            return Convert.ToBase64String(hashedBytes);
        }
    }
}
