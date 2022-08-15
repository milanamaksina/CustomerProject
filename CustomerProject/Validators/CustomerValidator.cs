using CustomerProject.Entities;
using FluentValidation;


namespace CustomerProject.Validators
{
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FirstName)
               .MaximumLength(50).WithMessage(CustomErrorMessage.FirstNameLenghtException);
            RuleFor(c => c.LastName)
               .NotEmpty().WithMessage(CustomErrorMessage.LastNameIsRequared)
               .MaximumLength(50).WithMessage(CustomErrorMessage.LastNameLenghtException);
            RuleFor(c => c.Addresses)
               .NotEmpty().WithMessage(CustomErrorMessage.AddressesIsRequared);
            RuleFor(c => c.PhoneNumber)
               .Matches(@"^\+?[1 - 9]\d{ 1, 14}$").WithMessage(CustomErrorMessage.PhoneNumberInvalidFormat);
            RuleFor(c => c.Email)
               .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage(CustomErrorMessage.EmailInvalidFormat);
            RuleFor(c => c.Notes)
               .NotEmpty().WithMessage(CustomErrorMessage.NotesAreRequared);
        }
    }
}
