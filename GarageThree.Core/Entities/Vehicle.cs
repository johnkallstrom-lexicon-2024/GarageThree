namespace GarageThree.Core.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegNumber { get; set; } = default!;
        public string Brand { get; set; } = default!;
        public string Model { get; set; } = default!;
        public DateTime RegisteredAt { get; set; }
        public Color Color { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; } = default!;

        public int GarageId { get; set; }
        public Garage Garage { get; set; } = default!;

        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; } = default!;
    }
}
