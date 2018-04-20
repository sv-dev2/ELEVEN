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

        public void ReadWriteNotepad(string symbol, string name, WebSocket4Net.WebSocket webSocket)
        {
            string symbols = string.Empty;
            using (var streamReader = new StreamReader(name + ".txt"))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            //check Index
            int Index = symbols.IndexOf(symbol);
            if (Index == 0)
            {
                symbols = symbols.Replace(symbol + ",", "");
                symbols = symbols.Replace(symbol, "");
            }
            else
            {
                symbols = symbols.Replace("," + symbol, "");
            }

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(name + ".txt", false))
            {
                file.Write(symbols);
                file.Close();
            }
            webSocket.Close();

        }
        
    }
}
