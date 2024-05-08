namespace GarageThree.Web.ViewModels.Vehicle
{
    public class VehicleCheckoutViewModel
    {
        [DisplayName("Days")]
        public int ParkedDays { get; set; }
        [DisplayName("Hours")]
        public int ParkedHours { get; set; }
        [DisplayName("Minutes")]
        public int ParkedMinutes { get; set; }
        [DisplayName("Total Parking Cost")]
        public decimal TotalParkingPrice { get; set; }
        public string Garage { get; set; } = default!;
        [DisplayName("Checkout At")]
        public DateTime CheckoutAt { get; set; }
        [DisplayName("Hourly Rate")]
        public int HourlyRate { get; set; }
        public VehicleViewModel Vehicle { get; set; } = default!;
        public MemberViewModel Member { get; set; } = default!;
    }
}
