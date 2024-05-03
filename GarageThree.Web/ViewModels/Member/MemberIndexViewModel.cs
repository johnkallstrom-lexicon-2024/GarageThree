namespace GarageThree.Web.ViewModels.Member;

public class MemberIndexViewModel
{
    public string SearchTerm { get; set; } = default!;
    public int PageSize { get; set; } = default!;
    public int CurrentPage  { get; set; } = default!;
    public IEnumerable<MemberViewModel> MemberViewModels { get; set; } = [];
}
