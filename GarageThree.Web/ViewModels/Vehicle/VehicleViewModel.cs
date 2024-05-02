using GarageThree.Web.ViewModels.Garage;
using GarageThree.Web.ViewModels.Member;

namespace GarageThree.Web.ViewModels.Vehicle;
public class VehicleViewModel
{
    public int Id { get; set; }
    public string RegNumber { get; set; } = default!;
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public DateTime RegisteredAt { get; set; }
    public Color Color { get; set; }

    public MemberViewModel Member { get; set; } = default!;
    public GarageViewModel Garage { get; set; } = default!;
    public VehicleTypeViewModel Type { get; set; } = default!;
}