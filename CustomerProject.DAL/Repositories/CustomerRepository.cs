using CustomerProject.DAL.BusinessEntities;
using System.Data.SqlClient;

namespace CustomerProject.DAL.Repositories
{
    public class CustomerRepository : BaseServerSettings, IRepository<Customer>
    {
        public void Create(Customer entity)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand(
                "INSERT INTO Customers(FirstName, LastName, PhoneNumber, Email, Notes, TotalPurchasesAmount)" +
                "VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Notes, @TotalPurchasesAmount)",
                connection);

            var customerFirstNameParam = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 50)
            {
                Value = entity.FirstName
            };
            var customerLastNameParam = new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 50)
            {
                Value = entity.LastName
            };
            var customerPhoneNumberParam = new SqlParameter("@PhoneNumber", System.Data.SqlDbType.NVarChar, 20)
            {
                Value = entity.PhoneNumber
            };
            var customerEmailParam = new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50)
            {
                Value = entity.Email
            };
            var customerNotesParam = new SqlParameter("@Notes", System.Data.SqlDbType.NVarChar, 250)
            {
                Value = entity.Notes
            };
            var customerTotalPurchasesAmountParam = new SqlParameter("@TotalPurchasesAmount", System.Data.SqlDbType.Decimal)
            {
                Value = entity.TotalPurchasesAmount
            };
            command.Parameters.Add(customerFirstNameParam);
            command.Parameters.Add(customerLastNameParam);
            command.Parameters.Add(customerPhoneNumberParam);
            command.Parameters.Add(customerEmailParam);
            command.Parameters.Add(customerNotesParam);
            command.Parameters.Add(customerTotalPurchasesAmountParam);
            command.ExecuteNonQuery();
        }

        public void Delete(Customer entity)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("DELETE FROM [Customers] WHERE CustomerId = @CustomerId", connection);
            var customerId = new SqlParameter("@CustomerId", System.Data.SqlDbType.Int)
            {
                Value = entity.Id
            };
            command.Parameters.Add(customerId);
            command.ExecuteNonQuery();
        }

        public Customer Read(Customer entity)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("SELECT * FROM [Customers] WHERE CustomerId = @CustomerId", connection);
            var customerId = new SqlParameter("@CustomerId", System.Data.SqlDbType.Int)
            {
                Value = entity.Id
            };
            command.Parameters.Add(customerId);
            using var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                return new Customer
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    Email = reader["Email"].ToString(),
                    Notes = reader["Notes"].ToString()
                };
            }
            reader.Close();
            return null;
        }

        public void Update(Customer entity)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("UPDATE [Customers] SET FirstName = @FirstName WHERE CustomerId = @CustomerId", connection);
            var customerId = new SqlParameter("@CustomerId", System.Data.SqlDbType.Int)
            {
                Value = entity.Id
            };
            var customerFirstNameParam = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 50)
            {
                Value = entity.FirstName
            };
            command.Parameters.Add(customerId);
            command.Parameters.Add(customerFirstNameParam);
            command.ExecuteNonQuery();
        }
    }
}
