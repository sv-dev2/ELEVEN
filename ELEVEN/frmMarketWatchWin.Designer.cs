namespace ELEVEN
{
    partial class frmMarketWatchWin
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
            this.txtAddRow = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dataGridMarketData = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMarketData)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.txtAddRow);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(706, 31);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // txtAddRow
            // 
            this.txtAddRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddRow.Location = new System.Drawing.Point(0, 0);
            this.txtAddRow.Name = "txtAddRow";
            this.txtAddRow.Size = new System.Drawing.Size(706, 20);
            this.txtAddRow.TabIndex = 0;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.dataGridMarketData);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 31);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(706, 324);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // dataGridMarketData
            // 
            this.dataGridMarketData.AllowUserToAddRows = false;
            this.dataGridMarketData.AllowUserToDeleteRows = false;
            this.dataGridMarketData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridMarketData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMarketData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridMarketData.HideOuterBorders = true;
            this.dataGridMarketData.Location = new System.Drawing.Point(0, 0);
            this.dataGridMarketData.MultiSelect = false;
            this.dataGridMarketData.Name = "dataGridMarketData";
            this.dataGridMarketData.ReadOnly = true;
            this.dataGridMarketData.RowHeadersVisible = false;
            this.dataGridMarketData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMarketData.ShowEditingIcon = false;
            this.dataGridMarketData.Size = new System.Drawing.Size(706, 324);
            this.dataGridMarketData.StandardTab = true;
            this.dataGridMarketData.TabIndex = 32;
            this.dataGridMarketData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMarketData_CellClick);
            // 
            // frmMarketWatchWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(706, 355);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMarketWatchWin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "frmMarketWatchWin";
            this.Text = "Market Watch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMarketWatchWin_FormClosing);
            this.Load += new System.EventHandler(this.frmMarketWatch_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmMarketWatchWin_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMarketData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAddRow;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridMarketData;
    }
}