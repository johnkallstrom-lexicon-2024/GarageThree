namespace GarageThree.Web.Validations
{
    public class SocialSecurityNumberAttribute() : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var configuration = validationContext.GetRequiredService<IConfiguration>();
            string errorMessage = configuration.GetValue<string>("Validations:SSN:ErrorMessage")!;
            int maxLength = configuration.GetValue<int>("Validations:SSN:MaxLength");

            return new ValidationResult(errorMessage);
        }
    }
}
