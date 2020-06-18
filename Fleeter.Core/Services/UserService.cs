using Fleeter.Core.Models;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services.Results;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Fleeter.Core.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class UserService : IUserService
    {
        private static readonly string INIT_PASSWORD = "geheim";


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
            var user = _repository.FindById(id);
            return user;
        }

        public BaseResult Delete(User user)
        {
            var found = _repository.FindById(user.Id);
            if (found is null)
            {
                return new BaseResult
                {
                    Status = Status.NotFound
                };
            }

            _repository.Delete(found);
            return new BaseResult
            {
                Status = Status.Deleted
            };
        }


        public LoginResult Login(string username, string password)
        {
            username = username.Trim();
            var user = _repository.FindByUsername(username);
            if (user is null)
            {
                return new LoginResult
                {
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
                User = user
            };
        }

        public BaseResult CreateOrUpdate(User user)
        {
            user.Username = user.Username.Trim();
            user.Firstname = user.Firstname?.Trim();
            user.Lastname = user.Lastname.Trim();
            try
            {
                if (user.Id > 0) // Existing User
                {
                    var found = _repository.FindById(user.Id);
                    if (found is null)
                    {
                        return new BaseResult
                        {
                            Status = Status.BadRequest,
                            Message = "Nutzer mit Nutzernamen existiert bereits"
                        };
                    }

                    if (string.IsNullOrEmpty(user.PasswordHash))
                        user.PasswordHash = found.PasswordHash;

                    _repository.Update(user);

                    return new BaseResult
                    {
                        Status = Status.Updated
                    };
                }
                else // New User
                {
                    var found = _repository.FindByUsername(user.Username);
                    if (!(found is null))
                    {
                        return new BaseResult
                        {
                            Status = Status.BadRequest,
                            Message = "Es existiert bereits ein Benutzer mit diesem Benutzernamen"
                        };
                    }
                    user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(INIT_PASSWORD);
                    _repository.Create(user);

                    return new BaseResult
                    {
                        Status = Status.Created
                    };
                }
            }
            catch (StaleObjectStateException ex)
            {
                return new BaseResult
                {
                    Status = Status.Conflict,
                    Message = "Beim Speichern ist ein Konflikt aufgetreten"
                };
            }
            catch (Exception ex)
            {
                return new BaseResult
                {
                    Status = Status.InternalServerError,
                    Message = "Es ist ein Fehler aufgetreten: " + ex.Message
                };
            }
        }

        public BaseResult ChangePassword(User u, string oldPassword, string newPassword)
        {
            var user = _repository.FindByUsername(u.Username);
            if (user is null)
            {
                return new BaseResult
                {
                    Status = Status.BadRequest,
                    Message = "Benutzer konnte nicht gefunden werden"
                };
            }

            if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.PasswordHash))
            {
                return new BaseResult
                {
                    Status = Status.BadRequest,
                    Message = "Passwort falsch"
                };
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

            _repository.Update(user);
            return new BaseResult
            {
                Status = Status.Updated
            };
        }
    }
}
