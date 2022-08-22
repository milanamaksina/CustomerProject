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
    }
}
