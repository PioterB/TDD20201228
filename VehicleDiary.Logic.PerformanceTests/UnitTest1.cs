using Moq;
using NUnit.Framework;
using VehicleDiary.TestData;
using VehiclesDiary.Tools.Persistence;

namespace VehicleDiary.Logic.PerformanceTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var repo = new Mock<IRepository<string, Car>>();
            repo.Setup(r => r.Exists(It.IsAny<string>())).Returns(false);
            var unitUnderTest = new VehiclesService(repo.Object);

            for (int i = 0; i < 10000; i++)
            {
                unitUnderTest.Add(VehiclesTestData.CreateCarRequest());
            }


            Assert.Pass();
        }
    }
}