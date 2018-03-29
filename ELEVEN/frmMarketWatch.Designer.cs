namespace ELEVEN
{
    partial class frmMarketWatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarketWatch));
            this.dataGridMarketData = new System.Windows.Forms.DataGridView();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMarketData)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridMarketData
            // 
            this.dataGridMarketData.AllowUserToDeleteRows = false;
            this.dataGridMarketData.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dataGridMarketData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridMarketData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridMarketData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dataGridMarketData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridMarketData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Symbol,
            this.Bid,
            this.Ask,
            this.Last,
            this.Volume,
            this.Spread,
            this.Manage});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridMarketData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridMarketData.EnableHeadersVisualStyles = false;
            this.dataGridMarketData.Location = new System.Drawing.Point(1, 0);
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
            this.dataGridMarketData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMarketData.Size = new System.Drawing.Size(402, 306);
            this.dataGridMarketData.TabIndex = 0;
            // 
            // Symbol
            // 
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            this.Symbol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Bid
            // 
            this.Bid.HeaderText = "Bid";
            this.Bid.Name = "Bid";
            this.Bid.ReadOnly = true;
            // 
            // Ask
            // 
            this.Ask.HeaderText = "Ask";
            this.Ask.Name = "Ask";
            this.Ask.ReadOnly = true;
            // 
            // Last
            // 
            this.Last.HeaderText = "Last";
            this.Last.Name = "Last";
            this.Last.ReadOnly = true;
            // 
            // Volume
            // 
            this.Volume.HeaderText = "Volume";
            this.Volume.Name = "Volume";
            this.Volume.ReadOnly = true;
            // 
            // Spread
            // 
            this.Spread.HeaderText = "Spread";
            this.Spread.Name = "Spread";
            this.Spread.ReadOnly = true;
            // 
            // Manage
            // 
            this.Manage.HeaderText = "Manage";
            this.Manage.Name = "Manage";
            this.Manage.ReadOnly = true;
            // 
            // frmMarketWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 270);
            this.Controls.Add(this.dataGridMarketData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMarketWatch";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.Text = "Market Watch";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMarketData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridMarketData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ask;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spread;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manage;
    }
}