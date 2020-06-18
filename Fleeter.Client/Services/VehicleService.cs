using Fleeter.Client.FleeterServiceProxy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public class VehicleService : IVehicleService
    {
        public Task<List<Vehicle>> GetAll()
        {
            var fleeter = new FleeterServiceClient();
            fleeter.Open();
            return fleeter.GetVehiclesAsync();
        }

        public Task<BaseResult> CreateOrUpdate(Vehicle v)
        {
            var fleeter = new FleeterServiceClient();
            fleeter.Open();
            return fleeter.CreateOrUpdateVehicleAsync(v);
        }

        public Task<BaseResult> Delete(Vehicle v)
        {
            var fleeter = new FleeterServiceClient();
            fleeter.Open();
            return fleeter.DeleteVehicleAsync(v);
        }


        public Task<BaseResult> AddRelation(VehicleToEmployeeRelation r)
        {
            var fleeter = new FleeterServiceClient();
            fleeter.Open();
            return fleeter.CreateEmployeeRelationAsync(r);
        }

        public Task<BaseResult> DeleteRelation(VehicleToEmployeeRelation r)
        {
            var fleeter = new FleeterServiceClient();
            fleeter.Open();
            return fleeter.DeleteEmployeeRelationAsync(r);
        }
    }
}
