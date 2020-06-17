using Fleeter.Core.Models;

namespace Fleeter.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public Employee FindByEmployeeNumber(int nr);
    }
}
