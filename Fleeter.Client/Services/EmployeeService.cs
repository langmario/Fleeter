using Fleeter.Client.FleeterServiceProxy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        public Task<List<Employee>> GetAll()
        {
            var fleeter = new FleeterServiceClient();
            fleeter.Open();
            return fleeter.GetEmployeesAsync();
        }

        public Task<BaseResult> CreateOrUpdate(Employee e)
        {
            var fleeter = new FleeterServiceClient();
            fleeter.Open();
            return fleeter.CreateOrUpdateEmployeeAsync(e);
        }

        public Task<BaseResult> Delete(Employee e)
        {
            var fleeter = new FleeterServiceClient();
            fleeter.Open();
            return fleeter.DeleteEmployeeAsync(e);
        }
    }
}
