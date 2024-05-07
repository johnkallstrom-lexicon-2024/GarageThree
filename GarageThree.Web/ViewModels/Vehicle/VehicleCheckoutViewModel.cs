namespace GarageThree.Web.ViewModels.Vehicle
{
    public class VehicleCheckoutViewModel
    {
        public TimeSpan ParkingPeriod { get; set; }
        public decimal TotalParkingPrice { get; set; }
        public decimal GarageHourlyRate { get; set; }
        public VehicleViewModel Vehicle { get; set; } = default!;
    }
}
