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
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
        private BindingSource bindingSource2 = new BindingSource();
        BindingList<FinexTicker> oldCustomerList = new BindingList<FinexTicker>();
        BindingList<FinexTicker> ObjTrading = new BindingList<FinexTicker>();
        List<OldData> OldWatchList = new List<OldData>();
        public frmMarketWatchWin()
        {
            InitializeComponent();
            AutoCompletetxtAddRow();
           
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



        System.Windows.Forms.DataGridViewImageColumn buttonColumn = new System.Windows.Forms.DataGridViewImageColumn();
        TextAndImageColumn column = new TextAndImageColumn();
        ImageList imgList = new ImageList();
        private void CreateDataGridColumn()
        {
            dataGridMarketData.DataSource = null;
            this.dataGridMarketData.Rows.Clear();
            dataGridMarketData.AutoGenerateColumns = false;
            dataGridMarketData.ColumnCount = 4;

            imgList.Images.Add(Properties.Resources.arrowred);
            imgList.Images.Add(Properties.Resources.arrowgreen);
            imgList.ImageSize = new Size(12, 17);
            imgList.TransparentColor = Color.Transparent;

            column.Image = imgList.Images[1];

            column.Name = "Symbol";
            column.HeaderText = "Symbol";
            column.DataPropertyName = "pair";
            column.Width = 60;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridMarketData.Columns.Insert(0, column);

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
            dataGridMarketData.Height = 25 * ObjTrading.Count() + 34;
            //txtAddRow.Location = new Point(0, 20 * ObjTrading.Count() + 36);
            dataGridMarketData.DataSource = ObjTrading;
        }
        public void ReBindDataSource()
        {
            dataGridMarketData.DataSource = null;
            this.dataGridMarketData.Rows.Clear();
            dataGridMarketData.Height = 25 * ObjTrading.Count() + 34;
            //txtAddRow.Location = new Point(0, 20 * ObjTrading.Count() + 36);
            dataGridMarketData.DataSource = ObjTrading;
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
                    AddSymbolTxtFile();
                    txtAddRow.Text = "click to add..";
                }

            }
        }

        private void TxtQuantity_GotFocus(object sender, EventArgs e)
        {
            txtAddRow.Text = string.Empty;
        }
        private async void frmMarketWatch_Load(object sender, EventArgs e)
        {
            txtAddRow.Text = "click to add..";
            SymbolFileExist();
            await IntialLoadMarketWatch();    
            CreateDataGridColumn();
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
        }
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        private async Task IntialLoadMarketWatch()
        {
            string symbols = string.Empty;

            using (var streamReader = new StreamReader(this.Name + ".txt"))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            ticker = PbBitfinexAPI.Get<string[][]>($"tickers?symbols=" + symbols);

            if (ticker != null)
            {

                BindingList<FinexTicker> customerList = new BindingList<FinexTicker>();
                for (int i = 0; i < ticker.Length; i++)
                {

                    customerList.Add(new FinexTicker { pair = ticker[i][0].Replace("t", ""), bid = ticker[i][1], ask = ticker[i][3], last_price = ticker[i][7], volume = ticker[i][8] });
                }
                //this.bindingSource1.DataSource = customerList;
                ObjTrading = customerList;
            }

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
            using (var streamReader = new StreamReader(this.Name + ".txt"))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            ticker = PbBitfinexAPI.Get<string[][]>($"tickers?symbols=" + symbols);

            if (ticker != null)
            {
                // dt.Clear();
                var bindingSource = this.dataGridMarketData.DataSource as BindingList<FinexTicker>;
                if (bindingSource != null)
                {
                    OldWatchList = new List<OldData>();
                    foreach (var item in bindingSource)
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

                BindingList<FinexTicker> customerList = new BindingList<FinexTicker>();
                for (int i = 0; i < ticker.Length; i++)
                {

                    if (bindingSource != null)
                    {
                        var result = bindingSource.Where(d => d.pair == ticker[i][0].Replace("t", "")).FirstOrDefault();
                        var oldResult = OldWatchList.Where(d => d.pair == ticker[i][0].Replace("t", "")).FirstOrDefault();
                        if (result != null)
                        {
                            result.ask = ticker[i][3];
                            result.bid = ticker[i][1];
                            bool bidBlue = true;
                            bool askBlue = true;
                            if (Convert.ToDecimal(result.bid) > Convert.ToDecimal(oldResult.bid))
                            {
                                this.dataGridMarketData.Rows[i].Cells[1].Style.ForeColor = Color.Blue;
                            }
                            else
                            {
                                this.dataGridMarketData.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                                bidBlue = false;
                            }
                            if (Convert.ToDecimal(result.ask) > Convert.ToDecimal(oldResult.ask))
                            {
                                this.dataGridMarketData.Rows[i].Cells[2].Style.ForeColor = Color.Blue;
                            }
                            else
                            {
                                this.dataGridMarketData.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                                askBlue = false;
                            }
                            if (!bidBlue || !askBlue)
                            {
                                ((TextAndImageCell)dataGridMarketData.Rows[i].Cells[0]).Image = imgList.Images[0];
                            }
                            else
                            {
                                ((TextAndImageCell)dataGridMarketData.Rows[i].Cells[0]).Image = imgList.Images[1];
                            }
                            result.last_price = ticker[i][7];
                            result.volume = ticker[i][8];
                        }

                    }
                }
                dispatcherTimer1.Interval = new TimeSpan(0, 0, 3);
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
            using (var streamReader = new StreamReader(this.Name + ".txt"))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            symbols = symbols.Replace(",t" + symbol, "");

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(this.Name + ".txt", false))
            {
                file.Write(symbols);
                file.Close();
            }
            await IntialLoadMarketWatch();
            ReBindDataSource();
        }
        private void frmMarketWatchWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            dispatcherTimer1.Stop();
            TabControl tabControl = this.MdiParent.Controls["tabControl1"] as TabControl;
            tabControl.TabPages.RemoveByKey(this.Name + ".txt");
            string name = this.Name;
            string fileName = name + ".txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        private async void txtAddRow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //await AddSymbolTxtFile();
            }
        }
        private async Task AddSymbolTxtFile()
        {
            dispatcherTimer1.Stop();
            string symbols = string.Empty;
            using (var streamReader = new StreamReader(this.Name + ".txt"))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            if (!symbols.Contains("t" + txtAddRow.Text))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.Name + ".txt", true))
                {
                    file.Write(",t" + txtAddRow.Text);
                    file.Close();
                }
            }
            await IntialLoadMarketWatch();
            ReBindDataSource();
            dispatcherTimer1.Start();
        }

        private void frmMarketWatchWin_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridMarketData.Focus();
        }
    }
}
