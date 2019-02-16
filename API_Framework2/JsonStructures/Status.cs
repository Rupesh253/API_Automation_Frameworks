using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Framework2.JsonStructures
{
    public class Status
    {
        public bool error { get; set; }
        public int code { get; set; }
        public string type { get; set; }
        public string message { get; set; }

    }
}
