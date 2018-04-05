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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtAddRow = new System.Windows.Forms.TextBox();
            this.dataGridMarketData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMarketData)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAddRow
            // 
            this.txtAddRow.Location = new System.Drawing.Point(0, 0);
            this.txtAddRow.Name = "txtAddRow";
            this.txtAddRow.Size = new System.Drawing.Size(214, 20);
            this.txtAddRow.TabIndex = 2;
            this.txtAddRow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddRow_KeyDown);
            // 
            // dataGridMarketData
            // 
            this.dataGridMarketData.AllowUserToAddRows = false;
            this.dataGridMarketData.AllowUserToDeleteRows = false;
            this.dataGridMarketData.AllowUserToOrderColumns = true;
            this.dataGridMarketData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dataGridMarketData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridMarketData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridMarketData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(119)))), ((int)(((byte)(183)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridMarketData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridMarketData.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridMarketData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridMarketData.EnableHeadersVisualStyles = false;
            this.dataGridMarketData.Location = new System.Drawing.Point(0, 26);
            this.dataGridMarketData.MultiSelect = false;
            this.dataGridMarketData.Name = "dataGridMarketData";
            this.dataGridMarketData.ReadOnly = true;
            this.dataGridMarketData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridMarketData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridMarketData.RowHeadersVisible = false;
            this.dataGridMarketData.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridMarketData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMarketData.Size = new System.Drawing.Size(705, 225);
            this.dataGridMarketData.TabIndex = 3;
            this.dataGridMarketData.Tag = "frmMarketWatch";
            this.dataGridMarketData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMarketData_CellClick);
            // 
            // frmMarketWatchWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(706, 355);
            this.Controls.Add(this.dataGridMarketData);
            this.Controls.Add(this.txtAddRow);
            this.Name = "frmMarketWatchWin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "frmMarketWatchWin";
            this.Text = "Market Watch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMarketWatchWin_FormClosing);
            this.Load += new System.EventHandler(this.frmMarketWatch_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmMarketWatchWin_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMarketData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtAddRow;
        private System.Windows.Forms.DataGridView dataGridMarketData;
    }
}