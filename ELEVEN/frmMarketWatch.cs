using DockSample;
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
using WeifenLuo.WinFormsUI.Docking;

namespace ELEVEN
{
    public partial class frmMarketWatch : DockContent
    {
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DataTable dt = new DataTable();
        public frmMarketWatch()
        {
            InitializeComponent();

            txtAddRow.GotFocus += TxtQuantity_GotFocus;
            txtAddRow.LostFocus += TxtQuantity_LostFocus;

         
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
            dataGridMarketData.Columns[0].DataPropertyName = "Symbol";
            dataGridMarketData.Columns[0].Width = 60;

            dataGridMarketData.Columns[1].HeaderText = "Bid";
            dataGridMarketData.Columns[1].Name = "Bid";
            dataGridMarketData.Columns[1].DataPropertyName = "Bid";
            dataGridMarketData.Columns[1].Width = 60;

            dataGridMarketData.Columns[2].Name = "Ask";
            dataGridMarketData.Columns[2].HeaderText = "Ask";
            dataGridMarketData.Columns[2].DataPropertyName = "Ask";
            dataGridMarketData.Columns[2].Width = 60;

            dataGridMarketData.Columns[3].Name = "Last";
            dataGridMarketData.Columns[3].HeaderText = "Last";
            dataGridMarketData.Columns[3].DataPropertyName = "Last";
            dataGridMarketData.Columns[3].Width = 60;

            dataGridMarketData.Columns[4].Name = "Volume";
            dataGridMarketData.Columns[4].HeaderText = "Volume";
            dataGridMarketData.Columns[4].DataPropertyName = "Volume";
            dataGridMarketData.Columns[4].Width = 63;


            buttonColumn.HeaderText = "";
            buttonColumn.Name = "buttonColumn";
            Image image = ELEVEN.Properties.Resources.Delete;

            buttonColumn.Image = image;
            buttonColumn.Width = 15;
            dataGridMarketData.Columns.Insert(5, buttonColumn);


            dataGridMarketData.DataSource = dt;
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
            dt.Columns.AddRange(
             new[]{
               // new DataColumn("Symbol"),new DataColumn("Bid"),new DataColumn("Ask"),new DataColumn("Last"),new DataColumn("Volume"),new DataColumn("Spread"),new DataColumn("Manage"),
                new DataColumn("Symbol"),new DataColumn("Bid"),new DataColumn("Ask"),new DataColumn("Last"),new DataColumn("Volume"),new DataColumn("Remove")
         });
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.RunWorkerAsync();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            LoadMarketWatch();
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

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
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
                dt.Clear();

                for (int i = 0; i < ticker.Length; i++)
                {
                    //dt.Rows.Add(ticker[i][0], ticker[i][1], ticker[i][3], ticker[i][7], ticker[i][8], "", "");                    
                    dt.Rows.Add(ticker[i][0].Replace("t", ""), ticker[i][1], ticker[i][3], ticker[i][7], ticker[i][8], "");
                }
                dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            }
            else
            {
                dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
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
            //foreach (DataGridViewRow dr in dataGridMarketData.Rows)
            //{
            //    height += dr.Height;
            //}

            //dataGridMarketData.Height = height;
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
                file.WriteLine(symbols);
                file.Close();
            }
            LoadMarketWatch();
            CreateDataGridColumn();
        }
    }
}
