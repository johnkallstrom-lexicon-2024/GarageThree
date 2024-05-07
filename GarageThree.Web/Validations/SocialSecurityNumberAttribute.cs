using System.Text.RegularExpressions;

namespace GarageThree.Web.Validations
{
    public partial class SocialSecurityNumberAttribute() : ValidationAttribute
    {
        [GeneratedRegex(@"(\D)")]
        private static partial Regex MyRegex();

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var configuration = validationContext.GetRequiredService<IConfiguration>();

            string errorMessage = configuration.GetValue<string>("Validations:SSN:ErrorMessage")!;
            int correctLength = configuration.GetValue<int>("Validations:SSN:CorrectLength");

            string? ssn = (string?)value;

            if (string.IsNullOrWhiteSpace(ssn) ||
                !ssn.Length.Equals(correctLength) ||
                MyRegex().IsMatch(ssn))
            {
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
