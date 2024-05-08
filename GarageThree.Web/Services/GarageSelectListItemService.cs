namespace GarageThree.Web.Services;

public class GarageSelectListItemService(IRepository<Garage> repository) : ISelectListItemService<Garage>
{
    private readonly IRepository<Garage> _repository = repository;

    public async Task<IEnumerable<SelectListItem>> GetSelectListItems(bool hasAllOption = false)
    {
        var garages = await _repository.GetAll();

        var options = garages.Select(g => new SelectListItem
        {
            Text = g.Name,
            Value = g.Id.ToString()
        }).ToList();

        if (hasAllOption)
        {
            options.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "All",
                Value = string.Empty
            });

        }

        return options;
    }
}