namespace GarageThree.Web.ViewModels.Checkout
{
    public class CheckoutViewModel
    {
        public int Id { get; set; }

        [DisplayName("Registration Number")]
        public string RegNumber { get; set; } = default!;

        [DisplayName("Vehicle Type")]
        public string VehicleType { get; set; } = default!;

        [DisplayName("Parked At")]
        public DateTime ParkedAt { get; set; }

        [DisplayName("Checkout At")]
        public DateTime CheckoutAt { get; set; }

        [DisplayName("Total Parking Cost")]
        public decimal TotalParkingCost { get; set; }

        [DisplayName("Period")]
        public TimeSpan ParkingPeriod { get; set; }

        public string Garage { get; set; } = default!;

        [DisplayName("Hourly Rate")]
        public int HourlyRate { get; set; }

        public MemberViewModel Member { get; set; } = default!;
    }
}
