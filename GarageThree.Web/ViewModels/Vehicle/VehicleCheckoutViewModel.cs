namespace GarageThree.Web.ViewModels.Vehicle
{
    public class VehicleCheckoutViewModel
    {
        public int ParkedDays { get; set; }
        public int ParkedHours { get; set; }
        public int ParkedMinutes { get; set; }
        public decimal TotalParkingPrice { get; set; }
        public string Garage { get; set; } = default!;
        public VehicleViewModel Vehicle { get; set; } = default!;
        public MemberViewModel Member { get; set; } = default!;
    }
}
