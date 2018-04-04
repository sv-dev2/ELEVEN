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

namespace ELEVEN
{
    public partial class frmMarketWatchWin : Form
    {
        public frmMarketWatchWin()
        {
            InitializeComponent();
            txtAddRow.GotFocus += TxtQuantity_GotFocus;
            txtAddRow.LostFocus += TxtQuantity_LostFocus;

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
                string symbols = "tBTCUSD";
                using (System.IO.StreamWriter file =
              new System.IO.StreamWriter(fileName, false))
                {
                    file.Write(symbols);
                    file.Close();
                }
            }
        }
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
        private BindingSource bindingSource2 = new BindingSource();
        BindingList<FinexTicker> oldCustomerList = new BindingList<FinexTicker>();
        List<OldData> OldWatchList = new List<OldData>();


        System.Windows.Forms.DataGridViewImageColumn buttonColumn = new System.Windows.Forms.DataGridViewImageColumn();
        private void CreateDataGridColumn()
        {
            dataGridMarketData.DataSource = null;
            this.dataGridMarketData.Rows.Clear();
            dataGridMarketData.AutoGenerateColumns = false;
            dataGridMarketData.ColumnCount = 5;

            dataGridMarketData.Columns[0].Name = "Symbol";
            dataGridMarketData.Columns[0].HeaderText = "Symbol";
            dataGridMarketData.Columns[0].DataPropertyName = "pair";
            dataGridMarketData.Columns[0].Width = 60;

            dataGridMarketData.Columns[1].HeaderText = "Bid";
            dataGridMarketData.Columns[1].Name = "Bid";
            dataGridMarketData.Columns[1].DataPropertyName = "bid";
            dataGridMarketData.Columns[1].Width = 60;

            dataGridMarketData.Columns[2].Name = "Ask";
            dataGridMarketData.Columns[2].HeaderText = "Ask";
            dataGridMarketData.Columns[2].DataPropertyName = "ask";
            dataGridMarketData.Columns[2].Width = 60;

            dataGridMarketData.Columns[3].Name = "Last";
            dataGridMarketData.Columns[3].HeaderText = "Last";
            dataGridMarketData.Columns[3].DataPropertyName = "last_price";
            dataGridMarketData.Columns[3].Width = 60;

            dataGridMarketData.Columns[4].Name = "Volume";
            dataGridMarketData.Columns[4].HeaderText = "Volume";
            dataGridMarketData.Columns[4].DataPropertyName = "volume";
            dataGridMarketData.Columns[4].Width = 63;


            buttonColumn.HeaderText = "";
            buttonColumn.Name = "buttonColumn";
            Image image = ELEVEN.Properties.Resources.Delete;

            buttonColumn.Image = image;
            buttonColumn.Width = 15;
            dataGridMarketData.Columns.Insert(5, buttonColumn);

            dataGridMarketData.DataSource = bindingSource2;
        }


        private void TxtQuantity_LostFocus(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtAddRow.Text))
                txtAddRow.Text = "click to add..";
        }

        private void TxtQuantity_GotFocus(object sender, EventArgs e)
        {
            txtAddRow.Text = string.Empty;
        }
        private void frmMarketWatch_Load(object sender, EventArgs e)
        {
            txtAddRow.Text = "click to add..";
            SymbolFileExist();
            LoadMarketWatch();
            CreateDataGridColumn();
            AutoCompletetxtAddRow();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            backgroundWorker2.RunWorkerAsync();
        }
        private void AutoCompletetxtAddRow()
        {
            AutoCompleteStringCollection SymbolCollection = new AutoCompleteStringCollection();
            var All_Symbol = PbBitfinexAPI.GetSymbol($"symbols");
            var Smbl = All_Symbol.Replace("[", "").Replace("]", "").Replace("\"", "").Split(',').Select(d => new[] { d.ToUpper() }).ToArray();
            for (int i = 0; i < Smbl.Count(); i++)
            {
                SymbolCollection.Add(Smbl[i][0]);
            }
            txtAddRow.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtAddRow.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtAddRow.AutoCompleteCustomSource = SymbolCollection;

        }
        private async void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            await LoadMarketWatch();
            CreateDataGridColumn();
            if (Index >= 0)
            {
                dataGridMarketData.Rows[Index].Selected = true;
            }
        }
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            dispatcherTimer1.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer1.Start();
        }
        string[][] ticker;
        private async Task LoadMarketWatch()
        {
            string symbols = string.Empty;
            using (var streamReader = new StreamReader(fileName))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            ticker = await PbBitfinexAPI.GetTiclers<string[][]>($"tickers?symbols=" + symbols);

            if (ticker != null)
            {
                // dt.Clear();
                oldCustomerList = this.bindingSource2.DataSource as BindingList<FinexTicker>;
                if (oldCustomerList != null)
                {
                    OldWatchList = new List<OldData>();
                    foreach (var item in oldCustomerList)
                    {
                        OldData oldWatch = new OldData();
                        oldWatch.ask = item.ask;
                        oldWatch.bid = item.bid;
                        oldWatch.last_price = item.last_price;
                        oldWatch.pair = item.pair;
                        oldWatch.volume = item.volume;
                        OldWatchList.Add(oldWatch);
                    }
                }
                bindingSource2.Clear();

                BindingList<FinexTicker> customerList = new BindingList<FinexTicker>();
                for (int i = 0; i < ticker.Length; i++)
                {
                    //dt.Rows.Add(ticker[i][0], ticker[i][1], ticker[i][3], ticker[i][7], ticker[i][8], "", "");                    
                    //dt.Rows.Add(ticker[i][0].Replace("t", ""), ticker[i][1], ticker[i][3], ticker[i][7], ticker[i][8], "");
                    customerList.Add(new FinexTicker { pair = ticker[i][0].Replace("t", ""), bid = ticker[i][1], ask = ticker[i][3], last_price = ticker[i][7], volume = ticker[i][8] });
                }
                this.bindingSource2.DataSource = customerList;
                //dispatcherTimer1.Interval = new TimeSpan(0, 0, 3);
            }
            else
            {
                dispatcherTimer1.Interval = new TimeSpan(0, 1, 0);
            }
        }
        int Index = -1;
        private void dataGridMarketData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Index = e.RowIndex;
        }
        private void dataGridMarketData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //var height = 40;
            foreach (DataGridViewRow dr in dataGridMarketData.Rows)
            {

            }
        }



        private async void dataGridMarketData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return; // header clicked

            if (e.ColumnIndex == dataGridMarketData.Columns["buttonColumn"].Index)
            {
                // Your logic here. You can gain access to any cell value via DataGridViewCellEventArgs
                string symbol = dataGridMarketData["Symbol", e.RowIndex].Value.ToString();
                await ReadWriteNotepad(symbol);
            }
        }
        private async Task ReadWriteNotepad(string symbol)
        {
            string symbols = string.Empty;
            using (var streamReader = new StreamReader(fileName))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            symbols = symbols.Replace(",t" + symbol, "");

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(fileName, false))
            {
                file.Write(symbols);
                file.Close();
            }
            await LoadMarketWatch();
            CreateDataGridColumn();
        }



        private void dataGridMarketData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var oldValue = dataGridMarketData[e.ColumnIndex, e.RowIndex].Value;
            var newValue = e.FormattedValue;
            if (oldValue != newValue)
            {

            }
        }

        private void dataGridMarketData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == this.dataGridMarketData.Columns["bid"].Index)
            {
                if (e.Value != null)
                {
                    var symbol = this.dataGridMarketData["Symbol", e.RowIndex].Value;
                    if (OldWatchList.Count > 0)
                    {
                        var result = OldWatchList.Where(m => m.pair == symbol.ToString()).FirstOrDefault();
                        string RepVisits = e.Value.ToString();
                        if (result != null)
                        {
                            if (Convert.ToDecimal(RepVisits) >= Convert.ToDecimal(result.bid))
                            {
                                this.dataGridMarketData.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor = Color.Blue;
                            }
                            else
                            {
                                this.dataGridMarketData.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor = Color.Red;
                            }
                        }
                    }

                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == this.dataGridMarketData.Columns["ask"].Index)
            {
                if (e.Value != null)
                {
                    var symbol = this.dataGridMarketData["Symbol", e.RowIndex].Value;
                    if (OldWatchList.Count > 0)
                    {
                        var result = OldWatchList.Where(m => m.pair == symbol.ToString()).FirstOrDefault();
                        string RepVisits = e.Value.ToString();
                        if (result != null)
                        {
                            if (Convert.ToDecimal(RepVisits) >= Convert.ToDecimal(result.ask))
                            {
                                this.dataGridMarketData.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor = Color.Blue;
                            }
                            else
                            {
                                this.dataGridMarketData.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor = Color.Red;
                            }
                        }
                    }

                }
            }
        }
        private void frmMarketWatchWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            dispatcherTimer1.Stop();
            TabControl tabControl = this.MdiParent.Controls["tabControl1"] as TabControl;
            tabControl.TabPages.RemoveByKey(this.Name);
            string name = this.Name;
            string fileName = name + ".txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        private void txtAddRow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AddSymbolTxtFile();
            }
        }
        private void AddSymbolTxtFile()
        {
            string symbols = string.Empty;
            using (var streamReader = new StreamReader(this.Name+".txt"))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            if (!symbols.Contains("t" + txtAddRow.Text))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.Name+".txt", true))
                {
                    file.Write(",t" + txtAddRow.Text);
                    file.Close();
                }
            }
            LoadMarketWatch();
            CreateDataGridColumn();
        }
    }
}
