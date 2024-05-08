namespace GarageThree.Core.Entities
{
    public class Garage
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Capacity { get; set; }
        public int HourlyRate { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = [];
    }
}
