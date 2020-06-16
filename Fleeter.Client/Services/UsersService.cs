using Fleeter.Client.UserServiceProxy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public class UsersService : IUsersService
    {
        public async Task<List<User>> GetAll()
        {
            var users = new UserServiceClient();
            users.Open();
            return await users.GetAllAsync();
        }

        public async Task<BaseResult> CreateOrUpdate(User user)
        {
            var users = new UserServiceClient();
            users.Open();
            return await users.CreateOrUpdateAsync(user);
        }

        public async Task<BaseResult> Delete(User user)
        {
            var users = new UserServiceClient();
            users.Open();
            return await users.DeleteAsync(user);
        }
    }
}
