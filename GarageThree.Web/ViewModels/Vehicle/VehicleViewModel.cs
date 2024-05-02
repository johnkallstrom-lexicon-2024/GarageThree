using GarageThree.Web.ViewModels.Garage;
using GarageThree.Web.ViewModels.Member;

namespace GarageThree.Web.ViewModels.Vehicle
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string RegNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime RegisteredAt { get; set; }
        public Color Color { get; set; }

        public MemberViewModel Member { get; set; } = default!;
        public GarageViewModel Garage { get; set; } = default!;
        public VehicleTypeViewModel Type { get; set; } = default!;
    }

    public class VehicleTypeViewModel
    {
        public string Name { get; set; }
        public int NumberOfWheels { get; set; }
    }
}
