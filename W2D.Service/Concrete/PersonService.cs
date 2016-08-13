using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using W2D.Domain.Entities;
using W2D.Repository;
using W2D.Service.Contracts;

namespace W2D.Service.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly Repository<Person> _repository = new Repository<Person>(new W2DEntities());

        public void Add(Person person)
        {
            _repository.Add(person);
            _repository.Save();
        }

        public void Update(Person person)
        {
            _repository.Update(person);
            _repository.Save();
        }

        public void Delete(Person person)
        {
            _repository.Delete(person);
            _repository.Save();
        }

        public IEnumerable<Person> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Person GetById(int id)
        {
            return _repository.FindById(id);
        }

        public Person FindT(Expression<Func<Person, bool>> predicad)
        {
            return _repository.FindT(predicad);
        }

    }
}
