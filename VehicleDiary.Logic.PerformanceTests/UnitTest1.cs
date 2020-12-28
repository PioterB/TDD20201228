using NUnit.Framework;

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
            var unitUnderTest = new VehiclesService();

            for (int i = 0; i < 10000; i++)
            {
                unitUnderTest.Add(new CarCreateRequest("n"));
            }


            Assert.Pass();
        }
    }
}