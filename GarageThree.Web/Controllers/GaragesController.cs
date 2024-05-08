namespace GarageThree.Web.Controllers;

public class GaragesController(IMapper mapper, IRepository<Garage> garageRepository) : Controller
{
    private readonly IMapper _mapper = mapper;
    private readonly IRepository<Garage> _garageRepository = garageRepository;

    public async Task<IActionResult> Index()
    {
        var garages = await _garageRepository.GetAll();

        GarageIndexViewModel viewModel = new()
        {
            Garages = _mapper.Map<IEnumerable<GarageViewModel>>(garages)
        };

        return View(viewModel);
    }
}