namespace GarageThree.Web.Controllers
{
    public class CheckoutsController(IMapper mapper, IRepository<Checkout> checkoutRepository) : Controller
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRepository<Checkout> _checkoutRepository = checkoutRepository;

        public async Task<IActionResult> Index(string? searchTerm)
        {
            var checkouts = await _checkoutRepository.GetAll();

            var viewModel = new CheckoutIndexViewModel
            {
                Checkouts = _mapper.Map<IEnumerable<CheckoutViewModel>>(checkouts),
                SearchTerm = !string.IsNullOrWhiteSpace(searchTerm) ? searchTerm : string.Empty
            };

            return View(viewModel);
        }
    }
}
