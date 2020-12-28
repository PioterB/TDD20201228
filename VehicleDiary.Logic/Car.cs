namespace VehicleDiary.Logic
{
    public class Car : Vehicle
    {
        public string Make { get; }

        public string Model { get; }

        public int? ProductionYear { get; }

        public Car(string name, string make = null, string model = null, in int? productionYear = null) : base(name)
        {
            Make = make;
            Model = model;
            ProductionYear = productionYear;
        }
    }
}