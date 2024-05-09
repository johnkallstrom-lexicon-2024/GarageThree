namespace GarageThree.Web.Controllers;

public class VehiclesController(
    IRepository<Garage> garageRepository,
    IRepository<Vehicle> vehicleRepository,
    IMessageService messageService,
    IMapper mapper) : Controller
{
    private readonly IMessageService _messageService = messageService;
    private readonly IMapper _mapper = mapper;
    private readonly IRepository<Garage> _garageRepository = garageRepository;
    private readonly IRepository<Vehicle> _vehicleRepository = vehicleRepository;

    public async Task<IActionResult> Index(int? garageId, string? searchTerm, MessageViewModel? message)
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

        viewModel.Message = message;
        return View(viewModel);
    }

    public IActionResult Create()
    {
        var viewModel = new VehicleCreateViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VehicleCreateViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var vehicle = _mapper.Map<Vehicle>(viewModel);
        var garage = await _garageRepository.GetById(vehicle.GarageId);

        if (garage is not null && garage.Vehicles.Count >= garage.Capacity)
        {
            ModelState.AddModelError("GarageCapacityExceeded", "The garage is full");
        }

        var parkedVehicle = await _vehicleRepository.Create(vehicle);

        var successMessage = _messageService.Success($"New vehicle parked in garage");
        return RedirectToAction(nameof(Index), successMessage);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var vehicleToEdit = await _vehicleRepository.GetById((int)id);

        VehicleEditViewModel viewModel = _mapper.Map<VehicleEditViewModel>(vehicleToEdit);
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(VehicleEditViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        var vehicleToUpdate = _mapper.Map<Vehicle>(viewModel);

        var updatedVehicle = await _vehicleRepository.Update(vehicleToUpdate);

        if (updatedVehicle is not null)
        {
            MessageViewModel messageViewModel = _messageService.Success($"Vehicle with registration number [{updatedVehicle.RegNumber}] edited at {DateTime.Now}");
            return RedirectToAction(nameof(Index), messageViewModel);
        }

        ViewBag.Message = _messageService.Error($"Could not edit vehicle with Registration Number [{viewModel.RegNumber}]");

        return View(viewModel);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var deletedVehicle = await _vehicleRepository.Delete(id);
        if (deletedVehicle is null)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Create), "Checkouts", deletedVehicle);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var vehicle = await _vehicleRepository.GetById((int)id);

        if (vehicle is null)
        {
            return NotFound();
        }

        VehicleViewModel viewModel = _mapper.Map<VehicleViewModel>(vehicle);
        viewModel.VehicleCount = (await _vehicleRepository.GetAll()).Count();
        viewModel.VehicleType = _mapper.Map<VehicleTypeViewModel>(vehicle.VehicleType);

        return View(viewModel);
    }
}