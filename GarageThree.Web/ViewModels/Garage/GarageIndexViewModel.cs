namespace GarageThree.Web.ViewModels.Garage
{
    public class GarageIndexViewModel
    {
        public string SearchTerm { get; set; } = default!;
        public int PageSize { get; set; } = default!;
        public int CurrentPage { get; set; } = default!;
        public IEnumerable<GarageViewModel> Garages { get; set; } = [];
    }
}
