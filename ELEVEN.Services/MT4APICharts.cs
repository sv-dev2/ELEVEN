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
    public class MT4APICharts : IDisposable, IToggleGateway
    {
        #region "MetaTrader Objects"
        MtApiClient apiClient = null;

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
        private static MT4APICharts instance = new MT4APICharts();
        // gets the instance of the singleton object
        public static MT4APICharts Instance
        {
            get { return instance; }
            set { instance = value; }
        }
        private MT4APICharts()
        {
            apiClient = new MtApiClient();
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
        }
        List<MT4Form> forms = new List<MT4Form>();
        public void Init(dynamic frmChart, string symbol)
        {
            #region "Connect to MetaTrader Server"  
            this.frmChart = frmChart;

            forms.Add(new MT4Form { form = frmChart, symbol = symbol });
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
                CandleAddition(e.Quote.Instrument);
            }
            catch (Exception ex)
            {


            }


        }

        private void CandleAddition(string symbol, ENUM_TIMEFRAMES pERIOD_CURRENT = ENUM_TIMEFRAMES.PERIOD_CURRENT)
        {
            var Form = forms.Where(m => m.symbol == symbol).FirstOrDefault();
            if (Form != null)
            {
                var formCandle = Form.form.candleDataMT as BindingList<CandleDataMT>;
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
                        formCandle.Add(candleData);
                    }
                    var max = formCandle.Max(m => m.High);
                    var min = formCandle.Min(m => m.Low);
                    frmChart.Invoke((Action)delegate ()
                    {
                        frmChart.chart1.ChartAreas["ChartArea1"].AxisY.Minimum = Convert.ToDouble(min);
                        frmChart.chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(max);
                        frmChart.chart1.DataSource = formCandle;

                    });
                }
            }

        }
        public BindingList<CandleDataMT> HistoricalCandles(string symbol, string candleTimeFrame)
        {

            System.Threading.Thread.Sleep(1000);//Mt server take time to connect
            if (apiClient.ConnectionState == MtConnectionState.Connected)
            {
                return RequestHistoricalCandles(symbol, GetENUM_TIMEFRAMES(candleTimeFrame));
            }
            return new BindingList<CandleDataMT>();

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
            //var checkCandle = listCandles.Where(m => m.Symbol == e.TimeBar.Symbol).FirstOrDefault();
            var Form = forms.Where(m => m.symbol == e.TimeBar.Symbol).FirstOrDefault();
            if (Form != null)
            {
                var formCandle = Form.form.candleDataMT as BindingList<CandleDataMT>;
                CandleDataMT candleData = new CandleDataMT();
                candleData.Symbol = e.TimeBar.Symbol;
                candleData.Close = e.TimeBar.Close;
                candleData.High = e.TimeBar.High;
                candleData.Low = e.TimeBar.Low;
                candleData.MTS = e.TimeBar.CloseTime;
                candleData.Open = e.TimeBar.Open;
                formCandle.Add(candleData);
                var max = formCandle.Max(m => m.High);
                var min = formCandle.Min(m => m.Low);
                frmChart.Invoke((Action)delegate ()
                {
                    frmChart.chart1.ChartAreas["ChartArea1"].AxisY.Minimum = Convert.ToDouble(min);
                    frmChart.chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(max);
                    frmChart.chart1.DataSource = formCandle;

                });
            }
        }

        private BindingList<CandleDataMT> RequestHistoricalCandles(string symbol, ENUM_TIMEFRAMES pERIOD_CURRENT)
        {
            var listCandles = new BindingList<CandleDataMT>();
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
            switch (candleTimeFrame)
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
    public class MT4Form
    {
        public dynamic form { get; set; }
        public string symbol { get; set; }
    }
}
