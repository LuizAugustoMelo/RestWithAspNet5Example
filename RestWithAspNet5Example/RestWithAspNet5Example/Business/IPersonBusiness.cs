using RestWithAspNet5Example.Data.DTO;

namespace RestWithAspNet5Example.Business
{
    public interface IPersonBusiness
    {
        PersonDTO Create(PersonDTO person);
        PersonDTO FindById(long id);
        List<PersonDTO> FindAll();
        PersonDTO Update(PersonDTO person);
        PersonDTO Disable(long id);
        void Delete(long id);
    }
}
