using RestWithAspNet5Example.Data.DTO;
using RestWithAspNet5Example.Hypermedia.Utils;
using RestWithAspNet5Example.Model;

namespace RestWithAspNet5Example.Business
{
    public interface IPersonBusiness
    {
        PersonDTO Create(PersonDTO person);
        PersonDTO FindById(long id);
        List<PersonDTO>? FindByName(string firstName, string lastName);
        List<PersonDTO> FindAll();
        PagedSearchDTO<PersonDTO> FindWithPagedSearch(string? name, string sortDirection, int pageSize, int page);
        PersonDTO Update(PersonDTO person);
        PersonDTO Disable(long id);
        void Delete(long id);
    }
}
