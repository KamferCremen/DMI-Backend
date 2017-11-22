using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using DMIPrivateServices.Model;

namespace DMIPrivateServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DMIService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DMIService.svc or DMIService.svc.cs at the Solution Explorer and start debugging.

    public class DMIService : IDMIService
    {
        public List<TemperatureData> AllTemperatures()
        {
            SqlCommand GetAllElements = new SqlCommand("SELECT * FROM weatherdata", DatabaseService.SqlCon());
            SqlDataReader reader = GetAllElements.ExecuteReader();
            DatabaseService.SqlCon().Close();

            return TemperatureUtils.ListCreator(reader);
        }

        public HttpStatusCode AddTemperature(String temperature)
        {
            SqlCommand InsertTemperature =
                new SqlCommand(
                    $"insert into weatherdata(Temperature, CaptureTime) values (@Temperature, @CaptureTime)",
                    DatabaseService.SqlCon());

            InsertTemperature.Parameters.AddWithValue("@Temperature", double.Parse(temperature));
            InsertTemperature.Parameters.AddWithValue("@CaptureTime", TemperatureUtils.Timestamp());


            if (InsertTemperature.ExecuteNonQuery() != 0)
            {
                DatabaseService.SqlCon().Close();
                return HttpStatusCode.Created;
            }

            DatabaseService.SqlCon().Close();
            return HttpStatusCode.BadRequest;
        }

        public float LiveTemperature()
        {
            //To be continued
            return 0;
        }

    }
}
