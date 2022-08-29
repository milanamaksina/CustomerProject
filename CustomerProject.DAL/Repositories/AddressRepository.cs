using CustomerProject.DAL.BusinessEntities;
using System.Data;
using System.Data.SqlClient;

namespace CustomerProject.DAL.Repositories
{
    public class AddressRepository : BaseServerSettings, IRepository<Address>
    {
        public void Create(Address entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Addresses(Line, Line2, AddressType, City, PostalCode, State, Country)" +
                    "VALUES (@Line, @Line2, @AddressType, @City, @PostalCode, @State, @Country)",
                    connection);

                var addressLine = new SqlParameter("@Line", System.Data.SqlDbType.NVarChar, 100)
                {
                    Value = entity.AddressLine
                };
                var addressLine2 = new SqlParameter("@Line2", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = entity.AddressLine2
                };
                var addressAddressType = new SqlParameter("@AddressType", System.Data.SqlDbType.NVarChar, 8)
                {
                    Value = entity.AddressType
                };
                var addressCity = new SqlParameter("@City", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = entity.City
                };
                var addressPostalCode = new SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar, 6)
                {
                    Value = entity.PostalCode
                };
                var addressStates = new SqlParameter("@State", System.Data.SqlDbType.NVarChar, 20)
                {
                    Value = entity.State
                };
                var addressCountry = new SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 14)
                {
                    Value = entity.Country
                };
                command.Parameters.Add(addressLine);
                command.Parameters.Add(addressLine2);
                command.Parameters.Add(addressAddressType);
                command.Parameters.Add(addressCity);
                command.Parameters.Add(addressPostalCode);
                command.Parameters.Add(addressStates);
                command.Parameters.Add(addressCountry);
                command.ExecuteNonQuery();
            }

        }

        public void Delete(int entityId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM [Customer] WHERE CustomerId = @CustomerId", connection);
                var customerIDParam = new SqlParameter("@CustomerID", SqlDbType.Int)
                {
                    Value = entityId
                };
                command.Parameters.Add(customerIDParam);
                command.ExecuteNonQuery();
            }
        }

        public Address Read(int entityId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [Customers] WHERE AddressId = @AddressId", connection);
                var customerId = new SqlParameter("@AddressId", System.Data.SqlDbType.Int)
                {
                    Value = entityId
                };
                command.Parameters.Add(customerId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return new Address
                        {
                            AddressLine = reader["Line"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressType = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            State = reader["State"].ToString(),
                            Country = reader["Country"].ToString()


                        };
                    }
                    reader.Close();
                    return null;
                }
            }
        }

        public void Update(Address entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE [Addresses] SET Line = @Line WHERE AddressId = @AddressId", connection);
                var addressId = new SqlParameter("@AddressId", System.Data.SqlDbType.Int)
                {
                    Value = entity.AddressId
                };
                var customerLine = new SqlParameter("@Line", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = entity.AddressLine
                };
                command.Parameters.Add(addressId);
                command.Parameters.Add(customerLine);
                command.ExecuteNonQuery();
            }

        }

        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "DELETE FROM Addresses",
                    connection);
                command.ExecuteNonQuery();
            }
        }

        public List<Address> GetAll()
        {
            List<Address> addresses = new List<Address>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Addresses", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addresses.Add(new Address
                        {
                            AddressId = Convert.ToInt32(reader["AddressId"]),
                            AddressLine = reader["Line"].ToString(),
                            AddressLine2 = reader["Line2"].ToString(),
                            AddressType = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            State = reader["StateName"].ToString(),
                            Country = reader["Country"].ToString()
                        });
                    }
                }
                return addresses;
            }
        }
    }
}
