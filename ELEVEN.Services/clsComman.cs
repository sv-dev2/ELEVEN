using ELEVEN.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Services
{
    public class clsComman
    {
        public void Seprateticklers(string symbols, ref StringBuilder sbBitfinex, ref StringBuilder sbTraders, ref StringBuilder sbIGMarket, ref StringBuilder sbICMarket)
        {
            sbBitfinex.Clear();
            sbTraders.Clear();
            sbIGMarket.Clear();
            sbICMarket.Clear();
            var allTicklers = symbols.Split(',');
            foreach (string tickler in allTicklers)
            {
                if (tickler.ToLower().IndexOf(Broker.BitFinex.ToString().ToLower()) > -1)
                {
                    var instrumentCode = tickler.Split('.');
                    if (sbBitfinex.Length > 1)
                    {
                        sbBitfinex.Append(",");
                    }
                    if (instrumentCode[1].Length > 4)
                    {
                        sbBitfinex.Append("t" + instrumentCode[1].ToUpper());//t and upper is appended/use only for bitfinex as per bitfinex API documentation
                    }
                    else
                    {
                        sbBitfinex.Append("f" + instrumentCode[1].ToUpper());//t and upper is appended/use only for bitfinex as per bitfinex API documentation
                    }


                }
                else if (tickler.IndexOf("MT") > -1)
                {
                    var instrumentCode = tickler.Split('.');
                    if (sbTraders.Length > 1)
                    {
                        sbTraders.Append(",");
                    }
                    sbTraders.Append(instrumentCode[1]);
                }
                else if (tickler.ToLower().Replace(" ", "").IndexOf(Broker.IGMarket.ToString().ToLower()) > -1)
                {
                    var instrumentCode = tickler.Split('.');
                    if (sbIGMarket.Length > 1)
                    {
                        sbIGMarket.Append(",");
                    }
                    sbIGMarket.Append(instrumentCode[1]);
                }
                else if (tickler.ToLower().Replace(" ", "").IndexOf(Broker.ICMarket.ToString().ToLower()) > -1)
                {
                    var instrumentCode = tickler.Split('.');
                    if (sbICMarket.Length > 1)
                    {
                        sbICMarket.Append(",");
                    }
                    sbICMarket.Append(instrumentCode[1]);
                }
            }
        }


        public static List<BitTimeframe> GetBitTimeFrame()
        {
            var timeFrame = new List<BitTimeframe>() {
                                new BitTimeframe {Text="one minute",Value="1m" },
                                new BitTimeframe {Text="five minutes",Value="5m" },
                                new BitTimeframe {Text="15 minutes",Value="15m" },
                                new BitTimeframe {Text="30 minutes",Value="30m" },
                                new BitTimeframe {Text="one hour",Value="1h" },
                                new BitTimeframe {Text="3 hours",Value="3h" },
                                new BitTimeframe {Text="6 hours",Value="6h" },
                                new BitTimeframe {Text="12 hours",Value="12h" },
                                new BitTimeframe {Text="one day",Value="1D" },
                                new BitTimeframe {Text="one week",Value="7D" },
                                new BitTimeframe {Text="two weeks",Value="14D" },
                                new BitTimeframe {Text="one month",Value="1M" }
            };
            return timeFrame;
        }
    }
}
