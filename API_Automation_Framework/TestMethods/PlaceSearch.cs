using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using log4net;
using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using System.Configuration;
using Newtonsoft.Json.Linq;
using API_Automation_Framework.TestResources.PlaceSearch;

namespace API_Automation_Framework.TestMethods
{
    [TestFixture]
    public class PlaceSearch
    {
        string baseHost_PlaceSearch = ConfigurationManager.AppSettings["BaseHost_PlaceSearch"];
        string baseUri_PlaceSearch = ConfigurationManager.AppSettings["BaseUri_PlaceSearch"];

        //string apiKey = ConfigurationManager.AppSettings["APIKey"];

        #region NearbySearchResource_Parameters_Conventional
        //string nearbySearchResource = ConfigurationManager.AppSettings["NearbySearchResource"];
        //string location_P_NBSR = ConfigurationManager.AppSettings["Location_P_NBSR"];
        //string radius_P_NBSR = ConfigurationManager.AppSettings["Radius_P_NBSR"];
        //string type_P_NBSR = ConfigurationManager.AppSettings["Type_P_NBSR"];
        //string keyword_P_NBSR = ConfigurationManager.AppSettings["Keyword_P_NBSR"];
        #endregion

        #region TextSearchResource_Parameters_Conventional
        //string textSearchResource = ConfigurationManager.AppSettings["TextSearchResource"];
        //string query_P_TBSR = ConfigurationManager.AppSettings["Query_P_TBSR"];
        #endregion

        #region RadarSearchResource_Parameters_Conventional
        //string radarSearchResource = ConfigurationManager.AppSettings["RadarSearchResource"];
        //string location_P_RSR = ConfigurationManager.AppSettings["Location_P_RSR"];
        //string radius_P_RSR = ConfigurationManager.AppSettings["Radius_P_RSR"];
        #endregion

        RestClient restClient = new RestClient();

        [SetUp]
        public void SetupForPlaceSearch()
        {
            restClient.BaseHost = baseHost_PlaceSearch;
            restClient.BaseUrl = new Uri(baseUri_PlaceSearch);
            Console.WriteLine("It's from PlaceSearch:SetupForPlaceSearch()");
            Console.WriteLine("===========================================");

        }
        [Test]
        public void NearbySearchMethod()
        {
            Console.WriteLine("NearbySearchMethod() Running");
            Console.WriteLine("****************************");

            NearBySearchResource nearBySearchResource = new NearBySearchResource();
            string accessToken = nearBySearchResource.GetAccessToken(restClient);
            nearBySearchResource.NearBySearch(restClient, accessToken);

            #region NearbySearchMethod_Conventional
            //AIzaSyC_AE7xCmkCY2WR_6Sk9-E699tGJijiax4
            //RestRequest restRequest1 = new RestRequest();
            //restRequest1.RequestFormat = DataFormat.Json;
            //restRequest1.Resource = nearbySearchResource;
            //restRequest1.AddQueryParameter("location", location_P_NBSR);
            //restRequest1.AddQueryParameter("radius", radius_P_NBSR);
            //restRequest1.AddQueryParameter("type", type_P_NBSR);
            //restRequest1.AddQueryParameter("keyword", keyword_P_NBSR);
            //restRequest1.AddQueryParameter("key", apiKey);
            //IRestResponse restResponse1 = restClient.Execute(restRequest1);
            //Console.WriteLine("It's from [Test]:NearbySearchMethod()");
            //Console.WriteLine("==========================");
            //Console.WriteLine("IsSuccessful= " + restResponse1.IsSuccessful);
            //Console.WriteLine("StatusCode= " + restResponse1.StatusCode);
            //Console.WriteLine("StatusDescription= " + restResponse1.StatusDescription);
            //Console.WriteLine("ResponseStatus= " + restResponse1.ResponseStatus);
            //Console.WriteLine("Content= \n" + restResponse1.Content);

            //JObject responseMainObject_NBSR = JObject.Parse(restResponse1.Content);
            ////JToken statusObject = responseMainObject_NBSR["status"].ToString();
            ////Console.WriteLine("statusObject" + statusObject);
            //JValue statusValue = (JValue)responseMainObject_NBSR["status"];
            //Console.WriteLine("statusValue" + statusValue);
            ////return (string)statusValue;
            #endregion
        }

        [Test]
        public void TextSearchMethod()
        {
            Console.WriteLine("TextSearchMethod() Running");
            Console.WriteLine("**************************");

            TextBySearchResource textBySearchResource = new TextBySearchResource();
            string accessToken = textBySearchResource.GetAccessToken(restClient);
            textBySearchResource.TextBySearch(restClient, accessToken);

            #region TextSearchMethod_Conventional
            //RestRequest restRequest2 = new RestRequest();
            //restRequest2.RequestFormat = DataFormat.Json;
            //restRequest2.Resource = textSearchResource;
            //restRequest2.AddQueryParameter("query", query_P_TBSR);
            //restRequest2.AddQueryParameter("key", apiKey);
            //IRestResponse restResponse2 = restClient.Execute(restRequest2);
            //Console.WriteLine("It's from [Test]:TextSearchMethod()");
            //Console.WriteLine("==========================");
            //Console.WriteLine("IsSuccessful= " + restResponse2.IsSuccessful);
            //Console.WriteLine("StatusCode= " + restResponse2.StatusCode);
            //Console.WriteLine("StatusDescription= " + restResponse2.StatusDescription);
            //Console.WriteLine("ResponseStatus= " + restResponse2.ResponseStatus);
            //Console.WriteLine("Content= \n" + restResponse2.Content);
            #endregion
        }
        [Test]
        public void RadarSearchMethod()
        {

            Console.WriteLine("RadarSearchMethod() Running");
            Console.WriteLine("***************************");

            RadarSearchResource radarSearchResource = new RadarSearchResource();
            string accessToken = radarSearchResource.GetAccessToken(restClient);
            radarSearchResource.RadarSearch(restClient, accessToken);

            #region RadarSearchMethod_Conventional
            //AIzaSyC_AE7xCmkCY3WR_6Sk9-E699tGJijiax4
            //RestRequest restRequest3 = new RestRequest();
            //restRequest3.RequestFormat = DataFormat.Json;
            //restRequest3.Resource = radarSearchResource;
            //restRequest3.AddQueryParameter("location", location_P_RSR);
            //restRequest3.AddQueryParameter("radius", radius_P_RSR);
            //restRequest3.AddQueryParameter("key", apiKey);
            //IRestResponse restResponse3 = restClient.Execute(restRequest3);
            //Console.WriteLine("It's from [Test]:RadarSearchMethod()");
            //Console.WriteLine("==========================");
            //Console.WriteLine("IsSuccessful= " + restResponse3.IsSuccessful);
            //Console.WriteLine("StatusCode= " + restResponse3.StatusCode);
            //Console.WriteLine("StatusDescription= " + restResponse3.StatusDescription);
            //Console.WriteLine("ResponseStatus= " + restResponse3.ResponseStatus);
            //Console.WriteLine("Content= \n" + restResponse3.Content);
            #endregion
        }

        [TearDown]
        public void TearDownForPlaceSearch()
        {
            Console.WriteLine("It's from PlaceSearch:TearDownForPlaceSearch()");
            Console.WriteLine("==============================================");
        }

    }
}
