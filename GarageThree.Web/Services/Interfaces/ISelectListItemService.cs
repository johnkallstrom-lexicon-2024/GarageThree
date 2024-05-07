namespace GarageThree.Web.Services.Interfaces
{
    public interface ISelectListItemService<T> where T : class
    {
        Task<IEnumerable<SelectListItem>> GetSelectListItems();
    }
}
