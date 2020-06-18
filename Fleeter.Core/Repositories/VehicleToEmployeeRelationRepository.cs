using Fleeter.Core.Database;
using Fleeter.Core.Models;

namespace Fleeter.Core.Repositories
{
    public class VehicleToEmployeeRelationRepository : BaseRepository<VehicleToEmployeeRelation>, IVehicleToEmployeeRelationRepository
    {
        public VehicleToEmployeeRelationRepository(IConnectionFactory factory) : base(factory)
        {
            
        }

        public override void Update(VehicleToEmployeeRelation entity)
        {
            throw new System.NotSupportedException();
        }
    }
}
