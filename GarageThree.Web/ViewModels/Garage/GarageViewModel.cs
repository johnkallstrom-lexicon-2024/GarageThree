namespace GarageThree.Web.ViewModels.Garage;

public class GarageViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Capacity { get; set; }
    [DisplayName("Hourly Rate")]
    public int HourlyRate { get; set; }
    [DisplayName("Vehicle Count")]
    public int VehicleCount => Vehicles.Count();
    public int GarageCount { get; set; }

    public IEnumerable<VehicleViewModel> Vehicles { get; set; } = [];
}