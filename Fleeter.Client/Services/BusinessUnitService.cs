using Fleeter.Client.FleeterServiceProxy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public class BusinessUnitService : IBusinessUnitService
    {
        public async Task<List<BusinessUnit>> GetAll()
        {
            var fleeter = new FleeterServiceClient();
            fleeter.Open();
            return await fleeter.GetBusinessUnitsAsync();
        }

        public async Task<BaseResult> CreateOrUpdate(BusinessUnit bu)
        {
            var fleeter = new FleeterServiceClient();
            fleeter.Open();
            return await fleeter.CreateOrUpdateBusinessUnitAsync(bu);
        }

        public async Task<BaseResult> Delete(BusinessUnit bu)
        {
            var fleeter = new FleeterServiceClient();
            fleeter.Open();
            return await fleeter.DeleteBusinessUnitAsync(bu);
        }
    }
}
