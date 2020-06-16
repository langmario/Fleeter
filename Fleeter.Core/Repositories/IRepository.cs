using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();

        T FindById(int id);

        void CreateOrUpdate(T entity);

        void Delete(T entity);
    }
}
