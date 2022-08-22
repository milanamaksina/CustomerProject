using CustomerProject.DAL.BusinessEntities;
using CustomerProject.DAL.Repositories;

namespace CustomerProject.Tests.CustomerProject.DAL.Tests
{
    public class AddressRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateRepository()
        {
            var addressRepository = new AddressRepository();
            Assert.NotNull(addressRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var addressRepository = new AddressRepository();
            var address = CreateMockAddress();
        }

        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            var addressRepository = new AddressRepository();

            var address = CreateMockAddress();

            addressRepository.Create(address);

            var createdAddress = addressRepository.Read(address);

            Assert.NotNull(createdAddress);
            Assert.Equal(address.State, createdAddress.State);
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var addressRepository = new AddressRepository();
            var address = CreateMockAddress();

            addressRepository.Create(address);

            address.City = "new-york";
            addressRepository.Update(address);

            var createdAddress = addressRepository.Read(address);

            Assert.NotNull(createdAddress);
            Assert.Equal("new-york", createdAddress.City);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var addressRepository = new AddressRepository();
            var address = CreateMockAddress();

            addressRepository.Create(address);

            var createdAddress = addressRepository.Read(address);
            Assert.NotNull(createdAddress);

            addressRepository.Delete(address);
            var deletedAddress = addressRepository.Read(address);
            Assert.Null(deletedAddress);
        }

        private Address CreateMockAddress()
        {
            var address = new Address();

            address.AddressLine = "Street 1";
            address.AddressLine2 = "House 3";
            address.AddressType = "Billing";
            address.City = "Los Angeles";
            address.PostalCode = "303000";
            address.State = "Michigana";
            address.Country = "Canada";

            return address;
        }
    }
}

