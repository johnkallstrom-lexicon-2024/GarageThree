using Microsoft.IdentityModel.Tokens;

namespace GarageThree.Web.Controllers;

public class VehicleTypesController(IMapper mapper,
                                    IMessageService messageService,
                                    IRepository<Vehicle> vehicleRepository,
                                    IRepository<VehicleType> vehicleTypeRepository) : Controller
{
    private readonly IMapper _mapper = mapper;
    private readonly IMessageService _messageService = messageService;
    private readonly IRepository<Vehicle> _vehicleRepository = vehicleRepository;
    private readonly IRepository<VehicleType> _vehicleTypeRepository = vehicleTypeRepository;

    public async Task<IActionResult> Index(MessageViewModel? messageViewModel)
    {
        if (messageViewModel is not null)
        {
            ViewBag.Message = messageViewModel;
        }

        var vehicleTypes = await _vehicleTypeRepository.GetAll();

        var typeViewModels = _mapper.Map<IEnumerable<VehicleTypeViewModel>>(vehicleTypes);

        foreach (var t in typeViewModels)
        {
            t.AssignedVehicleCount = (await _vehicleRepository.Filter(new QueryParams()
            {
                VehicleTypeId = t.Id
            })).Count();
        }

        VehicleTypeIndexViewModel viewModel = new()
        {
            VehicleTypes = typeViewModels
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
            Name = viewModel.Name,
        });

        if (existingVehicleType is not null)
        {
            ModelState.AddModelError("SsnExists", "Vehicle Type with given Name already exists");
            ViewBag.Message = _messageService.Error("Vehicle Type with given Name already exists");
        }

        if (!ModelState.IsValid) return View(viewModel);

        var vehicleTypeToCreate = _mapper.Map<VehicleType>(viewModel);

        var createdVehicletype = await _vehicleTypeRepository.Create(vehicleTypeToCreate);
        if (createdVehicletype is not null)
        {
            MessageViewModel successMessage = _messageService.Success($"Vehicle Type {createdVehicletype.Name} created at {DateTime.Now}.");
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

        var updatedVehicleType = await _vehicleTypeRepository.Update(vehicleTypeToUpdate);
        if (updatedVehicleType is not null)
        {
            MessageViewModel successMessage = _messageService.Success($"Vehicle Type {updatedVehicleType.Name} updated at {DateTime.Now}.");
            return RedirectToAction(nameof(Index), successMessage);
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

        viewModel.AssignedVehicleCount = (await _vehicleRepository.Filter(new QueryParams()
        {
            VehicleTypeId = viewModel.Id
        })).Count();

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

        var vehicleTypeToDelete = await _vehicleTypeRepository.GetById((int)id);

        if (vehicleTypeToDelete is null)
        {
            return NotFound();
        }

        var vehicleWithType = await _vehicleRepository.Filter(new QueryParams
        {
            VehicleTypeId = id
        });

        MessageViewModel message;

        if (!vehicleWithType.IsNullOrEmpty())
        {
            message = _messageService.Error($"Vehicle Type [{vehicleTypeToDelete.Name}] is currently in use");
        }
        else
        {
            var deletedVehicle = await _vehicleTypeRepository.Delete((int)id);

            message = deletedVehicle is null ? _messageService.Error($"Could not delete Vehicle Type [{vehicleTypeToDelete.Name}]") :
                                                       _messageService.Success($"Vehicle Type {vehicleTypeToDelete.Id} deleted");
        }

        return RedirectToAction(nameof(Index), message);
    }
}