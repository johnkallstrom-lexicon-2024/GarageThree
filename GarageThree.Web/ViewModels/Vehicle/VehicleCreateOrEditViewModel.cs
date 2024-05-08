namespace GarageThree.Web.ViewModels.Vehicle
{
    public class VehicleCreateOrEditViewModel
    {
        [Required]
        [DisplayName("Registration Number")]
        [UniqueRegistrationNumber]
        public string RegNumber { get; set; } = default!;

        [Required]
        public string Brand { get; set; }  = default!;

        [Required]
        public string Model { get; set; }  = default!;

        [Required]
        [DisplayName("Member")]
        public int MemberId { get; set; }

        [Required]
        [DisplayName("Garage")]
        public int GarageId { get; set; }

        //[Required]
        //[DisplayName("Vehicle Type")]
        //public int VehicleTypeId { get; set; }

        [Required]
        public Color Color { get; set; }
    }
}
