using RestWithAspNet5Example.Model;

namespace RestWithAspNet5Example.Service.Implemantations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Luiz",
                LastName = "Melo",
                Address = "Rua Arthur Soter Lopes da Silva, 715 - Jd Esmeralda - Sao Paulo - SP - BR",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }



        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = $"Person Name {i}",
                LastName = $"Person LastName {i}",
                Address = $"Some Address {i}",
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
