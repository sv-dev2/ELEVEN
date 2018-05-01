﻿namespace ELEVEN
{
    partial class frmCharts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCharts));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelTools = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.BtnShowHide = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnLockUnLock = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnAddText = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnPan = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnZoomOut = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnToggleZoom = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.comboTimeFrame = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTools)).BeginInit();
            this.panelTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboTimeFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.Area3DStyle.WallWidth = 10;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Default;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(645, 383);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // panelTools
            // 
            this.panelTools.Controls.Add(this.BtnShowHide);
            this.panelTools.Controls.Add(this.BtnLockUnLock);
            this.panelTools.Controls.Add(this.BtnAddText);
            this.panelTools.Controls.Add(this.BtnPan);
            this.panelTools.Controls.Add(this.BtnZoomOut);
            this.panelTools.Controls.Add(this.BtnToggleZoom);
            this.panelTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTools.Location = new System.Drawing.Point(0, 0);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(39, 383);
            this.panelTools.StateCommon.Color1 = System.Drawing.Color.White;
            this.panelTools.StateCommon.Color2 = System.Drawing.Color.White;
            this.panelTools.StateNormal.Color1 = System.Drawing.Color.White;
            this.panelTools.StateNormal.Color2 = System.Drawing.Color.White;
            this.panelTools.TabIndex = 1;
            // 
            // BtnShowHide
            // 
            this.BtnShowHide.Location = new System.Drawing.Point(1, 150);
            this.BtnShowHide.Name = "BtnShowHide";
            this.BtnShowHide.Size = new System.Drawing.Size(37, 29);
            this.BtnShowHide.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.BtnShowHide.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.BtnShowHide.StateCommon.Back.Image = global::ELEVEN.Properties.Resources.show_hide;
            this.BtnShowHide.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.BtnShowHide.TabIndex = 5;
            this.BtnShowHide.TabStop = false;
            this.BtnShowHide.Values.Text = "";
            this.BtnShowHide.Click += new System.EventHandler(this.BtnShowHide_Click);
            // 
            // BtnLockUnLock
            // 
            this.BtnLockUnLock.Location = new System.Drawing.Point(2, 120);
            this.BtnLockUnLock.Name = "BtnLockUnLock";
            this.BtnLockUnLock.Size = new System.Drawing.Size(37, 29);
            this.BtnLockUnLock.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.BtnLockUnLock.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.BtnLockUnLock.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.BtnLockUnLock.TabIndex = 4;
            this.BtnLockUnLock.TabStop = false;
            this.BtnLockUnLock.Values.Text = "";
            this.BtnLockUnLock.Click += new System.EventHandler(this.BtnLockUnLock_Click);
            // 
            // BtnAddText
            // 
            this.BtnAddText.Location = new System.Drawing.Point(2, 90);
            this.BtnAddText.Name = "BtnAddText";
            this.BtnAddText.Size = new System.Drawing.Size(37, 29);
            this.BtnAddText.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.BtnAddText.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.BtnAddText.StateCommon.Back.Image = global::ELEVEN.Properties.Resources.Texticon;
            this.BtnAddText.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.BtnAddText.TabIndex = 3;
            this.BtnAddText.TabStop = false;
            this.BtnAddText.Values.Text = "";
            this.BtnAddText.Click += new System.EventHandler(this.BtnAddText_Click);
            // 
            // BtnPan
            // 
            this.BtnPan.Location = new System.Drawing.Point(2, 60);
            this.BtnPan.Name = "BtnPan";
            this.BtnPan.Size = new System.Drawing.Size(37, 29);
            this.BtnPan.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.BtnPan.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.BtnPan.StateCommon.Back.Image = global::ELEVEN.Properties.Resources.pointer;
            this.BtnPan.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.BtnPan.TabIndex = 2;
            this.BtnPan.TabStop = false;
            this.BtnPan.Values.Text = "";
            this.BtnPan.Click += new System.EventHandler(this.BtnPan_Click);
            // 
            // BtnZoomOut
            // 
            this.BtnZoomOut.Location = new System.Drawing.Point(2, 30);
            this.BtnZoomOut.Name = "BtnZoomOut";
            this.BtnZoomOut.Size = new System.Drawing.Size(37, 29);
            this.BtnZoomOut.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.BtnZoomOut.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.BtnZoomOut.StateCommon.Back.Image = global::ELEVEN.Properties.Resources.zoom_out;
            this.BtnZoomOut.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.BtnZoomOut.TabIndex = 1;
            this.BtnZoomOut.TabStop = false;
            this.BtnZoomOut.Values.Text = "";
            this.BtnZoomOut.Click += new System.EventHandler(this.BtnZoomOut_Click);
            // 
            // BtnToggleZoom
            // 
            this.BtnToggleZoom.Location = new System.Drawing.Point(2, 0);
            this.BtnToggleZoom.Name = "BtnToggleZoom";
            this.BtnToggleZoom.Size = new System.Drawing.Size(37, 29);
            this.BtnToggleZoom.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.BtnToggleZoom.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.BtnToggleZoom.StateCommon.Back.Image = global::ELEVEN.Properties.Resources.zoom_in;
            this.BtnToggleZoom.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.BtnToggleZoom.TabIndex = 0;
            this.BtnToggleZoom.TabStop = false;
            this.BtnToggleZoom.Values.Text = "";
            this.BtnToggleZoom.Click += new System.EventHandler(this.BtnToggleZoom_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonPanel1);
            this.kryptonPanel2.Controls.Add(this.chart1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(39, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(645, 383);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.comboTimeFrame);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(645, 29);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel1.TabIndex = 1;
            // 
            // comboTimeFrame
            // 
            this.comboTimeFrame.DropDownWidth = 122;
            this.comboTimeFrame.Location = new System.Drawing.Point(0, 5);
            this.comboTimeFrame.Name = "comboTimeFrame";
            this.comboTimeFrame.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.comboTimeFrame.Size = new System.Drawing.Size(76, 21);
            this.comboTimeFrame.TabIndex = 0;
            // 
            // frmCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(684, 383);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panelTools);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCharts";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "frmCharts";
            this.Text = "Chart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCharts_FormClosing);
            this.Load += new System.EventHandler(this.CustomizedLineSeries_Load);
            this.Shown += new System.EventHandler(this.frmCharts_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTools)).EndInit();
            this.panelTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboTimeFrame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnToggleZoom;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnZoomOut;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnPan;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnAddText;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnShowHide;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnLockUnLock;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel panelTools;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboTimeFrame;
    }
}