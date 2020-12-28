using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VehiclesDiary.Tools.Persistence;

namespace VehicleDiary.Logic
{
    public interface IVehiclesService
    {
        bool Add(CarCreateRequest request);

        bool Remove(string name);
    }

    public class VehiclesService : IVehiclesService
    {
        private readonly IRepository<string, Car> _cars;

        public VehiclesService(IRepository<string, Car> carsRepository)
        {
            _cars = carsRepository;
        }

        public bool Add(CarCreateRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return false;
            }

            if (_cars.Exists(request.Name))
            {
                return false;
            }

            var car = request.ToCar();
            _cars.Add(car.Name, car);
            return true;
        }

        public bool Remove(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }

            if (_cars.Exists(name) == false)
            {
                return false;
            }

            _cars.Remove(name);
            return true;
        }
    }
}