namespace GarageThree.Core.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Avatar { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int Age { get; set; }
        public string Email { get; set; } = default!;
        public string SSN { get; set; } = default!;

        public ICollection<Vehicle> Vehicles { get; set; } = [];
    }
}
