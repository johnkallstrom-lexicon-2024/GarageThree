namespace GarageThree.Web.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string RegNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime RegisteredAt { get; set; }
        public Color Color { get; set; }

        public GarageViewModel Garage { get; set; } = default!;
        public VehicleTypeViewModel Type { get; set; } = default!;
    }

    public class VehicleTypeViewModel
    {
        public string Name { get; set; }
        public int NumberOfWheels { get; set; }
    }
}
