using GarageThree.Web.ViewModels.Message;

namespace GarageThree.Web.ViewModels.Member
{
    public class MemberCreateOrEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Avatar { get; set; } = default!;

        [Required]
        [Range(minimum: 5, maximum: 50, ErrorMessage = "Username must be between 5-50 characters")]
        [RegularExpression(@"[^\d\w]", ErrorMessage = "Only alphanumeric characters allowed in Username")]
        public string Username { get; set; } = default!;

        [Required]
        [DisplayName("First Name")]
        [Range(minimum: 3, maximum: 50, ErrorMessage = "First name must be between 3-50 characters")]
        public string FirstName { get; set; } = default!;

        [Required]
        [DisplayName("Last Name")]
        [Range(minimum: 3, maximum: 50, ErrorMessage = "Last name must be between 3-50 characters")]
        public string LastName { get; set; } = default!;

        [Range(minimum: 18, maximum: 130, ErrorMessage = "Age must be between 18-130")]
        public int Age { get; set; } = default!;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;

        [Required]
        [SocialSecurityNumber]
        [DisplayName("Social Security Number")]
        public string SSN { get; set; } = default!;

        public MessageViewModel? Message { get; set; }
    }
}
