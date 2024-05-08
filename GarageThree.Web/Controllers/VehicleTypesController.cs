namespace GarageThree.Web.Controllers;

public class VehicleTypesController(IMapper mapper,
                                    IMessageService messageService,
                                    IRepository<VehicleType> vehicleTypeRepository) : Controller
{
    private readonly IMapper _mapper = mapper;
    private readonly IMessageService _messageService = messageService;
    private readonly IRepository<VehicleType> _vehicleTypeRepository = vehicleTypeRepository;

    public async Task<IActionResult> Index()
    {
        var vehicleTypes = await _vehicleTypeRepository.GetAll();
        VehicleTypeIndexViewModel viewModel = new()
        {
            VehicleTypes = _mapper.Map<IEnumerable<VehicleTypeViewModel>>(vehicleTypes)
        };
        return View(viewModel);
    }

    public IActionResult Create() => View(new VehicleTypeCreateOrEditViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VehicleTypeCreateOrEditViewModel viewModel)
    {
        var existingVehicleType = await _vehicleTypeRepository.Single(new QueryParams()
        {
            SSN = viewModel.Name,
        });

        if (existingVehicleType is not null)
        {
            ModelState.AddModelError("SsnExists", "Vehicle Type with given Name already exists");
            ViewBag.Message = _messageService.Error("Vehicle Type with given Name already exists");
        }

        if (!ModelState.IsValid) return View(viewModel);

        var vehicleTypeToCreate = _mapper.Map<VehicleType>(viewModel);

        var newVehicleType = await _vehicleTypeRepository.Create(vehicleTypeToCreate);
        if (newVehicleType is not null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var vehicleTypeToEdit = await _vehicleTypeRepository.GetById((int)id);
        var viewModel = _mapper.Map<VehicleTypeCreateOrEditViewModel>(vehicleTypeToEdit);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(VehicleTypeCreateOrEditViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        var vehicleTypeToUpdate = _mapper.Map<VehicleType>(viewModel);

        var editedVehicleType = await _vehicleTypeRepository.Update(vehicleTypeToUpdate);
        if (editedVehicleType is not null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var vehicleType = await _vehicleTypeRepository.GetById((int)id);

        var viewModel = _mapper.Map<VehicleTypeViewModel>(vehicleType);
        viewModel.VehicleTypeCount = (await _vehicleTypeRepository.GetAll()).Count();

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var vehicleTypeToDelete = await _vehicleTypeRepository.Delete((int)id);
        if (vehicleTypeToDelete is null)
        {
            return NotFound();
        }

        ViewBag.Message = _messageService.Success($"Vehicle Type {vehicleTypeToDelete.Id} deleted");
        return RedirectToAction(nameof(Index));
    }
}