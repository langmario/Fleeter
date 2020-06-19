using Fleeter.Core.Models;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services;
using Fleeter.Core.Services.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Reflection;

namespace Fleeter.Core.Tests
{
    [TestClass]
    public class UserTests
    {
        private static readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private static IUserService _userService;
        private static readonly User _john = new User
        {
            Id = 1,
            Firstname = "John",
            Lastname = "Doe",
            Username = "johndoe",
            IsAdmin = false,
            PasswordHash = "$2y$10$1coNSX5TTw3cUDZdXw1AhOoRw6ewMTcVAU.1YVx.gEzQLpQNnvXjq", // geheim
            Version = 1
        };
        private static readonly User _jane = new User
        {
            Id = 1,
            Firstname = "John",
            Lastname = "Doe",
            Username = "johndoe",
            IsAdmin = false,
            PasswordHash = "$2y$10$1coNSX5TTw3cUDZdXw1AhOoRw6ewMTcVAU.1YVx.gEzQLpQNnvXjq", // geheim
            Version = 1
        };
        private static readonly User _nonExistent = new User
        {
            Id = 3,
            Firstname = "Max",
            Lastname = "Mustermann",
        };

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _userRepositoryMock.Setup(x => x.FindAll())
                .Returns(new[] { _john, _jane });

            _userRepositoryMock.Setup(x => x.FindById(1))
                .Returns(_john);

            _userRepositoryMock.Setup(x => x.Delete(_john));

            _userService = new UserService(_userRepositoryMock.Object);
        }

        [TestMethod]
        public void TestGettingAllUsers()
        {
            var result = _userService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void TestGettingUserById()
        {
            var result = _userService.GetById(1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGettingNullForInvalidUserId()
        {
            var result = _userService.GetById(99);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestDeletingNonExistentUser()
        {
            var result = _userService.Delete(_nonExistent);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, Status.NotFound);
        }

        [TestMethod]
        public void TestDeletingUser()
        {
            var result = _userService.Delete(_john);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, Status.Deleted);
        }
    }
}
