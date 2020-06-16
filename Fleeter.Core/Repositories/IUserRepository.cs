using Fleeter.Core.Models;

namespace Fleeter.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUsername(string username);
    }
}