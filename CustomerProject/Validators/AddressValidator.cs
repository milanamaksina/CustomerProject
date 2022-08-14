using System.ComponentModel.DataAnnotations;


namespace CustomerProject.Validators
{
    public class AddressValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var AllowCountry = new List<string>()
            {
                "USA", "United States Of America", "Canada", "United States"
            };
            var checker = AllowCountry.Contains(value.ToString());
            if (!checker)
            {
                return new ValidationResult(CustomErrorMessage.NotAllowedAddress);
            }
            return null;
        }
    }
}
