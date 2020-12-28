using System;
using System.Runtime.InteropServices;
using NUnit.Framework;
using VehicleDiary.Logic;

namespace VehiclesDiary.Logic.Test
{
    public class VehiclesServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_SomeName_Passes()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();
            var nazwa = "nazwa";

            // act/when
            var result = unitUnderTest.Add(nazwa);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_NoMake_Passes()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();
            var nazwa = "nazwa";

            // act/when
            var result = unitUnderTest.Add(nazwa);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_NoModel_Passes()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();
            var nazwa = "nazwa";

            // act/when
            var result = unitUnderTest.Add(nazwa);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_NoProductionYear_Passes()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();
            var nazwa = "nazwa";

            // act/when
            var result = unitUnderTest.Add(nazwa);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_Make_Passes()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();
            var nazwa = "nazwa";

            // act/when
            var result = unitUnderTest.Add(nazwa);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_Model_Passes()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();
            var nazwa = "nazwa";

            // act/when
            var result = unitUnderTest.Add(nazwa);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_ProductionYear_Passes()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();
            var nazwa = "nazwa";

            // act/when
            var result = unitUnderTest.Add(nazwa);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_NoName_Fail()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();

            // act/when
            var result = unitUnderTest.Add(null);

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Add_EmptyName_Fail()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();
            var nazwa = string.Empty;

            // act/when
            var result = unitUnderTest.Add(nazwa);

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Add_WhitespaceName_Fail()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();
            var nazwa = " ";

            // act/when
            var result = unitUnderTest.Add(nazwa);

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Add_DuplicatedName_Fail()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();
            var name = "nazwa";

            unitUnderTest.Add(name);

            // act/when
            var result = unitUnderTest.Add(name);

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Remove_ExistingName_Passes()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();
            var name = "nazwa";

            unitUnderTest.Add(name);

            // act/when
            var result = unitUnderTest.Remove(name);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Remove_EmptyName_Fail()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();
            var name = "nazwa";

            unitUnderTest.Add(name);

            // act/when
            var result = unitUnderTest.Remove(name);

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Remove_Nothing_Exception()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();

            // act/when
            TestDelegate action = () => unitUnderTest.Remove(null);

            // assert/than
            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void Remove_UnknownName_Fail()
        {
            // arrange/given
            var unitUnderTest = new VehiclesService();
            var name = "nazwa";

            // act/when
            var result = unitUnderTest.Remove(name);

            // assert/than
            Assert.IsFalse(result);
        }
    }
}