using DockSample;
using ELEVEN.Model;
using ELEVEN.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private readonly BackgroundWorker worker = new BackgroundWorker();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DataTable dt;
        public frmMarketWatch()
        {
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.AddRange(new[]
            {
                new DataColumn("Symbol"),new DataColumn("Bid"),new DataColumn("Ask"),new DataColumn("Last"),new DataColumn("Volume"),new DataColumn("Spread"),new DataColumn("Manage"),
            });
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }
        private void worker_DoWork(object Sender, DoWorkEventArgs e)
        {
            List<User> aa = new List<User>();
            var symbols = PbBitfinexAPI.GetSymbol("symbols");
            symbols = symbols.Replace("[", "").Replace("]", "").Replace("\"", "");
            string[] strings = symbols.Split(',');
            foreach (var item in strings)
            {
                var ticker = PbBitfinexAPI.Get<FinexTicker>($"pubticker/{item}");
                if (ticker != null)
                    //aa.Add();

                    dt.Rows.Add(item, ticker.bid, ticker.ask, ticker.last_price, ticker.volume);
            }
            e.Result = dt;
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridMarketData.DataSource = null;
            dataGridMarketData.DataSource = e.Result as DataTable;
        }
    }
}
