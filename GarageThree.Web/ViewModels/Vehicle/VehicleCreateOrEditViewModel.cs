namespace GarageThree.Web.ViewModels.Vehicle
{
    public class VehicleCreateOrEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public MemberViewModel Owner { get; set; }  = default!;

        [Required]
        public string Brand { get; set; }  = default!;

        [Required]
        public string Model { get; set; }  = default!;

        [Required]
        public Color Color { get; set; }
    }
}
