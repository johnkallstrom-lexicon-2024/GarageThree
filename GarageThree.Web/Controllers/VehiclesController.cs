namespace GarageThree.Web.Controllers
{
    public class VehiclesController(IMapper mapper, IRepository<Vehicle> repository) : Controller
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRepository<Vehicle> _repository = repository;

        public async Task<IActionResult> Index(int? garageId)
        {
            var vehicles = await _repository.Filter(new QueryParams
            {
                Id = garageId,
                SearchTerm = ""
            });

            var viewModel = new VehicleIndexViewModel
            {
                Vehicles = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicles)
            };
            if (garageId.HasValue) viewModel.GarageId = garageId.Value;

            return View(viewModel);
        }
    }
}
