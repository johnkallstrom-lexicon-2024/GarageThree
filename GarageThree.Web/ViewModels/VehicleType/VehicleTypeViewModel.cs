namespace GarageThree.Web.ViewModels.VehicleType;

public class VehicleTypeViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    [DisplayName("Number of Wheels")]
    public int NumberOfWheels { get; set; }
    [DisplayName("Assigned Vehicle Count")]
    public int AssignedVehicleCount { get; set; }
}