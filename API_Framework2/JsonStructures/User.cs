using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Framework2.JsonStructures
{
    public class User
    {
        public class Status
        {
            public bool error { get; set; }
            public int code { get; set; }
            public string type { get; set; }
            public string message { get; set; }

        }
        public class Data //This is the jSON data
        {
            public string domain { get; set; }
            public string email { get; set; }
            public string alias { get; set; }
            public string username { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public Int64 user_id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string role_name { get; set; }
            public Int64 role_id { get; set; }
            public string company { get; set; }
            public string message { get; set; }
        }
    }
}
