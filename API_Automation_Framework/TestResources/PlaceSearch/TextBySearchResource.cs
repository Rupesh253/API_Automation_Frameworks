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
    public class TextBySearchResource
    {
        string textSearchResource = ConfigurationManager.AppSettings["TextSearchResource"];
        string query_P_TBSR = ConfigurationManager.AppSettings["Query_P_TBSR"];

        public string GetAccessToken(RestClient restClient)
        {
            string apiKey = ConfigurationManager.AppSettings["APIKey_PlaceSearch"];
            return apiKey;
        }

        public void TextBySearch(RestClient restClient,string apiKey)
        {
            RestRequest restRequest = new RestRequest();
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.Resource = textSearchResource;
            restRequest.AddQueryParameter("query", query_P_TBSR);
            restRequest.AddQueryParameter("key", apiKey);
            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine("It's from TextBySearchResource:TextSearch()");
            Console.WriteLine("===========================================");
            Console.WriteLine("IsSuccessful= " + restResponse.IsSuccessful);
            Console.WriteLine("StatusCode= " + restResponse.StatusCode);
            Console.WriteLine("StatusDescription= " + restResponse.StatusDescription);
            Console.WriteLine("ResponseStatus= " + restResponse.ResponseStatus);
            Console.WriteLine("Content= \n" + restResponse.Content);
        }

    }
}
