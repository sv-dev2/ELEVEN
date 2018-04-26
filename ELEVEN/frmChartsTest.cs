using DevExpress.XtraCharts;
using ELEVEN.Models;
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

namespace ELEVEN
{
    public partial class frmChartsTest : Form
    {
        private MDIParentForm parentForm;

        public BindingList<CandleData> candleData;
        BindingList<CandleDataMT> candleDataMT;
        public string broker { get; set; }
        public string symbol { get; set; }
        private MT4API mT4API { get; set; }
        public frmChartsTest(MDIParentForm parentForm, string broker, string symbol)
        {
            InitializeComponent();
            candleData = new BindingList<CandleData>();
            //BindCharts();
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
        private void frmChartsTest_Load(object sender, EventArgs e)
        {
            //BindDataSource();
        }
        public void BindDataSource()
        {
            candleDataMT = (BindingList<CandleDataMT>)mT4API.HistoricalCandles(symbol);
            if (mT4API.listCandles.Count > 0)
            {
                var max = mT4API.listCandles.Max(m => m.High);
                var min = mT4API.listCandles.Min(m => m.Low);
                //chart1.ChartAreas["ChartArea1"].AxisY.Minimum = min;
                //chart1.ChartAreas["ChartArea1"].AxisY.Maximum = max;
            }
            // chart1.DataSource = mT4API.listCandles;
        }
        //public ChartControl chart1 = new ChartControl();
        //private void BindCharts()
        //{
        //    // Create a new chart.


        //    // Create a candlestick series.
        //    Series series1 = new Series("Stock Prices", ViewType.CandleStick);

        //    // Specify the date-time argument scale type for the series,
        //    // as it is qualitative, by default.
        //    series1.ArgumentScaleType = ScaleType.DateTime;

          

        //    // Add the series to the chart.
        //    chart1.Series.Add(series1);

        //    // Access the view-type-specific options of the series.
        //    CandleStickSeriesView myView = (CandleStickSeriesView)series1.View;

        //    myView.LineThickness = 2;
        //    myView.LevelLineLength = 0.25;

        //    // Specify the series reduction options.
        //    myView.ReductionOptions.ColorMode = ReductionColorMode.OpenToCloseValue;
        //    myView.ReductionOptions.FillMode = CandleStickFillMode.FilledOnReduction;
        //    myView.ReductionOptions.Level = StockLevel.Open;
        //    myView.ReductionOptions.Visible = true;

        //    // Access the chart's diagram.
        //  //  XYDiagram diagram = ((XYDiagram)chart1.Diagram);

        //    // Access the type-specific options of the diagram.
        //  //  diagram.AxisY.WholeRange.MinValue = 22;

        //    // Exclude weekends from the X-axis range,
        //    // to avoid gaps in the chart's data.
        //   // diagram.AxisX.DateTimeScaleOptions.WorkdaysOnly = true;

        //    // Hide the legend (if necessary).
        //    chart1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

        //    // Add a title to the chart (if necessary).
        //    //candlestickChart.Titles.Add(new ChartTitle());
        //    // candlestickChart.Titles[0].Text = "Candlestick Chart";

        //    // Add the chart to the form.
           
        //    chart1.Dock = DockStyle.Fill;
        //    this.Controls.Add(chart1);
        //}
    }
}
