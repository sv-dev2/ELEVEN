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

namespace ELEVEN.Services
{
    public class BitfinexSocket
    {
        WebSocket4Net.WebSocket webSocket;
        const string host = "wss://api.bitfinex.com/ws/2";
        // the one and only Singleton instance. 
        private static readonly BitfinexSocket instance = new BitfinexSocket();
        // gets the instance of the singleton object
        public static BitfinexSocket Instance
        {
            get { return instance; }
        }
        // private constructor. 
        private BitfinexSocket()
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

        private dynamic form { get; set; }
       
        private bool IsSocketOpened { get; set; } = false;
        List<AllForms> listForms = new List<AllForms>();
        public void Init(string symbol, dynamic form)
        {

           // this.form = form;
            listForms.Add(new AllForms { form = form,symbol=symbol });
          
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
                        BindingList<CandleData> candleData  = form.candleData as BindingList<CandleData>;
                        foreach (var item in data)
                        {
                            var candles = item.Split(',');
                            if (candles.Count() > 3)
                            {
                                form.candleData.Add(new CandleData { Close = Convert.ToDecimal(candles[2]), High = Convert.ToDecimal(candles[3]), Low = Convert.ToDecimal(candles[4]), Open = Convert.ToDecimal(candles[1]), Volume = Convert.ToDecimal(candles[5].ToString().Replace("]", "")), MTS = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Convert.ToInt64(candles[0])).ToLocalTime() });
                            }

                        }
                      
                        var max = candleData.Max(m => m.High);
                        var min = candleData.Min(m => m.Low);

                        form.Invoke((Action)delegate ()
                        {
                            form.chart1.ChartAreas["ChartArea1"].AxisY.Minimum = Convert.ToDouble(min);
                            form.chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(max);
                            form.chart1.DataSource = candleData;

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

    }
    public class AllForms
    {
        public dynamic form { get; set; }
        public int channelId { get; set; }
        public string symbol { get; set; }
    }
}
