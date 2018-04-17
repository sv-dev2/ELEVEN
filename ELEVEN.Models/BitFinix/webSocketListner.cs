using ELEVEN.Model;
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
        public string currency { get; set; }
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
        public DateTime MTS { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Volume { get; set; }
    }
    public class CandleDataMT : BaseModel
    {
        private DateTime _mts { get; set; }
        private double _open { get; set; }
        private double _close { get; set; }
        private double _high { get; set; }
        private double _low { get; set; }
        private double _volume { get; set; }

        public string Symbol { get; set; }
        public DateTime MTS { get { ConfirmOnUIThread(); return _mts; } set { ConfirmOnUIThread(); if (_mts != value) { _mts = value; Notify("MTS"); } } }
        public double Open { get { ConfirmOnUIThread(); return _open; } set { ConfirmOnUIThread(); if (_open != value) { _open = value; Notify("Open"); } } }
        public double Close { get { ConfirmOnUIThread(); return _close; } set { ConfirmOnUIThread(); if (_close != value) { _close = value; Notify("MTS"); } } }
        public double High { get { ConfirmOnUIThread(); return _high; } set { ConfirmOnUIThread(); if (_high != value) { _high = value; Notify("MTS"); } } }
        public double Low { get { ConfirmOnUIThread(); return _low; } set { ConfirmOnUIThread(); if (_low != value) { _low = value; Notify("MTS"); } } }
        public double Volume { get { ConfirmOnUIThread(); return _volume; } set { ConfirmOnUIThread(); if (_volume != value) { _volume = value; Notify("MTS"); } } }


    }
}
