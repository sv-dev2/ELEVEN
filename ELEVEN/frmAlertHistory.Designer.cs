namespace ELEVEN
{
    partial class frmAlertHistory
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
            this.Mainpanel = new System.Windows.Forms.Panel();
            this.Historypanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHistory = new System.Windows.Forms.Label();
            this.Managementpanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblManagement = new System.Windows.Forms.Label();
            this.lblAlert = new System.Windows.Forms.Label();
            this.Mainpanel.SuspendLayout();
            this.Historypanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Managementpanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mainpanel
            // 
            this.Mainpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Mainpanel.Controls.Add(this.Historypanel);
            this.Mainpanel.Controls.Add(this.Managementpanel);
            this.Mainpanel.Controls.Add(this.lblAlert);
            this.Mainpanel.Location = new System.Drawing.Point(13, 13);
            this.Mainpanel.Name = "Mainpanel";
            this.Mainpanel.Size = new System.Drawing.Size(390, 548);
            this.Mainpanel.TabIndex = 0;
            // 
            // Historypanel
            // 
            this.Historypanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Historypanel.Controls.Add(this.panel2);
            this.Historypanel.Location = new System.Drawing.Point(14, 302);
            this.Historypanel.Name = "Historypanel";
            this.Historypanel.Size = new System.Drawing.Size(362, 230);
            this.Historypanel.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblHistory);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(362, 53);
            this.panel2.TabIndex = 0;
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistory.Location = new System.Drawing.Point(13, 23);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(67, 19);
            this.lblHistory.TabIndex = 0;
            this.lblHistory.Text = "History";
            // 
            // Managementpanel
            // 
            this.Managementpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Managementpanel.Controls.Add(this.panel1);
            this.Managementpanel.Location = new System.Drawing.Point(14, 38);
            this.Managementpanel.Name = "Managementpanel";
            this.Managementpanel.Size = new System.Drawing.Size(362, 247);
            this.Managementpanel.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblManagement);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 49);
            this.panel1.TabIndex = 0;
            // 
            // lblManagement
            // 
            this.lblManagement.AutoSize = true;
            this.lblManagement.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagement.Location = new System.Drawing.Point(9, 16);
            this.lblManagement.Name = "lblManagement";
            this.lblManagement.Size = new System.Drawing.Size(105, 19);
            this.lblManagement.TabIndex = 0;
            this.lblManagement.Text = "Mangement";
            // 
            // lblAlert
            // 
            this.lblAlert.AutoSize = true;
            this.lblAlert.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlert.Location = new System.Drawing.Point(153, 9);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(63, 19);
            this.lblAlert.TabIndex = 0;
            this.lblAlert.Text = "ALERT";
            // 
            // frmAlertHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 573);
            this.Controls.Add(this.Mainpanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAlertHistory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "History";
            this.Mainpanel.ResumeLayout(false);
            this.Mainpanel.PerformLayout();
            this.Historypanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.Managementpanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Mainpanel;
        private System.Windows.Forms.Label lblAlert;
        private System.Windows.Forms.Panel Historypanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.Panel Managementpanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblManagement;
    }
}