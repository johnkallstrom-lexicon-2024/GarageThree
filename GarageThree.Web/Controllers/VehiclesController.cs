namespace GarageThree.Web.Controllers;
public class VehiclesController : Controller
{
    private readonly IMapper _mapper;
    private readonly ICheckoutService _checkoutService;
    private readonly IRepository<Member> _memberRepository;
    private readonly IRepository<Garage> _garageRepository;
    private readonly IRepository<Vehicle> _vehicleRepository;

        public VehiclesController(
            IRepository<Vehicle> vehicleRepository,
            IRepository<Garage> garageRepository,
            IRepository<Member> memberRepository,
            ICheckoutService checkoutService,
            IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _garageRepository = garageRepository;
            _memberRepository = memberRepository;
            _checkoutService = checkoutService;
            _mapper = mapper;
        }

    public async Task<IActionResult> Index(int? garageId, string? searchTerm)
    {
        var vehicles = await _vehicleRepository.Filter(new QueryParams
        {
            Id = garageId,
            SearchTerm = searchTerm
        });

        VehicleIndexViewModel viewModel = new()
        {
            Vehicles = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicles)
        };

        if (garageId.HasValue) viewModel.GarageId = garageId.Value;

    return View(viewModel);
}

    public IActionResult Create()
    {
        var viewModel = new VehicleCreateOrEditViewModel();

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(VehicleCreateOrEditViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        Vehicle vehicle = _mapper.Map<Vehicle>(viewModel);

        return View();
    }

    public async Task<IActionResult> Delete(int id)
    {
        var deletedVehicle = await _vehicleRepository.Delete(id);
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
            Member = _mapper.Map<MemberViewModel>(member),
        };

        return View(viewModel);
    }


    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }
        var vehicle = await _vehicleRepository.GetById((int)id);

        VehicleViewModel viewModel = _mapper.Map<VehicleViewModel>(vehicle);
        viewModel.VehicleCount = (await _vehicleRepository.GetAll()).Count();

        return View(viewModel);
    }
}