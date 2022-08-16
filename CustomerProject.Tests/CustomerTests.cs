using CustomerProject.Entities;
using CustomerProject.Validators;
using FluentValidation.TestHelper;
using System.Collections.Generic;

namespace CustomerProject.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            Address address = new Address("Pearl street","", AddressType.Billing, "New-York", "676565", "New-York", "United States");
            Assert.NotNull(address);

            Assert.Equal("Pearl street", address.AddressLine);
            Assert.Equal(AddressType.Billing, address.AddressType);
            Assert.Equal("New-York", address.City);
            Assert.Equal("676565", address.PostalCode);
            Assert.Equal("New-York", address.State);
            Assert.Equal("United States", address.Country);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            Address address = new Address("Pearl street", "", AddressType.Billing, "New-York", "676565", "New-York", "United States");

            Customer customer = new Customer()
            {
                FirstName = "anton",
                LastName = "ptushkin",
                Addresses = new List<Address> { address },
                PhoneNumber = "+150878682",
                Email = "anton@gmail.com",
                Notes = new List<string> { "note1" },
                TotalPurchasesAmount = 0
            };


            Assert.Equal("anton", customer.FirstName);
            Assert.Equal("ptushkin", customer.LastName);
            Assert.Equal(1, customer.Addresses.Count);
            Assert.Equal("+150878682", customer.PhoneNumber);
            Assert.Equal(1, customer.Notes.Count);
            Assert.Equal(0, customer.TotalPurchasesAmount);

        }

        [Fact]
        public void WhenCustomerAddressIsWrong_ShouldThrowException()
        {
            string test = "123456789012345678901234567890123456789012345678901234567890";

            Address address = new Address("", "", AddressType.Billing, test, "676565897827238", test, "USA" );
            var result = AddressValidator.Validate(address);

            Assert.Equal(CustomErrorMessage.AddressLineIsRequared, result[0]);
            Assert.Equal(CustomErrorMessage.CityLenghtException, result[1]);
            Assert.Equal(CustomErrorMessage.PostalCodeLenghtException, result[2]);
            Assert.Equal(CustomErrorMessage.StateLenghtException, result[3]);
            Assert.Equal(CustomErrorMessage.InvalidCountryName, result[4]);


        }


    }
}
