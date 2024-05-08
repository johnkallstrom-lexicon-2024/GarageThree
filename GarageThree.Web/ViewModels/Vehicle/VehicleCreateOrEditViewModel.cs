namespace GarageThree.Web.ViewModels.Vehicle
{
    public class VehicleCreateOrEditViewModel
    {     
        [Required]
        [DisplayName("Registration Number")]
        public string RegNumber { get; set; } = default!;

        [Required]
        public string Brand { get; set; }  = default!;

        [Required]
        public string Model { get; set; }  = default!;

        [Required]
        [DisplayName("Parked At")]
        public DateTime RegisterdAt { get; set; } = DateTime.Now;

        [Required]
        public int MemberId { get; set; }

        [Required]
        public int GarageId { get; set; }

        [Required]
        public Color Color { get; set; }
    }
}
