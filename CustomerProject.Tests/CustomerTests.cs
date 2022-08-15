using CustomerProject.Entities;
using CustomerProject.Validators;
using FluentValidation.TestHelper;
using System.Collections.Generic;

namespace CustomerProject.Tests
{
    public class CustomerTests
    {
        private CustomerValidator _customerValidator = new CustomerValidator();
        private AddressValidator _addressValidator = new AddressValidator();


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

        [Fact]
        public void WhenAddressModelIsNotCorrect_ShouldThrowExceptions()
        {
            List<Address> customerAddresses = new List<Address>();
            Address address = new Address("", "", AddressType.Shipping, "", "", "89236723262732", "France");

            var result = _addressValidator.TestValidate(address);
            result.ShouldHaveValidationErrorFor(x => x.AddressLine);
            result.ShouldHaveValidationErrorFor(x => x.AddressLine);
            result.ShouldHaveValidationErrorFor(x => x.City);
            result.ShouldHaveValidationErrorFor(x => x.PostalCode);
            result.ShouldHaveValidationErrorFor(x => x.Country);
        }

        [Fact]
        public void TotalPurchasesAmountCanBeNull()
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
                TotalPurchasesAmount = 0
            };

            Assert.Equal(0, actualCustomer.TotalPurchasesAmount);
        }

        [Fact]
        public void WhenCustomerModelIsNotCorrect_ShouldThrowExceptions()
        {
            Customer actualCustomer = new Customer()
            {
                FirstName = "Alex",
                LastName = "",
                Addresses = new List<Address>(),
                PhoneNumber = "+19",
                Email = "alexcom",
                Notes = new List<string>(),
                TotalPurchasesAmount = 0
            };

            var result = _customerValidator.TestValidate(actualCustomer);
            result.ShouldHaveValidationErrorFor(x => x.LastName);
            result.ShouldHaveValidationErrorFor(x => x.Addresses);
            result.ShouldHaveValidationErrorFor(x => x.PhoneNumber);
            result.ShouldHaveValidationErrorFor(x => x.Email);
            result.ShouldHaveValidationErrorFor(x => x.Notes);
        }




    }
}
