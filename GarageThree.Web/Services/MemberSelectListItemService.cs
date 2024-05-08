namespace GarageThree.Web.Services;

public class MemberSelectListItemService(IRepository<Member> repository) : ISelectListItemService<Member>
{
    private readonly IRepository<Member> _repository = repository;

    public async Task<IEnumerable<SelectListItem>> GetSelectListItems(bool hasAllOption = false)
    {
        var members = await _repository.GetAll();

        return members.Select(m => new SelectListItem
        {
            Text = $"{m.FirstName} {m.LastName}",
            Value = m.Id.ToString()
        }).ToList();
    }
}