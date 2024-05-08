namespace GarageThree.Web.Services
{
    public class VehicleTypeSelectListItemService(IRepository<VehicleType> repository) : ISelectListItemService<VehicleType>
    {
        private readonly IRepository<VehicleType> _repository = repository;

        public async Task<IEnumerable<SelectListItem>> GetSelectListItems(bool hasAllOption = false)
        {
            var vehicleTypes = await _repository.GetAll();

            var options = vehicleTypes.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString()
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
}
