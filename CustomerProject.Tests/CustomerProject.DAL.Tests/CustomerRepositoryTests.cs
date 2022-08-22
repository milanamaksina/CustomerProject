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


    }
}
