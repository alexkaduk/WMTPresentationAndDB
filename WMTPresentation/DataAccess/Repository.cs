using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WMTPresentation.DataAccess.Interfaces;
using WMTPresentation.Entities;

namespace WMTPresentation.DataAccess
{
    public abstract class Repository<T> : IRepository<T> where T:class, IEntity,  new()
    {
        private readonly DbContext _dataContext;

        protected Repository(IDatabaseFactory databaseFactory)
        {
            _dataContext = databaseFactory.Get();
        }

        protected DbContext DataContext
        {
            get { return _dataContext; }
        }

        public IQueryable<T> Query()
        {
            return _dataContext.Set<T>().AsQueryable();
        }

        public T Get(long id)
        {
            return _dataContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T Get(Func<T, bool> predicate)
        {
            return _dataContext.Set<T>().FirstOrDefault(predicate);
        }

        protected void Update(T entity)
        {
            if (_dataContext.Entry(entity).State == EntityState.Detached)
            {
                _dataContext.Set<T>().Attach(entity);
                _dataContext.Entry(entity).State = entity.IsNew() ? EntityState.Added : EntityState.Modified;
            }
        }

        public void Edit(T entity)
        {
            Update(entity);

            _dataContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            var softDelete = entity as ISoftDeleteEntity;
            if (softDelete != null)
            {
                softDelete.IsDeleted = true;
                Update(entity);
            }
            else
            {
                _dataContext.Set<T>().Remove(entity);
            }

            _dataContext.SaveChanges();
        }
    }
}
