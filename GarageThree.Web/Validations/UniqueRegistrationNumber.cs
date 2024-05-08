namespace GarageThree.Web.Validations
{
    public class UniqueRegistrationNumber : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string errorMessage = "The registration number was not unique";

            var vehicleRepository = validationContext.GetRequiredService<IRepository<Vehicle>>();

            if (value is null) return new ValidationResult(errorMessage);

            string? registrationNumber = value.ToString();
            if (vehicleRepository.Any(v => v.RegNumber.Equals(registrationNumber)))
            {
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
