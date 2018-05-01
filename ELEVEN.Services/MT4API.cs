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
        public BindingList<CandleDataMT> listCandles = null;
        public bool IsConnected { get; private set; }
        private readonly TimeframeTradeMonitor _timeframeTradeMonitor;
        private readonly TimerTradeMonitor _timerTradeMonitor;
        private dynamic frmChart;
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
        public MT4API(dynamic frmChart)
        {
            #region "Connect to MetaTrader Server"            

           
            this.frmChart = frmChart;
            apiClient = new MtApiClient();
            listCandles = new BindingList<CandleDataMT>();
            // apiClient.QuoteUpdated += ApiClient_QuoteUpdated;
            apiClient.QuoteUpdate += ApiClient_QuoteUpdate;
            apiClient.ConnectionStateChanged += ApiClient_ConnectionStateChanged;

            _timerTradeMonitor = new TimerTradeMonitor(apiClient) { Interval = 10000 }; // 10 sec
            _timerTradeMonitor.AvailabilityOrdersChanged += _tradeMonitor_AvailabilityOrdersChanged;

            _timeframeTradeMonitor = new TimeframeTradeMonitor(apiClient);
            _timeframeTradeMonitor.AvailabilityOrdersChanged += _tradeMonitor_AvailabilityOrdersChanged;

            apiClient.OnLastTimeBar += apiClient_OnLastTimeBar;
            //Connect to MT
            _timerTradeMonitor.Start();
            _timeframeTradeMonitor.Start();
            apiClient.BeginConnect(8222);
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
                if (listCandles != null && listCandles.Count > 0)
                {
                    var checkCandle = listCandles.Where(m => m.Symbol == e.Quote.Instrument).FirstOrDefault();
                    if (checkCandle != null)
                    {
                        CandleAddition(e.Quote.Instrument);
                    }

                }
            }
            catch (Exception)
            {


            }


        }
        private void UpdateWatchList(MtQuote quote)
        {
            //check if Form is watchlist
            string formType = frmChart.Tag;
            if (formType == "frmMarketWatchWin")
            {
                var watchList = frmChart.ObjTrading as BindingList<FinexTicker>;
                var watch = watchList.Where(m => m.pair == Broker.MT.ToString() + "." + quote.Instrument).FirstOrDefault();
                if (watch != null)
                {
                    bool bidBlue = true;
                    bool askBlue = true;
                    int index = watchList.IndexOf(watch);
                    if (Convert.ToDecimal(quote.Bid) > Convert.ToDecimal(watch.bid))
                    {
                        frmChart.dataGridMarketData.Rows[index].Cells[1].Style.ForeColor = Color.Blue;
                    }
                    else
                    {
                        frmChart.dataGridMarketData.Rows[index].Cells[1].Style.ForeColor = Color.Red;
                        bidBlue = false;
                    }
                    if (Convert.ToDecimal(quote.Ask) > Convert.ToDecimal(watch.ask))
                    {
                        frmChart.dataGridMarketData.Rows[index].Cells[2].Style.ForeColor = Color.Blue;
                    }
                    else
                    {
                        frmChart.dataGridMarketData.Rows[index].Cells[2].Style.ForeColor = Color.Red;
                        askBlue = false;
                    }
                    if (!bidBlue || !askBlue)
                    {
                        ((TextAndImageCell)frmChart.dataGridMarketData.Rows[index].Cells[0]).Image = frmChart.imgList.Images[0];
                    }
                    else
                    {
                        ((TextAndImageCell)frmChart.dataGridMarketData.Rows[index].Cells[0]).Image = frmChart.imgList.Images[1];
                    }
                    watch.ask = quote.Ask.ToString();
                    watch.bid = quote.Bid.ToString();
                }
            }
        }
        private void CandleAddition(string symbol, ENUM_TIMEFRAMES pERIOD_CURRENT = ENUM_TIMEFRAMES.PERIOD_CURRENT)
        {
            var rates = apiClient.CopyRates(symbol, pERIOD_CURRENT, 0, 1);
            if (rates != null)
            {
                foreach (var rate in rates)
                {
                    CandleDataMT candleData = new CandleDataMT();
                    candleData.Symbol = symbol;
                    candleData.Close = rate.Close;
                    candleData.High = rate.High;
                    candleData.Low = rate.Low;
                    candleData.MTS = rate.Time;
                    candleData.Open = rate.Open;
                    candleData.Volume = rate.RealVolume;
                    listCandles.Add(candleData);
                }
                frmChart.Invoke((Action)delegate ()
                {
                    frmChart.chart1.DataSource = null;
                    frmChart.chart1.DataSource = listCandles;

                });
            }
        }
        public BindingList<CandleDataMT> HistoricalCandles(string symbol,string candleTimeFrame)
        {

            System.Threading.Thread.Sleep(1000);//Mt server take time to connect
            if (apiClient.ConnectionState == MtConnectionState.Connected)
            {
                return RequestHistoricalCandles(symbol, GetENUM_TIMEFRAMES(candleTimeFrame));
            }
            return listCandles;

        }
      
        public List<MtQuote> GetQuotes()
        {

            System.Threading.Thread.Sleep(1000);//Mt server take time to connect
            if (apiClient.ConnectionState == MtConnectionState.Connected)
            {

                return apiClient.GetQuotes();
            }

            return new List<MtQuote>();
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
        private void apiClient_OnLastTimeBar(object sender, TimeBarArgs e)
        {
            var checkCandle = listCandles.Where(m => m.Symbol == e.TimeBar.Symbol).FirstOrDefault();
            if (checkCandle != null)
            {
                CandleDataMT candleData = new CandleDataMT();
                candleData.Symbol = e.TimeBar.Symbol;
                candleData.Close = e.TimeBar.Close;
                candleData.High = e.TimeBar.High;
                candleData.Low = e.TimeBar.Low;
                candleData.MTS = e.TimeBar.CloseTime;
                candleData.Open = e.TimeBar.Open;
                listCandles.Add(candleData);

                frmChart.Invoke((Action)delegate ()
                {
                    frmChart.chart1.DataSource = null;
                    frmChart.chart1.DataSource = listCandles;

                });
            }
        }

        private BindingList<CandleDataMT> RequestHistoricalCandles(string symbol, ENUM_TIMEFRAMES pERIOD_CURRENT)
        {
            var rates = apiClient.CopyRates(symbol, pERIOD_CURRENT, DateTime.Now.AddDays(-15), DateTime.Now);
            if (rates != null)
            {
                foreach (var rate in rates)
                {
                    CandleDataMT candleData = new CandleDataMT();
                    candleData.Symbol = symbol;
                    candleData.Close = rate.Close;
                    candleData.High = rate.High;
                    candleData.Low = rate.Low;
                    candleData.MTS = rate.Time;
                    candleData.Open = rate.Open;
                    candleData.Volume = rate.RealVolume;
                    listCandles.Add(candleData);
                }
            }
            return listCandles;
        }
        public ENUM_TIMEFRAMES GetENUM_TIMEFRAMES(string candleTimeFrame)
        {
            switch(candleTimeFrame)
            {
                case "1":
                    return ENUM_TIMEFRAMES.PERIOD_M1;
                case "2":
                    return ENUM_TIMEFRAMES.PERIOD_M2;
                case "3":
                    return ENUM_TIMEFRAMES.PERIOD_M3;
                case "4":
                    return ENUM_TIMEFRAMES.PERIOD_M4;
                case "5":
                    return ENUM_TIMEFRAMES.PERIOD_M5;
                case "15":
                    return ENUM_TIMEFRAMES.PERIOD_M15;
                case "30":
                    return ENUM_TIMEFRAMES.PERIOD_M30;
                case "60":
                    return ENUM_TIMEFRAMES.PERIOD_H1;
                case "240":
                    return ENUM_TIMEFRAMES.PERIOD_H4;
                case "1440":
                    return ENUM_TIMEFRAMES.PERIOD_D1;
                case "10080":
                    return ENUM_TIMEFRAMES.PERIOD_W1;
                case "43200":
                    return ENUM_TIMEFRAMES.PERIOD_MN1;
                default:
                    return ENUM_TIMEFRAMES.PERIOD_CURRENT;
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
}
