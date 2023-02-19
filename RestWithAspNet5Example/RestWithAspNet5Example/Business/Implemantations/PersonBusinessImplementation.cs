using RestWithAspNet5Example.Data.Converter.Implementation;
using RestWithAspNet5Example.Data.DTO;
using RestWithAspNet5Example.Hypermedia.Utils;
using RestWithAspNet5Example.Model;
using RestWithAspNet5Example.Repository;
using RestWithAspNet5Example.Repository.Users;

namespace RestWithAspNet5Example.Business.Implemantations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IPersonRepository IPersonRepository)
        {
            _repository = IPersonRepository;
            _converter = new PersonConverter();
        }

        public List<PersonDTO?>? FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PagedSearchDTO<PersonDTO> FindWithPagedSearch(string? name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.ToUpper().Equals("DESC")) ? "ASC" : "DESC";
            var size = pageSize < 1 ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = $"SELECT * FROM person p WHERE 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) 
                query += $"AND p.FirstName LIKE '%{name}%'";
            query += $"ORDER BY p.FirstName {sort} LIMIT {size} OFFSET {offset}";
            
            string countQuery = "SELECT count(*) FROM person p WHERE 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name))
                countQuery += $"AND p.FirstName LIKE '%{name}%'";


            var persons = _repository.FindWithPagedSearch(query);

            int totalResult = _repository.GetCount(countQuery);

            return new PagedSearchDTO<PersonDTO>()
            {
                CurrentPage = offset,
                Values = _converter.Parse(persons),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResult
            };
        }

        public PersonDTO? FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        public List<PersonDTO>? FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }

        public PersonDTO? Create(PersonDTO person)
        {
            var personEntity = _converter.Parse(person);
            return _converter.Parse(_repository.Create(personEntity));
        }

        public PersonDTO? Update(PersonDTO person)
        {
            var personEntity = _converter.Parse(person);
            return _converter.Parse(_repository.Update(personEntity));
        }

        public PersonDTO? Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
