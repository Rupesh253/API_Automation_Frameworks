using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Framework2.JsonStructures
{
    public class Roles
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
            public string role_name { get; set; }
            public Int64 role_id { get; set; }
        }
    }
}
