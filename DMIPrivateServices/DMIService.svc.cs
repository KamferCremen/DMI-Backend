using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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

        public HttpStatusCode AddTemperature(TemperatureData temperature)
        {
            SqlCommand InsertTemperature =
                new SqlCommand(
                    "insert into weatherdata(Temperature, CaptureTime) values (@Temperature, @CaptureTime)",
                    DatabaseService.SqlCon());

            InsertTemperature.Parameters.AddWithValue("@Temperature", temperature.Temperature);
            InsertTemperature.Parameters.AddWithValue("@CaptureTime", TemperatureUtils.Timestamp());

            if (InsertTemperature.ExecuteNonQuery() != 0)
            {
                DatabaseService.SqlCon().Close();
                return HttpStatusCode.Created;
            }

            DatabaseService.SqlCon().Close();
            return HttpStatusCode.BadRequest;
        }

        public TemperatureData EditTemperature(string id, TemperatureData temperature)
        {
            SqlCommand UpdateTemperature =
                new SqlCommand(
                    "update weatherdata set Temperature = @Temperature where Id = @Id", DatabaseService.SqlCon());
            UpdateTemperature.Parameters.AddWithValue("@Temperature", temperature.Temperature);
            UpdateTemperature.Parameters.AddWithValue("@Id", Int32.Parse(id));
    
            UpdateTemperature.ExecuteNonQuery();
            DatabaseService.SqlCon().Close();

            return DatabaseService.GetByObjectId(id);
        }

        public HttpStatusCode RemoveTemperature(string id)
        {
            SqlCommand DeleteTemperature =
                new SqlCommand(
                    "delete from weatherdata where Id = @Id", DatabaseService.SqlCon());
            DeleteTemperature.Parameters.AddWithValue("@Id", Int32.Parse(id));

            DeleteTemperature.ExecuteNonQuery();
            DatabaseService.SqlCon().Close();

            return HttpStatusCode.OK;
        }

        public double LiveTemperature()
        {
            return Model.LiveTemperature.Instance.LiveTemp;
        }

        public HttpStatusCode AddLiveTemperature(string temperature)
        {
            if (Double.TryParse(temperature, out double result))
                Model.LiveTemperature.Instance.LiveTemp = result;
            else
                return HttpStatusCode.BadRequest;

            return HttpStatusCode.OK;
        }

        public List<TemperatureData> DateTimeTemperatures(string datetimestart, string datetimeend)
        {
            SqlCommand GetAllElementBetweenDates = new SqlCommand("SELECT * FROM weatherdata" +
            $" WHERE CaptureTime BETWEEN CONVERT(datetime, '{datetimestart}', 105) AND CONVERT(datetime, '{datetimeend}', 105)",
                                                                  DatabaseService.SqlCon());
            SqlDataReader reader = GetAllElementBetweenDates.ExecuteReader();
            DatabaseService.SqlCon().Close();

            return TemperatureUtils.ListCreator(reader);
        }
    }
}
