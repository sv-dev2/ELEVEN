using ComponentFactory.Krypton.Toolkit;
using ELEVEN.Models;
using ELEVEN.Services;
using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocket4Net;

namespace ELEVEN
{
    public partial class frmCharts : KryptonForm
    {
        private MDIParentForm parentForm;

        public BindingList<CandleData> candleData;
        BindingList<CandleDataMT> candleDataMT;
        public string broker { get; set; }
        public string symbol { get; set; }
        private MT4API mT4API { get; set; }
        public frmCharts(MDIParentForm parentForm, string broker, string symbol)
        {
            InitializeComponent();
            candleData = new BindingList<CandleData>();

            this.parentForm = parentForm;
            this.broker = broker;
            this.symbol = symbol;
            if (broker.ToLower() == "bitfinex")
                InitBitFinex();
            else
            {
                mT4API = new MT4API(this);
                candleDataMT = new BindingList<CandleDataMT>();
            }
            this.Text = broker + "." + symbol.Replace("t", "");
        }
        private void InitBitFinex()
        {
            BitfinexSocket.Instance.Init(symbol, this);
           
        }


        private void CustomizedLineSeries_Load(object sender, EventArgs e)
        {
            ChartSettings();
            if (mT4API != null)
            {
                BindDataSource();
            }
        }
        public void BindDataSource()
        {
            candleDataMT = (BindingList<CandleDataMT>)mT4API.HistoricalCandles(symbol);
            if (mT4API.listCandles.Count > 0)
            {
                var max = mT4API.listCandles.Max(m => m.High);
                var min = mT4API.listCandles.Min(m => m.Low);
                chart1.ChartAreas["ChartArea1"].AxisY.Minimum = min;
                chart1.ChartAreas["ChartArea1"].AxisY.Maximum = max;
            }
            chart1.DataSource = mT4API.listCandles;
            //chart1.DataBind();
        }
        private void ChartSettings()
        {
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

            chart1.Series["Series1"].XValueMember = "MTS";
            chart1.Series["Series1"].YValueMembers = "High,Low,Open,Close";
            chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.Series["Series1"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Blue";
            chart1.Series["Series1"]["ShowOpenClose"] = "Both";
            chart1.Series["Series1"]["OpenCloseStyle"] = "Triangle";
            chart1.DataManipulator.IsStartFromFirst = true;
        }
        private void frmCharts_FormClosing(object sender, FormClosingEventArgs e)
        {

            TabControl tabControl = parentForm.Controls["tabControl1"] as TabControl;
            tabControl.TabPages.RemoveByKey(this.Name);
            var formObj = BitfinexSocket.Instance.listForms.Where(m => m.form == this).FirstOrDefault();
            if (formObj != null)
            {
                BitfinexSocket.Instance.listForms.Remove(formObj);
            }
        }
    }
}
