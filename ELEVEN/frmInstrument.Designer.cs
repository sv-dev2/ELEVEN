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
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.BtnCreateInstrument);
            this.kryptonPanel1.Controls.Add(this.txtInstrumentDescription);
            this.kryptonPanel1.Controls.Add(this.txtInstrumentCode);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(520, 261);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // BtnCreateInstrument
            // 
            this.BtnCreateInstrument.Location = new System.Drawing.Point(202, 130);
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
            this.txtInstrumentDescription.Location = new System.Drawing.Point(202, 88);
            this.txtInstrumentDescription.Name = "txtInstrumentDescription";
            this.txtInstrumentDescription.Size = new System.Drawing.Size(200, 20);
            this.txtInstrumentDescription.TabIndex = 3;
            // 
            // txtInstrumentCode
            // 
            this.txtInstrumentCode.Location = new System.Drawing.Point(202, 43);
            this.txtInstrumentCode.Name = "txtInstrumentCode";
            this.txtInstrumentCode.Size = new System.Drawing.Size(200, 20);
            this.txtInstrumentCode.TabIndex = 2;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(68, 89);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(135, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Instrument Description";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(68, 47);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Instrument Code";
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
            this.Text = "Instrument";
            this.Load += new System.EventHandler(this.frmInstrument_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCreateInstrument;
        private System.Windows.Forms.TextBox txtInstrumentDescription;
        private System.Windows.Forms.TextBox txtInstrumentCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}