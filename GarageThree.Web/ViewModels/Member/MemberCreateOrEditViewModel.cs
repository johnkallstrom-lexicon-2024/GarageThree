using GarageThree.Web.ViewModels.Message;

namespace GarageThree.Web.ViewModels.Member
{
    public class MemberCreateOrEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [Url]
        public string Avatar { get; set; } = default!;

        [Required]
        [MinLength(5, ErrorMessage = "Username must be at least 5 charactes")]
        [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
        [RegularExpression(@"[\d\w'_''-']*", ErrorMessage = @"Only characters a-z, ""-"" and ""_"" allowed")]
        public string Username { get; set; } = default!;

        [Required]
        [DisplayName("First Name")]
        [MinLength(3, ErrorMessage = "First name  must be at least 3 charactes")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        [RegularExpression(@"[a-zA-Z]*", ErrorMessage = "Only alphabetical characters allowed")]
        public string FirstName { get; set; } = default!;

        [Required]
        [DisplayName("Last Name")]
        [MinLength(3, ErrorMessage = "Last name  must be at least 3 charactes")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        [RegularExpression(@"[a-zA-Z]*", ErrorMessage = "Only alphabetical characters allowed")]
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
