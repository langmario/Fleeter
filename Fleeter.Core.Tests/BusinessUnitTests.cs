using Fleeter.Core.Models;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services;
using Fleeter.Core.Services.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Fleeter.Core.Tests
{
    [TestClass]
    public class BusinessUnitTests
    {
        private static readonly Mock<IBusinessUnitRepository> _businessUnitRepositoryMock = new Mock<IBusinessUnitRepository>();
        private static IFleeterService _service;

        private static readonly BusinessUnit _buMarketing = new BusinessUnit
        {
            Id = 1,
            Name = "Marketing",
            Version = 1
        };
        private static readonly BusinessUnit _buResearch = new BusinessUnit
        {
            Id = 2,
            Name = "Research",
            Version = 1
        };
        private static readonly BusinessUnit _buToSave = new BusinessUnit
        {
            Name = "Marketing",
            Description = "this should fail"
        };


        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _businessUnitRepositoryMock.Setup(x => x.FindAll())
                .Returns(new[] { _buMarketing, _buResearch });

            _businessUnitRepositoryMock.Setup(x => x.FindById(1))
                .Returns(_buMarketing);
            _businessUnitRepositoryMock.Setup(x => x.FindById(2))
                .Returns(_buResearch);

            _businessUnitRepositoryMock.Setup(x => x.FindByName("Marketing"))
                .Returns(_buMarketing);

            _businessUnitRepositoryMock.Setup(x => x.Delete(_buMarketing));

            _service = new FleeterService(_businessUnitRepositoryMock.Object, null, null);
        }

        [TestMethod]
        public void TestGettingAllBusinessUnits()
        {
            var result = _service.GetBusinessUnits();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public void TestDeletingValidBusinessUnit()
        {
            var result = _service.DeleteBusinessUnit(_buMarketing);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, Status.Deleted);
        }

        [TestMethod]
        public void TestSavingBusinessUnitWithAlreadyExistingName()
        {
            var result = _service.CreateOrUpdateBusinessUnit(_buToSave);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Status, Status.BadRequest);
        }
    }
}
