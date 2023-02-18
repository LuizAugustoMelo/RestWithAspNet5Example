﻿using RestWithAspNet5Example.Data.Converter.Implementation;
using RestWithAspNet5Example.Data.DTO;
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

        public PersonDTO? FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
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
