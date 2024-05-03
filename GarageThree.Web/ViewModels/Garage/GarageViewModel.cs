using GarageThree.Web.ViewModels.Vehicle;

namespace GarageThree.Web.ViewModels.Garage
{
    public class GarageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }  = default!;
        public int Capacity { get; set; }

        public IEnumerable<VehicleViewModel> Vehicles { get; set; } = [];
    }
}
