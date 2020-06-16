using Fleeter.Core.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Core.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, ISearchableEntity
    {
        protected readonly IConnectionFactory _factory;

        public BaseRepository(IConnectionFactory factory)
        {
            _factory = factory;
        }
        public virtual IEnumerable<T> FindAll()
        {
            using var session = _factory.OpenSession();
            return session.Query<T>();
        }

        public virtual T FindById(int id)
        {
            using var session = _factory.OpenSession();
            return session.Query<T>().Where(e => e.Id == id).SingleOrDefault(null);
        }

        public virtual void CreateOrUpdate(T entity)
        {
            using var session = _factory.OpenSession();
            using var transaction = session.BeginTransaction();
            session.Save(entity);
            transaction.Commit();
        }

        public virtual void Delete(T entity)
        {
            using var session = _factory.OpenSession();
            using var transaction = session.BeginTransaction();
            session.Delete(entity);
            transaction.Commit();
        }

    }
}
