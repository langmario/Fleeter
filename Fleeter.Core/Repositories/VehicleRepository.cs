using Fleeter.Core.Database;
using Fleeter.Core.Models;
using System.Linq;

namespace Fleeter.Core.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IConnectionFactory factory) : base(factory) { }

        public override void Create(Vehicle entity)
        {
            entity.LicensePlate = entity.LicensePlate.ToUpper();
            base.Create(entity);
        }

        public Vehicle FindByLicensePlate(string licensePlate)
        {
            using var session = _factory.OpenSession();
            return session.Query<Vehicle>().FirstOrDefault(v => v.LicensePlate.ToUpper() == licensePlate.ToUpper());
        }
    }
}
