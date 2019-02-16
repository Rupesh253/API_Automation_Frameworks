using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using API_Framework2.JsonStructures;
using System.IO;
using log4net;
using RestSharp;
using System.Configuration;
using Newtonsoft.Json;

namespace API_Framework2.TestAuxiliaries
{

    public class A : LoginSessionToken
    {
        public class B : LoginSessionToken.Data
        {
            public class C : LoginSessionToken.Status
            {
                public class D : Roles.Data
                {
                    public class E : Roles.Status
                    {
                        public class F : Status
                        {
                            public class G : JsonStructures.User.Data
                            {
                                public class H : JsonStructures.User.Status
                                {

                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public class Helpers : A
    {
        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string GetAccessToken()
        {
            string clientId = ConfigurationSettings.AppSettings["client_id"].ToString();
            string clientSecret = ConfigurationSettings.AppSettings["client_secret"].ToString();
            string baseHost = ConfigurationSettings.AppSettings["baseHost"].ToString();
            string baseUrl = ConfigurationSettings.AppSettings["baseUrl"].ToString();
            string accessToken = null;
            string refreshToken = null;
            string baseDirectoy = AppDomain.CurrentDomain.BaseDirectory;
            string temp = baseDirectoy.Replace("bin", "TestData").Replace("Debug\\", "");
            string filePath = temp + "RequestBodyForGettingTokens.json";
            Tokens tokens = new Tokens();


            try
            {
                RestClient client = new RestClient();
                client.BaseHost = baseHost;
                client.BaseUrl = new Uri(baseUrl);

                RestRequest request = new RestRequest();
                request.Resource = "/auth/oauth2/v2/token";
                request.RequestFormat = DataFormat.Json;
                request.Method = Method.POST;
                request.AddHeader("Authorization", $"Basic <base64 encoded {clientId}: {clientSecret}>");
                request.AddJsonBody("Send the body here RequestBodyForGettingTokens");

                IRestResponse restResponse = client.Execute(request);
                tokens = JsonConvert.DeserializeObject<Tokens>(restResponse.Content);
                accessToken = tokens.access_token;
                refreshToken = tokens.refresh_token;
            }
            catch (Exception ex)
            {

            }
            return (string.IsNullOrEmpty(accessToken)) ? null : accessToken;
        }
        public class Validations
        {
            private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            public Status status { get; set; }
            public LoginSessionToken loginSessionToken { get; set; }
            public LoginSessionToken.Data loginSessionTokenData { get; set; }
            public LoginSessionToken.Status loginSessionTokenStatus { get; set; }
            public Roles roles { get; set; }
            public Roles.Data rolesData { get; set; }
            public Roles.Status rolesStatus { get; set; }
            public User user { get; set; }
            public User.Data userData { get; set; }
            public User.Status userStatus { get; set; }
            public Validations(Status status = null,
                LoginSessionToken loginSessionToken = null, LoginSessionToken.Data loginSessionTokenData = null, LoginSessionToken.Status loginSessionTokenStatus = null,
                Roles roles = null, Roles.Data rolesData = null, Roles.Status rolesStatus = null,
                User user = null, User.Data userData = null, User.Status userStatus = null)
            {
                this.status = status;
                this.loginSessionToken = loginSessionToken;
                this.loginSessionTokenData = loginSessionTokenData;
                this.loginSessionTokenStatus = loginSessionTokenStatus;
                this.roles = roles;
                this.rolesData = rolesData;
                this.rolesStatus = rolesStatus;
                this.user = user;
                this.userData = userData;
                this.userStatus = userStatus;
            }
            public void StatusValidations(int responseCode)
            {
                switch (responseCode)
                {
                    case 200:
                        int actualCode200 = status.code;
                        bool actualError200 = status.error;
                        string actualType200 = status.type;
                        string actualMessage200 = status.message;

                        Assert.AreEqual("200", actualCode200, $"Status code is mismatch");
                        Assert.IsFalse(actualError200, $"Status error is mismatch");
                        Assert.AreEqual("success", actualType200, $"Status type is mismatch");
                        Assert.AreEqual("Success", actualMessage200, $"Status message is mismatch");
                        break;

                    case 400:
                        int actualCode400 = status.code;
                        bool actualError400 = status.error;
                        string actualType400 = status.type;
                        string actualMessage400 = status.message;

                        Assert.AreEqual("400", actualCode400, $"Status code is mismatch");
                        Assert.IsTrue(actualError400, $"Status error is mismatch");
                        Assert.AreEqual("bad request", actualType400, $"Status type is mismatch");
                        Assert.AreEqual("Authorization Information is incorrect", actualMessage400, $"Status message is mismatch");
                        break;

                    case 401:
                        int actualCode401 = status.code;
                        bool actualError401 = status.error;
                        string actualType401 = status.type;
                        string actualMessage401 = status.message;

                        Assert.AreEqual("401", actualCode401, $"Status code is mismatch");
                        Assert.IsTrue(actualError401, $"Status error is mismatch");
                        Assert.AreEqual("Unauthorized", actualType401, $"Status type is mismatch");
                        Assert.AreEqual("Authentication Failure", actualMessage401, $"Status message is mismatch");
                        break;

                    case 403:
                        int actualCode403 = status.code;
                        bool actualError403 = status.error;
                        string actualType403 = status.type;
                        string actualMessage403 = status.message;

                        Assert.AreEqual("403", actualCode403, $"Status code is mismatch");
                        Assert.IsTrue(actualError403, $"Status error is mismatch");
                        Assert.AreEqual("forbidden", actualType403, $"Status type is mismatch");
                        Assert.AreEqual("user is not authorized to access this User", actualMessage403, $"Status message is mismatch");
                        break;

                    case 404:
                        int actualCode404 = status.code;
                        bool actualError404 = status.error;
                        string actualType404 = status.type;
                        string actualMessage404 = status.message;

                        Assert.AreEqual("404", actualCode404, $"Status code is mismatch");
                        Assert.IsTrue(actualError404, $"Status error is mismatch");
                        Assert.AreEqual("not found", actualType404, $"Status type is mismatch");
                        Assert.AreEqual($"User for id {userData.user_id} was not found", actualMessage404, $"Status message is mismatch");
                        break;

                    default:
                        break;

                }
            }
        }
    }
}
