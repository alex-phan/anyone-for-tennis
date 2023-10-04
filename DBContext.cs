using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TennisCourtMembershipSoft
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
                    "Data Source = LAPTOP-1U3PBG58\\SQLEXPRESS; Initial Catalog = TennisMemberShip; Integrated Security = True");
        } 
    }

}
