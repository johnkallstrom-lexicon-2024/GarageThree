namespace GarageThree.Web.Controllers;

public class VehiclesController(IMapper mapper, IRepository<Vehicle> vehicleRepository, IRepository<Member> memberRepository) : Controller
{
    private readonly IMapper _mapper = mapper;
    private readonly IRepository<Vehicle> _vehicleRepository = vehicleRepository;

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
    [HttpGet]
   
}