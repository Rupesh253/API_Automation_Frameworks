﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Framework2.JsonStructures
{
    public class Tokens
    {
        public string access_token { get; set; }
        public string created_at { get; set; }
        public string refresh_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }

    }
}
