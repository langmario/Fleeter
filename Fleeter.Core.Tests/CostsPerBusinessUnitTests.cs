using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Fleeter.Core.Models;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Fleeter.Core.Tests
{
    [TestClass]
    public class CostsPerBusinessUnitTests
    {
        private static readonly Mock<IVehicleRepository> _vehicleRepositoryMock = new Mock<IVehicleRepository>();
        private static readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new Mock<IEmployeeRepository>();
        private static readonly Mock<IBusinessUnitRepository> _businessUnitRepositoryMock = new Mock<IBusinessUnitRepository>();
        private static IFleeterService _service;

        private static readonly List<BusinessUnit> _businessUnits = new List<BusinessUnit>
        {
            new BusinessUnit
            {
                Id = 1,
                Name = "Research"
            },
            new BusinessUnit
            {
                Id = 2,
                Name = "Development"
            }
        };
        private static readonly List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Salutation = "Ms",
                Firstname = "John",
                Lastname = "Doe",
                BusinessUnit = _businessUnits[0],
                EmployeeNumber = 1000,
            },
            new Employee
            {
                Id = 2,
                Salutation = "Mr",
                Firstname = "Jane",
                Lastname = "Doe",
                BusinessUnit = _businessUnits[1],
                EmployeeNumber = 1001,
            }
        };
        private static readonly List<Vehicle> _vehicles = new List<Vehicle>
        {
            new Vehicle
            {
                Id = 1,
                Brand = "Porsche",
                Model = "911",
                Insurance = 120,
                LeasingFrom = new DateTime(2020, 1, 1),
                LeasingTo = new DateTime(2020, 1, 31),
                LeasingRate = 90
            },
            new Vehicle
            {
                Id = 2,
                Brand = "Porsche",
                Model = "911",
                Insurance = 240,
                LeasingFrom = new DateTime(2020, 2, 1),
                LeasingTo = new DateTime(2020, 2, 28),
                LeasingRate = 180
            },
        };


        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _vehicles[0].EmployeeRelations = new List<VehicleToEmployeeRelation>
            {
                new VehicleToEmployeeRelation
                {
                    Id = 1,
                    Employee = _employees[0],
                    Vehicle = _vehicles[0],
                    StartDate = new DateTime(2020, 1, 1),
                    EndDate = new DateTime(2020, 1, 31)
                }
            };
            _vehicles[1].EmployeeRelations = new List<VehicleToEmployeeRelation>
            {
                new VehicleToEmployeeRelation
                {
                    Id = 2,
                    Employee = _employees[1],
                    Vehicle = _vehicles[1],
                    StartDate = new DateTime(2020, 2, 1),
                    EndDate = new DateTime(2020, 2, 28)
                }
            };

            _vehicleRepositoryMock.Setup(x => x.FindAll())
                .Returns(_vehicles);
            _employeeRepositoryMock.Setup(x => x.FindAll())
                .Returns(_employees);
            _businessUnitRepositoryMock.Setup(x => x.FindAll())
                .Returns(_businessUnits);

            _service = new FleeterService(_businessUnitRepositoryMock.Object, _vehicleRepositoryMock.Object, _employeeRepositoryMock.Object);
        }

        [TestMethod]
        public void TestCountsAreCorrect()
        {
            var result = _service.GetCostsPerMonthPerBusinessUnit();

            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void TestBusinessUnitsExist()
        {
            var result = _service.GetCostsPerMonthPerBusinessUnit();

            Assert.IsNotNull(result.First(c => c.BusinessUnit == _businessUnits[0]));
            Assert.IsNotNull(result.First(c => c.BusinessUnit == _businessUnits[1]));
        }

        [TestMethod]
        public void TestCostsAreCorrect()
        {
            var result = _service.GetCostsPerMonthPerBusinessUnit();

            Assert.AreEqual(100, result.First(c => c.BusinessUnit == _businessUnits[0]).Costs);
            Assert.AreEqual(200, result.First(c => c.BusinessUnit == _businessUnits[1]).Costs);
        }
    }
}
