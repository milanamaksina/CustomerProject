using CustomerProject.Entities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CustomerProject.Validators
{
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public static List<string> Validate(Customer customer)
        {
            List<string> errors = new List<string>();
            if ((customer.FirstName != null) && (customer.FirstName.Length > 50))
            {
                errors.Add(CustomErrorMessage.FirstNameLenghtException);
            }
            if (customer.LastName.Length > 50)
            {
                errors.Add(CustomErrorMessage.LastNameLenghtException);
            }
            if ((customer.Addresses == null) || (customer.Addresses.Count == 0))
            {
                errors.Add(CustomErrorMessage.AddressesIsRequared);
            }
            if ((customer.PhoneNumber != null) && !(Regex.IsMatch(customer.PhoneNumber, @"^\+?[1-9]\d{1,14}$")))
            {
                errors.Add(CustomErrorMessage.PhoneNumberInvalidFormat);
            }
            if ((customer.Email != null) && !(Regex.IsMatch(customer.Email,
                @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")))
            {
                errors.Add(CustomErrorMessage.EmailInvalidFormat);
            }
            if ((customer.Notes == null) || (customer.Notes.Count == 0))
            {
                errors.Add(CustomErrorMessage.NotesAreRequared);
            }

            return errors;
        }
    }
}
