namespace VehicleDiary.Logic
{
    public class CarCreateRequest
    {
        public CarCreateRequest(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int ProductionYear { get; set; }

        public Car ToCar()
        {
            return new Car(Name, Make, Model, ProductionYear);
        }
    }
}