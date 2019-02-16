using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.VisualStudio.TestAdapter;
using NUnit.Framework;

namespace API_Automation_Framework
{
    [TestFixture]
    public class Gmail
    {
        [Test]
        public static void GmailGET()
        {
            RestClient restClient = new RestClient();
            restClient.BaseHost = "googleapis.com";
            restClient.BaseUrl = new Uri("https://www.googleapis.com");


            RestRequest restRequest = new RestRequest("/gmail/v1/users/rupesharyan250@gmail.com/profile", Method.GET);
            restRequest.AddQueryParameter("access_token", "Jkqy2EUMlv457xh9Zcmy5EcX");
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse restResponse = restClient.Execute(restRequest);

            Console.WriteLine("\n restClient.BaseHost = " + restClient.BaseHost + "\n");
            Console.WriteLine("\n restClient.BaseUrl = " + restClient.BaseUrl + "\n");

            Console.WriteLine("\n restRequest.Resource = " + restRequest.Resource + "\n");

            foreach (Parameter p in restRequest.Parameters)
            {
                Console.WriteLine("\n restRequest.Parameters = " + restRequest.Parameters + "\n");
            }

            Console.WriteLine("\n restRequest.RequestFormat = " + restRequest.RequestFormat + "\n");
            Console.WriteLine("\n restResponse.Content = \n" + restResponse.Content + "\n");
            Console.WriteLine("\n restResponse.Server = " + restResponse.Server + "\n");
            Console.WriteLine("\n restResponse.ResponseUri = " + restResponse.ResponseUri + "\n");
            Console.WriteLine("\n restResponse.StatusCode = " + restResponse.StatusCode + "\n");
            Console.WriteLine("\n restResponse.StatusDescription = " + restResponse.StatusDescription + "\n");
            Console.WriteLine("\n restResponse.ResponseStatus = " + restResponse.ResponseStatus + "\n");
        }
    }
}
