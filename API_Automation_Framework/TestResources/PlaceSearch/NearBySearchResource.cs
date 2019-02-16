using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using log4net;
using System.Reflection;
using System.Configuration;
using System.Threading;

namespace API_Automation_Framework.TestResources.PlaceSearch
{
    public class NearBySearchResource
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        string nearbySearchResource = ConfigurationManager.AppSettings["NearbySearchResource"];
        string location_P_NBSR = ConfigurationManager.AppSettings["Location_P_NBSR"];
        string radius_P_NBSR = ConfigurationManager.AppSettings["Radius_P_NBSR"];
        string type_P_NBSR = ConfigurationManager.AppSettings["Type_P_NBSR"];
        string keyword_P_NBSR = ConfigurationManager.AppSettings["Keyword_P_NBSR"];
        //string apiKey = ConfigurationManager.AppSettings["APIKey"];static

        public string GetAccessToken(RestClient restClient)
        {           
            log.Info("Requesting Request Token");
            log.Info("Acquiring Access Token");
            string apiKey = ConfigurationManager.AppSettings["APIKey_PlaceSearch"];
            log.Debug("Acquired Access Token = "+apiKey);
            return apiKey;
        }


        public void NearBySearch(RestClient restClient,string apiKey)
        {

            RestRequest restRequest = new RestRequest();
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.Resource = nearbySearchResource;
            restRequest.AddQueryParameter("location", location_P_NBSR);
            restRequest.AddQueryParameter("radius", radius_P_NBSR);
            restRequest.AddQueryParameter("type", type_P_NBSR);
            restRequest.AddQueryParameter("keyword", keyword_P_NBSR);
            restRequest.AddQueryParameter("key", apiKey);
            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine("It's from NearBySearchResource:NearbySearch()");
            Console.WriteLine("=============================================");
            Console.WriteLine("IsSuccessful= " + restResponse.IsSuccessful);
            Console.WriteLine("StatusCode= " + restResponse.StatusCode);
            Console.WriteLine("StatusDescription= " + restResponse.StatusDescription);
            Console.WriteLine("ResponseStatus= " + restResponse.ResponseStatus);
            Console.WriteLine("Content= \n" + restResponse.Content);

            JObject responseMainObject_NBSR = JObject.Parse(restResponse.Content);
            //JToken statusObject = responseMainObject_NBSR["status"].ToString();
            //Console.WriteLine("statusObject" + statusObject);
            JValue statusValue = (JValue)responseMainObject_NBSR["status"];
            Console.WriteLine("statusValue" + statusValue);
        }

    }
}
