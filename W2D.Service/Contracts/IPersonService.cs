using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using W2D.Domain.Entities;

namespace W2D.Service.Contracts
{
    public interface IPersonService
    {
        void Add(Person person);
        void Update(Person person);
        void Delete(Person person);
        IEnumerable<Person> GetAll();
        Person GetById(int id);
        Person FindT(Expression<Func<Person, bool>> predicad);
    }

}
