namespace GarageThree.Persistence.Parameters
{
    public class QueryParams
    {
        public string? SearchTerm { get; set; }
        public object? Id { get; set; }
        public string? Name { get; set; }
        public int? VehicleTypeId { get; set; }
        public string? SSN { get; set; }
    }
}