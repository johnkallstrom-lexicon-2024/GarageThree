namespace GarageThree.Web.Controllers
{
    public class CheckoutsController(IRepository<Checkout> checkoutRepository) : Controller
    {
        private readonly IRepository<Checkout> _checkoutRepository = checkoutRepository;

        public async Task<IActionResult> Index()
        {
            var checkouts = await _checkoutRepository.GetAll();

            return View(checkouts);
        }
    }
}
