namespace GarageThree.Web.Controllers
{
    public class VehiclesController(
        ICheckoutService checkoutService,
        IMapper mapper, 
        IRepository<Vehicle> repository) : Controller
    {
        private readonly ICheckoutService _checkoutService = checkoutService;
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

        public async Task<IActionResult> Delete(int id)
        {
            var deletedVehicle = await _repository.Delete(id);
            if (deletedVehicle is null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Checkout), _mapper.Map<VehicleViewModel>(deletedVehicle));
        }

        public IActionResult Checkout(VehicleViewModel vehicle)
        {
            TimeSpan parkingPeriod = _checkoutService.CalculateParkingPeriod(vehicle.RegisteredAt);
            decimal totalParkingPrice = _checkoutService.CalculateTotalParkingPrice(vehicle.RegisteredAt);

            var viewModel = new VehicleCheckoutViewModel
            {
                ParkedDays = parkingPeriod.Days,
                ParkedHours = (int)parkingPeriod.TotalHours,
                ParkedMinutes = (int)parkingPeriod.TotalMinutes,
                TotalParkingPrice = totalParkingPrice,
                Vehicle = vehicle
            };

            return View(viewModel);
        }
    }
}
