namespace GarageThree.Web.ViewModels.Member
{
    public class MemberCreateOrEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Avatar { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Range(minimum: 18, maximum: double.MaxValue)]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName]
        [Required]
        public string SSN { get; set; }
    }
}
