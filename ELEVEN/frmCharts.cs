using ComponentFactory.Krypton.Toolkit;
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
using System.Windows.Forms.DataVisualization.Charting;


namespace ELEVEN
{
    public partial class frmCharts : KryptonForm
    {
        private MDIParentForm parentForm;

        public BindingList<CandleData> candleData;
        BindingList<CandleDataMT> candleDataMT;
        public List<ChartZoomOut> zoomList { get; set; }
        public string broker { get; set; }
        public string symbol { get; set; }
        private MT4API mT4API { get; set; }
        public List<string> annotationList = new List<string>();
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
            zoomList = new List<ChartZoomOut>();
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
        }
        private void ChartSettings()
        {

            chart1.Series["Series1"].XValueMember = "MTS";
            chart1.Series["Series1"].YValueMembers = "High,Low,Open,Close";
            chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.Series["Series1"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Blue";
            chart1.Series["Series1"]["ShowOpenClose"] = "Both";
            chart1.Series["Series1"]["OpenCloseStyle"] = "Triangle";
            chart1.DataManipulator.IsStartFromFirst = true;
            this.chart1.ChartAreas[0].AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            //chart1.MouseWheel += Chart1_MouseWheel;
            chart1.MouseDown += Chart1_MouseDown;
            chart1.MouseMove += chart1_MouseMove;
        }
        double mDown = double.NaN;
        private void Chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (zoomList.Count <= 0 || !isPan)
            {
                return;
            }
            Axis ax = chart1.ChartAreas[0].AxisX;
            mDown = ax.PixelPositionToValue(e.Location.X);
        }
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (zoomList.Count <= 0 || !isPan)
            {
                return;
            }
            try
            {
                if (!e.Button.HasFlag(MouseButtons.Left)) return;
                Axis ax = chart1.ChartAreas[0].AxisX;
                double range = ax.Maximum - ax.Minimum;
                double xv = ax.PixelPositionToValue(e.Location.X);
                double oldPos = ax.ScaleView.Position;
                ax.ScaleView.Position -= (xv - mDown);
            }
            catch
            {


            }

        }
        private void Chart1_MouseWheel(object sender, MouseEventArgs e)
        {

            try
            {
                if (e.Delta < 0)
                {
                    chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
                    chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
                }

                if (e.Delta > 0)
                {
                    double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    double yMin = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                    double yMax = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                    double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 5;
                    double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 5;
                    double posYStart = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 5;
                    double posYFinish = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 5;

                    chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                    chart1.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
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

        private void frmCharts_Shown(object sender, EventArgs e)
        {
            //chart1.EnableZoomAndPanControls(ChartCursorSelected, ChartCursorMoved,
            //   zoomChanged,
            //   new ChartOption()
            //   {
            //       ContextMenuAllowToHideSeries = true,
            //       XAxisPrecision = 0,
            //       YAxisPrecision = 2,

            //   });

        }

        private void zoomChanged(Chart sender)
        {

        }

        private void ChartCursorMoved(Chart sender, ChartCursor cursor)
        {
            // txtChartValue.Text = x.ToString("F4") + ", " + y.ToString("F4");
        }

        private void ChartCursorSelected(Chart sender, ChartCursor cursor)
        {
            //txtChartSelect.Text = x.ToString("F4") + ", " + y.ToString("F4");
        }
        KryptonButton ZoomIn;
        KryptonButton ZoomOut;
        bool firstVisit = false;
        private void BtnToggleZoom_Click(object sender, EventArgs e)
        {
            ZoomIn = sender as KryptonButton;
            chart1.Cursor = System.Windows.Forms.Cursors.Default;
            isPan = false;
            firstVisit = true;
            if (zoomList.Count < 5)
            {
                double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double yMin = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                double yMax = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum;
                int width = this.Width;
                int height = this.Height;
                double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(width / 2) - (xMax - xMin) / 5;
                double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(width / 2) + (xMax - xMin) / 5;
                double posYStart = chart1.ChartAreas[0].AxisY.PixelPositionToValue(height / 2) - (yMax - yMin) / 2;
                double posYFinish = chart1.ChartAreas[0].AxisY.PixelPositionToValue(height / 2) + (yMax - yMin) / 2;

                chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                chart1.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                zoomList.Add(new ChartZoomOut { Index = zoomList.Count + 1, PosXFinish = posXFinish, PosXStart = posXStart, PosYFinish = posYFinish, PosYStart = posYStart });
                if (ZoomOut != null)
                {
                    ZoomOut.Enabled = true;
                }
            }
            else
            {
                ZoomIn.Enabled = false;
            }
        }





        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            chart1.Cursor = System.Windows.Forms.Cursors.Default;
            isPan = false;
            ZoomOut = sender as KryptonButton;
            if (zoomList.Count > 0)
            {
                if (firstVisit)
                {
                    var firstPoint = zoomList.OrderByDescending(m => m.Index).FirstOrDefault();
                    zoomList.Remove(firstPoint);
                    firstVisit = false;
                }
                var points = zoomList.OrderByDescending(m => m.Index).FirstOrDefault();
                if (points != null)
                {
                    chart1.ChartAreas[0].AxisX.ScaleView.Zoom(points.PosXStart, points.PosXFinish);
                    chart1.ChartAreas[0].AxisY.ScaleView.Zoom(points.PosYStart, points.PosYFinish);
                    zoomList.Remove(points);
                }
                else
                {
                    chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                    chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
                    ZoomOut.Enabled = false;
                }

                if (ZoomIn != null)
                {
                    ZoomIn.Enabled = true;
                }
            }
            else
            {
                chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
                ZoomOut.Enabled = false;
            }
        }
        bool isPan = false;
        private void BtnPan_Click(object sender, EventArgs e)
        {
            isPan = true;
            chart1.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void BtnAddText_Click(object sender, EventArgs e)
        {
            isPan = false;
            //CalloutAnnotation a = new CalloutAnnotation();
            //a.Text = "My Annotation";
            //a.ToolTip = "Annotation tool tip";
            //a.ForeColor = Color.Green;          
            //a.AnchorDataPoint = chart1.Series[0].Points[0];
            //a.Visible = true;
            //a.LineWidth = 2;
            //chart1.Annotations.Add(a);

            var annotation = new frmAnnotation();
            var result = annotation.ShowDialog();
            if (result == DialogResult.OK)
            {
                // this one is not anchored on a point:
                TextAnnotation TA = new TextAnnotation();
                TA.Text = annotation.AnnotationText;
                TA.ForeColor = Color.White;
                TA.AnchorX = 50;  // 50% of chart width
                TA.AnchorY = 20;  // 20% of chart height, from top!
                chart1.Annotations.Add(TA);
                annotationList.Add(annotation.Text);
            }

        }
    }


}
