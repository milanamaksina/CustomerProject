using CustomerProject.Validators;
using System.ComponentModel.DataAnnotations;


namespace CustomerProject.Entities
{
    public class Address
    {
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public AddressType AddressType { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

}
