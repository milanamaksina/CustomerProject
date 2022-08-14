using CustomerProject.Entities;
using FluentValidation;
using System.ComponentModel.DataAnnotations;


namespace CustomerProject.Validators
{
        
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            var availableCountries = new List<string> {"USA", "Canada"};
            RuleFor(c => c.AddressLine)
               .NotEmpty().WithMessage(CustomErrorMessage.AddressLineIsRequared)
               .MaximumLength(100).WithMessage(CustomErrorMessage.AddressLineLenghtException);
            RuleFor(c => c.AddressLine2)
               .MaximumLength(100).WithMessage(CustomErrorMessage.AddressLine2LenghtException);
            RuleFor(c => c.AddressType)
               .IsInEnum().WithMessage(CustomErrorMessage.AddressTypeIsNotEnum);
            RuleFor(c => c.City)
               .NotEmpty().WithMessage(CustomErrorMessage.CityIsRequared)
               .MaximumLength(50).WithMessage(CustomErrorMessage.CityLenghtException);
            RuleFor(c => c.PostalCode)
               .NotEmpty().WithMessage(CustomErrorMessage.PostalCodeIsRequared)
               .MaximumLength(6).WithMessage(CustomErrorMessage.PostalCodeLenghtException);
            RuleFor(c => c.State)
               .NotEmpty().WithMessage(CustomErrorMessage.StateIsRequared)
               .MaximumLength(20).WithMessage(CustomErrorMessage.StateLenghtException);
            RuleFor(c => c.Country)
              .NotEmpty().WithMessage(CustomErrorMessage.CountryIsRequared)
              .Must(c => availableCountries.Contains(c)).WithMessage(CustomErrorMessage.InvalidCountryName);
              //.Must(c=>c.Equals("USA")||c.Equals("Canada"));
        }


    }
}
