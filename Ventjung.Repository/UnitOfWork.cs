using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Ventjung.Repository
{
    public class UnitOfWork : IDisposable
    {
        DbContext _ctx;
        private TransactionScope _transaction;
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private bool disposed = false;
        public UnitOfWork(DbContext ctx)
        {
            _ctx = ctx;
        }
        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories.Keys.Contains(typeof(T)) == true)
            {
                return _repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repo = new Repository<T>(_ctx);
            _repositories.Add(typeof(T), repo);
            return repo;
        }
        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void StartTransaction()
        {
            _transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        }
        public void Commit()
        {
            try
            {
                _ctx.SaveChanges();
                _transaction.Complete();
            }
            finally
            {
                _transaction.Dispose();
            }
        }
    }
}
