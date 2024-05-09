namespace GarageThree.Web.Controllers
{
    public class CheckoutsController(
        IRepository<Member> memberRepository,
        IRepository<Garage> garageRepository, 
        IMapper mapper, 
        IRepository<Checkout> checkoutRepository) : Controller
    {
        private readonly IRepository<Member> _memberRepository = memberRepository;
        private readonly IRepository<Garage> _garageRepository = garageRepository;
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

        public IActionResult Details(CheckoutViewModel checkout) => View(checkout);

        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            var member = await _memberRepository.GetById(vehicle.MemberId);
            var garage = await _garageRepository.GetById(vehicle.GarageId);

            if (vehicle is not null &&
                garage is not null && 
                member is not null)
            {
                TimeSpan parkingPeriod = DateTime.Now - vehicle.RegisteredAt;
                int totalHours = (int)parkingPeriod.TotalHours;
                decimal totalParkingCost = totalHours * garage.HourlyRate;

                var checkout = new Checkout()
                {
                    RegNumber = vehicle.RegNumber,
                    VehicleType = vehicle.VehicleType.Name,
                    ParkedAt = vehicle.RegisteredAt,
                    TotalParkingCost = totalParkingCost,
                    HourlyRate = garage.HourlyRate,
                    Garage = garage.Name,
                    MemberId = vehicle.MemberId,
                    Member = member
                };

                var newCheckout = await _checkoutRepository.Create(checkout);
                return RedirectToAction(nameof(Details), _mapper.Map<CheckoutViewModel>(newCheckout));
            }

            return RedirectToAction(nameof(Index), nameof(VehiclesController), new { });
        }
    }
}
