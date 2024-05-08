using GarageThree.Web.ViewModels.Message;

namespace GarageThree.Web.Controllers;

public class MembersController(IMapper mapper, IRepository<Member> memberRepository, IMessageService messageService) : Controller
{
    private readonly IMapper _mapper = mapper;
    private readonly IRepository<Member> _memberRepository = memberRepository;
    private readonly IMessageService _messageService = messageService;

    public async Task<IActionResult?> Index()
    {
        var members = await _memberRepository.GetAll();
        MemberIndexViewModel indexViewModel = new()
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
            ViewBag.Message = _messageService.Error("Member with given SSN already exists");
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

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var member = await _memberRepository.GetById((int)id);

        var viewModel = _mapper.Map<MemberViewModel>(member);
        viewModel.MemberCount = (await _memberRepository.GetAll()).Count();

        return View(viewModel);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var modelToEdit = await _memberRepository.GetById((int)id);
        var viewModel = _mapper.Map<MemberCreateOrEditViewModel>(modelToEdit);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(MemberCreateOrEditViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        var memberToUpdate = _mapper.Map<Member>(viewModel);

        var updatedMember = await _memberRepository.Update(memberToUpdate);
        if (updatedMember is not null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var memberToDelete = await _memberRepository.Delete((int)id);

        if (memberToDelete is not null)
        {
            ViewBag.Message = _messageService.Success($"Member {memberToDelete.Id} deleted");
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index));
    }
}