namespace GarageThree.Web.Controllers;
public class VehiclesController(
    IRepository<Vehicle> vehicleRepository,
    IRepository<Garage> garageRepository,
    IRepository<Member> memberRepository,
    ICheckoutService checkoutService,
    IMessageService messageService,
    IMapper mapper) : Controller
{
    private readonly IMessageService _messageService = messageService;
    private readonly IMapper _mapper = mapper;
    private readonly ICheckoutService _checkoutService = checkoutService;
    private readonly IRepository<Member> _memberRepository = memberRepository;
    private readonly IRepository<Garage> _garageRepository = garageRepository;
    private readonly IRepository<Vehicle> _vehicleRepository = vehicleRepository;

    public async Task<IActionResult> Index(int? garageId, string? searchTerm, MessageViewModel? messageViewModel)
    {
        if (messageViewModel is not null)
        {
            ViewBag.Message = messageViewModel;
        }

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

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var vehicleToEdit = await _vehicleRepository.GetById((int)id);

        VehicleCreateOrEditViewModel viewModel = _mapper.Map<VehicleCreateOrEditViewModel>(vehicleToEdit);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(VehicleCreateOrEditViewModel viewModel)
    {
        var vehicleToEdit = _mapper.Map<Vehicle>(viewModel);
        var editedVehicle = await _vehicleRepository.Update(vehicleToEdit);
        if (editedVehicle != null)
        {
            MessageViewModel messageViewModel = _messageService.Success($"Vehicle with id [{editedVehicle.Id}] edited at {DateTime.Now}");
            return RedirectToAction(nameof(Index), messageViewModel);
        }

        ViewBag.Message = _messageService.Error($"Could not edit vehicle with id [{viewModel.Id}]");

        return View(viewModel);
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
