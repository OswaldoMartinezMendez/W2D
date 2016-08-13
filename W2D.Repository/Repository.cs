using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace W2D.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicad)
        {
            return _context.Set<T>().Where(predicad);
        }

        public T FindT(Expression<Func<T, bool>> predicad)
        {
            return _context.Set<T>().Where(predicad).FirstOrDefault();
        }

        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            if (_context.Entry<T>(entity).State != System.Data.Entity.EntityState.Detached)
                _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            if (_context.Entry<T>(entity).State == System.Data.Entity.EntityState.Detached)
                _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(T enntity)
        {
            if (_context.Entry<T>(enntity).State == System.Data.Entity.EntityState.Detached)
                _context.Set<T>().Attach(enntity);
            _context.Entry<T>(enntity).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            return;
        }
    }
}
