using Fleeter.Client.UserServiceProxy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetAll();

        Task<BaseResult> CreateOrUpdate(User user);

        Task<BaseResult> Delete(User user);
    }
}