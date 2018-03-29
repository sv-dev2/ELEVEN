namespace ELEVEN
{
    partial class frmPositions
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StrategyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarketPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarketValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnrealizedPL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPosition = new System.Windows.Forms.Label();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.btnSettings = new RoundButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(119)))), ((int)(((byte)(183)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StrategyName,
            this.Symbol,
            this.Qty,
            this.MarketPrice,
            this.MarketValue,
            this.Cost,
            this.UnrealizedPL,
            this.Manage});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(1, 43);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(797, 247);
            this.dataGridView1.TabIndex = 23;
            // 
            // StrategyName
            // 
            this.StrategyName.HeaderText = "Strategy Name";
            this.StrategyName.Name = "StrategyName";
            this.StrategyName.ReadOnly = true;
            // 
            // Symbol
            // 
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // MarketPrice
            // 
            this.MarketPrice.HeaderText = "Market Price";
            this.MarketPrice.Name = "MarketPrice";
            this.MarketPrice.ReadOnly = true;
            // 
            // MarketValue
            // 
            this.MarketValue.HeaderText = "Market Value";
            this.MarketValue.Name = "MarketValue";
            this.MarketValue.ReadOnly = true;
            // 
            // Cost
            // 
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // UnrealizedPL
            // 
            this.UnrealizedPL.HeaderText = "Unrealized PL";
            this.UnrealizedPL.Name = "UnrealizedPL";
            this.UnrealizedPL.ReadOnly = true;
            // 
            // Manage
            // 
            this.Manage.HeaderText = "Manage";
            this.Manage.Name = "Manage";
            this.Manage.ReadOnly = true;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPosition.Location = new System.Drawing.Point(13, 7);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(93, 16);
            this.lblPosition.TabIndex = 12;
            this.lblPosition.Text = "Position (5)";
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(79)))), ((int)(((byte)(104)))));
            this.btnCloseAll.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCloseAll.FlatAppearance.BorderSize = 2;
            this.btnCloseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseAll.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseAll.ForeColor = System.Drawing.Color.White;
            this.btnCloseAll.Location = new System.Drawing.Point(595, 2);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(111, 35);
            this.btnCloseAll.TabIndex = 24;
            this.btnCloseAll.Text = "Close All";
            this.btnCloseAll.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btnSettings.BackgroundImage = global::ELEVEN.Properties.Resources.settings;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btnSettings.FlatAppearance.BorderSize = 2;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(712, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(40, 35);
            this.btnSettings.TabIndex = 25;
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // frmPositions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 291);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnCloseAll);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblPosition);
            this.Name = "frmPositions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Positions";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrategyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarketPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarketValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnrealizedPL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manage;
        private System.Windows.Forms.Button btnCloseAll;
        private RoundButton btnSettings;
    }
}