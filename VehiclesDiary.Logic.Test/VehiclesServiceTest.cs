using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Moq;
using NUnit.Framework;
using VehicleDiary.Logic;
using VehicleDiary.TestData;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Logic.Test
{
    public class VehiclesServiceTest
    {
        private VehiclesService _unitUnderTest;
        private Mock<IRepository<string, Car>> _repo;


        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IRepository<string, Car>>();
            _unitUnderTest = new VehiclesService(_repo.Object);
        }

        [Test]
        public void Add_SomeName_Passes()
        {
            // arrange/given
            var request = VehiclesTestData.CreateCarRequest();

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_NoMake_Passes()
        {
            // arrange/given
            var request = VehiclesTestData.CreateCarRequest();

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_NoModel_Passes()
        {
            // arrange/given
            var request = VehiclesTestData.CreateCarRequest();

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_NoProductionYear_Passes()
        {
            // arrange/given
            var request = VehiclesTestData.CreateCarRequest();

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_Make_Passes()
        {
            // arrange/given
            var request = VehiclesTestData.CreateCarRequest(make: "make");

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_Model_Passes()
        {
            // arrange/given
            var request = VehiclesTestData.CreateCarRequest(model: "mymodel");

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_ProductionYear_Passes()
        {
            // arrange/given
            var request = VehiclesTestData.CreateCarRequest("naz");

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_NoName_Fail()
        {
            // arrange/given

            // act/when
            var result = _unitUnderTest.Add(VehiclesTestData.CreateCarRequest(null));

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Add_EmptyName_Fail()
        {
            // arrange/given
            var request = VehiclesTestData.CreateCarRequest(string.Empty);

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Add_WhitespaceName_Fail()
        {
            // arrange/given
            var request = VehiclesTestData.CreateCarRequest(" ");

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Add_DuplicatedName_Fail()
        {
            // arrange/given
            var request = VehiclesTestData.CreateCarRequest();
            request = new CarCreateRequest("name", null, null);
            _repo.Setup(r => r.Exists(request.Name)).Returns(true);

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Remove_ExistingName_Passes()
        {
            // arrange/given
            var request = VehiclesTestData.CreateCarRequest();
            _repo.Setup(r => r.Exists(request.Name)).Returns(true);

            // act/when
            var result = _unitUnderTest.Remove(request.Name);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Remove_EmptyName_Fail()
        {
            // arrange/given
            var name = "nazwa";

            // act/when
            var result = _unitUnderTest.Remove(" ");

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Remove_Nothing_Exception()
        {
            // arrange/given

            // act/when
            TestDelegate action = () => _unitUnderTest.Remove(null);

            // assert/than
            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void Remove_UnknownName_Fail()
        {
            // arrange/given
            var name = "nazwa";

            // act/when
            var result = _unitUnderTest.Remove(name);

            // assert/than
            Assert.IsFalse(result);
        }
    }
}