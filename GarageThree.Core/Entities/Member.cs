namespace GarageThree.Core.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string SSN { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = [];
    }
}
