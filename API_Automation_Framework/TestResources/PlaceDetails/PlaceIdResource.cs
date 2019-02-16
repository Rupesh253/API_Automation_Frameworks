using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RestSharp;
using API_Automation_Framework.TestAuxiliaries;
using static API_Automation_Framework.TestAuxiliaries.Helpers.JSON;

namespace API_Automation_Framework.TestResources.PlaceDetails
{
    class PlaceIdResource
    {
        string placeIdResource = ConfigurationManager.AppSettings["PlaceIdResource"];
        string placeId_P_PIdR = ConfigurationManager.AppSettings["PlaceId_P_PIdR"];

        public string GetAccessToken(RestClient restClient)
        {
            string apiKey = ConfigurationManager.AppSettings["APIKey_PlaceDetails"];
            return apiKey;
        }

        public void PlaceId(RestClient restClient, string apiKey)
        {
            RestRequest restRequest = new RestRequest();
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.Resource = placeIdResource;
            restRequest.AddQueryParameter("placeid", placeId_P_PIdR);
            restRequest.AddQueryParameter("key", apiKey);
            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine("It's from PlaceIdResource:PlaceId()");
            Console.WriteLine("===================================");
            Console.WriteLine("IsSuccessful= " + restResponse.IsSuccessful);
            Console.WriteLine("StatusCode= " + restResponse.StatusCode);
            Console.WriteLine("StatusDescription= " + restResponse.StatusDescription);
            Console.WriteLine("ResponseStatus= " + restResponse.ResponseStatus);
            Console.WriteLine("Content= \n" + restResponse.Content);
            new Helpers.JSON().Generate(restResponse.Content,"PlaceId");
        }


    }
}
