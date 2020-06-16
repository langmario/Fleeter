using Fleeter.Core.Database;
using Fleeter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Core.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IConnectionFactory factory) : base(factory) { }

        public override void CreateOrUpdate(User entity)
        {
            entity.Username = entity.Username.ToLower();
            base.CreateOrUpdate(entity);
        }

        public User FindByUsername(string username)
        {
            using var session = _factory.OpenSession();
            return session.Query<User>().FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
        }
    }
}
