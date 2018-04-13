using ELEVEN.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NQuotes;


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
            // BitfinexAPI pbBitfinexAPI = new BitfinexAPI();
            //pbBitfinexAPI.GetMarginInformation();
            //pbBitfinexAPI.ExecuteBuyOrderBTC("ltcusd", 0.3M, 10, Models.OrderExchange.Bitfinex, Models.OrderType.ExchangeMarket);
            //CommandQueue commandQueue = new CommandQueue();
            //CommandResultQueue commandResultQueue = new CommandResultQueue();

            //MqlApi mqlApi = new MqlApi(commandQueue, commandResultQueue);
            //var sadsa=mqlApi.Ask;
            Application.Run(new MDIParentForm());
            
        }
    }
}
