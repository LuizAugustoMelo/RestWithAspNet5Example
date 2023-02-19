using RestWithAspNet5Example.Data.DTO;
using RestWithAspNet5Example.Model;

namespace RestWithAspNet5Example.Repository.Users
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person? Disable(long id);
        List<Person>? FindByName(string firstName, string lastName);
    }
}
