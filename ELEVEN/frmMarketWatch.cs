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
        //private readonly BackgroundWorker worker = new BackgroundWorker();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DataTable dt = new DataTable();
        public frmMarketWatch()
        {
            InitializeComponent();
            dt.Columns.AddRange(new[]
            {
                new DataColumn("Symbol"),new DataColumn("Bid"),new DataColumn("Ask"),new DataColumn("Last"),new DataColumn("Volume"),new DataColumn("Spread"),new DataColumn("Manage"),
            });
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            string symbols = new StreamReader("Symbols.txt").ReadLine();
            string[][] ticker = PbBitfinexAPI.Get<string[][]>($"tickers?symbols="+ symbols);
            
            if(ticker!=null)
            {
                dt.Clear();
                for (int i = 0; i < ticker.Length; i++)
                {
                    dt.Rows.Add(ticker[i][0], ticker[i][1], ticker[i][3], ticker[i][7], ticker[i][8], "", "");
                }
                dataGridMarketData.DataSource = null;
                dataGridMarketData.DataSource = dt;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            }
           else
            {
                dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            }
            //worker.DoWork += worker_DoWork;
            //worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            //worker.RunWorkerAsync();
        }

        //private void worker_DoWork(object Sender, DoWorkEventArgs e)
        //{
        //    List<FinexTicker> ticker = PbBitfinexAPI.Get<FinexTicker>($"tickers?symbols=btcusd,ltcusd,ltcbtc,ethusd,ethbtc,etcbtc,etcusd,rrtusd,rrtbtc,zecusd,zecbtc,xmrusd");

        //    //btcusd,ltcusd,ltcbtc,ethusd,ethbtc,etcbtc,etcusd,rrtusd,rrtbtc,zecusd,zecbtc,xmrusd
        //    //var symbols = PbBitfinexAPI.GetSymbol("symbols");
        //    //symbols = symbols.Replace("[", "").Replace("]", "").Replace("\"", "");
        //    //string[] strings = symbols.Split(',');
        //    //foreach (var item in strings)
        //    //{
        //    //    var ticker = PbBitfinexAPI.Get<FinexTicker>($"pubticker/{item}");
        //    //    if (ticker != null)
        //    //    {
        //    //        dt.Rows.Add(item, ticker.bid, ticker.ask, ticker.last_price, ticker.volume);
        //    //    }
        //    //}
        //    e.Result = ticker;
        //}
        //private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    dataGridMarketData.DataSource = null;
        //    dataGridMarketData.DataSource = e.Result;
        //}
    }
}
