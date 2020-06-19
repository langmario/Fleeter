using Fleeter.Core.Models;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Fleeter.Core.Tests
{
    [TestClass]
    public class LoginTests
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

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _userRepositoryMock.Setup(x => x.FindByUsername("johndoe"))
                .Returns(_user);

            _userService = new UserService(_userRepositoryMock.Object);
        }


        [TestMethod]
        public void TestLoginWithCorrectCredentials()
        {
            var result = _userService.Login("johndoe", "geheim");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.User);
        }

        [TestMethod]
        public void TestLoginWithIncorrectPassword()
        {
            var result = _userService.Login("johndoe", "invalide");

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.User);
            Assert.IsNotNull(result.Message);
        }

        [TestMethod]
        public void TestLoginWithNotExistentUsername()
        {
            var result = _userService.Login("janedoe", "geheim");

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.User);
            Assert.IsNotNull(result.Message);
        }
    }
}
