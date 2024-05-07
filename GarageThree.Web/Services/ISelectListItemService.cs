using Microsoft.AspNetCore.Mvc.Rendering;

namespace GarageThree.Web.Services
{
    public interface ISelectListItemService<T> where T : class
    {
        Task<IEnumerable<SelectListItem>> GetSelectListItems(bool useAllOption = false);
    }
}
