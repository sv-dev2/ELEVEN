using ELEVEN.Model;
using ELEVEN.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Services
{
    public class BitfinexWatchlistSocket : IDisposable
    {
        WebSocket4Net.WebSocket webSocket;
        StringBuilder sbBitfinex = new StringBuilder();
        StringBuilder sbTraders = new StringBuilder();
        StringBuilder sbIGMarket = new StringBuilder();
        StringBuilder sbICMarket = new StringBuilder();
        clsComman comman = null;
        //public BindingList<FinexTicker> ObjTrading = new BindingList<FinexTicker>();
        const string host = "wss://api.bitfinex.com/ws/2";
        // the one and only Singleton instance. 
        private static BitfinexWatchlistSocket instance = new BitfinexWatchlistSocket();
        // gets the instance of the singleton object
        public static BitfinexWatchlistSocket Instance
        {
            get { return instance; }
            set { instance = value; }
        }
        // private constructor. 
        private BitfinexWatchlistSocket()
        {
            comman = new clsComman();
            webSocket = new WebSocket4Net.WebSocket(host);
            webSocket.Open();
            webSocket.Opened += WebSocket_Opened;
            webSocket.Closed += WebSocket_Closed;
            webSocket.Error += WebSocket_Error;
            webSocket.MessageReceived += WebSocket_MessageReceived;
        }
        private dynamic form { get; set; }

        private bool IsSocketOpened { get; set; } = false;
        public List<WatchListForm> listForms = new List<WatchListForm>();
        public void Init(dynamic form)
        {

            while (!IsSocketOpened)
            {
            }
            if (IsSocketOpened)
            {
                SendSymbol(form);
            }
        }
        private void SendSymbol(dynamic RefForm)
        {
            var ObjTrading = RefForm.ObjTrading as BindingList<FinexTicker>;

            string symbols = string.Empty;
            using (var streamReader = new StreamReader(RefForm.Name + ".txt"))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }

            if (symbols != null)
            {

                comman.Seprateticklers(symbols, ref sbBitfinex, ref sbTraders, ref sbIGMarket, ref sbICMarket);
                //Check if Symbol Exist               
                var hasSymbol = list.Where(m => sbBitfinex.ToString().Split(',').Contains(m.Symbol)).ToList();
                if (hasSymbol != null)
                {
                    List<int> channelList = new List<int>();
                    foreach (var item in hasSymbol)
                    {
                        channelList.Add(item.ChannelId);
                    }
                    listForms.Add(new WatchListForm { form = RefForm, symbol = sbBitfinex.ToString(), channelId = channelList });
                }
                else
                {
                    listForms.Add(new WatchListForm { form = RefForm, symbol = sbBitfinex.ToString() });
                }
                foreach (var item in sbBitfinex.ToString().Split(','))
                {
                    if (item != string.Empty)
                    {
                        var request = new webSocketListner();
                        request.channel = "ticker";
                        request.symbol = item;
                        request._event = "subscribe";
                        var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(request);
                        jsonString = jsonString.Replace("_event", "event");
                        webSocket.Send(jsonString);
                    }
                }
            }
            else
            {
                RefForm.Invoke((Action)delegate ()
                {
                    RefForm.dataGridMarketData.DataSource = ObjTrading;
                });
            }


        }
        private void WebSocket_Closed(object sender, EventArgs e)
        {
            webSocket.Dispose();
            //form.ObjTrading = new BindingList<FinexTicker>();
            webSocket = new WebSocket4Net.WebSocket(host);
            webSocket.Open();
            webSocket.Opened += WebSocket_Opened;
            webSocket.Closed += WebSocket_Closed;
            webSocket.Error += WebSocket_Error;

            webSocket.MessageReceived += WebSocket_MessageReceived;
            ReInitallizeForm();
        }
        private void ReInitallizeForm()
        {
            list = new List<MapSymbolChannel>();
            var backUp = listForms;
            listForms = new List<WatchListForm>();
            foreach (var item in backUp)
            {
                item.form.ObjTrading = new BindingList<FinexTicker>();
                Init(item.form);
            }
        }
        private void WebSocket_Opened(object sender, EventArgs e)
        {

            IsSocketOpened = true;

        }
        private void WebSocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {

        }
        List<MapSymbolChannel> list = new List<MapSymbolChannel>();
        private void WebSocket_MessageReceived(object sender, WebSocket4Net.MessageReceivedEventArgs e)
        {

            if (e.Message.Contains("subscribed"))
            {
                if (e.Message.Contains("currency"))
                {
                    var items = JsonConvert.DeserializeObject<Subscribe>(e.Message);
                    MapSymbolChannel mapSymbol = new MapSymbolChannel();
                    mapSymbol.ChannelId = items.chanId;
                    mapSymbol.Symbol = "f" + items.currency;
                    list.Add(mapSymbol);
                    var objForms = listForms.Where(m => m.symbol.IndexOf("f" + items.currency) > -1).ToList();
                    foreach (var item in objForms)
                    {
                        item.channelId.Add(items.chanId);
                        item.form.Invoke((Action)delegate ()
                        {
                            item.form.ObjTrading.Add(new FinexTicker { Id = items.chanId, broker = Broker.BitFinex.ToString().ToUpper(), pair = Broker.BitFinex.ToString().ToUpper() + "." + items.currency.Replace("t", ""), bid = "0", ask = "0", last_price = "", volume = "" });
                            item.form.dataGridMarketData.DataSource = item.form.ObjTrading;
                        });
                    }


                }
                else
                {
                    var items = JsonConvert.DeserializeObject<Subscribe>(e.Message);
                    MapSymbolChannel mapSymbol = new MapSymbolChannel();
                    mapSymbol.ChannelId = items.chanId;
                    mapSymbol.Symbol = "t" + items.pair;
                    list.Add(mapSymbol);
                    var objForms = listForms.Where(m => m.symbol.IndexOf(items.pair) > -1).ToList();
                    foreach (var item in objForms)
                    {
                        item.channelId.Add(items.chanId);
                        item.form.Invoke((Action)delegate ()
                       {
                           item.form.ObjTrading.Add(new FinexTicker { Id = items.chanId, broker = Broker.BitFinex.ToString().ToUpper(), pair = Broker.BitFinex.ToString().ToUpper() + "." + items.pair.Replace("t", ""), bid = "0", ask = "0", last_price = "", volume = "" });
                           item.form.dataGridMarketData.DataSource = item.form.ObjTrading;
                       });
                    }

                }

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
                    if (data.Count() > 2) //snapshot
                    {
                        var instrument = data[1].Replace(",", string.Empty);
                        var objForms = listForms.Where(m => m.channelId.Contains(Convert.ToInt32(instrument))).ToList();
                        foreach (var item in objForms)
                        {
                            var ObjTrading = item.form.ObjTrading as BindingList<FinexTicker>;
                            var p = ObjTrading.Where(m => m.Id == Convert.ToInt32(instrument)).FirstOrDefault();
                            if (p != null)
                            {
                                var items = data[2].Split(',');
                                GridColumnDataChanges(items, p, ObjTrading, item.form);
                            }
                            else
                            {
                                var listSymbol = list.Where(m => m.ChannelId == Convert.ToInt32(instrument)).FirstOrDefault().Symbol;
                                var items = data[2].Split(',');
                                item.form.Invoke((Action)delegate ()
                                {
                                    item.form.ObjTrading.Add(new FinexTicker { Id = Convert.ToInt32(instrument), broker = Broker.BitFinex.ToString().ToUpper(), pair = Broker.BitFinex.ToString().ToUpper() + "." + listSymbol.Replace("t", "").Replace("f", ""), bid = items[1], ask = items[3], last_price = items[7], volume = items[8] });
                                    item.form.dataGridMarketData.DataSource = item.form.ObjTrading;
                                });
                            }
                        }

                    }
                    else
                    {
                        var items = JsonConvert.DeserializeObject<string[]>(e.Message);
                        if (items.Count() > 3)
                        {
                            var instrument = data[1].Replace(",", string.Empty);
                            var objForms = listForms.Where(m => m.channelId.Contains(Convert.ToInt32(instrument))).ToList();
                            foreach (var item in objForms)
                            {
                                var ObjTrading = item.form.ObjTrading as BindingList<FinexTicker>;
                                var p = ObjTrading.Where(m => m.Id == Convert.ToInt32(items[0])).FirstOrDefault();
                                if (p != null)
                                {
                                    GridColumnDataChanges(items, p, ObjTrading, item.form);
                                }
                                else
                                {
                                    var listSymbol = list.Where(m => m.ChannelId == Convert.ToInt32(instrument)).FirstOrDefault().Symbol;

                                    item.form.Invoke((Action)delegate ()
                                    {
                                        item.form.ObjTrading.Add(new FinexTicker { Id = Convert.ToInt32(instrument), broker = Broker.BitFinex.ToString().ToUpper(), pair = Broker.BitFinex.ToString().ToUpper() + "." + listSymbol.Replace("t", "").Replace("f", ""), bid = items[1], ask = items[3], last_price = items[7], volume = items[8] });
                                        item.form.dataGridMarketData.DataSource = item.form.ObjTrading;
                                    });
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {

                }

            }

        }

        private void GridColumnDataChanges(string[] items, FinexTicker p, BindingList<FinexTicker> ObjTrading, dynamic form)
        {
            bool bidBlue = true;
            bool askBlue = true;
            int index = ObjTrading.IndexOf(p);
            if (Convert.ToDecimal(items[1]) > Convert.ToDecimal(p.bid))
            {
                form.dataGridMarketData.Rows[index].Cells[1].Style.ForeColor = Color.Blue;
            }
            else
            {
                form.dataGridMarketData.Rows[index].Cells[1].Style.ForeColor = Color.Red;
                bidBlue = false;
            }
            if (Convert.ToDecimal(items[3]) > Convert.ToDecimal(p.ask))
            {
                form.dataGridMarketData.Rows[index].Cells[2].Style.ForeColor = Color.Blue;
            }
            else
            {
                form.dataGridMarketData.Rows[index].Cells[2].Style.ForeColor = Color.Red;
                askBlue = false;
            }
            if (!bidBlue || !askBlue)
            {
                ((TextAndImageCell)form.dataGridMarketData.Rows[index].Cells[0]).Image = form.imgList.Images[0];
            }
            else
            {
                ((TextAndImageCell)form.dataGridMarketData.Rows[index].Cells[0]).Image = form.imgList.Images[1];
            }
            p.ask = Convert.ToString((items[3]));
            p.bid = Convert.ToString((items[1]));
            p.last_price = Convert.ToString(items[7]);
            p.volume = Convert.ToString(items[8]);
        }

        public void AddSymbolTxtFile(dynamic form, dynamic txtAddRow)
        {

            string symbols = string.Empty;
            using (var streamReader = new StreamReader(form.Name + ".txt"))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            if (symbols == null)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(form.Name + ".txt", true))
                {
                    file.Write(txtAddRow.Text.ToUpper());
                    file.Close();

                }
                if (txtAddRow.Text.ToLower().IndexOf("bitfinex") > -1)
                {
                    List<int> channel = new List<int>();
                    var checkmapping = list.Where(m => m.Symbol == "t" + txtAddRow.Text.Split('.')[1].ToUpper()).FirstOrDefault();
                    if (checkmapping != null)
                    {
                        channel.Add(checkmapping.ChannelId);
                    }
                    else
                    {
                        checkmapping = list.Where(m => m.Symbol == "f" + txtAddRow.Text.Split('.')[1].ToUpper()).FirstOrDefault();
                        if (checkmapping != null)
                        {
                            channel.Add(checkmapping.ChannelId);
                        }
                    }
                    listForms.Add(new WatchListForm { form = form, symbol = txtAddRow.Text.ToUpper(), channelId = channel });

                    var request = new webSocketListner();
                    request.channel = "ticker";
                    request.symbol = txtAddRow.Text.Split('.')[1].ToUpper();
                    request._event = "subscribe";
                    //listWebList.Add(request);
                    var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(request);
                    jsonString = jsonString.Replace("_event", "event");
                    webSocket.Send(jsonString);
                }

            }
            else if (!symbols.Contains(txtAddRow.Text.ToUpper()))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(form.Name + ".txt", true))
                {
                    file.Write("," + txtAddRow.Text.ToUpper());
                    file.Close();
                }
                using (var streamReader = new StreamReader(form.Name + ".txt"))
                {
                    symbols = streamReader.ReadLine();
                    streamReader.Close();
                }

                // listForms.Add(new WatchListForm { form = form, symbol = sbBitfinex.ToString() });

                if (txtAddRow.Text.ToLower().IndexOf("bitfinex") > -1)
                {
                    var checkmapping = list.Where(m => m.Symbol == "t" + txtAddRow.Text.Split('.')[1].ToUpper()).FirstOrDefault();
                    int channel = 0;
                    if (checkmapping != null)
                    {
                        channel = checkmapping.ChannelId;
                    }
                    else
                    {
                        checkmapping = list.Where(m => m.Symbol == "f" + txtAddRow.Text.Split('.')[1].ToUpper()).FirstOrDefault();
                        if (checkmapping != null)
                        {
                            channel = checkmapping.ChannelId;
                        }
                    }
                    comman.Seprateticklers(symbols, ref sbBitfinex, ref sbTraders, ref sbIGMarket, ref sbICMarket);
                    var checkForm = listForms.Where(m => m.form == form).FirstOrDefault();
                    if (checkForm != null)
                    {
                        checkForm.symbol = sbBitfinex.ToString();
                        checkForm.channelId.Add(channel);
                    }

                    var request = new webSocketListner();
                    request.channel = "ticker";
                    request.symbol = txtAddRow.Text.Split('.')[1].ToUpper();
                    request._event = "subscribe";
                    //listWebList.Add(request);
                    var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(request);
                    jsonString = jsonString.Replace("_event", "event");
                    webSocket.Send(jsonString);
                }
            }
        }

        public void Dispose()
        {
            webSocket.Close();
            listForms = new List<WatchListForm>();
        }

        public void ReadWriteNotepad(string symbol, string name, dynamic form)
        {
            this.form = form;
            string symbols = string.Empty;
            using (var streamReader = new StreamReader(name + ".txt"))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            //check Index
            int Index = symbols.IndexOf(symbol);
            if (Index == 0)
            {
                symbols = symbols.Replace(symbol + ",", "");
                symbols = symbols.Replace(symbol, "");
            }
            else
            {
                symbols = symbols.Replace("," + symbol, "");
            }

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(name + ".txt", false))
            {
                file.Write(symbols);
                file.Close();
            }
            webSocket.Close();

        }
    }

    public class WatchListForm
    {
        public WatchListForm()
        {
            channelId = new List<int>();
        }

        public dynamic form { get; set; }
        public List<int> channelId { get; set; }
        public string symbol { get; set; }
    }
    public class MapSymbolChannel
    {
        public int ChannelId { get; set; }
        public string Symbol { get; set; }
    }
}
