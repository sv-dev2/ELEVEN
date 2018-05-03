using ComponentFactory.Krypton.Toolkit;
using ELEVEN.DBConnection;
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
        public string candleTimeFrame = "1m";
        public List<string> annotationList = new List<string>();
        public ImageList imgList = new ImageList();
        public frmCharts(MDIParentForm parentForm, string broker, string symbol)
        {
            InitializeComponent();
            candleData = new BindingList<CandleData>();

            this.parentForm = parentForm;
            this.broker = broker;
            this.symbol = symbol;

            zoomList = new List<ChartZoomOut>();

        }
        private void SetInitials()
        {
            customToolTip.SetToolTip(btnBarChart, "Range Bar Chart");
            customToolTip.SetToolTip(btnLineChart, "Renko Chart");
            customToolTip.SetToolTip(BtnCandleStickChart, "Candlestick Chart");
            customToolTip.SetToolTip(BtnToggleZoom, "Zoom In");
            customToolTip.SetToolTip(BtnZoomOut, "Zoom Out");
            customToolTip.SetToolTip(BtnPan, "Cursor/Pan");
            customToolTip.SetToolTip(BtnShowHide, "Hide Tool");
            customToolTip.SetToolTip(BtnLockUnLock, "Lock/UnLock Tools");
            customToolTip.SetToolTip(BtnHeikenAshi, "Heikin-Ashi Chart");
        }

        private void InitBitFinex()
        {
            BitfinexSocket.Instance.Init(symbol, this, candleTimeFrame);
            var timeFrame = clsComman.GetBitTimeFrame();
            BindCombobox(timeFrame);
        }
        private void BindCombobox(List<ClsTimeframe> timeFrame)
        {
            comboTimeFrame.DataSource = timeFrame;
            comboTimeFrame.ValueMember = "Value";
            comboTimeFrame.DisplayMember = "Text";
            comboTimeFrame.SelectedValue = candleTimeFrame;

        }

        private void CustomizedLineSeries_Load(object sender, EventArgs e)
        {

            imgList.Images.Add(Properties.Resources.lock_icon);
            imgList.Images.Add(Properties.Resources.open_lock);
            imgList.TransparentColor = Color.Transparent;
            BtnLockUnLock.StateCommon.Back.Image = imgList.Images[1];
            LoadAnnotations();
            LoadZoomPoints();
            LoadFormToolState();
            ChartSettings();
            SetInitials();
            if (broker.ToLower() == "bitfinex")
                InitBitFinex();
            else
            {
               
                MT4APICharts.Instance.Init(this);
                if (candleTimeFrame == null || candleTimeFrame == "1m")
                {
                    candleTimeFrame = "0";
                }

                candleDataMT = new BindingList<CandleDataMT>();
                var timeFrame = clsComman.GetMTTimeFrame();
                BindCombobox(timeFrame);
                BindDataSource();
            }
            this.Text = broker + "." + symbol.Replace("t", "");          
           
            comboTimeFrame.SelectedIndexChanged += ComboTimeFrame_SelectedIndexChanged;
        }

        private void ComboTimeFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as KryptonComboBox;
            string timeframe = Convert.ToString(combo.SelectedValue);
            //var isExist = clsComman.GetBitTimeFrame().Where(m => m.Value == bitTimeframe).FirstOrDefault();
            if (timeframe != null && timeframe != candleTimeFrame)
            {
                candleTimeFrame = timeframe;
                if (broker.ToLower() == Broker.BitFinex.ToString().ToLower())
                {
                    BitfinexSocket.Instance.webSocket.Close();
                    BitfinexSocket.Instance.ReConnect(this.symbol, this, timeframe);
                }
                else if (broker.ToLower() == Broker.MT.ToString().ToLower())
                {
                    MT4APICharts.Instance.Dispose();
                    MT4APICharts.Instance.StartGateway();
                    MT4APICharts.Instance.listCandles = new BindingList<CandleDataMT>();
                    BindDataSource();
                }

            }
        }

        private void LoadAnnotations()
        {
            var annotations = SQLiteDBOperation.ReteriveChartAnnotations(this.Name);
            foreach (var item in annotations)
            {
                // this one is not anchored on a point:
                TextAnnotation TA = new TextAnnotation();
                TA.Text = item;
                TA.ForeColor = Color.White;
                TA.AnchorX = 50;  // 50% of chart width
                TA.AnchorY = 20;  // 20% of chart height, from top!
                chart1.Annotations.Add(TA);
                annotationList.Add(item);
            }
        }
        private void LoadZoomPoints()
        {
            zoomList = SQLiteDBOperation.ReteriveChartZoomList(this.Name);
            if (zoomList != null && zoomList.Count > 0)
            {
                var points = zoomList.OrderByDescending(m => m.Index).FirstOrDefault();
                if (points != null)
                {
                    chart1.ChartAreas[0].AxisX.ScaleView.Zoom(points.PosXStart, points.PosXFinish);
                    chart1.ChartAreas[0].AxisY.ScaleView.Zoom(points.PosYStart, points.PosYFinish);
                }
            }

        }
        private void LoadFormToolState()
        {
            var toolState = SQLiteDBOperation.ReteriveFormToolState(this.Name);
            candleTimeFrame = toolState?.TimeFrame ?? "1m";
            if (toolState != null)
            {
                panelVisible = Convert.ToBoolean(toolState.VisibleState == 1 ? true : false);
                if (!panelVisible)
                {
                    panelTools.Visible = false;
                }
                isLocked = Convert.ToBoolean(toolState.LockState == 1 ? true : false);
                if (isLocked)
                {
                    foreach (var item in panelTools.Controls)
                    {
                        var button = item as KryptonButton;
                        if (button != null && button.Name != "BtnLockUnLock")
                        {
                            button.Enabled = false;
                        }
                    }
                }
            }
        }
        public void BindDataSource()
        {
            candleDataMT = (BindingList<CandleDataMT>)MT4APICharts.Instance.HistoricalCandles(symbol, candleTimeFrame);
            if (MT4APICharts.Instance.listCandles.Count > 0)
            {
                var max = MT4APICharts.Instance.listCandles.Max(m => m.High);
                var min = MT4APICharts.Instance.listCandles.Min(m => m.Low);
                chart1.ChartAreas["ChartArea1"].AxisY.Minimum = min;
                chart1.ChartAreas["ChartArea1"].AxisY.Maximum = max;
            }
            chart1.DataSource = MT4APICharts.Instance.listCandles;
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
            try
            {
                mDown = ax.PixelPositionToValue(e.Location.X);
            }
            catch
            {
            }

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
                    double pX = chart1.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    double pY = chart1.ChartAreas[0].CursorY.Position; //Y Axis Coordinate of your mouse cursor

                    double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    double yMin = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                    double yMax = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                    double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 5;
                    double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 5;
                    double posYStart = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 2;
                    double posYFinish = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 2;

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
            try
            {
                ZoomIn = sender as KryptonButton;
                chart1.Cursor = System.Windows.Forms.Cursors.Default;
                isPan = false;
                firstVisit = true;
                if (zoomList.Count < 5)
                {
                    chart1.Capture = false;
                    double pX = chart1.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                    double pY = chart1.ChartAreas[0].CursorY.Position; //Y Axis Coordinate of your mouse cursor

                    double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    double yMin = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                    double yMax = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum;
                    int width = this.Width;
                    int height = this.Height;
                    double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(70) - (xMax - xMin) / 5;
                    double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(70) + (xMax - xMin) / 5;
                    double posYStart = chart1.ChartAreas[0].AxisY.PixelPositionToValue(70) - (yMax - yMin) / 2;
                    double posYFinish = chart1.ChartAreas[0].AxisY.PixelPositionToValue(70) + (yMax - yMin) / 2;

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
            catch
            {
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
                annotationList.Add(annotation.AnnotationText);
            }

        }

        private void BtnShowHide_Click(object sender, EventArgs e)
        {
            panelTools.Visible = false;
            panelVisible = false;
        }
        public bool isLocked = false;
        public bool panelVisible = true;
        private void BtnLockUnLock_Click(object sender, EventArgs e)
        {
            if (isLocked)
            {
                foreach (var item in panelTools.Controls)
                {
                    var button = item as KryptonButton;
                    if (button != null)
                    {
                        button.Enabled = true;
                    }
                }
                isLocked = false;
                BtnLockUnLock.StateCommon.Back.Image = imgList.Images[1];
            }
            else
            {
                foreach (var item in panelTools.Controls)
                {
                    var button = item as KryptonButton;
                    if (button != null && button.Name != "BtnLockUnLock")
                    {
                        button.Enabled = false;
                    }
                }
                isLocked = true;
                BtnLockUnLock.StateCommon.Back.Image = imgList.Images[0];
            }
        }



        private void chart1_AxisScrollBarClicked(object sender, ScrollBarEventArgs e)
        {
            if (e.ButtonType == ScrollBarButtonType.ZoomReset)
            {
                e.IsHandled = true;

                chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);

                this.chart1.ChartAreas[0].CursorX.SelectionStart = double.NaN;
                this.chart1.ChartAreas[0].CursorY.SelectionEnd = double.NaN;

                zoomList = new List<ChartZoomOut>();
                if (ZoomOut != null)
                {
                    ZoomOut.Enabled = false;
                }
                if (ZoomIn != null)
                {
                    ZoomIn.Enabled = true;
                }
            }
        }

        private void btnBarChart_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = SeriesChartType.RangeBar;


        }

        private void btnLineChart_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = SeriesChartType.Renko;
        }

        private void BtnCandleStickChart_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = SeriesChartType.Candlestick;

        }

        private void BtnHeikenAshi_Click(object sender, EventArgs e)
        {

        }




        private void BtnTrendline_Click(object sender, EventArgs e)
        {

            // chart1.MouseClick += Chart1_MouseClick;
            // chart1.Paint += Chart1_Paint;

        }
        private void Chart1_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(e.Location);
            chart1.Invalidate();
            //chart1.MouseClick -= Chart1_MouseClick;
        }

        List<Point> points = new List<Point>();
        Point lastPoint = Point.Empty;
        private void Chart1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Point pt in points)
            {
                double dx = chart1.ChartAreas[0].AxisX.PixelPositionToValue(pt.X);
                double dy = chart1.ChartAreas[0].AxisY.PixelPositionToValue(pt.Y);
                chart1.Series[0].Points.AddXY(dx, dy);
            }
            if (points.Count > 1)
            {
                using (Pen pen = new Pen(Color.Red, 2.5f))
                    e.Graphics.DrawLines(pen, points.ToArray());

            }



        }
    }


}
