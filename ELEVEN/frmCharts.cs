using ComponentFactory.Krypton.Toolkit;
using ELEVEN.Models;
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
        public frmCharts(MDIParentForm parentForm)
        {
            InitializeComponent();
            candleData = new BindingList<CandleData>();
            this.parentForm = parentForm;
            webSocket = new WebSocket4Net.WebSocket(host);
            #region "Bitfinex"
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
                                candleData.Add(new CandleData { Close = Convert.ToDecimal(candles[2]), High = Convert.ToDecimal(candles[3]), Low = Convert.ToDecimal(candles[4]), Open = Convert.ToDecimal(candles[1]), Volume = Convert.ToDecimal(candles[5].ToString().Replace("]", "")), MTS =DateTime.Now.AddMilliseconds(Convert.ToInt64(candles[0])) });
                            }

                        }
                        this.Invoke((Action)delegate ()
                        {
                            chart1.DataSource = candleData;
                            chart1.DataBind();
                        });
                    }
                    else
                    {
                        var items = data[2].Split(',');
                    }

                }
                catch(Exception)
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
            webCandle.key = "trade:1m:tLTCUSD";
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(webCandle);
            jsonString = jsonString.Replace("_event", "event");
            webSocket.Send(jsonString);
        }

        private void CustomizedLineSeries_Load(object sender, EventArgs e)
        {
            ChartSettings();
        }
        private void ChartSettings()
        {
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

            chart1.Series["Series1"].XValueMember = "MTS";
            chart1.Series["Series1"].YValueMembers = "High,Low,Open,Close";
            chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.Series["Series1"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Blue";           
            chart1.Series["Series1"]["ShowOpenClose"] = "Both";
            chart1.DataManipulator.IsStartFromFirst = true;
        }
        private void frmCharts_FormClosing(object sender, FormClosingEventArgs e)
        {

            TabControl tabControl = parentForm.Controls["tabControl1"] as TabControl;
            tabControl.TabPages.RemoveByKey(this.Name);
        }
    }
}
