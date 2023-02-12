using RestWithAspNet5Example.Data.DTO;
using RestWithAspNet5Example.Model;

namespace RestWithAspNet5Example.Business
{
    public interface IBookBusiness
    {
        BookDTO FindById(long id);
        List<BookDTO> FindAll();
        BookDTO Create(BookDTO book);
        BookDTO Update(BookDTO book);
        void Delete(long id);
    }
}
