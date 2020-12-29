using System;
using System.Diagnostics.CodeAnalysis;
using TestDataGenerators;
using VehicleDiary.Logic;

namespace VehicleDiary.TestData
{
    public class VehiclesTestData
    {
        [ExcludeFromCodeCoverage]
        public static CarCreateRequest CreateCarRequest(string name = "nazwa", string make = null, string model = null)
        {
            return new CarCreateRequest(name, make, model);
        }

        public static Car CreateCar()
        {
            return new Car(StringGenerator.Create(5));
        }
    }
}
