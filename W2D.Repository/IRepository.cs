using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace W2D.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicad);
        T FindT(Expression<Func<T, bool>> predicad);
        T FindById(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T enntity);

        void Save();
    }

}
