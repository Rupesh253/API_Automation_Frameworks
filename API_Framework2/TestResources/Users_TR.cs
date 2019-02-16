using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RestSharp;
using API_Framework2.TestAuxiliaries;
using API_Framework2.JsonStructures;
using Newtonsoft.Json;

namespace API_Framework2.TestResources
{
    public class Users_TR
    {
        string getUsersResourceUrl = ConfigurationSettings.AppSettings["getUsersResourceUrl"].ToString();
        string baseHost= ConfigurationSettings.AppSettings["baseHost"].ToString();
        string baseUrl = ConfigurationSettings.AppSettings["baseUrl"].ToString();
        string accessToken = new Helpers().GetAccessToken();
        User user = new User();
        User.Data userData = new User.Data();
        User.Status userStatus = new User.Status();
        Helpers helpers = new Helpers();
        Helpers.Validations validations = new Helpers.Validations();
        public void GetUsers()
        {
            RestClient client = new RestClient();
            client.BaseHost = baseHost;
            client.BaseUrl = new Uri(baseUrl);

            RestRequest request = new RestRequest();
            request.Resource = getUsersResourceUrl;
            request.RequestFormat = DataFormat.Json;
            request.Method = Method.POST;
            request.AddHeader("Authorization", $"bearer : {accessToken}");
            request.AddQueryParameter("email","v-rusom");
            request.AddQueryParameter("firstname","Rupesh");
           

            IRestResponse restResponse = client.Execute(request);


            user = JsonConvert.DeserializeObject<User>(restResponse.Content);
            userStatus = JsonConvert.DeserializeObject<User.Status>(restResponse.Content);
            userData = JsonConvert.DeserializeObject<User.Data>(restResponse.Content);

            validations.StatusValidations(Convert.ToInt16(restResponse.StatusCode));
        }


    }

}
