namespace GarageThree.Web.ViewModels
{
    public class GarageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public IEnumerable<VehicleViewModel> Vehicles { get; set; } = [];
    }
}
