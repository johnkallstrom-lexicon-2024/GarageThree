namespace GarageThree.Web.Controllers
{
    public class VehiclesController(IMapper mapper, IRepository<Vehicle> repository) : Controller
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRepository<Vehicle> _repository = repository;

        public async Task<IActionResult> Index()
        {
            var vehicles = await _repository.GetAll();

            var viewModel = new VehicleIndexViewModel();
            viewModel.Vehicles = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicles);

            return View(viewModel);
        }
    }
}
