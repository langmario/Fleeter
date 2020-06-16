using Fleeter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
        void SaveOrUpdate(User user);

        [OperationContract]
        void Delete(User user);
    }
}
