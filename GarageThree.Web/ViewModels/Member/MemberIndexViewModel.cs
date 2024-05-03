namespace GarageThree.Web.ViewModels.Member;

public class MemberIndexViewModel
{
    public static string SearchTerm { get; set; } = default!;
    public static int PageSize { get; set; } = default!;
    public static int CurrentPage  { get; set; } = default!;

    public int Id { get; set; }
    public string Avatar { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Name => $"{FirstName} {LastName}";
    public string Email { get; set; } = default!;
    public int VehicleCount { get; set; } = default!;
}
