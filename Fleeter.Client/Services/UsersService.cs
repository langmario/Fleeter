using Fleeter.Client.UserServiceProxy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public class UsersService : IUsersService
    {
        public Task<List<User>> GetAll()
        {
            var users = new UserServiceClient();
            users.Open();
            return users.GetAllAsync();
        }

        public async Task<BaseResult> CreateOrUpdate(User user)
        {
            var users = new UserServiceClient();
            users.Open();
            return await users.CreateOrUpdateAsync(user);
        }

        public Task<BaseResult> Delete(User user)
        {
            var users = new UserServiceClient();
            users.Open();
            return users.DeleteAsync(user);
        }
    }
}
