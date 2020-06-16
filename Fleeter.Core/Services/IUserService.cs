using Fleeter.Core.Models;
using Fleeter.Core.Services.Results;
using System.Collections.Generic;
using System.ServiceModel;

namespace Fleeter.Core.Services
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        IEnumerable<User> GetAll();

        [OperationContract]
        User GetById(int id);

        [OperationContract]
        LoginResult Login(string username, string password);

        [OperationContract]
        BaseResult CreateOrUpdate(User user);

        [OperationContract]
        BaseResult Delete(User user);
    }
}
