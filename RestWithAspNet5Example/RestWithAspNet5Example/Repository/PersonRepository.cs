using RestWithAspNet5Example.Model;
using RestWithAspNet5Example.Model.Context;
using RestWithAspNet5Example.Repository.Generic;
using RestWithAspNet5Example.Repository.Users;

namespace RestWithAspNet5Example.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySQLContext context) : base (context) { }

        public Person? Disable(long id)
        {
            var user = _context.Persons.SingleOrDefault(p => p.Id == id);

            if (user == null) return null;

            user.Enabled = false;

            try
            {
                _context.Entry(user).CurrentValues.SetValues(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return user;
        }
    }
}
