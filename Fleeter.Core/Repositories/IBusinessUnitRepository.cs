using Fleeter.Core.Models;

namespace Fleeter.Core.Repositories
{
    public interface IBusinessUnitRepository : IRepository<BusinessUnit>
    {
        BusinessUnit FindByName(string name);
    }
}
