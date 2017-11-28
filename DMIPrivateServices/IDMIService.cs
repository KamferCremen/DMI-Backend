using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DMIPrivateServices.Model;

namespace DMIPrivateServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDMIService
    {
        //CRUD
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "temperatures")]
        List<TemperatureData> AllTemperatures();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "temperatures")]
        HttpStatusCode AddTemperature(TemperatureData temperature);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "temperatures/{id}")]
        TemperatureData EditTemperature(String id, TemperatureData temperature);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "temperatures/{Id}")]
        HttpStatusCode RemoveTemperature(String id);

        //Live temperatur
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "temperatures/live")]
        double LiveTemperature();

        //Temperatures between a DateTime interval
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "temperatures/?datestart={datetimestart}&dateend={datetimeend}")]
        List<TemperatureData> DateTimeTemperatures(String datetimestart, String datetimeend);
    }
}
