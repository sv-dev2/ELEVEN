using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class webSocketListner
    {
        public string _event { get; set; }
        public string channel { get; set; }
        public string symbol { get; set; }
    }
    public class Subscribe
    {
        public string @event { get; set; }
        public string channel { get; set; }
        public int chanId { get; set; }
        public string pair { get; set; }
    }
    public class webCandleListner
    {
        public string _event { get; set; }
        public string channel { get; set; }
        public string key { get; set; }
    }
    public class webCandleResponse
    {
        public string @event { get; set; }
        public string channel { get; set; }
        public int chanId { get; set; }
        public string key { get; set; }
    }
    public class CandleData
    {
        public Int64 MTS { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Volume { get; set; }
    }
}
