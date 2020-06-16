using Fleeter.Client.FleeterServiceProxy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public interface IBusinessUnitService
    {
        Task<List<BusinessUnit>> GetAll();
        Task<BaseResult> CreateOrUpdate(BusinessUnit bu);
        Task<BaseResult> Delete(BusinessUnit bu);
    }
}