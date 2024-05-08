namespace GarageThree.Web.ViewModels.VehicleType
{
    public class VehicleTypeCreateOrEditViewModel
    {
        public string Name { get; set; } = default!;
        [DisplayName("Number of Wheels")]
        public int NumberOfWheels { get; set; }
    }
}