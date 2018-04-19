using ComponentFactory.Krypton.Toolkit;
using ELEVEN.Models;
using ELEVEN.Services;
using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocket4Net;

namespace ELEVEN
{
    public partial class frmCharts : KryptonForm
    {
        private MDIParentForm parentForm;
        WebSocket4Net.WebSocket webSocket;
        const string host = "wss://api.bitfinex.com/ws/2";
        BindingList<CandleData> candleData;
        BindingList<CandleDataMT> candleDataMT;
        public string broker { get; set; }
        public string symbol { get; set; }
        private MT4API mT4API { get; set; }
        public frmCharts(MDIParentForm parentForm, string broker,string symbol)
        {
            InitializeComponent();
            candleData = new BindingList<CandleData>();

            this.parentForm = parentForm;
            this.broker = broker;
            this.symbol = symbol;
            if (broker.ToLower() == "bitfinex")
                InitBitFinex();
            else
            {
                mT4API = new MT4API(this);
                candleDataMT = new BindingList<CandleDataMT>();
            }
            this.Text = broker + "." + symbol.Replace("t", "");
        }
        private void InitBitFinex()
        {

            #region "Bitfinex"
            webSocket = new WebSocket4Net.WebSocket(host);
            webSocket.Open();
            webSocket.Opened += WebSocket_Opened;
            webSocket.Closed += WebSocket_Closed;
            webSocket.Error += WebSocket_Error;
            webSocket.MessageReceived += WebSocket_MessageReceived;
            #endregion
        }
        private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            if (e.Message.Contains("subscribed"))
            {
                var items = JsonConvert.DeserializeObject<webCandleResponse>(e.Message);

            }

            if (e.Message.Contains("hb"))
            {
                return;
            }

            if (e.Message.Contains("["))
            {
                try
                {
                    var data = e.Message.Split('[');
                    if (data.Count() > 3)
                    {
                        foreach (var item in data)
                        {
                            var candles = item.Split(',');
                            if (candles.Count() > 3)
                            {
                                candleData.Add(new CandleData { Close = Convert.ToDecimal(candles[2]), High = Convert.ToDecimal(candles[3]), Low = Convert.ToDecimal(candles[4]), Open = Convert.ToDecimal(candles[1]), Volume = Convert.ToDecimal(candles[5].ToString().Replace("]", "")), MTS = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Convert.ToInt64(candles[0])).ToLocalTime() });
                            }

                        }
                        var max = candleData.Max(m => m.High);
                        var min = candleData.Min(m => m.Low);
                       
                        this.Invoke((Action)delegate ()
                        {
                            chart1.ChartAreas["ChartArea1"].AxisY.Minimum =Convert.ToDouble(min);
                            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(max);
                            chart1.DataSource = candleData;
                          
                        });
                    }
                    else
                    {

                        var candles = data[2].Split(',');
                        candleData.Add(new CandleData { Close = Convert.ToDecimal(candles[2]), High = Convert.ToDecimal(candles[3]), Low = Convert.ToDecimal(candles[4]), Open = Convert.ToDecimal(candles[1]), Volume = Convert.ToDecimal(candles[5].ToString().Replace("]", "")), MTS = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Convert.ToInt64(candles[0])).ToLocalTime() });
                        var max = candleData.Max(m => m.High);
                        var min = candleData.Min(m => m.Low);

                        this.Invoke((Action)delegate ()
                        {
                            chart1.ChartAreas["ChartArea1"].AxisY.Minimum = Convert.ToDouble(min);
                            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(max);
                            chart1.DataSource = candleData;
                           
                        });

                    }

                }
                catch (Exception)
                {

                }

            }

        }

        private void WebSocket_Error(object sender, ErrorEventArgs e)
        {

        }

        private void WebSocket_Closed(object sender, EventArgs e)
        {

        }

        private void WebSocket_Opened(object sender, EventArgs e)
        {
            webCandleListner webCandle = new webCandleListner();
            webCandle.channel = "candles";
            webCandle._event = "subscribe";
            webCandle.key = "trade:1m:" + symbol;
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(webCandle);
            jsonString = jsonString.Replace("_event", "event");
            webSocket.Send(jsonString);
        }

        private void CustomizedLineSeries_Load(object sender, EventArgs e)
        {
            ChartSettings();
            if (mT4API != null)
            {
                BindDataSource();
            }
        }
        public void BindDataSource()
        {
            candleDataMT = (BindingList<CandleDataMT>)mT4API.HistoricalCandles(symbol);
            if(mT4API.listCandles.Count>0)
            {
                var max = mT4API.listCandles.Max(m => m.High);
                var min = mT4API.listCandles.Min(m => m.Low);
                chart1.ChartAreas["ChartArea1"].AxisY.Minimum = min;
                chart1.ChartAreas["ChartArea1"].AxisY.Maximum = max;
            }          
            chart1.DataSource = mT4API.listCandles;
            //chart1.DataBind();
        }
        private void ChartSettings()
        {
           // chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            //chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

            chart1.Series["Series1"].XValueMember = "MTS";
            chart1.Series["Series1"].YValueMembers = "High,Low,Open,Close";
            chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.Series["Series1"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Blue";
            chart1.Series["Series1"]["ShowOpenClose"] = "Both";
            chart1.Series["Series1"]["OpenCloseStyle"] = "Triangle";
            chart1.DataManipulator.IsStartFromFirst = true;
        }
        private void frmCharts_FormClosing(object sender, FormClosingEventArgs e)
        {

            TabControl tabControl = parentForm.Controls["tabControl1"] as TabControl;
            tabControl.TabPages.RemoveByKey(this.Name);
        }
    }
}
