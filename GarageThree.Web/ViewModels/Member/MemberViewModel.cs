namespace GarageThree.Web.ViewModels.Member;

public class MemberViewModel
{
    public int Id { get; set; }
    public string Avatar { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Name => $"{FirstName} {LastName}";
    public int Age { get; set; }
    public string Email { get; set; } = default!;
    public string SSN { get; set; } = default!;

    public IEnumerable<VehicleViewModel> Vehicles { get; set; } = [];
}
