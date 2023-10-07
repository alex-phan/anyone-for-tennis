using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AnyoneForTennis
{

    public class DBContext
    {
        public SqlConnection Connection;
        public SqlCommand Command;
        public SqlDataReader Reader;

        public DBContext()
        {
            Connection =
            new SqlConnection(
                    "Data Source=DESKTOP-KAK0201\\MSSQLSERVER01;Initial Catalog=AnyoneForTennis;Integrated Security=True");
        } 
    }

}
