using System;
using TestDataGenerators;
using VehicleDiary.Logic;
using VehiclesDiary.Controllers;

namespace VehicleDiary.TestData
{
    public class DiaryTestData
    {
        public static EventCreationRequest CreateCreationRequest(Car owner = null, int mileage = 1000, DateTime? date = null)
        {
            owner ??= VehiclesTestData.CreateCar();

            date ??= DateTime.Now;

            return EventCreationRequest.CreateValid(owner, mileage, date.Value);
        }

        public static EventCreation CreateCreationDto(string vehicleName = null)
        {
            vehicleName ??= StringGenerator.Create(5);

            return new EventCreation()
            {
                VehicleName = vehicleName
            };
        }

        public static DiaryItem CreateDiaryItem(Car car = null, int mileage = 1000, DateTime? timestamp = null)
        {
            car ??= VehiclesTestData.CreateCar();
            timestamp ??= DateTime.Now;
            var valid = new DiaryItem(car, mileage, timestamp.Value);

            /* do magic here with reflection to modify object however you want */

            return valid;
        }
    }
}