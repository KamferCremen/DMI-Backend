using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DMIPrivateServices.Model;

namespace DMIPrivateServices
{
    public class TemperatureUtils
    {

        public static List<TemperatureData> ListCreator(SqlDataReader reader)
        {
            List<TemperatureData> TemporaryList = new List<TemperatureData>();

            while (reader.Read())
            {
                TemperatureData TemporaryObj = new TemperatureData();

                TemporaryObj.Id = reader.GetInt32(0);
                TemporaryObj.Temperature = reader.GetDouble(1);
                TemporaryObj.CaptureTime = reader.GetDateTime(2);

                TemporaryList.Add(TemporaryObj);
            }

            return TemporaryList;
        }

        public static DateTime Timestamp()
        {
            return DateTime.Now;
        }

    }
}