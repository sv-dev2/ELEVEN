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
        #endregion
        public MT4API(object frm)
        {
            #region "Connect to MetaTrader Server"            
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
            Console.WriteLine("Bid= " + e.Quote.Bid.ToString() + " -Ask = " + e.Quote.Ask.ToString());
            if (listCandles != null && listCandles.Count > 0)
            {
                CandleAddition(e.Quote.Instrument);
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
            }
        }
        public BindingList<CandleDataMT> HistoricalCandles()
        {

            System.Threading.Thread.Sleep(1000);//Mt server take time to connect
            if (apiClient.ConnectionState == MtConnectionState.Connected)
            {
                return RequestHistoricalCandles();
            }
            return listCandles;

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

        }
        private BindingList<CandleDataMT> RequestHistoricalCandles(string symbol = "USDJPY", ENUM_TIMEFRAMES pERIOD_CURRENT = ENUM_TIMEFRAMES.PERIOD_CURRENT)
        {
            var rates = apiClient.CopyRates(symbol, pERIOD_CURRENT, 0, 100);
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
