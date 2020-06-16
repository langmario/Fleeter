using Fleeter.Core.Database;
using Fleeter.Core.Models;

namespace Fleeter.Core.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IConnectionFactory factory) : base(factory) { }
    }
}
