using Fleeter.Core.Models;
using Fleeter.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Core.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }


        public IEnumerable<User> GetAll()
        {
            return _repository.FindAll();
        }

        public User GetById(int id)
        {
            return _repository.FindById(id);
        }

        public void Delete(User user)
        {
            _repository.Delete(user);
        }


        public LoginResult Login(string username, string password)
        {
            var user = _repository.FindByUsername(username);
            if (user is null)
            {
                return new LoginResult
                {
                    Success = false,
                    Message = "Ungültige Anmeldedaten"
                };
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return new LoginResult
                {
                    Success = false,
                    Message = "Ungültige Anmeldedaten"
                };
            }

            return new LoginResult
            {
                Success = true,
                Message = null,
                User = user
            };
        }

        public void SaveOrUpdate(User user)
        {
            throw new NotImplementedException();
        }
    }
}
