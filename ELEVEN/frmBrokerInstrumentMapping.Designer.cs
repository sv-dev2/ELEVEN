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
            this.btnCreateMap = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.chkTrades = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkPrices = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.txtBIC = new System.Windows.Forms.TextBox();
            this.comboInstrument = new System.Windows.Forms.ComboBox();
            this.comboBroker = new System.Windows.Forms.ComboBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAddMapping = new System.Windows.Forms.TabPage();
            this.tabPageMapping = new System.Windows.Forms.TabPage();
            this.tabPageUpdateMapping = new System.Windows.Forms.TabPage();
            this.btnUpdate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ComboUpdateBIC = new System.Windows.Forms.TextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkUpdateTrades = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkUpdatePrices = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.comboUpdateInstrument = new System.Windows.Forms.ComboBox();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.comboUpdateBroker = new System.Windows.Forms.ComboBox();
            this.dataGridMappings = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageAddMapping.SuspendLayout();
            this.tabPageMapping.SuspendLayout();
            this.tabPageUpdateMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMappings)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tabControl1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(632, 388);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btnCreateMap
            // 
            this.btnCreateMap.Location = new System.Drawing.Point(294, 254);
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
            // chkTrades
            // 
            this.chkTrades.Location = new System.Drawing.Point(294, 224);
            this.chkTrades.Name = "chkTrades";
            this.chkTrades.Size = new System.Drawing.Size(19, 13);
            this.chkTrades.TabIndex = 9;
            this.chkTrades.Values.Text = "";
            // 
            // chkPrices
            // 
            this.chkPrices.Location = new System.Drawing.Point(294, 180);
            this.chkPrices.Name = "chkPrices";
            this.chkPrices.Size = new System.Drawing.Size(19, 13);
            this.chkPrices.TabIndex = 8;
            this.chkPrices.Values.Text = "";
            // 
            // txtBIC
            // 
            this.txtBIC.Location = new System.Drawing.Point(294, 141);
            this.txtBIC.Name = "txtBIC";
            this.txtBIC.Size = new System.Drawing.Size(138, 20);
            this.txtBIC.TabIndex = 7;
            // 
            // comboInstrument
            // 
            this.comboInstrument.FormattingEnabled = true;
            this.comboInstrument.Location = new System.Drawing.Point(294, 101);
            this.comboInstrument.Name = "comboInstrument";
            this.comboInstrument.Size = new System.Drawing.Size(138, 21);
            this.comboInstrument.TabIndex = 6;
            // 
            // comboBroker
            // 
            this.comboBroker.FormattingEnabled = true;
            this.comboBroker.Location = new System.Drawing.Point(294, 60);
            this.comboBroker.Name = "comboBroker";
            this.comboBroker.Size = new System.Drawing.Size(138, 21);
            this.comboBroker.TabIndex = 5;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(118, 224);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel5.TabIndex = 4;
            this.kryptonLabel5.Values.Text = "Feed Trades";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(118, 180);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel4.TabIndex = 3;
            this.kryptonLabel4.Values.Text = "Feed Prices";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(118, 141);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(141, 20);
            this.kryptonLabel3.TabIndex = 2;
            this.kryptonLabel3.Values.Text = "Broker Instrument Code";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(118, 101);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(70, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Instrument";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(118, 62);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(46, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Broker";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAddMapping);
            this.tabControl1.Controls.Add(this.tabPageMapping);
            this.tabControl1.Controls.Add(this.tabPageUpdateMapping);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(632, 388);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            // 
            // tabPageAddMapping
            // 
            this.tabPageAddMapping.Controls.Add(this.btnCreateMap);
            this.tabPageAddMapping.Controls.Add(this.txtBIC);
            this.tabPageAddMapping.Controls.Add(this.kryptonLabel1);
            this.tabPageAddMapping.Controls.Add(this.chkTrades);
            this.tabPageAddMapping.Controls.Add(this.kryptonLabel2);
            this.tabPageAddMapping.Controls.Add(this.chkPrices);
            this.tabPageAddMapping.Controls.Add(this.kryptonLabel3);
            this.tabPageAddMapping.Controls.Add(this.kryptonLabel4);
            this.tabPageAddMapping.Controls.Add(this.comboInstrument);
            this.tabPageAddMapping.Controls.Add(this.kryptonLabel5);
            this.tabPageAddMapping.Controls.Add(this.comboBroker);
            this.tabPageAddMapping.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddMapping.Name = "tabPageAddMapping";
            this.tabPageAddMapping.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddMapping.Size = new System.Drawing.Size(624, 362);
            this.tabPageAddMapping.TabIndex = 0;
            this.tabPageAddMapping.Text = "Add Mapping";
            this.tabPageAddMapping.UseVisualStyleBackColor = true;
            // 
            // tabPageMapping
            // 
            this.tabPageMapping.Controls.Add(this.dataGridMappings);
            this.tabPageMapping.Location = new System.Drawing.Point(4, 22);
            this.tabPageMapping.Name = "tabPageMapping";
            this.tabPageMapping.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMapping.Size = new System.Drawing.Size(624, 362);
            this.tabPageMapping.TabIndex = 1;
            this.tabPageMapping.Text = "Mapping";
            this.tabPageMapping.UseVisualStyleBackColor = true;
            // 
            // tabPageUpdateMapping
            // 
            this.tabPageUpdateMapping.Controls.Add(this.btnUpdate);
            this.tabPageUpdateMapping.Controls.Add(this.ComboUpdateBIC);
            this.tabPageUpdateMapping.Controls.Add(this.kryptonLabel6);
            this.tabPageUpdateMapping.Controls.Add(this.chkUpdateTrades);
            this.tabPageUpdateMapping.Controls.Add(this.kryptonLabel7);
            this.tabPageUpdateMapping.Controls.Add(this.chkUpdatePrices);
            this.tabPageUpdateMapping.Controls.Add(this.kryptonLabel8);
            this.tabPageUpdateMapping.Controls.Add(this.kryptonLabel9);
            this.tabPageUpdateMapping.Controls.Add(this.comboUpdateInstrument);
            this.tabPageUpdateMapping.Controls.Add(this.kryptonLabel10);
            this.tabPageUpdateMapping.Controls.Add(this.comboUpdateBroker);
            this.tabPageUpdateMapping.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdateMapping.Name = "tabPageUpdateMapping";
            this.tabPageUpdateMapping.Size = new System.Drawing.Size(624, 362);
            this.tabPageUpdateMapping.TabIndex = 2;
            this.tabPageUpdateMapping.Text = "Update Mapping";
            this.tabPageUpdateMapping.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(314, 253);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.btnUpdate.Size = new System.Drawing.Size(100, 50);
            this.btnUpdate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnUpdate.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Values.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ComboUpdateBIC
            // 
            this.ComboUpdateBIC.Location = new System.Drawing.Point(314, 140);
            this.ComboUpdateBIC.Name = "ComboUpdateBIC";
            this.ComboUpdateBIC.Size = new System.Drawing.Size(138, 20);
            this.ComboUpdateBIC.TabIndex = 18;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(138, 61);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(46, 20);
            this.kryptonLabel6.TabIndex = 11;
            this.kryptonLabel6.Values.Text = "Broker";
            // 
            // chkUpdateTrades
            // 
            this.chkUpdateTrades.Location = new System.Drawing.Point(314, 223);
            this.chkUpdateTrades.Name = "chkUpdateTrades";
            this.chkUpdateTrades.Size = new System.Drawing.Size(19, 13);
            this.chkUpdateTrades.TabIndex = 20;
            this.chkUpdateTrades.Values.Text = "";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(138, 100);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(70, 20);
            this.kryptonLabel7.TabIndex = 12;
            this.kryptonLabel7.Values.Text = "Instrument";
            // 
            // chkUpdatePrices
            // 
            this.chkUpdatePrices.Location = new System.Drawing.Point(314, 179);
            this.chkUpdatePrices.Name = "chkUpdatePrices";
            this.chkUpdatePrices.Size = new System.Drawing.Size(19, 13);
            this.chkUpdatePrices.TabIndex = 19;
            this.chkUpdatePrices.Values.Text = "";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(138, 140);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(141, 20);
            this.kryptonLabel8.TabIndex = 13;
            this.kryptonLabel8.Values.Text = "Broker Instrument Code";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(138, 179);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel9.TabIndex = 14;
            this.kryptonLabel9.Values.Text = "Feed Prices";
            // 
            // comboUpdateInstrument
            // 
            this.comboUpdateInstrument.FormattingEnabled = true;
            this.comboUpdateInstrument.Location = new System.Drawing.Point(314, 100);
            this.comboUpdateInstrument.Name = "comboUpdateInstrument";
            this.comboUpdateInstrument.Size = new System.Drawing.Size(138, 21);
            this.comboUpdateInstrument.TabIndex = 17;
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(138, 223);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel10.TabIndex = 15;
            this.kryptonLabel10.Values.Text = "Feed Trades";
            // 
            // comboUpdateBroker
            // 
            this.comboUpdateBroker.FormattingEnabled = true;
            this.comboUpdateBroker.Location = new System.Drawing.Point(314, 59);
            this.comboUpdateBroker.Name = "comboUpdateBroker";
            this.comboUpdateBroker.Size = new System.Drawing.Size(138, 21);
            this.comboUpdateBroker.TabIndex = 16;
            // 
            // dataGridMappings
            // 
            this.dataGridMappings.AllowUserToAddRows = false;
            this.dataGridMappings.AllowUserToDeleteRows = false;
            this.dataGridMappings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridMappings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMappings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridMappings.HideOuterBorders = true;
            this.dataGridMappings.Location = new System.Drawing.Point(3, 3);
            this.dataGridMappings.MultiSelect = false;
            this.dataGridMappings.Name = "dataGridMappings";
            this.dataGridMappings.ReadOnly = true;
            this.dataGridMappings.RowHeadersVisible = false;
            this.dataGridMappings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMappings.ShowEditingIcon = false;
            this.dataGridMappings.Size = new System.Drawing.Size(618, 356);
            this.dataGridMappings.StandardTab = true;
            this.dataGridMappings.TabIndex = 34;
            // 
            // frmBrokerInstrumentMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 388);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBrokerInstrumentMapping";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Broker Instrument Mapping";
            this.Load += new System.EventHandler(this.frmBrokerInstrumentMapping_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageAddMapping.ResumeLayout(false);
            this.tabPageAddMapping.PerformLayout();
            this.tabPageMapping.ResumeLayout(false);
            this.tabPageUpdateMapping.ResumeLayout(false);
            this.tabPageUpdateMapping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMappings)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAddMapping;
        private System.Windows.Forms.TabPage tabPageMapping;
        private System.Windows.Forms.TabPage tabPageUpdateMapping;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUpdate;
        private System.Windows.Forms.TextBox ComboUpdateBIC;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkUpdateTrades;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkUpdatePrices;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private System.Windows.Forms.ComboBox comboUpdateInstrument;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private System.Windows.Forms.ComboBox comboUpdateBroker;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridMappings;
    }
}