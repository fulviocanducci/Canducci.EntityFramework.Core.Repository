using Canducci.EntityFramework.Repository.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Canducci.EntityFramework.Repository.EFCore
{
    public abstract class Repository<T> : IRepository<T> where T: class
    {
        private DbContext Context { get; }
        private DbSet<T> Model { get; }

        public Repository(DbContext context)
        {
            Context = context;
            Model = Context.Set<T>();
        }

        public T Add(T model)
        {
            Model.Add(model);
            Save();
            return model;
        }

        public async Task<T> AddAsync(T model)
        {
            Model.Add(model);
            await SaveAsync();
            return model;
        }

        public bool Delete(T model)
        {
            Model.Remove(model);
            return Save() > 0;
        }

        public bool Delete(params object[] keys)
        {
            var model = Find(keys);
            return Delete(model);
        }

        public bool Delete(Expression<Func<T, bool>> where)
        {
            var model = Model.Where(where).FirstOrDefault();
            if (model != null)
            {
                return Delete(model);
            }
            return false;
        }

        public async Task<bool> DeleteAsync(T model)
        {
            Model.Remove(model);
            return await SaveAsync() > 0;
        }

        public async Task<bool> DeleteAsync(params object[] keys)
        {
            var model = await FindAsync(keys);
            if (model != null)
            {
                return await DeleteAsync(model);
            }
            return false;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> where)
        {
            var model =  await Model.Where(where).FirstOrDefaultAsync();
            if (model != null)
            {
                return await DeleteAsync(model);
            }
            return false;
        }

        public bool Edit(T model)
        {
            Model.Update(model);
            return Save() > 0;
        }

        public async Task<bool> EditAsync(T model)
        {
            Model.Update(model);
            return await SaveAsync() > 0;
        }

        public T Find(params object[] keys)
        {
            return Model.Find(keys);
        }

        public async Task<T> FindAsync(params object[] keys)
        {
            return await Model.FindAsync(keys);
        }

        public IEnumerable Get()
        {
            return Model.AsEnumerable();
        }

        public IEnumerable<T> Get(Expression<Func<T, object>> orderBy)
        {
            return Model.OrderBy(orderBy).AsEnumerable();
        }

        public async Task<IList> GetAsync()
        {
            return await Model.ToListAsync();
        }

        public async Task<IList<T>> GetAsync(Expression<Func<T, object>> orderBy)
        {
            return await Model.OrderBy(orderBy).ToListAsync();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public IQueryable<T> Query()
        {            
            return Model.AsNoTracking().AsQueryable();
        }
        public IQueryable<TResult> Query<TResult>(Expression<Func<T, TResult>> select)
        {
            return Query()
                .Select(select);
        }
        public IQueryable<TResult> Query<TResult, Tkey>(Expression<Func<T, TResult>> select, Expression<Func<TResult, Tkey>> orderBy)
        {
            return Query(select)
                .OrderBy(orderBy);
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Repository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        
        #endregion
    }
}
