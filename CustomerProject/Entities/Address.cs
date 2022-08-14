using CustomerProject.Validators;
using System.ComponentModel.DataAnnotations;


namespace CustomerProject.Entities
{
    public class Address
    {
        [Required(ErrorMessage = CustomErrorMessage.AddressLineIsRequared)]
        [StringLength(100, ErrorMessage = CustomErrorMessage.AddressLineLenghtException)]
        public string AddressLine { get; set; }
        [StringLength(100, ErrorMessage = CustomErrorMessage.AddressLine2LenghtException)]
        public string AddressLine2 { get; set; }
        [EnumDataType(typeof(AddressType))]
        public AddressType AddressType { get; set; }
        [Required(ErrorMessage = CustomErrorMessage.CityIsRequared)]
        [StringLength(50, ErrorMessage = CustomErrorMessage.CityLenghtException)]
        public string City { get; set; }
        [Required(ErrorMessage = CustomErrorMessage.PostalCodeIsRequared)]
        [StringLength(6, ErrorMessage = CustomErrorMessage.PostalCodeLenghtException)]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = CustomErrorMessage.StateIsRequared)]
        [StringLength(20, ErrorMessage = CustomErrorMessage.StateIsRequared)]
        public string State { get; set; }
        [Required(ErrorMessage = CustomErrorMessage.CountryIsRequared)]
        [AddressValidator]
        public string Country { get; set; }
    }

}
