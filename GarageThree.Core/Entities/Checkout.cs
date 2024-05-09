namespace GarageThree.Core.Entities
{
    public class Checkout
    {
        public int Id { get; set; }
        public string RegNumber { get; set; } = default!;
        public string VehicleType { get; set; } = default!;
        public DateTime ParkedAt { get; set; }
        public DateTime CheckoutAt { get; set; }
        public decimal TotalParkingCost { get; set; }
        public string Garage { get; set; } = default!;
        public int HourlyRate { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; } = default!;
    }
}
