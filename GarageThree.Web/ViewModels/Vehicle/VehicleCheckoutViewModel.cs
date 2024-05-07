namespace GarageThree.Web.ViewModels.Vehicle
{
    public class VehicleCheckoutViewModel
    {
        public int ParkedDays { get; set; }
        public int ParkedHours { get; set; }
        public int ParkedMinutes { get; set; }
        public decimal TotalParkingPrice { get; set; }
        public VehicleViewModel Vehicle { get; set; } = default!;
    }
}
