using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Moq;
using NUnit.Framework;
using VehicleDiary.Logic;
using VehiclesDiary.Controllers;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Tests
{
    public class VehiclesControllerTests
    {
        private VehiclesController _unitUnderTest;
        private Mock<IVehiclesService> _serviceMock;
        private Mock<IRepository<string, Car>> _repoMock;

        [OneTimeSetUp]
        public void SingleSetup()
        {
        }

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<IVehiclesService>();
            _repoMock = new Mock<IRepository<string, Car>>();
            _unitUnderTest = new VehiclesController(_serviceMock.Object, _repoMock.Object);
        }

        [Test]
        public void Get_Nothing_EmptyCollection()
        {
            _repoMock.Setup(r => r.GetAll()).Returns((IEnumerable<Car>)null);

            var items= _unitUnderTest.Get();

            CollectionAssert.IsEmpty(items);
        }
        
        [Test]
        public void Get_SomeItems_RespectiveCollection()
        {
            _repoMock.Setup(r => r.GetAll()).Returns(new Car[] {new Car("name"),});

            var items = _unitUnderTest.Get();

            CollectionAssert.IsNotEmpty(items);
            CollectionAssert.AllItemsAreNotNull(items);
            Assert.AreEqual(1, items.Count());
        }

        [Test]
        public void Remove()
        {
            Assert.Pass();
        }

        [TearDown]
        public void Teardown()
        {
        }

        [OneTimeTearDown]
        public void SingleTeardown()
        {
        }
    }
}