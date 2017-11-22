using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DMIPrivateServices
{
    public class DatabaseService
    {
        private const String _sqlConString = "Data Source=kasper.database.windows.net;Initial Catalog=DB;Integrated Security=False;User ID=Kasper;Password=Kylling123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static SqlConnection SqlCon()
        {
            SqlConnection con = new SqlConnection(_sqlConString);
            con.Open();
            return con;
        }
    }
}