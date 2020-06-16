using Fleeter.Client.UserServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public class UsersService : IUsersService
    {
        public async Task<List<User>> GetAll()
        {
            var users = new UserServiceClient();
            // client.Open();
            return await users.GetAllAsync();
        }
    }
}
