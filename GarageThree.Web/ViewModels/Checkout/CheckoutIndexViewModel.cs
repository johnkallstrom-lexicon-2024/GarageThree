namespace GarageThree.Web.ViewModels.Checkout
{
    public class CheckoutIndexViewModel
    {
        public string SearchTerm { get; set; } = default!;
        public IEnumerable<CheckoutViewModel> Checkouts { get; set; } = [];
    }
}
