using Fleeter.Core.Database;
using Fleeter.Core.Models;
using System.Linq;

namespace Fleeter.Core.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConnectionFactory factory) : base(factory) { }

        public Employee FindByEmployeeNumber(int nr)
        {
            using var session = _factory.OpenSession();
            return session.Query<Employee>().FirstOrDefault(e => e.EmployeeNumber == nr);
        }
    }
}
