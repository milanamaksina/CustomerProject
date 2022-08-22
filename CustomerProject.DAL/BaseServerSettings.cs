using System.Data.SqlClient;

namespace CustomerProject.DAL
{
    public class BaseServerSettings
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection(@"Server=DESKTOP-NDUG8BN;Database=CustomerLib_Maksina.db;Trusted_Connection=True;");
        }
    }
}
