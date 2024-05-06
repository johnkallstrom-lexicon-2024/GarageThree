using GarageThree.Web.ViewModels.Message;

namespace GarageThree.Web.Controllers
{
    public class MembersController(IMapper mapper, IRepository<Member> memberRepository) : Controller
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRepository<Member> _memberRepository = memberRepository;

        public async Task<IActionResult?> Index()
        {
            var members = await _memberRepository.GetAll();
            var indexViewModel = new MemberIndexViewModel
            {
                MemberViewModels = _mapper.ProjectTo<MemberViewModel>(members.AsQueryable())
            };
            return View(indexViewModel);
        }

        public IActionResult Create() => View(new MemberCreateOrEditViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberCreateOrEditViewModel viewModel)
        {
            var existingMember = await _memberRepository.Single(new QueryParams()
            {
                SSN = viewModel.SSN
            });

            if (existingMember is not null)
            {
                ModelState.AddModelError("SsnExists", "Member with given SSN already exists");
                viewModel.Message = new MessageViewModel()
                {
                    IsActive = true,
                    Type = ViewModels.Enums.MessageType.Danger,
                    Text = "Member with given SSN already exists",
                };
            }

            if (!ModelState.IsValid) return View(viewModel);

            var memberToCreate = _mapper.Map<Member>(viewModel);

            var newMember = await _memberRepository.Create(memberToCreate);
            if (newMember is not null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
    }
}