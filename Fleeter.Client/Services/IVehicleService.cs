using Fleeter.Client.FleeterServiceProxy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetAll();

        Task<BaseResult> CreateOrUpdate(Vehicle v);

        Task<BaseResult> Delete(Vehicle v);

        Task<BaseResult> AddRelation(VehicleToEmployeeRelation r);

        Task<BaseResult> DeleteRelation(VehicleToEmployeeRelation r);
    }
}