﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class PubTicker
    {
        public string mid { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string last_price { get; set; }
        public string low { get; set; }
        public string high { get; set; }
        public string volume { get; set; }
        public string timestamp { get; set; }
    }
}
