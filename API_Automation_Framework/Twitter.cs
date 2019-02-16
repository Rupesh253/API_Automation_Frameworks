using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.VisualStudio.TestAdapter;
using NUnit.Framework;
using RestSharp.Authenticators;

namespace API_Automation_Framework
{
    [TestFixture]
    class Twitter
    {
        [Test]
        public static void TwitterPOST()
        {
            string consumerKey = "xxxxxxxxXXXYYYYYYYYZZZZZZZ";
            string consumerSecret = "XXXXXXXXXXXXXXXXXXXXYYYYYYYYYYYYYYZZZZZZ";
            string accessToken = "XXXXXXYYYYYYYZZZZZZZZZZZZ";
            string accessTokenSecret = "XXXXXXXXXXYYYYYYYYYYYYYZZZZZZZZZZZZZZ";


            RestClient restClient = new RestClient();
            restClient.BaseHost = "api.twitter.com";
            restClient.BaseUrl = new Uri("https://api.twitter.com");
            restClient.Authenticator = new OAuth1Authenticator();
            {
                OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret);
                //OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret);
                //OAuth1Authenticator.ForProtectedResource(consumerKey, consumerSecret, accessToken, accessTokenSecret);
                //OAuth1Authenticator.ForClientAuthentication(consumerKey, consumerSecret,"XXXXXXXYYYYYYYZZZZZZZ","XXXXYYYYYYY");

            }
            RestRequest restRequest = new RestRequest();
            restRequest.Resource = "/oauth/request_token";
            restRequest.Method = Method.POST;
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
