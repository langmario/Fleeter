using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Fleeter.Core.Models;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services;
using Fleeter.Core.Services.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Fleeter.Core.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        private static readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new Mock<IEmployeeRepository>();
        private static IFleeterService _service;

        private static Employee _employeeJohn = new Employee
        {
            Id = 1,
            EmployeeNumber = 100,
            Firstname = "John",
            Lastname = "Joe",
            Version = 1
        };
        private static Employee _employeeJane = new Employee
        {
            Id = 2,
            EmployeeNumber = 101,
            Firstname = "Jane",
            Lastname = "Joe",
            Version = 1
        };
        private static Employee _employeeToSave = new Employee
        {
            EmployeeNumber = 100,
            Firstname = "Test",
            Lastname = "Test"
        };


        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _employeeRepositoryMock.Setup(x => x.FindAll())
                .Returns(new[] { _employeeJohn, _employeeJane });

            _employeeRepositoryMock.Setup(x => x.FindById(1))
                .Returns(_employeeJohn);
            _employeeRepositoryMock.Setup(x => x.FindById(2))
                .Returns(_employeeJane);

            _employeeRepositoryMock.Setup(x => x.FindByEmployeeNumber(100))
                .Returns(_employeeJohn);

            _employeeRepositoryMock.Setup(x => x.Delete(_employeeJohn));

            _service = new FleeterService(null, null, _employeeRepositoryMock.Object);
        }

        [TestMethod]
        public void TestGettingAllEmployees()
        {
            var result = _service.GetEmployees();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void TestGettingEmployeeById()
        {
            var result = _service.DeleteEmployee(_employeeJohn);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, Status.Deleted);
        }

        [TestMethod]
        public void TestSavingEmployeeWithAlreadyExistingEmployeeNumber()
        {
            var result = _service.CreateOrUpdateEmployee(_employeeToSave);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, Status.BadRequest);
        }
    }
}
