using System.Data.SqlClient;

namespace CustomerProject.DAL
{
    public class BaseServerSettings
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=.//sql2019;Initial Catalog = CustomerLib_Maksina.db;Persist Security Info=True;");
        }
    }
}
