using Fleeter.Core.Database;
using Fleeter.Core.Models;
using System.Linq;

namespace Fleeter.Core.Repositories
{
    public class BusinessUnitRepository : BaseRepository<BusinessUnit>, IBusinessUnitRepository
    {
        public BusinessUnitRepository(IConnectionFactory factory) : base(factory) { }

        public BusinessUnit FindByName(string name)
        {
            using var session = _factory.OpenSession();
            return session.Query<BusinessUnit>().FirstOrDefault(bu => bu.Name.ToLower() == name.ToLower());
        }
    }
}
