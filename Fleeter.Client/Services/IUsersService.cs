using Fleeter.Client.UserServiceProxy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleeter.Client.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetAll();
    }
}