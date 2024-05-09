namespace GarageThree.Web.Controllers
{
    public class CheckoutsController(
        IRepository<VehicleType> vehicleTypeRepository,
        IRepository<Member> memberRepository,
        IRepository<Garage> garageRepository, 
        IMapper mapper, 
        IRepository<Checkout> checkoutRepository) : Controller
    {
        private readonly IRepository<VehicleType> _vehicleTypeRepository = vehicleTypeRepository;
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

        public async Task<IActionResult> Details(int id)
        {
            var checkout = await _checkoutRepository.GetById(id);
            return View(_mapper.Map<CheckoutViewModel>(checkout));
        }

        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            var type = await _vehicleTypeRepository.GetById(vehicle.VehicleTypeId);
            var garage = await _garageRepository.GetById(vehicle.GarageId);

            if (vehicle is not null &&
                type is not null &&
                garage is not null)
            {
                TimeSpan parkingPeriod = DateTime.Now - vehicle.RegisteredAt;
                int totalHours = (int)parkingPeriod.TotalHours;
                decimal totalParkingCost = totalHours * garage.HourlyRate;

                var checkout = new Checkout()
                {
                    RegNumber = vehicle.RegNumber,
                    VehicleType = type.Name,
                    ParkedAt = vehicle.RegisteredAt,
                    TotalParkingCost = totalParkingCost,
                    HourlyRate = garage.HourlyRate,
                    Garage = garage.Name,
                    MemberId = vehicle.MemberId,
                };

                var createdCheckout = await _checkoutRepository.Create(checkout);
                return RedirectToAction(nameof(Details), new { createdCheckout.Id });
            }

            return RedirectToAction(nameof(Index), nameof(VehiclesController), new { });
        }
    }
}
