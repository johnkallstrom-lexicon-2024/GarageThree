namespace GarageThree.Core.Entities
{
    public class Checkout
    {
        public int Id { get; set; }
        public int ParkedDays { get; set; }
        public int ParkedHours { get; set; }
        public int ParkedMinutes { get; set; }
        public decimal TotalParkingCost { get; set; }
        public string Garage { get; set; } = default!;
        public int HourlyRate { get; set; }
        public DateTime Created { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; } = default!;

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = default!;
    }
}
