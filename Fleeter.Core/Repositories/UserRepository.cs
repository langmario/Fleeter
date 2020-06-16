using Fleeter.Core.Database;
using Fleeter.Core.Models;
using System.Linq;

namespace Fleeter.Core.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IConnectionFactory factory) : base(factory) { }

        public User FindByUsername(string username)
        {
            using var session = _factory.OpenSession();
            return session.Query<User>().FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
        }
    }
}
