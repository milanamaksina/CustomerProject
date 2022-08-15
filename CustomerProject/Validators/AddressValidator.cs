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
            RuleFor(a => a.AddressLine)
               .NotEmpty().WithMessage(CustomErrorMessage.AddressLineIsRequared)
               .MaximumLength(100).WithMessage(CustomErrorMessage.AddressLineLenghtException);
            RuleFor(a => a.AddressLine2)
               .MaximumLength(100).WithMessage(CustomErrorMessage.AddressLine2LenghtException);
            RuleFor(a => a.AddressType)
               .IsInEnum().WithMessage(CustomErrorMessage.AddressTypeIsNotEnum);
            RuleFor(a => a.City)
               .NotEmpty().WithMessage(CustomErrorMessage.CityIsRequared)
               .MaximumLength(50).WithMessage(CustomErrorMessage.CityLenghtException);
            RuleFor(a => a.PostalCode)
               .NotEmpty().WithMessage(CustomErrorMessage.PostalCodeIsRequared)
               .MaximumLength(6).WithMessage(CustomErrorMessage.PostalCodeLenghtException);
            RuleFor(a => a.State)
               .NotEmpty().WithMessage(CustomErrorMessage.StateIsRequared)
               .MaximumLength(20).WithMessage(CustomErrorMessage.StateLenghtException);
            RuleFor(a => a.Country)
              .NotEmpty().WithMessage(CustomErrorMessage.CountryIsRequared)
              .Must(a => availableCountries.Contains(a)).WithMessage(CustomErrorMessage.InvalidCountryName);
        }


    }
}
