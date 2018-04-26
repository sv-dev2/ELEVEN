using ELEVEN.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;
using SuperSocket.ClientEngine;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace ELEVEN.Services
{
    public class BitfinexSocket : IDisposable
    {
        WebSocket4Net.WebSocket webSocket;
        const string host = "wss://api.bitfinex.com/ws/2";
        // the one and only Singleton instance. 
        private static BitfinexSocket instance = new BitfinexSocket();
        // gets the instance of the singleton object
        public static BitfinexSocket Instance
        {
            get { return instance; }
            set { instance = value; }
        }
        // private constructor. 
        private BitfinexSocket()
        {

            webSocket = new WebSocket4Net.WebSocket(host);
            webSocket.Open();
            webSocket.Opened += WebSocket_Opened;
            webSocket.Closed += WebSocket_Closed;
            webSocket.Error += WebSocket_Error;
            webSocket.MessageReceived += WebSocket_MessageReceived;

        }

        private dynamic form { get; set; }

        private bool IsSocketOpened { get; set; } = false;
        public List<AllForms> listForms = new List<AllForms>();
        List<MapSymbolChart> list = new List<MapSymbolChart>();
        public void Init(string symbol, dynamic form)
        {

            // this.form = form;
            var hasSymbol = list.Where(m => m.Symbol == symbol).FirstOrDefault();
            if (hasSymbol != null)
            {
                form.candleData = hasSymbol.candleData;
                listForms.Add(new AllForms { form = form, symbol = symbol, channelId = hasSymbol.ChannelId });
            }
            else
            {
                listForms.Add(new AllForms { form = form, symbol = symbol });
            }


            while (!IsSocketOpened)
            {
            }
            if (IsSocketOpened)
            {
                SendSymbol(symbol);
            }
        }
        private void SendSymbol(string symbol)
        {
            webCandleListner webCandle = new webCandleListner();
            webCandle.channel = "candles";
            webCandle._event = "subscribe";
            webCandle.key = "trade:1m:" + symbol;
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(webCandle);
            jsonString = jsonString.Replace("_event", "event");
            webSocket.Send(jsonString);
        }
        private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            if (e.Message.Contains("subscribed"))
            {
                var items = JsonConvert.DeserializeObject<webCandleResponse>(e.Message);
                var objForm = listForms.Where(m => m.symbol == items.key.Split(':')[2]).FirstOrDefault();
                objForm.channelId = items.chanId;

                MapSymbolChart mapSymbol = new MapSymbolChart();
                mapSymbol.ChannelId = items.chanId;
                mapSymbol.Symbol = items.key.Split(':')[2];
                list.Add(mapSymbol);
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
                        var channelId = data[1].Split(',')[0];
                        form = listForms.Where(m => m.channelId == Convert.ToInt32(channelId)).FirstOrDefault().form;
                        BindingList<CandleData> candleData = form.candleData as BindingList<CandleData>;
                        foreach (var item in data)
                        {
                            var candles = item.Split(',');
                            if (candles.Count() > 3)
                            {
                                form.candleData.Add(new CandleData { Close = Convert.ToDecimal(candles[2]), High = Convert.ToDecimal(candles[3]), Low = Convert.ToDecimal(candles[4]), Open = Convert.ToDecimal(candles[1]), Volume = Convert.ToDecimal(candles[5].ToString().Replace("]", "")), MTS = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Convert.ToInt64(candles[0])).ToLocalTime() });
                            }

                        }
                        var formObj = list.Where(m => m.ChannelId == Convert.ToInt32(channelId)).FirstOrDefault();
                        formObj.candleData = form.candleData;
                        var max = candleData.Max(m => m.High);
                        var min = candleData.Min(m => m.Low);

                        form.Invoke((Action)delegate ()
                        {
                           
                            form.chart1.ChartAreas["ChartArea1"].AxisY.Minimum = Convert.ToDouble(min);
                            form.chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(max);
                            form.chart1.DataSource = candleData;
                           // BindCharts(form, candleData);
                        });
                    }
                    else
                    {
                        var channelId = data[1].Split(',')[0];
                        form = listForms.Where(m => m.channelId == Convert.ToInt32(channelId)).FirstOrDefault().form;
                        BindingList<CandleData> candleData = form.candleData as BindingList<CandleData>;


                        var candles = data[2].Split(',');
                        candleData.Add(new CandleData { Close = Convert.ToDecimal(candles[2]), High = Convert.ToDecimal(candles[3]), Low = Convert.ToDecimal(candles[4]), Open = Convert.ToDecimal(candles[1]), Volume = Convert.ToDecimal(candles[5].ToString().Replace("]", "")), MTS = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Convert.ToInt64(candles[0])).ToLocalTime() });
                        var max = candleData.Max(m => m.High);
                        var min = candleData.Min(m => m.Low);
                        var formObj = list.Where(m => m.ChannelId == Convert.ToInt32(channelId)).FirstOrDefault();
                        formObj.candleData = candleData;

                        form.Invoke((Action)delegate ()
                        {
                            form.chart1.ChartAreas["ChartArea1"].AxisY.Minimum = Convert.ToDouble(min);
                            form.chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(max);
                            form.chart1.DataSource = candleData;

                        });

                    }

                }
                catch (Exception)
                {

                }

            }

        }

        private void WebSocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {

        }

        private void WebSocket_Closed(object sender, EventArgs e)
        {

        }

        private void WebSocket_Opened(object sender, EventArgs e)
        {
            IsSocketOpened = true;
        }

        public void Dispose()
        {
            webSocket.Close();
        }

        private void BindCharts(dynamic form, BindingList<CandleData> bindingList)
        {
            // Create a new chart.

            var max = bindingList.Max(m => m.High);
            var min = bindingList.Min(m => m.Low);
            // Create a candlestick series.
            Series series1 = new Series("Stock Prices", ViewType.CandleStick);

            // Specify the date-time argument scale type for the series,
            // as it is qualitative, by default.
            series1.ArgumentScaleType = ScaleType.DateTime;
          
            series1.ArgumentDataMember = "MTS";
            series1.ValueDataMembers.AddRange(new string[] { "Low", "High", "Open", "Close" });

            // Add the series to the chart.
            form.chart1.Series.Add(series1);
            form.chart1.Series["Stock Prices"].DataSource = bindingList;
            // Access the view-type-specific options of the series.
            CandleStickSeriesView myView = (CandleStickSeriesView)series1.View;

            myView.LineThickness = 2;
            myView.LevelLineLength = 0.25;

            // Specify the series reduction options.
            myView.ReductionOptions.ColorMode = ReductionColorMode.OpenToCloseValue;
            myView.ReductionOptions.FillMode = CandleStickFillMode.FilledOnReduction;
            myView.ReductionOptions.Level = StockLevel.Open;
            myView.ReductionOptions.Visible = true;

            // Access the chart's diagram.
            XYDiagram diagram = ((XYDiagram)form.chart1.Diagram);

            // Access the type-specific options of the diagram.
            diagram.AxisY.WholeRange.MinValue = min;
            diagram.AxisY.WholeRange.MaxValue = max;
            diagram.AxisY.WholeRange.SideMarginsValue = 0.5;

      
            // Exclude weekends from the X-axis range,
            // to avoid gaps in the chart's data.
            diagram.AxisX.DateTimeScaleOptions.WorkdaysOnly = true;
           





        }

    }
    public class AllForms
    {
        public dynamic form { get; set; }
        public int channelId { get; set; }
        public string symbol { get; set; }
    }
    public class MapSymbolChart
    {
        public int ChannelId { get; set; }
        public string Symbol { get; set; }
        public BindingList<CandleData> candleData { get; set; }
    }
}
