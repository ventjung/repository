using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ventjung.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        DbContext _ctx;
        DbSet<T> _dbSet;
        public Repository(DbContext dbContext)
        {
            _ctx = dbContext;
            _dbSet = _ctx.Set<T>();
        }
        public void Dispose()
        {
            _ctx.Dispose();
        }
        public virtual void Create(T entity)
        {
            _dbSet.Attach(entity);
            _ctx.Entry(entity).State = EntityState.Added;
        }
        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _ctx.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            _dbSet.Attach(entity);
            _ctx.Entry(entity).State = EntityState.Deleted;
        }
        public IQueryable<T> GetQuery()
        {
            return _dbSet;
        }
        public IQueryable<T> GetQueryAsNoTracking()
        {
            return _dbSet.AsNoTracking();
        }
        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }
        public T First(Func<T, bool> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }
        public virtual T Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }
        public virtual async Task<T> FindAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }
        public IEnumerable<T> GetList()
        {
            return GetQuery().ToList();
        }
        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await GetQuery().ToListAsync();
        }
        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
