using ELEVEN.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ELEVEN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //BitfinexAPI pbBitfinexAPI = new BitfinexAPI();
           //pbBitfinexAPI.GetBalances();
            //pbBitfinexAPI.ExecuteBuyOrderBTC("ltcusd", 0.3M, 10, Models.OrderExchange.Bitfinex, Models.OrderType.ExchangeMarket);
            Application.Run(new MDIParentForm());
            
        }
    }
}
