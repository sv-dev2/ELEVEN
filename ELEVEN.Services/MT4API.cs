using ELEVEN.Models;
using MtApi;
using MtApi.Monitors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Services
{
    public class MT4API : IDisposable
    {
        #region "MetaTrader Objects"
        MtApiClient apiClient = null;
        public BindingList<CandleDataMT> listCandles = null;
        public bool IsConnected { get; private set; }
        private readonly TimeframeTradeMonitor _timeframeTradeMonitor;
        private readonly TimerTradeMonitor _timerTradeMonitor;
        private dynamic frm;
        #endregion
        public MT4API(dynamic frm)
        {
            #region "Connect to MetaTrader Server"            
            apiClient = new MtApiClient();
            listCandles = new BindingList<CandleDataMT>();
            this.frm = frm;
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
        public MT4API()
        {
            #region "Connect to MetaTrader Server"            
            apiClient = new MtApiClient();          
            apiClient.ConnectionStateChanged += ApiClient_ConnectionStateChanged;
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
            Console.WriteLine("Bid= " + e.Quote.Bid.ToString() + " -Ask = " + e.Quote.Ask.ToString());
            if (listCandles != null && listCandles.Count > 0)
            {
                var checkCandle = listCandles.Where(m => m.Symbol == e.Quote.Instrument).FirstOrDefault();
                if(checkCandle!=null)
                {
                    CandleAddition(e.Quote.Instrument);
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
                frm.Invoke((Action)delegate ()
                {
                    frm.chart1.DataSource = null;
                    frm.chart1.DataSource = listCandles;

                });
            }
        }
        public BindingList<CandleDataMT> HistoricalCandles(string symbol)
        {

            System.Threading.Thread.Sleep(1000);//Mt server take time to connect
            if (apiClient.ConnectionState == MtConnectionState.Connected)
            {
                return RequestHistoricalCandles(symbol);
            }
            return listCandles;

        }
        public MqlTick SymbolInfoTick(string symbol)
        {

            System.Threading.Thread.Sleep(1000);//Mt server take time to connect
            if (apiClient.ConnectionState == MtConnectionState.Connected)
            {

                return apiClient.SymbolInfoTick(symbol);
            }

            return new MqlTick();
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

                frm.Invoke((Action)delegate ()
                {
                    frm.chart1.DataSource = null;
                    frm.chart1.DataSource = listCandles;

                });
            }            
        }

        private BindingList<CandleDataMT> RequestHistoricalCandles(string symbol = "USDJPY", ENUM_TIMEFRAMES pERIOD_CURRENT = ENUM_TIMEFRAMES.PERIOD_CURRENT)
        {
            var rates = apiClient.CopyRates(symbol, pERIOD_CURRENT, DateTime.Now.AddMonths(-1), DateTime.Now);
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

        public void Dispose()
        {
            _timerTradeMonitor.Stop();
            _timeframeTradeMonitor.Stop();
            apiClient.BeginDisconnect();
        }
        #endregion
    }
}
