using Fleeter.Client.FleeterServiceProxy;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Fleeter.Client.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<BaseResult> CreateOrUpdate(Employee e);
        Task<BaseResult> Delete(Employee e);
    }
}
