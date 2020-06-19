using Fleeter.Core.Models;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Fleeter.Core.Tests
{
    [TestClass]
    public class CostsPerMonthTests
    {
        private static readonly Mock<IVehicleRepository> _vehicleRepositoryMock = new Mock<IVehicleRepository>();
        private static IFleeterService _service;

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
                Id = 1,
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
            _vehicleRepositoryMock.Setup(x => x.FindAll())
                .Returns(_vehicles);

            _service = new FleeterService(null, _vehicleRepositoryMock.Object, null);
        }

        [TestMethod]
        public void TestMonthCountsAreCorrect()
        {
            var result = _service.GetCostsPerMonth();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void TestMonthCostsAreCorrect()
        {
            var result = _service.GetCostsPerMonth();

            Assert.AreEqual(100, result[new DateTime(2020, 1, 1)].Costs);
            Assert.AreEqual(200, result[new DateTime(2020, 2, 1)].Costs);
        }

        [TestMethod]
        public void TestMonthVehicleCountsAreCorrect()
        {
            var result = _service.GetCostsPerMonth();

            Assert.AreEqual(1, result[new DateTime(2020, 1, 1)].Count);
            Assert.AreEqual(1, result[new DateTime(2020, 2, 1)].Count);
        }
    }
}
