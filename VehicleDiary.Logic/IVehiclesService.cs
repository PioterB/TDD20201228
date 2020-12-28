using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace VehicleDiary.Logic
{
    public interface IVehiclesService
    {
        bool Add(CarCreateRequest request);

        bool Remove(string name);
    }

    public class VehiclesService : IVehiclesService
    {
        private readonly IDictionary<string, Car> _cars = new Dictionary<string, Car>();

        public bool Add(CarCreateRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return false;
            }

            if (_cars.ContainsKey(request.Name))
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

            if (_cars.ContainsKey(name) == false)
            {
                return false;
            }

            return _cars.Remove(name);
        }
    }
}