namespace GarageThree.Web.Controllers
{
    public class MembersController(IMapper mapper, IRepository<Member> memberRepository) : Controller
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRepository<Member> _memberRepository = memberRepository;

        public async Task<IActionResult?> Index()
        {
            if (!await _memberRepository.Any())
            {
                return NotFound();
            }

            var members = await _memberRepository.GetAll();
            var viewModels = _mapper.ProjectTo<MemberIndexViewModel>(members.AsQueryable());
            return View(viewModels);
        }
    }
}