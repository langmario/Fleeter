using Fleeter.Core.Models;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services;
using Fleeter.Core.Services.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Fleeter.Core.Tests
{
    [TestClass]
    public class ChangePasswordTests
    {
        private static readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private static IUserService _userService;
        private static readonly User _user = new User
        {
            Id = 1,
            Firstname = "John",
            Lastname = "Doe",
            Username = "johndoe",
            IsAdmin = false,
            PasswordHash = "$2y$10$1coNSX5TTw3cUDZdXw1AhOoRw6ewMTcVAU.1YVx.gEzQLpQNnvXjq", // geheim
            Version = 1
        };
        private static readonly User _nonExistentUser = new User
        {
            Id = 1,
            Firstname = "John",
            Lastname = "Doe",
            Username = "johndoe",
            IsAdmin = false,
            PasswordHash = "$2y$10$1coNSX5TTw3cUDZdXw1AhOoRw6ewMTcVAU.1YVx.gEzQLpQNnvXjq", // geheim
            Version = 1
        };

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _userRepositoryMock.Setup(x => x.FindByUsername("johndoe"))
                .Returns(_user);

            _userService = new UserService(_userRepositoryMock.Object);
        }


        [TestMethod]
        public void TestPasswordChangeWithCorrectOldPassword()
        {
            var result = _userService.ChangePassword(_user, "geheim", "geheimer");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, Status.Updated);
        }

        [TestMethod]
        public void TestPasswordChangeWithIncorrectOldPassword()
        {
            var result = _userService.ChangePassword(_user, "falsches Password", "geheimer");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, Status.BadRequest);
            Assert.IsNotNull(result.Message);
        }

        [TestMethod]
        public void TestPasswordChangeWithNonExistentUser()
        {
            var result = _userService.ChangePassword(_nonExistentUser, "egal", "geheim");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, Status.BadRequest);
            Assert.IsNotNull(result.Message);
        }
    }
}
