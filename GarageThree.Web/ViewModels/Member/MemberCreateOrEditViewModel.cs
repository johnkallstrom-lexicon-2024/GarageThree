namespace GarageThree.Web.ViewModels.Member
{
    public class MemberCreateOrEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Avatar { get; set; } = default!;

        [Required]
        public string Username { get; set; } = default!;

        [Required]
        public string FirstName { get; set; } = default!;

        [Required]
        public string LastName { get; set; } = default!;

        [Required]
        [Range(minimum: 18, maximum: double.MaxValue)]
        public int Age { get; set; } = default!;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;

        [SocialSecurityNumber]
        [DisplayName("Social Security Number")]
        [Required]
        public string SSN { get; set; } = default!;
    }
}
