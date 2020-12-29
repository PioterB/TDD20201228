using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.CodeAnalysis;
using Moq;
using NUnit.Framework;
using VehicleDiary.Logic;
using VehicleDiary.TestData;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Logic.Test
{
    public class DiaryServiceTests
    {
        private DiaryService _unitUnderTest;
        private Mock<IRepository<string, DiaryItem>> _diaryRepo;
        private Mock<IRepository<string, Car>> _carsRepo;
        
        [SetUp]
        public void Setup()
        {
            _carsRepo = new Mock<IRepository<string, Car>>();

            _diaryRepo = new Mock<IRepository<string, DiaryItem>>();
            _unitUnderTest = new DiaryService(_diaryRepo.Object, _carsRepo.Object);
        }

        [Test]
        public void Add_FutureDate_Fails()
        {
            // arrange/given
            var request = DiaryTestData.CreateCreationRequest(date: DateTime.Now.AddDays(1));

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Add_PassedDate_Successful()
        {
            // arrange/given
            var request = DiaryTestData.CreateCreationRequest(date: DateTime.Now.AddDays(-1));

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Add_MileageBiggerThanLastKnown_Successful()
        {
            // arrange/given
            var diaryItem = DiaryTestData.CreateDiaryItem();
            _diaryRepo.Setup(m => m.GetAll()).Returns(new[] {diaryItem});
            
            var request = DiaryTestData.CreateCreationRequest(diaryItem.Car, diaryItem.Mileage + 1);

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_MileageSmallerThanLastKnown_Rejected()
        {
            // arrange/given
            var diaryItem = DiaryTestData.CreateDiaryItem();
            _diaryRepo.Setup(m => m.GetAll()).Returns(new[] { diaryItem });

            var request = DiaryTestData.CreateCreationRequest(diaryItem.Car, diaryItem.Mileage - 1);

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Add_MileageSmallerThanPreviousDate_Rejected()
        {
            // arrange/given
            var knownDate = DateTime.Now.AddDays(-2);
            var diaryItem = DiaryTestData.CreateDiaryItem(timestamp: knownDate);
            _diaryRepo.Setup(m => m.GetAll()).Returns(new[] { diaryItem });
            var request = DiaryTestData.CreateCreationRequest(
                diaryItem.Car, 
                diaryItem.Mileage - 1, 
                diaryItem.DateTime.AddDays(1));

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Add_MileageHigherThanFallowingDate_Rejected()
        {
            // arrange/given
            var knownDate = DateTime.Now.AddDays(-2);
            var diaryItem = DiaryTestData.CreateDiaryItem(timestamp: knownDate);
            _diaryRepo.Setup(m => m.GetAll()).Returns(new[] { diaryItem });
            var request = DiaryTestData.CreateCreationRequest(
                diaryItem.Car,
                diaryItem.Mileage + 1,
                diaryItem.DateTime.AddDays(-1));

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsFalse(result);
        }

        [Test]
        public void Add_MileageHigherBetweenOtherEvents_Success()
        {
            // arrange/given
            var knownDate = DateTime.Now.AddDays(-2);
            var prevItem = DiaryTestData.CreateDiaryItem(timestamp: knownDate);
            var nextItem = DiaryTestData.CreateDiaryItem(
                car: prevItem.Car, 
                mileage: prevItem.Mileage+2, 
                timestamp: knownDate.AddDays(2));
            _diaryRepo.Setup(m => m.GetAll()).Returns(new[] { prevItem, nextItem });
            var request = DiaryTestData.CreateCreationRequest(
                prevItem.Car,
                prevItem.Mileage + 1,
                prevItem.DateTime.AddDays(1));

            // act/when
            var result = _unitUnderTest.Add(request);

            // assert/than
            Assert.IsFalse(result);
        }
    }
}