using DockSample;
using ELEVEN.Model;
using ELEVEN.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using WeifenLuo.WinFormsUI.Docking;

namespace ELEVEN
{
    public partial class frmMarketWatch : DockContent
    {

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        // DataTable dt = new DataTable();
        private BindingSource bindingSource1 = new BindingSource();
        BindingList<FinexTicker> ObjTrading = new BindingList<FinexTicker>();

        List<OldData> OldWatchList = new List<OldData>();
        public frmMarketWatch()
        {
            InitializeComponent();
            AutoCompletetxtAddRow();
            txtAddRow.GotFocus += TxtQuantity_GotFocus;
            txtAddRow.LostFocus += TxtQuantity_LostFocus;
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
            //foreach (DataRow dr in dt.Rows)
            //{

            //    dataGridMarketData.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);

            //}
            // dataGridMarketData.DataSource = bindingSource1;
            dataGridMarketData.Height = 20* ObjTrading.Count()+34;
            txtAddRow.Location = new Point(0, 20 * ObjTrading.Count() + 36);
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
        private void frmMarketWatch_Load(object sender, EventArgs e)
        {
            txtAddRow.Text = "click to add..";
            IntialLoadMarketWatch();
            CreateDataGridColumn();

            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.RunWorkerAsync();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            LoadMarketWatch();
            // CreateDataGridColumn();
            //if (Index >= 0)
            //{
            //    dataGridMarketData.Rows[Index].Selected = true;
            //}
        }
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void IntialLoadMarketWatch()
        {
            string symbols = string.Empty;
            using (var streamReader = new StreamReader("Symbols.txt"))
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
        string[][] ticker;
        private void LoadMarketWatch()
        {
            string symbols = string.Empty;
            using (var streamReader = new StreamReader("Symbols.txt"))
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
                            if (Convert.ToDecimal(result.bid) > Convert.ToDecimal(oldResult.bid))
                            {
                                this.dataGridMarketData.Rows[i].Cells[1].Style.ForeColor = Color.Blue;
                            }
                            else
                            {
                                this.dataGridMarketData.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                            }
                            if (Convert.ToDecimal(result.ask) > Convert.ToDecimal(oldResult.ask))
                            {
                                this.dataGridMarketData.Rows[i].Cells[2].Style.ForeColor = Color.Blue;
                            }
                            else
                            {
                                this.dataGridMarketData.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                            }
                            result.last_price = ticker[i][7];
                            result.volume = ticker[i][8];
                        }

                    }
                }
               // dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            }
            else
            {
                dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            }
        }


        private void dataGridMarketData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return; // header clicked

            if (e.ColumnIndex == dataGridMarketData.Columns["buttonColumn"].Index)
            {
                // Your logic here. You can gain access to any cell value via DataGridViewCellEventArgs
                string symbol = dataGridMarketData["Symbol", e.RowIndex].Value.ToString();
                ReadWriteNotepad(symbol);
            }
        }
        private void ReadWriteNotepad(string symbol)
        {
            string symbols = string.Empty;
            using (var streamReader = new StreamReader("Symbols.txt"))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            symbols = symbols.Replace(",t" + symbol, "");

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"Symbols.txt", false))
            {
                file.Write(symbols);
                file.Close();
            }
            IntialLoadMarketWatch();
            CreateDataGridColumn();
        }


        private void txtAddRow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                // AddSymbolTxtFile();
            }

        }

        private void AddSymbolTxtFile()
        {
            dispatcherTimer.Stop();
            string symbols = string.Empty;
            using (var streamReader = new StreamReader("Symbols.txt"))
            {
                symbols = streamReader.ReadLine();
                streamReader.Close();
            }
            if (!symbols.Contains("t" + txtAddRow.Text))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Symbols.txt", true))
                {
                    file.Write(",t" + txtAddRow.Text);
                    file.Close();
                }
            }
            IntialLoadMarketWatch();
            CreateDataGridColumn();
            dispatcherTimer.Start();
        }

        private void frmMarketWatch_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridMarketData.Focus();
        }


    }
}
