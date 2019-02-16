using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Framework2.JsonStructures
{
    public class LoginSessionToken
    {
        public class Status
        {
            public bool error { get; set; }
            public int code { get; set; }
            public string type { get; set; }
            public string message { get; set; }
        }
        public class Data
        {
            public string status { get; set; }
            public string session_token { get; set; }
            public string expires_at { get; set; }
            public class User
            {
                public string username { get; set; }
                public string email { get; set; }
                public string firstname { get; set; }
                public int id { get; set; }
                public string lastname { get; set; }

            }

        }
    }
}
