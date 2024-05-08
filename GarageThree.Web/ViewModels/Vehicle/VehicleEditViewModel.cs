namespace GarageThree.Web.ViewModels.Vehicle;

public class VehicleEditViewModel
{

    public int Id { get; set; }
 
    public string RegNumber { get; set; } = default!;

    [Required]
    public string Brand { get; set; } = default!;

    [Required]
    public string Model { get; set; } = default!;

    [Required]
    [DisplayName("Member")]
    public int MemberId { get; set; }
    
    public int GarageId { get; set; }

    public int VehicleTypeId { get; set; }

    [Required]
    public Color Color { get; set; }
}
