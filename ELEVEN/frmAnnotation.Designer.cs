namespace ELEVEN
{
    partial class frmAnnotation
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
            this.BtnAnnotation = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtAnnotation = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAnnotation
            // 
            this.BtnAnnotation.Location = new System.Drawing.Point(182, 76);
            this.BtnAnnotation.Name = "BtnAnnotation";
            this.BtnAnnotation.Size = new System.Drawing.Size(143, 53);
            this.BtnAnnotation.TabIndex = 1;
            this.BtnAnnotation.Values.Text = "ADD";
            this.BtnAnnotation.Click += new System.EventHandler(this.BtnAnnotation_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(492, 46);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.kryptonPanel1.StateCommon.Color2 = System.Drawing.Color.Transparent;
            this.kryptonPanel1.TabIndex = 0;
            // 
            // txtAnnotation
            // 
            this.txtAnnotation.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAnnotation.Location = new System.Drawing.Point(0, 46);
            this.txtAnnotation.Name = "txtAnnotation";
            this.txtAnnotation.Size = new System.Drawing.Size(492, 24);
            this.txtAnnotation.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnnotation.TabIndex = 2;
            // 
            // frmAnnotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 180);
            this.Controls.Add(this.txtAnnotation);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.BtnAnnotation);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAnnotation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Annotation";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnAnnotation;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAnnotation;
    }
}