using Fleeter.Core.Models;

namespace Fleeter.Core.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Vehicle FindByLicensePlate(string licensePlate);
    }
}
