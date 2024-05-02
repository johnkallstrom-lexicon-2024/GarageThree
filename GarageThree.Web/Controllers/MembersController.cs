namespace GarageThree.Web.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMapper _mapper;

        public MembersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MemberCreateOrEditViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var member = _mapper.Map<Member>(viewModel);

            // Pass entity to repository method

            return View(viewModel);
        }
    }
}
