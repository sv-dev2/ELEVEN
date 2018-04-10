using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Model
{
    public class FinexTicker : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _mid;
        private string _bid;
        private string _ask;
        private string _last_price;
        private string _low;
        private string _high;
        private string _volume;
        private string _timestamp;
        private string _pair;
        private string _broker;
        public string mid
        {
            get
            {
                return _mid;
            }

            set
            {
                if (value != this._mid)
                {
                    this._mid = value;
                    //NotifyPropertyChanged("mid");
                }
            }
        }
        public string bid
        {
            get
            {
                return _bid;
            }

            set
            {
                if (value != this._bid)
                {
                    this._bid = value;
                    NotifyPropertyChanged("bid");
                }
            }
        }
        public string ask
        {
            get
            {
                return _ask;
            }

            set
            {
                if (value != this._ask)
                {
                    this._ask = value;
                    NotifyPropertyChanged("ask");
                }
            }
        }
        public string last_price
        {
            get
            {
                return _last_price;
            }

            set
            {
                if (value != this._last_price)
                {
                    this._last_price = value;
                    NotifyPropertyChanged("last_price");
                }
            }
        }
        public string low
        {
            get
            {
                return _low;
            }

            set
            {
                if (value != this._low)
                {
                    this._low = value;
                   // NotifyPropertyChanged("low");
                }
            }
        }
        public string high
        {
            get
            {
                return _high;
            }

            set
            {
                if (value != this._high)
                {
                    this._high = value;
                    //NotifyPropertyChanged("high");
                }
            }
        }
        public string volume
        {
            get
            {
                return _volume;
            }

            set
            {
                if (value != this._volume)
                {
                    this._volume = value;
                    NotifyPropertyChanged("volume");
                }
            }
        }
        public string timestamp
        {
            get
            {
                return _timestamp;
            }

            set
            {
                if (value != this._timestamp)
                {
                    this._timestamp = value;
                   // NotifyPropertyChanged("timestamp");
                }
            }
        }
        public string pair
        {
            get
            {
                return _pair;
            }

            set
            {
                if (value != this._pair)
                {
                    this._pair = value;
                    //NotifyPropertyChanged("pair");
                }
            }
        }
        public string broker
        {
            get
            {
                return _broker;
            }

            set
            {
                if (value != this._broker)
                {
                    this._broker = value;
                    //NotifyPropertyChanged("mid");
                }
            }
        }
    }
    public class OldData
    {

        public string mid { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string last_price { get; set; }
        public string low { get; set; }
        public string high { get; set; }
        public string volume { get; set; }
        public string timestamp { get; set; }
        public string pair { get; set; }
        public string broker { get; set; }
    }

    public class FinexStats
    {
        public int period { get; set; }
        public string volume { get; set; }
    }

    public class Symbols
    {
        public string Symbol { get; set; }
    }
}
