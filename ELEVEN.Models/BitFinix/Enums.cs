using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public enum Broker { BitFinex, IGMarket, ICMarket, ActiveTraders }
    public enum OrderExchange
    {
        Bitfinex,
        Bitstamp,
        All
    }
    public enum OrderType
    {
        MarginMarket,
        MarginLimit,
        MarginStop,
        MarginTrailingStop,
        ExchangeMarket
    }
    public enum OrderSide
    {
        Buy,
        Sell
    }
    public enum OrderSymbol
    {
        BTCUSD
    }
}
