using AutoFixture;
using CustomerProject.DAL.BusinessEntities;
using CustomerProject.DAL.Repositories;

namespace CustomerProject.Tests.CustomerProject.DAL.Tests
{
    public class CustomerRepositoryTests
    {


        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var repository = new CustomerRepository();
            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var repository = new CustomerRepository();
            var customer = new Customer
            {
                FirstName = "Misha",
                LastName = "Grishin",
                PhoneNumber = "+219474280516700",
                Email = "misha@mail.ru",
                TotalPurchasesAmount = 1,
                Notes = "note1"
            };
            repository.Create(customer);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var customerRepository = new CustomerRepository();
            customerRepository.DeleteAll();

            var customer = CreateMockCustomer();
            customerRepository.Create(customer);

            var createdCustomer = customerRepository.Read(customer);

            Assert.Equal(customer.FirstName, createdCustomer.FirstName);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var customerRepository = new CustomerRepository();
            var customer = CreateMockCustomer();

            customerRepository.Create(customer);
            customer.FirstName = "Oleg";
            customerRepository.Update(customer);

            var createdCustomer = customerRepository.Read(customer);

            Assert.NotNull(createdCustomer);
            Assert.Equal("Oleg", createdCustomer.FirstName);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerRepository = new CustomerRepository();
            var customer = CreateMockCustomer();

            customerRepository.Create(customer);

            customerRepository.Delete(customer);
            var deletedCustomer = customerRepository.Read(customer);
            Assert.Null(deletedCustomer);
        }

        private Customer CreateMockCustomer()
        {
            var customer = new Customer();
          
            customer.FirstName = "Mishka";
            customer.LastName = "Grishin";
            customer.PhoneNumber = "+219474280516700";
            customer.Email = "mishka@mail.com";
            customer.Notes = "note1";
            customer.TotalPurchasesAmount = 10;

            return customer;
        }

    }
}
