using Fleeter.Core.Database;
using Fleeter.Core.Models;

namespace Fleeter.Core.Repositories
{
    public class BusinessUnitRepository : BaseRepository<BusinessUnit>, IBusinessUnitRepository
    {
        public BusinessUnitRepository(IConnectionFactory factory) : base(factory) { }
    }
}
