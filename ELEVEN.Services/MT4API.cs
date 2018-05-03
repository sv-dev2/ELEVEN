using ELEVEN.Model;
using ELEVEN.Models;
using MtApi;
using MtApi.Monitors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Services
{
    public class MT4API : IDisposable, IToggleGateway
    {
        #region "MetaTrader Objects"
        MtApiClient apiClient = null;

        public bool IsConnected { get; private set; }
        private readonly TimeframeTradeMonitor _timeframeTradeMonitor;
        private readonly TimerTradeMonitor _timerTradeMonitor;
        private dynamic frmMarketWatch;
        List<MT4WatchList> watchListForms = new List<MT4WatchList>();
        #endregion
        #region "Properties"
        /// <summary>
        /// Gets or sets the gateway parameters.
        /// </summary>
        /// <value>
        /// The gateway parameters.
        /// </value>
        public Gateway Gateway
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the gateway parameters.
        /// </summary>
        /// <value>
        /// The gateway parameters.
        /// </value>
        public GatewayParameters GatewayParameters
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the type of the gateway.
        /// </summary>
        /// <value>
        /// The type of the gateway.
        /// </value>
        public ConstEnum.GatewayType GatewayType
        {
            get;
            set;
        }
        #endregion


        public MT4API(Gateway gateway, GatewayParameters gatewayParameters)
        {
            Gateway = gateway;
            GatewayParameters = gatewayParameters;
        }
        private static MT4API instance = new MT4API();
        // gets the instance of the singleton object
        public static MT4API Instance
        {
            get { return instance; }
            set { instance = value; }
        }
        private MT4API()
        {
            apiClient = new MtApiClient();
            // apiClient.QuoteUpdated += ApiClient_QuoteUpdated;
            apiClient.QuoteUpdate += ApiClient_QuoteUpdate;
            apiClient.ConnectionStateChanged += ApiClient_ConnectionStateChanged;

            _timerTradeMonitor = new TimerTradeMonitor(apiClient) { Interval = 10000 }; // 10 sec
            _timerTradeMonitor.AvailabilityOrdersChanged += _tradeMonitor_AvailabilityOrdersChanged;

            _timeframeTradeMonitor = new TimeframeTradeMonitor(apiClient);
            _timeframeTradeMonitor.AvailabilityOrdersChanged += _tradeMonitor_AvailabilityOrdersChanged;


            //Connect to MT
            _timerTradeMonitor.Start();
            _timeframeTradeMonitor.Start();
            apiClient.BeginConnect(8222);
        }
        public void Init(dynamic frmMarketWatch, string symbol)
        {
            #region "Connect to MetaTrader Server"  
            //this.frmMarketWatch = frmMarketWatch;
            watchListForms.Add(new MT4WatchList { form = frmMarketWatch, symbol = symbol });
            #endregion
        }

        #region "MT4 methods"
        private void ApiClient_ConnectionStateChanged(object sender, MtConnectionEventArgs e)
        {
            switch (e.Status)
            {
                case MtConnectionState.Connected:
                    IsConnected = true;
                    break;
                case MtConnectionState.Disconnected:
                case MtConnectionState.Failed:
                    IsConnected = false;
                    break;
            }
        }

        private void ApiClient_QuoteUpdate(object sender, MtQuoteEventArgs e)
        {
            Console.WriteLine("Symbom:" + e.Quote.Instrument + " -Bid= " + e.Quote.Bid.ToString() + " -Ask = " + e.Quote.Ask.ToString());
            try
            {
                UpdateWatchList(e.Quote);

            }
            catch (Exception)
            {


            }


        }
        private void UpdateWatchList(MtQuote quote)
        {
            //check if Form is watchlist
            var forms = watchListForms.Where(m => m.symbol.Split(',').Contains(quote.Instrument)).ToList();
            foreach (var item in forms)
            {
                frmMarketWatch = item.form;
                var watchList = frmMarketWatch.ObjTrading as BindingList<FinexTicker>;
                var watch = watchList.Where(m => m.pair == Broker.MT.ToString() + "." + quote.Instrument).FirstOrDefault();
                if (watch != null)
                {
                    bool bidBlue = true;
                    bool askBlue = true;
                    int index = watchList.IndexOf(watch);
                    if (Convert.ToDecimal(quote.Bid) > Convert.ToDecimal(watch.bid))
                    {
                        frmMarketWatch.dataGridMarketData.Rows[index].Cells[1].Style.ForeColor = Color.Blue;
                    }
                    else
                    {
                        frmMarketWatch.dataGridMarketData.Rows[index].Cells[1].Style.ForeColor = Color.Red;
                        bidBlue = false;
                    }
                    if (Convert.ToDecimal(quote.Ask) > Convert.ToDecimal(watch.ask))
                    {
                        frmMarketWatch.dataGridMarketData.Rows[index].Cells[2].Style.ForeColor = Color.Blue;
                    }
                    else
                    {
                        frmMarketWatch.dataGridMarketData.Rows[index].Cells[2].Style.ForeColor = Color.Red;
                        askBlue = false;
                    }
                    if (!bidBlue || !askBlue)
                    {
                        ((TextAndImageCell)frmMarketWatch.dataGridMarketData.Rows[index].Cells[0]).Image = frmMarketWatch.imgList.Images[0];
                    }
                    else
                    {
                        ((TextAndImageCell)frmMarketWatch.dataGridMarketData.Rows[index].Cells[0]).Image = frmMarketWatch.imgList.Images[1];
                    }
                    watch.ask = quote.Ask.ToString();
                    watch.bid = quote.Bid.ToString();
                }
            }
        

        }



        public List<MtQuote> GetQuotes()
        {
            System.Threading.Thread.Sleep(1000);//Mt server take time to connect
            return apiClient.GetQuotes();
        }
        private void _tradeMonitor_AvailabilityOrdersChanged(object sender, AvailabilityOrdersEventArgs e)
        {
            if (e.Opened != null)
            {

            }

            if (e.Closed != null)
            {

            }
        }




        public void Dispose()
        {
            //_timerTradeMonitor.Stop();
            //_timeframeTradeMonitor.Stop();
            apiClient.BeginDisconnect();
        }

        public void StartGateway()
        {
            apiClient.BeginConnect(8222);
        }

        public void StopGateway()
        {
            apiClient.BeginDisconnect();
        }
        #endregion
    }
    public class MT4WatchList
    {
        public MT4WatchList()
        {

        }

        public dynamic form { get; set; }
        public string symbol { get; set; }
    }
}
