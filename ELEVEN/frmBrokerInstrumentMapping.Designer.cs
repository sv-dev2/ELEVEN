namespace ELEVEN
{
    partial class frmBrokerInstrumentMapping
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.comboBroker = new System.Windows.Forms.ComboBox();
            this.comboInstrument = new System.Windows.Forms.ComboBox();
            this.txtBIC = new System.Windows.Forms.TextBox();
            this.chkPrices = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkTrades = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnCreateMap = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnCreateMap);
            this.kryptonPanel1.Controls.Add(this.chkTrades);
            this.kryptonPanel1.Controls.Add(this.chkPrices);
            this.kryptonPanel1.Controls.Add(this.txtBIC);
            this.kryptonPanel1.Controls.Add(this.comboInstrument);
            this.kryptonPanel1.Controls.Add(this.comboBroker);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(633, 344);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(58, 44);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(46, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Broker";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(58, 83);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(70, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Instrument";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(58, 123);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(141, 20);
            this.kryptonLabel3.TabIndex = 2;
            this.kryptonLabel3.Values.Text = "Broker Instrument Code";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(58, 162);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel4.TabIndex = 3;
            this.kryptonLabel4.Values.Text = "Feed Prices";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(58, 206);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel5.TabIndex = 4;
            this.kryptonLabel5.Values.Text = "Feed Trades";
            // 
            // comboBroker
            // 
            this.comboBroker.FormattingEnabled = true;
            this.comboBroker.Location = new System.Drawing.Point(234, 42);
            this.comboBroker.Name = "comboBroker";
            this.comboBroker.Size = new System.Drawing.Size(138, 21);
            this.comboBroker.TabIndex = 5;
            // 
            // comboInstrument
            // 
            this.comboInstrument.FormattingEnabled = true;
            this.comboInstrument.Location = new System.Drawing.Point(234, 83);
            this.comboInstrument.Name = "comboInstrument";
            this.comboInstrument.Size = new System.Drawing.Size(138, 21);
            this.comboInstrument.TabIndex = 6;
            // 
            // txtBIC
            // 
            this.txtBIC.Location = new System.Drawing.Point(234, 123);
            this.txtBIC.Name = "txtBIC";
            this.txtBIC.Size = new System.Drawing.Size(138, 20);
            this.txtBIC.TabIndex = 7;
            // 
            // chkPrices
            // 
            this.chkPrices.Location = new System.Drawing.Point(234, 162);
            this.chkPrices.Name = "chkPrices";
            this.chkPrices.Size = new System.Drawing.Size(19, 13);
            this.chkPrices.TabIndex = 8;
            this.chkPrices.Values.Text = "";
            // 
            // chkTrades
            // 
            this.chkTrades.Location = new System.Drawing.Point(234, 206);
            this.chkTrades.Name = "chkTrades";
            this.chkTrades.Size = new System.Drawing.Size(19, 13);
            this.chkTrades.TabIndex = 9;
            this.chkTrades.Values.Text = "";
            // 
            // btnCreateMap
            // 
            this.btnCreateMap.Location = new System.Drawing.Point(234, 236);
            this.btnCreateMap.Name = "btnCreateMap";
            this.btnCreateMap.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.btnCreateMap.Size = new System.Drawing.Size(100, 50);
            this.btnCreateMap.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateMap.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnCreateMap.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btnCreateMap.TabIndex = 10;
            this.btnCreateMap.Values.Text = "Create";
            this.btnCreateMap.Click += new System.EventHandler(this.btnCreateMap_Click);
            // 
            // frmBrokerInstrumentMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 344);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBrokerInstrumentMapping";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Broker Instrument Mapping";
            this.Load += new System.EventHandler(this.frmBrokerInstrumentMapping_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkTrades;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkPrices;
        private System.Windows.Forms.TextBox txtBIC;
        private System.Windows.Forms.ComboBox comboInstrument;
        private System.Windows.Forms.ComboBox comboBroker;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCreateMap;
    }
}