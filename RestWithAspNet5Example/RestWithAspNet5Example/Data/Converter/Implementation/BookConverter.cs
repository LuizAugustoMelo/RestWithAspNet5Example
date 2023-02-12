using RestWithAspNet5Example.Data.Converter.Contract;
using RestWithAspNet5Example.Data.DTO;
using RestWithAspNet5Example.Model;
using System.Net;
using System.Reflection;

namespace RestWithAspNet5Example.Data.Converter.Implementation
{
    public class BookConverter : IParser<BookDTO, Book>, IParser<Book, BookDTO>
    {
        public Book? Parse(BookDTO origin)
        {
            if (origin == null) return null;

            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                Launch_Date = origin.Launch_Date,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public BookDTO? Parse(Book origin)
        {
            if (origin == null) return null;

            return new BookDTO
            {
                Id = origin.Id,
                Author = origin.Author,
                Launch_Date = origin.Launch_Date,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<Book?>? Parse(List<BookDTO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public List<BookDTO?>? Parse(List<Book> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
