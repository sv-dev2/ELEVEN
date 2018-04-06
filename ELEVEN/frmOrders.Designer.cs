namespace ELEVEN
{
    partial class frmOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrders));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSecurity = new System.Windows.Forms.TextBox();
            this.comboBuySell = new System.Windows.Forms.ComboBox();
            this.comboBoxMarket = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.comboBoxStocks = new System.Windows.Forms.ComboBox();
            this.comboBoxNumber = new System.Windows.Forms.ComboBox();
            this.dataGridViewOrder = new System.Windows.Forms.DataGridView();
            this.StrategyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Side = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilledQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.btnSettings = new RoundButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order (5)";
            // 
            // txtSecurity
            // 
            this.txtSecurity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecurity.Location = new System.Drawing.Point(12, 44);
            this.txtSecurity.Name = "txtSecurity";
            this.txtSecurity.Size = new System.Drawing.Size(115, 23);
            this.txtSecurity.TabIndex = 1;
            // 
            // comboBuySell
            // 
            this.comboBuySell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBuySell.FormattingEnabled = true;
            this.comboBuySell.Items.AddRange(new object[] {
            "BUY",
            "SELL",
            "SELL_SHORT"});
            this.comboBuySell.Location = new System.Drawing.Point(129, 44);
            this.comboBuySell.Name = "comboBuySell";
            this.comboBuySell.Size = new System.Drawing.Size(121, 24);
            this.comboBuySell.TabIndex = 2;
            // 
            // comboBoxMarket
            // 
            this.comboBoxMarket.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMarket.FormattingEnabled = true;
            this.comboBoxMarket.Items.AddRange(new object[] {
            "MARKET",
            "LIMIT",
            "STOP",
            "STOP_LIMIT"});
            this.comboBoxMarket.Location = new System.Drawing.Point(252, 44);
            this.comboBoxMarket.Name = "comboBoxMarket";
            this.comboBoxMarket.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMarket.TabIndex = 3;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(375, 44);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(115, 23);
            this.txtQuantity.TabIndex = 4;
            // 
            // comboBoxStocks
            // 
            this.comboBoxStocks.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStocks.FormattingEnabled = true;
            this.comboBoxStocks.Items.AddRange(new object[] {
            "STOCKS\t",
            "FOREX",
            "FUTURES",
            "CRYPTOS"});
            this.comboBoxStocks.Location = new System.Drawing.Point(492, 44);
            this.comboBoxStocks.Name = "comboBoxStocks";
            this.comboBoxStocks.Size = new System.Drawing.Size(121, 24);
            this.comboBoxStocks.TabIndex = 5;
            // 
            // comboBoxNumber
            // 
            this.comboBoxNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxNumber.FormattingEnabled = true;
            this.comboBoxNumber.Items.AddRange(new object[] {
            "XZY123"});
            this.comboBoxNumber.Location = new System.Drawing.Point(615, 44);
            this.comboBoxNumber.Name = "comboBoxNumber";
            this.comboBoxNumber.Size = new System.Drawing.Size(121, 24);
            this.comboBoxNumber.TabIndex = 6;
            // 
            // dataGridViewOrder
            // 
            this.dataGridViewOrder.AllowUserToDeleteRows = false;
            this.dataGridViewOrder.AllowUserToOrderColumns = true;
            this.dataGridViewOrder.AllowUserToResizeColumns = false;
            this.dataGridViewOrder.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dataGridViewOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(119)))), ((int)(((byte)(183)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewOrder.ColumnHeadersHeight = 35;
            this.dataGridViewOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StrategyName,
            this.OrderId,
            this.Symbol,
            this.Side,
            this.Qty,
            this.OpenTime,
            this.Price,
            this.State,
            this.FilledQty,
            this.Manage});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewOrder.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewOrder.EnableHeadersVisualStyles = false;
            this.dataGridViewOrder.Location = new System.Drawing.Point(-1, 112);
            this.dataGridViewOrder.MultiSelect = false;
            this.dataGridViewOrder.Name = "dataGridViewOrder";
            this.dataGridViewOrder.ReadOnly = true;
            this.dataGridViewOrder.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewOrder.RowHeadersVisible = false;
            this.dataGridViewOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrder.Size = new System.Drawing.Size(801, 179);
            this.dataGridViewOrder.TabIndex = 11;
            // 
            // StrategyName
            // 
            this.StrategyName.HeaderText = "Strategy Name";
            this.StrategyName.Name = "StrategyName";
            this.StrategyName.ReadOnly = true;
            // 
            // OrderId
            // 
            this.OrderId.HeaderText = "Order Id";
            this.OrderId.Name = "OrderId";
            this.OrderId.ReadOnly = true;
            // 
            // Symbol
            // 
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            // 
            // Side
            // 
            this.Side.HeaderText = "Side";
            this.Side.Name = "Side";
            this.Side.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // OpenTime
            // 
            this.OpenTime.HeaderText = "Open Time";
            this.OpenTime.Name = "OpenTime";
            this.OpenTime.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // FilledQty
            // 
            this.FilledQty.HeaderText = "FilledQty";
            this.FilledQty.Name = "FilledQty";
            this.FilledQty.ReadOnly = true;
            // 
            // Manage
            // 
            this.Manage.HeaderText = "Manage";
            this.Manage.Name = "Manage";
            this.Manage.ReadOnly = true;
            // 
            // btnDetails
            // 
            this.btnDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(119)))), ((int)(((byte)(183)))));
            this.btnDetails.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btnDetails.FlatAppearance.BorderSize = 2;
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Location = new System.Drawing.Point(12, 71);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(111, 35);
            this.btnDetails.TabIndex = 12;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSubmit.FlatAppearance.BorderSize = 2;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(129, 71);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(111, 35);
            this.btnSubmit.TabIndex = 13;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(79)))), ((int)(((byte)(104)))));
            this.btnCancelAll.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCancelAll.FlatAppearance.BorderSize = 2;
            this.btnCancelAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAll.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAll.ForeColor = System.Drawing.Color.White;
            this.btnCancelAll.Location = new System.Drawing.Point(591, 3);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Size = new System.Drawing.Size(111, 35);
            this.btnCancelAll.TabIndex = 14;
            this.btnCancelAll.Text = "Cancel All";
            this.btnCancelAll.UseVisualStyleBackColor = false;
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
            this.btnSettings.Location = new System.Drawing.Point(704, 4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(40, 35);
            this.btnSettings.TabIndex = 17;
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 291);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnCancelAll);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.dataGridViewOrder);
            this.Controls.Add(this.comboBoxNumber);
            this.Controls.Add(this.comboBoxStocks);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.comboBoxMarket);
            this.Controls.Add(this.comboBuySell);
            this.Controls.Add(this.txtSecurity);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrders";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "frmOrders";
            this.Text = "Orders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrders_FormClosing);
            this.Load += new System.EventHandler(this.frmOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSecurity;
        private System.Windows.Forms.ComboBox comboBuySell;
        private System.Windows.Forms.ComboBox comboBoxMarket;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox comboBoxStocks;
        private System.Windows.Forms.ComboBox comboBoxNumber;
        private System.Windows.Forms.DataGridView dataGridViewOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrategyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Side;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilledQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manage;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancelAll;
        private RoundButton btnSettings;
    }
}