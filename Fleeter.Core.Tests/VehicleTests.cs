using System;
using System.Linq;
using Fleeter.Core.Models;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services;
using Fleeter.Core.Services.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Fleeter.Core.Tests
{
    [TestClass]
    public class VehicleTests
    {
        private static readonly Mock<IVehicleRepository> _vehicleRepositoryMock = new Mock<IVehicleRepository>();
        private static IFleeterService _service;

        private static Vehicle _vehicle1 = new Vehicle
        {
            Id = 1,
            LicensePlate = "ABC-ABC-1000",
            Brand = "Porsche",
            Model = "911",
            Version = 1
        };
        private static Vehicle _vehicle2 = new Vehicle
        {
            Id = 2,
            LicensePlate = "ABC-ABC-1001",
            Brand = "Porsche",
            Model = "911",
            Version = 1
        };
        private static Vehicle _invalidVehicleToSave = new Vehicle
        {
            LicensePlate = "ABC-ABC-1000",
            Brand = "Porsche",
            Model = "911"
        };
        private static Vehicle _validVehicleToSave = new Vehicle
        {
            LicensePlate = "ABC-ABC-1002",
            Brand = "Porsche",
            Model = "911",
            Insurance = 100,
            LeasingFrom = DateTime.Now,
            LeasingTo = DateTime.Now,
            LeasingRate = 100,
        };

        private static VehicleToEmployeeRelation _relation = new VehicleToEmployeeRelation
        {
            Employee = new Employee
            {
                Id = 1,
                BusinessUnit = new BusinessUnit
                {
                    Id = 1,
                    Name = "Test"
                },
                Firstname = "John",
                Lastname = "Doe",
                EmployeeNumber = 1
            },
            StartDate = DateTime.Today
        };

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _vehicleRepositoryMock.Setup(x => x.FindAll())
                .Returns(new[] { _vehicle1, _vehicle2 });

            _vehicleRepositoryMock.Setup(x => x.FindById(1))
                .Returns(_vehicle1);
            _vehicleRepositoryMock.Setup(x => x.FindById(2))
                .Returns(_vehicle2);

            _vehicleRepositoryMock.Setup(x => x.Create(_validVehicleToSave));

            _vehicleRepositoryMock.Setup(x => x.FindByLicensePlate("ABC-ABC-1000"))
                .Returns(_vehicle1);

            _vehicleRepositoryMock.Setup(x => x.Update(_vehicle1));

            _vehicleRepositoryMock.Setup(x => x.Delete(_vehicle1));

            _service = new FleeterService(null, _vehicleRepositoryMock.Object, null);
        }

        [TestMethod]
        public void TestGettingAllVehicles()
        {
            var result = _service.GetVehicles();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void TestDeletingVehicleById()
        {
            var result = _service.DeleteVehicle(_vehicle1);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Deleted, result.Status);
        }

        [TestMethod]
        public void TestSavingVehicleWithAlreadyExistingLicensePlate()
        {
            var result = _service.CreateOrUpdateVehicle(_invalidVehicleToSave);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.BadRequest, result.Status);
        }

        [TestMethod]
        public void TestSavingValidVehicle()
        {
            var result = _service.CreateOrUpdateVehicle(_validVehicleToSave);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Created, result.Status);
        }

        [TestMethod]
        public void TestAddingEmployeeRelationToVehicle()
        {
            var result = _service.CreateEmployeeRelation(_vehicle1, _relation);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Created, result.Status);
        }
    }
}
