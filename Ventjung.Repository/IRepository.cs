using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ventjung.Repository
{
    public interface IRepository<T> : IDisposable
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetQuery();
        IQueryable<T> GetQueryAsNoTracking();
        T Single(Expression<Func<T, bool>> predicate);
        T First(Func<T, bool> predicate);
        T Find(params object[] keyValues);
        Task<T> FindAsync(params object[] keyValues);
        IEnumerable<T> GetList();
        Task<IEnumerable<T>> GetListAsync();
        void SaveChanges();
    }
}
