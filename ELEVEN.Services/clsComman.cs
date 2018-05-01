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


        public static List<ClsTimeframe> GetBitTimeFrame()
        {
            var timeFrame = new List<ClsTimeframe>() {
                                new ClsTimeframe {Text="one minute",Value="1m" },
                                new ClsTimeframe {Text="five minutes",Value="5m" },
                                new ClsTimeframe {Text="15 minutes",Value="15m" },
                                new ClsTimeframe {Text="30 minutes",Value="30m" },
                                new ClsTimeframe {Text="one hour",Value="1h" },
                                new ClsTimeframe {Text="3 hours",Value="3h" },
                                new ClsTimeframe {Text="6 hours",Value="6h" },
                                new ClsTimeframe {Text="12 hours",Value="12h" },
                                new ClsTimeframe {Text="one day",Value="1D" },
                                new ClsTimeframe {Text="one week",Value="7D" },
                                new ClsTimeframe {Text="two weeks",Value="14D" },
                                new ClsTimeframe {Text="one month",Value="1M" }
            };
            return timeFrame;
        }
        public static List<ClsTimeframe> GetMTTimeFrame()
        {
            var timeFrame = new List<ClsTimeframe>() {
                        new ClsTimeframe {Text="CURRENT ",Value="0" },
                        new ClsTimeframe {Text="M1",Value="1" },                      
                        new ClsTimeframe {Text="M5",Value="5" },
                        new ClsTimeframe {Text="M15",Value="15" },
                        new ClsTimeframe {Text="M30",Value="30" },
                        new ClsTimeframe {Text="H1",Value="60" },
                        new ClsTimeframe {Text="H4",Value="240" },
                        new ClsTimeframe {Text="D1",Value="1440" },
                        new ClsTimeframe {Text="W1",Value="10080" },
                        new ClsTimeframe {Text="MN1",Value="43200" },

            };
            return timeFrame;
        }
    }
}
