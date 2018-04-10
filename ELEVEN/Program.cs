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
            PbBitfinexAPI pbBitfinexAPI = new PbBitfinexAPI();
            //pbBitfinexAPI.GetAccountInfo();
            pbBitfinexAPI.ExecuteBuyOrderBTC("BTCUSD", 0.3M, 1000, Models.OrderExchange.Bitfinex, Models.OrderType.ExchangeMarket);
            Application.Run(new MDIParentForm());
            
        }
    }
}
