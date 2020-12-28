using NUnit.Framework;

namespace VehiclesDiary.Tests
{
    public class VehiclesControllerTests
    {
        [OneTimeSetUp]
        public void SingleSetup()
        {
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        
        [Test]
        public void Test2()
        {
            Assert.Fail();
        }

        [Test]
        public void Test3()
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