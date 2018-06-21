using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;

namespace ArthsAppProject
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> GetWithChild(int id);
        Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
        Task<T> Get(Expression<Func<T, bool>> predicate);
        AsyncTableQuery<T> AsQueryable();
        void Insert(T entity);
        void InsertWithChild(T entity);
        void Update(T entity);
        void UpdateWithChild(T entity);
        Task<int> Delete(T entity);
    }
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private SQLiteAsyncConnection db;

        public Repository(SQLiteAsyncConnection db)
        {
            this.db = db;
        }

        public AsyncTableQuery<T> AsQueryable() =>
            db.Table<T>();

        public async Task<List<T>> GetAll() =>
            await db.Table<T>().ToListAsync();

        public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = db.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync();
        }

        public async Task<T> Get(int id) =>
             await db.FindWithChildrenAsync<T>(id, true);

        public async Task<T> Get(Expression<Func<T, bool>> predicate) =>
            await db.FindAsync<T>(predicate);

        public async Task<T> GetWithChild(int pk) =>
            await db.GetWithChildrenAsync<T>(pk);

        public async void Insert(T entity) =>
            await db.InsertAsync(entity);

        public async void InsertWithChild(T entity) =>
            await db.InsertWithChildrenAsync(entity);

        public async void Update(T entity) =>
             await db.UpdateAsync(entity);

        public async void UpdateWithChild(T entity) =>
             await db.UpdateWithChildrenAsync(entity);

        public async Task<int> Delete(T entity) =>
             await db.DeleteAsync(entity);
    }

}
