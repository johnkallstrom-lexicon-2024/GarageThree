namespace GarageThree.Web.ViewModels.Vehicle
{
    public class VehicleTypeIndexViewModel
    {
        public string SearchTerm { get; set; } = default!;
        public int PageSize { get; set; } = default!;
        public int CurrentPage { get; set; } = default!;
        public int GarageId { get; set; } = default!;
        public IEnumerable<VehicleTypeViewModel> VehicleTypes { get; set; } = [];
    }
}