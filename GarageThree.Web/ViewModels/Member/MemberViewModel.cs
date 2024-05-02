using GarageThree.Web.ViewModels.Vehicle;

namespace GarageThree.Web.ViewModels.Member
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string SSN { get; set; }

        public IEnumerable<VehicleViewModel> Vehicles { get; set; } = [];
    }
}
