namespace GarageThree.Persistence.Parameters
{
    public class QueryParams
    {
        public string SearchTerm { get; set; } = default!;
        public object? Id { get; set; }
        public string? SSN { get; set; }
    }
}
