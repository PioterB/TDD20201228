namespace VehicleDiary.Logic
{
    public class CarCreateRequest
    {
        public CarCreateRequest(string name, string make, string model)
        {
            Name = name;
            Make = make;
            Model = model;
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