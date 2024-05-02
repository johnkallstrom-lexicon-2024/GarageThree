namespace GarageThree.Web.ViewModels.Member
{
    public class MemberCreateOrEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Avatar { get; set; } = default!;

        [Required]
        public string Username { get; set; }  = default!;

        [Required]
        public string FirstName { get; set; }  = default!;

        [Required]
        public string LastName { get; set; }  = default!;

        [Required]
        [DataType(DataType.EmailAddress)] 
        public string Email { get; set; }  = default!;
    }
}
