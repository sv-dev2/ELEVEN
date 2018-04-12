using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class OrderWindow
    {      

        public static List<ComboProperty> GetSide()
        {
            return new List<ComboProperty> { new ComboProperty { Id = 1, Value = "Buy" },new ComboProperty {Id=2,Value="Sell" } };
        }
        public static List<ComboProperty> GetOrderType()
        {
            return new List<ComboProperty> { new ComboProperty { Id = 1, Value = "market" }, new ComboProperty { Id = 2, Value = "Limit" }, new ComboProperty { Id = 3, Value = "Stop" }
            , new ComboProperty { Id = 4, Value = "Trailing-Stop" }, new ComboProperty { Id = 5, Value = "Exchange Market" } };
        }
        public static List<ComboProperty> GetExchange()
        {
            return new List<ComboProperty> { new ComboProperty { Id = 1, Value = "Bitfinex" }, new ComboProperty { Id = 2, Value = "Bitstamp" }, new ComboProperty { Id = 3, Value = "All" } };
        }
    }

    public class ComboProperty
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
