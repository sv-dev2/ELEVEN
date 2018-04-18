using ComponentFactory.Krypton.Toolkit;
using ELEVEN.DBConnection;
using ELEVEN.Model;
using ELEVEN.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using ELEVEN.Models;
using MtApi;
using P23.MetaTrader4.Manager;
using P23.MetaTrader4.Manager.Contracts;
using Newtonsoft.Json;
using System.Globalization;
using MtApi.Monitors;

namespace ELEVEN
{
    public partial class frmMarketWatchWin : KryptonForm
    {
        #region "Object Declaration"
        BrokerInstrumentMapping instrumentMapping = null;


        private BindingSource bindingSource2 = new BindingSource();
        BindingList<FinexTicker> oldCustomerList = new BindingList<FinexTicker>();
        public BindingList<FinexTicker> ObjTrading = new BindingList<FinexTicker>();

        StringBuilder sbBitfinex = new StringBuilder();
        StringBuilder sbTraders = new StringBuilder();
        StringBuilder sbIGMarket = new StringBuilder();
        StringBuilder sbICMarket = new StringBuilder();
        const string host = "wss://api.bitfinex.com/ws/2";
        WebSocket4Net.WebSocket webSocket;
        #endregion
        MT4API mT4API = null;
        clsComman comman = null;
        public frmMarketWatchWin()
        {
            InitializeComponent();

            mT4API = new MT4API(this);
            comman = new clsComman();
            #region "Bitfinex"
            instrumentMapping = new BrokerInstrumentMapping();
            AutoCompletetxtAddRow();
            txtAddRow.GotFocus += TxtQuantity_GotFocus;
            txtAddRow.LostFocus += TxtQuantity_LostFocus;
            webSocket = new WebSocket4Net.WebSocket(host);
            #endregion

        }

        private void frmMarketWatch_Load(object sender, EventArgs e)
        {
            txtAddRow.Text = "click to add..";
            SymbolFileExist();
            CreateDataGridColumn();
            #region "Bitfinex"
            webSocket.Open();
            webSocket.Opened += WebSocket_Opened;
            webSocket.Closed += WebSocket_Closed;
            webSocket.Error += WebSocket_Error;
            webSocket.MessageReceived += WebSocket_MessageReceived;
            #endregion
            #region "Meta Trader"
            GetMetaTraderSymbols();
            #endregion
        }


        string fileName = string.Empty;
        private void SymbolFileExist()
        {
            string name = this.Name;
            fileName = name + ".txt";
            if (!File.Exists(fileName))
            {
                var streamWriter = File.CreateText(fileName);
                streamWriter.Close();
                streamWriter.Dispose();

            }
        }



        System.Windows.Forms.DataGridViewImageColumn buttonColumn = new System.Windows.Forms.DataGridViewImageColumn();
        TextAndImageColumn column = new TextAndImageColumn();
        public ImageList imgList = new ImageList();
        private void CreateDataGridColumn()
        {
            dataGridMarketData.DataSource = null;
            this.dataGridMarketData.Rows.Clear();
            dataGridMarketData.AutoGenerateColumns = false;
            dataGridMarketData.ColumnCount = 5;

            imgList.Images.Add(Properties.Resources.arrowred);
            imgList.Images.Add(Properties.Resources.arrowgreen);
            imgList.ImageSize = new Size(12, 17);
            imgList.TransparentColor = Color.Transparent;

            column.Image = imgList.Images[1];

            column.Name = "Symbol";
            column.HeaderText = "Symbol";
            column.DataPropertyName = "pair";
            column.Width = 75;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridMarketData.Columns.Insert(0, column);

            dataGridMarketData.Columns[1].HeaderText = "Bid";
            dataGridMarketData.Columns[1].Name = "Bid";
            dataGridMarketData.Columns[1].DataPropertyName = "bid";


            dataGridMarketData.Columns[2].Name = "Ask";
            dataGridMarketData.Columns[2].HeaderText = "Ask";
            dataGridMarketData.Columns[2].DataPropertyName = "ask";


            dataGridMarketData.Columns[3].Name = "Last";
            dataGridMarketData.Columns[3].HeaderText = "Last";
            dataGridMarketData.Columns[3].DataPropertyName = "last_price";


            dataGridMarketData.Columns[4].Name = "Volume";
            dataGridMarketData.Columns[4].HeaderText = "Volume";
            dataGridMarketData.Columns[4].DataPropertyName = "volume";


            buttonColumn.HeaderText = "";
            buttonColumn.Name = "buttonColumn";
            Image image = ELEVEN.Properties.Resources.Delete;

            buttonColumn.Image = image;
            buttonColumn.Width = 15;
            dataGridMarketData.Columns.Insert(5, buttonColumn);

            dataGridMarketData.Columns[6].Name = "broker";
            dataGridMarketData.Columns[6].HeaderText = "broker";
            dataGridMarketData.Columns[6].DataPropertyName = "broker";
            dataGridMarketData.Columns[6].Visible = false;


        }


        private void TxtQuantity_LostFocus(object sender, EventArgs e)
        {
            if (txtAddRow.Text != "click to add..")
            {
                if (String.IsNullOrWhiteSpace(txtAddRow.Text))
                {
                    txtAddRow.Text = "click to add..";
                }
                else
                {
                    comman.AddSymbolTxtFile(this.Name, txtAddRow, webSocket);
                    txtAddRow.Text = "click to add..";
                }

            }
        }

        private void TxtQuantity_GotFocus(object sender, EventArgs e)
        {
            txtAddRow.Text = string.Empty;
        }


        private void WebSocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {

        }
        BindingList<FinexTicker> list = new BindingList<FinexTicker>();
        private void WebSocket_MessageReceived(object sender, WebSocket4Net.MessageReceivedEventArgs e)
        {
            object obj;
            if (e.Message.Contains("subscribed"))
            {
                if (e.Message.Contains("currency"))
                {
                    var items = JsonConvert.DeserializeObject<Subscribe>(e.Message);
                    obj = this.Invoke((Action)delegate ()
                    {
                        ObjTrading.Add(new FinexTicker { Id = items.chanId, broker = Broker.BitFinex.ToString().ToUpper(), pair = Broker.BitFinex.ToString().ToUpper() + "." + items.currency.Replace("t", ""), bid = "0", ask = "0", last_price = "", volume = "" });
                        dataGridMarketData.DataSource = ObjTrading;
                    });
                }
                else
                {
                    var items = JsonConvert.DeserializeObject<Subscribe>(e.Message);
                    obj = this.Invoke((Action)delegate ()
                    {
                        ObjTrading.Add(new FinexTicker { Id = items.chanId, broker = Broker.BitFinex.ToString().ToUpper(), pair = Broker.BitFinex.ToString().ToUpper() + "." + items.pair.Replace("t", ""), bid = "0", ask = "0", last_price = "", volume = "" });
                        dataGridMarketData.DataSource = ObjTrading;
                    });
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
                        //var bids = data[3].Split(',');
                        // var asks = data[4].Split(',');
                        var instrument = data[1].Replace(",", string.Empty);
                        var p = ObjTrading.Where(m => m.Id == Convert.ToInt32(instrument)).FirstOrDefault();
                        if (p != null)
                        {
                            var items = data[2].Split(',');
                            GridColumnDataChanges(items, p);
                        }

                    }
                    else
                    {
                        var items = JsonConvert.DeserializeObject<string[]>(e.Message);
                        if (items.Count() > 3)
                        {
                            var p = ObjTrading.Where(m => m.Id == Convert.ToInt32(items[0])).FirstOrDefault();
                            if (p != null)
                            {
                                GridColumnDataChanges(items, p);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            }

        }
        private void GridColumnDataChanges(string[] items, FinexTicker p)
        {
            bool bidBlue = true;
            bool askBlue = true;
            int index = ObjTrading.IndexOf(p);
            if (Convert.ToDecimal(items[1]) > Convert.ToDecimal(p.bid))
            {
                this.dataGridMarketData.Rows[index].Cells[1].Style.ForeColor = Color.Blue;
            }
            else
            {
                this.dataGridMarketData.Rows[index].Cells[1].Style.ForeColor = Color.Red;
                bidBlue = false;
            }
            if (Convert.ToDecimal(items[3]) > Convert.ToDecimal(p.ask))
            {
                this.dataGridMarketData.Rows[index].Cells[2].Style.ForeColor = Color.Blue;
            }
            else
            {
                this.dataGridMarketData.Rows[index].Cells[2].Style.ForeColor = Color.Red;
                askBlue = false;
            }
            if (!bidBlue || !askBlue)
            {
                ((TextAndImageCell)dataGridMarketData.Rows[index].Cells[0]).Image = imgList.Images[0];
            }
            else
            {
                ((TextAndImageCell)dataGridMarketData.Rows[index].Cells[0]).Image = imgList.Images[1];
            }
            p.ask = Convert.ToString((items[3]));
            p.bid = Convert.ToString((items[1]));
            p.last_price = Convert.ToString(items[7]);
            p.volume = Convert.ToString(items[8]);
        }
        private void WebSocket_Closed(object sender, EventArgs e)
        {
            webSocket.Dispose();
            ObjTrading = new BindingList<FinexTicker>();
            webSocket = new WebSocket4Net.WebSocket(host);
            webSocket.Open();
            webSocket.Opened += WebSocket_Opened;
            webSocket.Closed += WebSocket_Closed;
            webSocket.Error += WebSocket_Error;

            webSocket.MessageReceived += WebSocket_MessageReceived;
        }

        private void WebSocket_Opened(object sender, EventArgs e)
        {
            List<webSocketListner> listWebList = new List<webSocketListner>();
            string symbols = string.Empty;
            using (var streamReader = new StreamReader(this.Name + ".txt"))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            if (symbols != null)
            {
                comman.Seprateticklers(symbols, ref sbBitfinex, ref sbTraders, ref sbIGMarket, ref sbICMarket);
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
                this.Invoke((Action)delegate ()
                {
                    dataGridMarketData.DataSource = ObjTrading;
                });
            }




        }

        public void AutoCompletetxtAddRow()
        {
            AutoCompleteStringCollection SymbolCollection = new AutoCompleteStringCollection();
            var result = instrumentMapping.SearchMapping();
            foreach (var item in result)
            {
                SymbolCollection.Add(item.BrokerCode + "." + item.BrokerInstrumentCode);
            }
            txtAddRow.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtAddRow.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtAddRow.AutoCompleteCustomSource = SymbolCollection;

        }

        private void dataGridMarketData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return; // header clicked

            if (e.ColumnIndex == dataGridMarketData.Columns["buttonColumn"].Index)
            {
                // Your logic here. You can gain access to any cell value via DataGridViewCellEventArgs
                string symbol = dataGridMarketData["Symbol", e.RowIndex].Value.ToString();
                string broker = dataGridMarketData["broker", e.RowIndex].Value.ToString();
                if (broker.ToLower() == Broker.BitFinex.ToString().ToLower())
                {
                    comman.ReadWriteNotepad(symbol, this.Name, webSocket);
                }
                else if (broker.ToLower() == Broker.MT.ToString().ToLower())
                {
                    MessageBox.Show(this, "Meta Trader symbol can not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmMarketWatchWin_FormClosing(object sender, FormClosingEventArgs e)
        {

            TabControl tabControl = this.MdiParent.Controls["tabControl1"] as TabControl;
            tabControl.TabPages.RemoveByKey(this.Name);

        }

        private void txtAddRow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //await AddSymbolTxtFile();
            }
        }


        private void frmMarketWatchWin_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridMarketData.Focus();
        }
        #region "Meta Trader"
        private void GetMetaTraderSymbols()
        {
            string symbols = string.Empty;
            using (var streamReader = new StreamReader(this.Name + ".txt"))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            if (symbols != null)
            {
                comman.Seprateticklers(symbols, ref sbBitfinex, ref sbTraders, ref sbIGMarket, ref sbICMarket);
                var quotes = mT4API.GetQuotes();
                foreach (var item in quotes)
                {
                    this.Invoke((Action)delegate ()
                   {
                       ObjTrading.Add(new FinexTicker { Id = 0, broker = Broker.MT.ToString().ToUpper(), pair = Broker.MT.ToString().ToUpper() + "." + item.Instrument, bid = item.Bid.ToString(), ask = item.Ask.ToString(), last_price = "0", volume = "0" });

                   });


                }
                dataGridMarketData.DataSource = ObjTrading;
            }

        }
        #endregion
    }
}
