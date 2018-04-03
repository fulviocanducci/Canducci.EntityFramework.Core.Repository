using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Canducci.EntityFramework.Repository.Core
{
    public interface IRepository<T>: IDisposable where T: class
    {
        T Add(T model);
        bool Edit(T model);
        bool Delete(T model);
        bool Delete(params object[] keys);
        bool Delete(Expression<Func<T, bool>> where);
        T Find(params object[] keys);
        IEnumerable Get();
        IEnumerable<T> Get(Expression<Func<T, object>> orderBy);

        int Save();

        #region Async
        Task<T> AddAsync(T model);
        Task<bool> EditAsync(T model);
        Task<bool> DeleteAsync(T model);
        Task<bool> DeleteAsync(params object[] keys);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> where);
        Task<T> FindAsync(params object[] keys);
        Task<IList> GetAsync();
        Task<IList<T>> GetAsync(Expression<Func<T, object>> orderBy);

        Task<int> SaveAsync();
        #endregion

        IQueryable<T> Query();
        IQueryable<TResult> Query<TResult>(Expression<Func<T, TResult>> select);
        IQueryable<TResult> Query<TResult>(Expression<Func<T, TResult>> select, params Expression<Func<TResult, object>>[] order);
    }
}
