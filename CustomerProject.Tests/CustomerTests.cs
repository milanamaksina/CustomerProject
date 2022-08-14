using CustomerProject.Entities;
using CustomerProject.Validators;
using System.Collections.Generic;

namespace CustomerProject.Tests
{
    public class CustomerTests
    {
        private CustomerValidator _validator = new CustomerValidator();

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            List<Address> customerAddresses = new List<Address>();
            Address address = new Address("Pearl Street", "23/12", AddressType.Shipping, "New-York", "234213", "New-York", "USA");
            customerAddresses.Add(address);
            List<string> testNotes = new List<string>();
            testNotes.Add("note");

            Customer actualCustomer = new Customer()
            {
                FirstName = "Alex",
                LastName = "Smith",
                Addresses = customerAddresses,
                PhoneNumber = "+195534912",
                Email = "alex@gmail.com",
                Notes = testNotes, 
                TotalPurchasesAmount = 1
            };

            Assert.Equal("Alex", actualCustomer.FirstName);
            Assert.Equal("Smith", actualCustomer.LastName);
            Assert.Equal(customerAddresses, actualCustomer.Addresses);
            Assert.Equal("+195534912", actualCustomer.PhoneNumber);
            Assert.Equal("alex@gmail.com", actualCustomer.Email);
            Assert.Equal(testNotes, actualCustomer.Notes);
            Assert.Equal(1, actualCustomer.TotalPurchasesAmount);
        }



    }
}
