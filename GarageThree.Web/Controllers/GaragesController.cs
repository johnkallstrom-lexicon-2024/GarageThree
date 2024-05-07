namespace GarageThree.Web.Controllers;

public class GaragesController(IMapper mapper, IRepository<Garage> repository) : Controller
{

    private readonly IMapper _mapper = mapper;
    private readonly IRepository<Garage> _repository = repository;

    public async Task<IActionResult> Index()
    {
        var garages = await _repository.GetAll();

        var viewModel = new GarageIndexViewModel
        {
            Garages = _mapper.Map<IEnumerable<GarageViewModel>>(garages)
        };

        return View(viewModel);
    }
}