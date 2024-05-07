namespace GarageThree.Web.Controllers
{
    public class VehiclesController(
        IRepository<Member> memberRepository,
        IRepository<Garage> _garageRepository,
        ICheckoutService checkoutService,
        IMapper mapper,
        IRepository<Vehicle> repository) : Controller
    {
        private readonly IRepository<Member> _memberRepository = memberRepository;
        private readonly IRepository<Garage> _garageRepository = _garageRepository;
        private readonly ICheckoutService _checkoutService = checkoutService;
        private readonly IMapper _mapper = mapper;
        private readonly IRepository<Vehicle> _repository = repository;

    public async Task<IActionResult> Index(int? garageId)
    {
        var vehicles = await _vehicleRepository.Filter(new QueryParams
        {
            Id = garageId,
            SearchTerm = ""
        });

        VehicleIndexViewModel viewModel = new()
        {
            Vehicles = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicles)
        };
        
        if (garageId.HasValue) viewModel.GarageId = garageId.Value;

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletedVehicle = await _repository.Delete(id);
            if (deletedVehicle is null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Checkout), deletedVehicle);
        }

        public async Task<IActionResult> Checkout(Vehicle deletedVehicle)
        {
            var member = await _memberRepository.GetById(deletedVehicle.MemberId);
            var garage = await _garageRepository.GetById(deletedVehicle.GarageId);

            TimeSpan parkingPeriod = _checkoutService.CalculateParkingPeriod(deletedVehicle.RegisteredAt);
            decimal totalParkingPrice = _checkoutService.CalculateTotalParkingPrice(deletedVehicle.RegisteredAt);

            var viewModel = new VehicleCheckoutViewModel
            {
                ParkedDays = parkingPeriod.Days,
                ParkedHours = (int)parkingPeriod.TotalHours,
                ParkedMinutes = (int)parkingPeriod.TotalMinutes,
                TotalParkingPrice = totalParkingPrice,
                Garage = garage is null ? string.Empty : garage.Name,
                CheckoutAt = DateTime.Now,
                HourlyRate = _checkoutService.GetHourlyRate(),
                Vehicle = _mapper.Map<VehicleViewModel>(deletedVehicle),
                Member = mapper.Map<MemberViewModel>(member),
            };

            return View(viewModel);
        }
    }
}
