namespace GarageThree.Web.ViewModels.Garage
{
    public class GarageCreateOrEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(5, 100)]
        public int Capacity { get; set; }
    }
}
