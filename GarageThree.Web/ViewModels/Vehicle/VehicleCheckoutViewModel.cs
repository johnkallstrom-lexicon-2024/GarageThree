namespace GarageThree.Web.ViewModels.Vehicle
{
    public class VehicleCheckoutViewModel
    {
        public TimeSpan ParkingPeriod { get; set; }
        public decimal TotalParkingPrice { get; set; }
        public string Garage { get; set; } = default!;
        public decimal GarageHourlyRate { get; set; }
        public VehicleViewModel Vehicle { get; set; } = default!;
        public MemberViewModel Member { get; set; } = default!;
    }
}
