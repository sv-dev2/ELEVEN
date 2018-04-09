namespace ELEVEN
{
    partial class frmBroker
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAddBroker = new System.Windows.Forms.TabPage();
            this.BtnCreateBroker = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtBrokerDescription = new System.Windows.Forms.TextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtBrokerCode = new System.Windows.Forms.TextBox();
            this.tabPageBroker = new System.Windows.Forms.TabPage();
            this.dataGridBrokers = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.tabPageUpdateBroker = new System.Windows.Forms.TabPage();
            this.btnUpdate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtUpdateDescription = new System.Windows.Forms.TextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtUpdateBroker = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageAddBroker.SuspendLayout();
            this.tabPageBroker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBrokers)).BeginInit();
            this.tabPageUpdateBroker.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tabControl1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(484, 305);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAddBroker);
            this.tabControl1.Controls.Add(this.tabPageBroker);
            this.tabControl1.Controls.Add(this.tabPageUpdateBroker);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(484, 305);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            // 
            // tabPageAddBroker
            // 
            this.tabPageAddBroker.Controls.Add(this.BtnCreateBroker);
            this.tabPageAddBroker.Controls.Add(this.kryptonLabel1);
            this.tabPageAddBroker.Controls.Add(this.txtBrokerDescription);
            this.tabPageAddBroker.Controls.Add(this.kryptonLabel2);
            this.tabPageAddBroker.Controls.Add(this.txtBrokerCode);
            this.tabPageAddBroker.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddBroker.Name = "tabPageAddBroker";
            this.tabPageAddBroker.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddBroker.Size = new System.Drawing.Size(476, 279);
            this.tabPageAddBroker.TabIndex = 0;
            this.tabPageAddBroker.Text = "Add Broker";
            this.tabPageAddBroker.UseVisualStyleBackColor = true;
            // 
            // BtnCreateBroker
            // 
            this.BtnCreateBroker.Location = new System.Drawing.Point(187, 157);
            this.BtnCreateBroker.Name = "BtnCreateBroker";
            this.BtnCreateBroker.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.BtnCreateBroker.Size = new System.Drawing.Size(100, 50);
            this.BtnCreateBroker.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreateBroker.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.BtnCreateBroker.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.BtnCreateBroker.TabIndex = 4;
            this.BtnCreateBroker.Values.Text = "Create";
            this.BtnCreateBroker.Click += new System.EventHandler(this.BtnCreateBroker_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(61, 74);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(78, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Broker Code";
            // 
            // txtBrokerDescription
            // 
            this.txtBrokerDescription.Location = new System.Drawing.Point(187, 115);
            this.txtBrokerDescription.Name = "txtBrokerDescription";
            this.txtBrokerDescription.Size = new System.Drawing.Size(200, 21);
            this.txtBrokerDescription.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(61, 116);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(111, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Broker Description";
            // 
            // txtBrokerCode
            // 
            this.txtBrokerCode.Location = new System.Drawing.Point(187, 70);
            this.txtBrokerCode.Name = "txtBrokerCode";
            this.txtBrokerCode.Size = new System.Drawing.Size(200, 21);
            this.txtBrokerCode.TabIndex = 2;
            // 
            // tabPageBroker
            // 
            this.tabPageBroker.Controls.Add(this.dataGridBrokers);
            this.tabPageBroker.Location = new System.Drawing.Point(4, 22);
            this.tabPageBroker.Name = "tabPageBroker";
            this.tabPageBroker.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBroker.Size = new System.Drawing.Size(476, 279);
            this.tabPageBroker.TabIndex = 1;
            this.tabPageBroker.Text = "Brokers";
            this.tabPageBroker.UseVisualStyleBackColor = true;
            // 
            // dataGridBrokers
            // 
            this.dataGridBrokers.AllowUserToAddRows = false;
            this.dataGridBrokers.AllowUserToDeleteRows = false;
            this.dataGridBrokers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridBrokers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBrokers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridBrokers.HideOuterBorders = true;
            this.dataGridBrokers.Location = new System.Drawing.Point(3, 3);
            this.dataGridBrokers.MultiSelect = false;
            this.dataGridBrokers.Name = "dataGridBrokers";
            this.dataGridBrokers.ReadOnly = true;
            this.dataGridBrokers.RowHeadersVisible = false;
            this.dataGridBrokers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridBrokers.ShowEditingIcon = false;
            this.dataGridBrokers.Size = new System.Drawing.Size(470, 273);
            this.dataGridBrokers.StandardTab = true;
            this.dataGridBrokers.TabIndex = 33;
            this.dataGridBrokers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBrokers_CellClick);
            // 
            // tabPageUpdateBroker
            // 
            this.tabPageUpdateBroker.Controls.Add(this.btnUpdate);
            this.tabPageUpdateBroker.Controls.Add(this.kryptonLabel3);
            this.tabPageUpdateBroker.Controls.Add(this.txtUpdateDescription);
            this.tabPageUpdateBroker.Controls.Add(this.kryptonLabel4);
            this.tabPageUpdateBroker.Controls.Add(this.txtUpdateBroker);
            this.tabPageUpdateBroker.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdateBroker.Name = "tabPageUpdateBroker";
            this.tabPageUpdateBroker.Size = new System.Drawing.Size(476, 279);
            this.tabPageUpdateBroker.TabIndex = 2;
            this.tabPageUpdateBroker.Text = "Update";
            this.tabPageUpdateBroker.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(201, 158);
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
            this.kryptonLabel3.Location = new System.Drawing.Point(75, 75);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(78, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Broker Code";
            // 
            // txtUpdateDescription
            // 
            this.txtUpdateDescription.Location = new System.Drawing.Point(201, 116);
            this.txtUpdateDescription.Name = "txtUpdateDescription";
            this.txtUpdateDescription.Size = new System.Drawing.Size(200, 21);
            this.txtUpdateDescription.TabIndex = 8;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(75, 117);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(111, 20);
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "Broker Description";
            // 
            // txtUpdateBroker
            // 
            this.txtUpdateBroker.Location = new System.Drawing.Point(201, 71);
            this.txtUpdateBroker.Name = "txtUpdateBroker";
            this.txtUpdateBroker.Size = new System.Drawing.Size(200, 21);
            this.txtUpdateBroker.TabIndex = 7;
            // 
            // frmBroker
            // 
            this.AcceptButton = this.BtnCreateBroker;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 305);
            this.Controls.Add(this.kryptonPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBroker";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmBroker";
            this.Text = "Manage Broker";
            this.Load += new System.EventHandler(this.frmBroker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageAddBroker.ResumeLayout(false);
            this.tabPageAddBroker.PerformLayout();
            this.tabPageBroker.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBrokers)).EndInit();
            this.tabPageUpdateBroker.ResumeLayout(false);
            this.tabPageUpdateBroker.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCreateBroker;
        private System.Windows.Forms.TextBox txtBrokerDescription;
        private System.Windows.Forms.TextBox txtBrokerCode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAddBroker;
        private System.Windows.Forms.TabPage tabPageBroker;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridBrokers;
        private System.Windows.Forms.TabPage tabPageUpdateBroker;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUpdate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private System.Windows.Forms.TextBox txtUpdateDescription;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private System.Windows.Forms.TextBox txtUpdateBroker;
    }
}