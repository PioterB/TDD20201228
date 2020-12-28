using System.Reflection.Metadata.Ecma335;
using VehicleDiary.Logic;

namespace VehiclesDiary.Controllers
{
    public class VehiclePreview
    {
        public VehiclePreview(Car car)
        {
            Name = car.Name;
        }

        public string Name { get; }
    }
}