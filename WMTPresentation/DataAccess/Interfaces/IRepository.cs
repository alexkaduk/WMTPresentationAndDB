using System;
using System.Linq;
using WMTPresentation.Entities;

namespace WMTPresentation.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> Query();
        T Get(long id);
        T Get(Func<T, bool> predicate);
        void Edit(T entity);
        void Delete(T entity);
    }
}
