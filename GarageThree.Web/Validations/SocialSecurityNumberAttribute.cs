using System.Text.RegularExpressions;

namespace GarageThree.Web.Validations
{
    public class SocialSecurityNumberAttribute() : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var configuration = validationContext.GetRequiredService<IConfiguration>();

            string errorMessage = configuration.GetValue<string>("Validations:SSN:ErrorMessage")!;
            int correctLength = configuration.GetValue<int>("Validations:SSN:CorrectLength");

            string? ssn = (string?)value;

            if (string.IsNullOrWhiteSpace(ssn)) return new ValidationResult(errorMessage);
            if (!ssn.Length.Equals(correctLength)) return new ValidationResult(errorMessage);
            if (Regex.IsMatch(ssn, @"(\D)")) return new ValidationResult(errorMessage);

            return ValidationResult.Success;
        }
    }
}
