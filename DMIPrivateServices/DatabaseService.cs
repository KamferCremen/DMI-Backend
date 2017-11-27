using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DMIPrivateServices.Model;

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

        public static TemperatureData GetByObjectId(String id)
        {
            SqlCommand GetElementById = new SqlCommand("SELECT * FROM weatherdata WHERE Id = @Id", SqlCon());
            GetElementById.Parameters.AddWithValue("@Id", Int32.Parse(id));

            SqlDataReader reader = GetElementById.ExecuteReader();
            SqlCon().Close();

            return TemperatureUtils.ObjectCreator(reader);
        }
    }
}