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
        StringBuilder sbBitfinex = new StringBuilder();
        StringBuilder sbTraders = new StringBuilder();
        StringBuilder sbIGMarket = new StringBuilder();
        StringBuilder sbICMarket = new StringBuilder();

        private BindingSource bindingSource2 = new BindingSource();
        BindingList<FinexTicker> oldCustomerList = new BindingList<FinexTicker>();
        public BindingList<FinexTicker> ObjTrading = new BindingList<FinexTicker>();
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
           
            #endregion

        }

        private void frmMarketWatch_Load(object sender, EventArgs e)
        {
            txtAddRow.Text = "click to add..";
            SymbolFileExist();
            CreateDataGridColumn();
            BitfinexWatchlistSocket.Instance.Init(this);
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
                    BitfinexWatchlistSocket.Instance.AddSymbolTxtFile(this, txtAddRow);
                    txtAddRow.Text = "click to add..";
                }

            }
        }

        private void TxtQuantity_GotFocus(object sender, EventArgs e)
        {
            txtAddRow.Text = string.Empty;
        }


      
        BindingList<FinexTicker> list = new BindingList<FinexTicker>();
       
      
     

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
                    // comman.ReadWriteNotepad(symbol, this.Name, webSocket);//TODO
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
            var formObj = BitfinexWatchlistSocket.Instance.listForms.Where(m => m.form == this).FirstOrDefault();
            if(formObj != null)
            {
                BitfinexWatchlistSocket.Instance.listForms.Remove(formObj);
            }
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
