using Fleeter.Core.Database;
using Fleeter.Core.Models;

namespace Fleeter.Core.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConnectionFactory factory) : base(factory) { }
    }
}
