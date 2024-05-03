namespace GarageThree.Web.Validations
{
    public class SocialSecurityNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return base.IsValid(value);
        }
    }
}
