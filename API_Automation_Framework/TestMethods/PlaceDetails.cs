using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Automation_Framework.TestMethods;
using NUnit.Framework;
using API_Automation_Framework.TestResources.PlaceDetails;
using RestSharp;
using System.Configuration;
using log4net;
using API_Automation_Framework.TestAuxiliaries;
using static API_Automation_Framework.TestAuxiliaries.Helpers.JSON;



namespace API_Automation_Framework.TestMethods
{
    [TestFixture]
    public class PlaceDetails
    {
        string baseHost_PlaceDetails = ConfigurationManager.AppSettings["BaseHost_PlaceDetails"];
        string baseUri_PlaceDetails = ConfigurationManager.AppSettings["BaseUri_PlaceDetails"];
        private readonly static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        RestClient restClient = new RestClient();
       

        [SetUp]
        public void SetUpForPlaceDetails()
        {
            restClient.BaseHost = baseHost_PlaceDetails;
            restClient.BaseUrl = new Uri(baseUri_PlaceDetails);
            Console.WriteLine("It's from PlaceDetails:[SetUp] SetUpForPlaceDetails()");
            Console.WriteLine("=====================================================");
            log.Info($"SetUpForPlaceDetails(): Rest client setup completed with BaseHost= {restClient.BaseHost} \n BaseUrl={restClient.BaseUrl}");
        }

        [Test]
        public void PlaceIdMethod()
        {
            Console.WriteLine("[Test] PlaceIdMethod() Running");
            Console.WriteLine("***********************");

            PlaceIdResource placeIdResource = new PlaceIdResource();
            string accessToken = placeIdResource.GetAccessToken(restClient);
            placeIdResource.PlaceId(restClient, accessToken);
            
        }


        [TearDown]
        public void TearDownForPlaceDetails()
        {
            Console.WriteLine("It's from PlaceDetails:[TearDown] TearDownForPlaceDetails()");
            Console.WriteLine("================================================");
        }



    }
}
