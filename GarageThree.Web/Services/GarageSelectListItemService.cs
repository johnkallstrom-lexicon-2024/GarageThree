using GarageThree.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GarageThree.Web.Services
{
    public class GarageSelectListItemService(IRepository<Garage> repository) : ISelectListItemService<Garage>
    {
        private readonly IRepository<Garage> _repository = repository;

        public async Task<IEnumerable<SelectListItem>> GetSelectListItems()
        {
            var garages = await _repository.GetAll();
            return garages.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name
            });
        }
    }
}
