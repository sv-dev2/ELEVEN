namespace ELEVEN
{
    partial class frmInstrument
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
            this.BtnCreateInstrument = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtInstrumentDescription = new System.Windows.Forms.TextBox();
            this.txtInstrumentCode = new System.Windows.Forms.TextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAddInstrument = new System.Windows.Forms.TabPage();
            this.tabPageInstruments = new System.Windows.Forms.TabPage();
            this.tabPageUpdateInstrument = new System.Windows.Forms.TabPage();
            this.txtUpdateDescription = new System.Windows.Forms.TextBox();
            this.btnUpdate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtUpdateInstrumentCode = new System.Windows.Forms.TextBox();
            this.dataGridInstruments = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageAddInstrument.SuspendLayout();
            this.tabPageInstruments.SuspendLayout();
            this.tabPageUpdateInstrument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInstruments)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tabControl1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(520, 261);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // BtnCreateInstrument
            // 
            this.BtnCreateInstrument.Location = new System.Drawing.Point(204, 142);
            this.BtnCreateInstrument.Name = "BtnCreateInstrument";
            this.BtnCreateInstrument.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.BtnCreateInstrument.Size = new System.Drawing.Size(100, 50);
            this.BtnCreateInstrument.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreateInstrument.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.BtnCreateInstrument.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.BtnCreateInstrument.TabIndex = 4;
            this.BtnCreateInstrument.Values.Text = "Create";
            this.BtnCreateInstrument.Click += new System.EventHandler(this.BtnCreateInstrument_Click);
            // 
            // txtInstrumentDescription
            // 
            this.txtInstrumentDescription.Location = new System.Drawing.Point(204, 102);
            this.txtInstrumentDescription.Name = "txtInstrumentDescription";
            this.txtInstrumentDescription.Size = new System.Drawing.Size(200, 20);
            this.txtInstrumentDescription.TabIndex = 3;
            // 
            // txtInstrumentCode
            // 
            this.txtInstrumentCode.Location = new System.Drawing.Point(204, 57);
            this.txtInstrumentCode.Name = "txtInstrumentCode";
            this.txtInstrumentCode.Size = new System.Drawing.Size(200, 20);
            this.txtInstrumentCode.TabIndex = 2;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(70, 103);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(135, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Instrument Description";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(70, 61);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Instrument Code";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAddInstrument);
            this.tabControl1.Controls.Add(this.tabPageInstruments);
            this.tabControl1.Controls.Add(this.tabPageUpdateInstrument);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(520, 261);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            // 
            // tabPageAddInstrument
            // 
            this.tabPageAddInstrument.Controls.Add(this.txtInstrumentDescription);
            this.tabPageAddInstrument.Controls.Add(this.BtnCreateInstrument);
            this.tabPageAddInstrument.Controls.Add(this.kryptonLabel1);
            this.tabPageAddInstrument.Controls.Add(this.kryptonLabel2);
            this.tabPageAddInstrument.Controls.Add(this.txtInstrumentCode);
            this.tabPageAddInstrument.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddInstrument.Name = "tabPageAddInstrument";
            this.tabPageAddInstrument.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddInstrument.Size = new System.Drawing.Size(512, 235);
            this.tabPageAddInstrument.TabIndex = 0;
            this.tabPageAddInstrument.Text = "Add Instrument";
            this.tabPageAddInstrument.UseVisualStyleBackColor = true;
            // 
            // tabPageInstruments
            // 
            this.tabPageInstruments.Controls.Add(this.dataGridInstruments);
            this.tabPageInstruments.Location = new System.Drawing.Point(4, 22);
            this.tabPageInstruments.Name = "tabPageInstruments";
            this.tabPageInstruments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInstruments.Size = new System.Drawing.Size(512, 235);
            this.tabPageInstruments.TabIndex = 1;
            this.tabPageInstruments.Text = "Instrument";
            this.tabPageInstruments.UseVisualStyleBackColor = true;
            // 
            // tabPageUpdateInstrument
            // 
            this.tabPageUpdateInstrument.Controls.Add(this.txtUpdateDescription);
            this.tabPageUpdateInstrument.Controls.Add(this.btnUpdate);
            this.tabPageUpdateInstrument.Controls.Add(this.kryptonLabel3);
            this.tabPageUpdateInstrument.Controls.Add(this.kryptonLabel4);
            this.tabPageUpdateInstrument.Controls.Add(this.txtUpdateInstrumentCode);
            this.tabPageUpdateInstrument.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdateInstrument.Name = "tabPageUpdateInstrument";
            this.tabPageUpdateInstrument.Size = new System.Drawing.Size(512, 235);
            this.tabPageUpdateInstrument.TabIndex = 2;
            this.tabPageUpdateInstrument.Text = "Update Instrument";
            this.tabPageUpdateInstrument.UseVisualStyleBackColor = true;
            // 
            // txtUpdateDescription
            // 
            this.txtUpdateDescription.Location = new System.Drawing.Point(223, 95);
            this.txtUpdateDescription.Name = "txtUpdateDescription";
            this.txtUpdateDescription.Size = new System.Drawing.Size(200, 20);
            this.txtUpdateDescription.TabIndex = 8;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(223, 135);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.btnUpdate.Size = new System.Drawing.Size(100, 50);
            this.btnUpdate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnUpdate.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Values.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(89, 54);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Instrument Code";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(89, 96);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(135, 20);
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "Instrument Description";
            // 
            // txtUpdateInstrumentCode
            // 
            this.txtUpdateInstrumentCode.Location = new System.Drawing.Point(223, 50);
            this.txtUpdateInstrumentCode.Name = "txtUpdateInstrumentCode";
            this.txtUpdateInstrumentCode.Size = new System.Drawing.Size(200, 20);
            this.txtUpdateInstrumentCode.TabIndex = 7;
            // 
            // dataGridInstruments
            // 
            this.dataGridInstruments.AllowUserToAddRows = false;
            this.dataGridInstruments.AllowUserToDeleteRows = false;
            this.dataGridInstruments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridInstruments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInstruments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridInstruments.HideOuterBorders = true;
            this.dataGridInstruments.Location = new System.Drawing.Point(3, 3);
            this.dataGridInstruments.MultiSelect = false;
            this.dataGridInstruments.Name = "dataGridInstruments";
            this.dataGridInstruments.ReadOnly = true;
            this.dataGridInstruments.RowHeadersVisible = false;
            this.dataGridInstruments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridInstruments.ShowEditingIcon = false;
            this.dataGridInstruments.Size = new System.Drawing.Size(506, 229);
            this.dataGridInstruments.StandardTab = true;
            this.dataGridInstruments.TabIndex = 34;
            this.dataGridInstruments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridInstruments_CellClick);
            // 
            // frmInstrument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 261);
            this.Controls.Add(this.kryptonPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInstrument";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Instrument";
            this.Load += new System.EventHandler(this.frmInstrument_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageAddInstrument.ResumeLayout(false);
            this.tabPageAddInstrument.PerformLayout();
            this.tabPageInstruments.ResumeLayout(false);
            this.tabPageUpdateInstrument.ResumeLayout(false);
            this.tabPageUpdateInstrument.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInstruments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCreateInstrument;
        private System.Windows.Forms.TextBox txtInstrumentDescription;
        private System.Windows.Forms.TextBox txtInstrumentCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAddInstrument;
        private System.Windows.Forms.TabPage tabPageInstruments;
        private System.Windows.Forms.TabPage tabPageUpdateInstrument;
        private System.Windows.Forms.TextBox txtUpdateDescription;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUpdate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private System.Windows.Forms.TextBox txtUpdateInstrumentCode;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridInstruments;
    }
}