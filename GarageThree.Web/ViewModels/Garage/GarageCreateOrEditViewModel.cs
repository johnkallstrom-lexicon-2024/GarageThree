namespace GarageThree.Web.ViewModels.Garage;

public class GarageCreateOrEditViewModel
{
    public int Id { get; set; }

    [Required]
    [MinLength(5, ErrorMessage = "Username must be at least 5 charactes")]
    [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
    [RegularExpression(@"[a-zA-Z\s0-9-_]*", ErrorMessage = "Invalid characters")]
    public string Name { get; set; } = default!;

    [Required]
    [Range(5, 1000, ErrorMessage = "Value must between 5-1000")]
    public int Capacity { get; set; } = 5;

    [Required]
    [Range(10, 30, ErrorMessage = "Value must between 10-30")]
    public int HourlyRate { get; set; } = 10;
}