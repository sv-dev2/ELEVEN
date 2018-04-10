using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class NewOrderRequest : GenericRequest
    {
        public string symbol;
        public string amount;
        public string price;
        public string exchange;
        public string side;
        public string type;
        //public bool is_hidden=false;
        public NewOrderRequest(string nonce, string symbol, decimal amount, decimal price, OrderExchange exchange, string side, OrderType type)
        {
            this.symbol = symbol;
            this.amount = amount.ToString(CultureInfo.InvariantCulture);
            this.price = price.ToString(CultureInfo.InvariantCulture);
            this.exchange = EnumHelper.EnumToStr(exchange);
            this.side = side;
            this.type = EnumHelper.EnumToStr(type);
            this.nonce = nonce;
            this.request = "order/new";
        }
    }
    public class EnumHelper
    {
        private static Dictionary<object, string> enumStr = null;
        private static Dictionary<object, string> Get()
        {
            if (enumStr == null)
            {
                enumStr = new Dictionary<object, string>();
                enumStr.Add(OrderSymbol.BTCUSD, "btcusd");

                enumStr.Add(OrderExchange.All, "all");
                enumStr.Add(OrderExchange.Bitfinex, "bitfinex");
                enumStr.Add(OrderExchange.Bitstamp, "bitstamp");

                enumStr.Add(OrderSide.Buy, "buy");
                enumStr.Add(OrderSide.Sell, "sell");

                enumStr.Add(OrderType.MarginLimit, "limit");
                enumStr.Add(OrderType.MarginMarket, "market");
                enumStr.Add(OrderType.MarginStop, "stop");
                enumStr.Add(OrderType.MarginTrailingStop, "trailing-stop");
                enumStr.Add(OrderType.ExchangeMarket, "exchange market");
            }
            return enumStr;
        }

        public static string EnumToStr(object enumItem)
        {
            return Get()[enumItem];
        }
    }
}
