namespace GarageThree.Web.Controllers;

public class VehicleTypesController(IMapper mapper,
                                    IRepository<VehicleType> vehicleTypeRepository) : Controller
{

    private readonly IMapper _mapper = mapper;
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
}