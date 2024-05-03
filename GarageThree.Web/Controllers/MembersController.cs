namespace GarageThree.Web.Controllers
{
    public class MembersController(IRepository<Member> repository, IMapper mapper) : Controller
    {
        private readonly IRepository<Member> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MemberCreateOrEditViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var memberToCreate = _mapper.Map<Member>(viewModel);

            var newMember = _repository.Create(memberToCreate);
            if (newMember is not null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
    }
}
