namespace GarageThree.Web.Controllers;

public class VehiclesController(IMapper mapper, IRepository<Vehicle> vehicleRepository) : Controller
{
    private readonly IMapper _mapper = mapper;
    private readonly IRepository<Vehicle> _vehicleRepository = vehicleRepository;

        public async Task<IActionResult> Index(int? garageId, string? searchTerm)
        {
            var vehicles = await _repository.Filter(new QueryParams
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

        public IActionResult Clear() => RedirectToAction(nameof(Index), new { });
    }
}
