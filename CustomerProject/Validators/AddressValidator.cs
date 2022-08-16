using CustomerProject.Entities;
using FluentValidation;
using System.ComponentModel.DataAnnotations;


namespace CustomerProject.Validators
{
        
    public class AddressValidator
    {
        public static List<string> Validate(Address address)
        {
            List<string> errors = new List<string>();
            if (address.AddressLine.Length > 100)
            {
                errors.Add(CustomErrorMessage.AddressLineLenghtException);
            }
            if ((address.AddressLine2 != null) || (address.AddressLine2.Length > 100))
            {
                errors.Add(CustomErrorMessage.AddressLineIsRequared);
            }
            if (address.City.Length > 50)
            {
                errors.Add(CustomErrorMessage.CityLenghtException);
            }
            if (address.PostalCode.Length > 6)
            {
                errors.Add(CustomErrorMessage.PostalCodeLenghtException);
            }
            if (address.State.Length > 20)
            {
                errors.Add(CustomErrorMessage.StateLenghtException);
            }
            if (!(address.Country == "United States" || address.Country == "Canada"))
            {
                errors.Add(CustomErrorMessage.InvalidCountryName);
            }

            return errors;
        }


    }
}
