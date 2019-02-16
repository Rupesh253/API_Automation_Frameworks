using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using log4net;
using System.Configuration;

namespace API_Automation_Framework.TestResources.PlaceSearch
{
    public class RadarSearchResource
    {
        string radarSearchResource = ConfigurationManager.AppSettings["RadarSearchResource"];
        string location_P_RSR = ConfigurationManager.AppSettings["Location_P_RSR"];
        string radius_P_RSR = ConfigurationManager.AppSettings["Radius_P_RSR"];

        public string GetAccessToken(RestClient restClient)
        {
            string apiKey = ConfigurationManager.AppSettings["APIKey_PlaceSearch"];
            return apiKey;
        }

        public void RadarSearch(RestClient restClient,string apiKey)
        {
            RestRequest restRequest = new RestRequest();
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.Resource = radarSearchResource;
            restRequest.AddQueryParameter("location", location_P_RSR);
            restRequest.AddQueryParameter("radius", radius_P_RSR);
            restRequest.AddQueryParameter("key", apiKey);
            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine("It's from RadarSearchResource:RadarSearch()");
            Console.WriteLine("===========================================");
            Console.WriteLine("IsSuccessful= " + restResponse.IsSuccessful);
            Console.WriteLine("StatusCode= " + restResponse.StatusCode);
            Console.WriteLine("StatusDescription= " + restResponse.StatusDescription);
            Console.WriteLine("ResponseStatus= " + restResponse.ResponseStatus);
            Console.WriteLine("Content= \n" + restResponse.Content);
        }


    }
}
