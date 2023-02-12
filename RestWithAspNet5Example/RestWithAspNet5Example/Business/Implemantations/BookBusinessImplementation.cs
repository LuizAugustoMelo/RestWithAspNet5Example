using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestWithAspNet5Example.Data.Converter.Contract;
using RestWithAspNet5Example.Data.Converter.Implementation;
using RestWithAspNet5Example.Data.DTO;
using RestWithAspNet5Example.Model;
using RestWithAspNet5Example.Model.Context;
using RestWithAspNet5Example.Repository;
using System;

namespace RestWithAspNet5Example.Business.Implemantations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> IBookRepository)
        {
            _repository = IBookRepository;
            _converter = new BookConverter();
        }

        public List<BookDTO?>? FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookDTO? FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookDTO? Create(BookDTO book)
        {
            var bookEntity = _converter.Parse(book);
            return _converter.Parse(_repository.Create(bookEntity));
        }

        public BookDTO? Update(BookDTO book)
        {
            var bookEntity = _converter.Parse(book);
            return _converter.Parse(_repository.Update(bookEntity));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
