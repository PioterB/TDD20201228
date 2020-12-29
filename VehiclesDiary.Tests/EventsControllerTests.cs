using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using VehicleDiary.Logic;
using VehicleDiary.TestData;
using VehiclesDiary.Controllers;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Tests
{
    public class EventsControllerTests
    {
        private Mock<IDiaryService> _serviceMock;
        private Mock<IRepository<string, Car>> _repoMock;
        private EventsController _unitUnderTest;

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<IDiaryService>();
            _repoMock = new Mock<IRepository<string, Car>>();
            _unitUnderTest = new EventsController(_serviceMock.Object, _repoMock.Object);
        }

        [Test]
        public void Create_ExistingCar_Passes()
        {
            var car = VehiclesTestData.CreateCar();
            _repoMock.Setup(r => r.Exists(car.Name)).Returns(true);
            

            var request = DiaryTestData.CreateCreationDto(car.Name);

            var result = _unitUnderTest.Create(request);

            Assert.AreEqual(HttpStatusCode.Accepted, result.StatusCode);
        }

        [Test]
        public void Create_MissingCar_Fails()
        {
            var car = VehiclesTestData.CreateCar();
            _repoMock.Setup(r => r.Exists(car.Name)).Returns(false);

            var request = DiaryTestData.CreateCreationDto(car.Name);

            var result = _unitUnderTest.Create(request);

            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}