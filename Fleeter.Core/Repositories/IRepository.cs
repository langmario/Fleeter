using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        IList<T> FindAll();

        T FindById(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
