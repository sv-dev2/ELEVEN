﻿namespace ELEVEN
{
    partial class frmAlertWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlertWindow));
            this.lblCondition = new System.Windows.Forms.Label();
            this.ddCondition1 = new System.Windows.Forms.ComboBox();
            this.ddCondition2 = new System.Windows.Forms.ComboBox();
            this.ddCondition3 = new System.Windows.Forms.ComboBox();
            this.ConditionNumeric = new System.Windows.Forms.NumericUpDown();
            this.lblOptions = new System.Windows.Forms.Label();
            this.lblExpirationTime = new System.Windows.Forms.Label();
            this.txtCalender = new System.Windows.Forms.TextBox();
            this.txtTimer = new System.Windows.Forms.TextBox();
            this.chkShowPopup = new System.Windows.Forms.CheckBox();
            this.lblAlertAction = new System.Windows.Forms.Label();
            this.chkPlaySound = new System.Windows.Forms.CheckBox();
            this.ddAlertAction1 = new System.Windows.Forms.ComboBox();
            this.ddAlertAction2 = new System.Windows.Forms.ComboBox();
            this.chkSendEmail = new System.Windows.Forms.CheckBox();
            this.chkEmailToSMS = new System.Windows.Forms.CheckBox();
            this.chkSMS = new System.Windows.Forms.CheckBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOnlyOnce = new System.Windows.Forms.Button();
            this.btnOncePerBar = new System.Windows.Forms.Button();
            this.btnOncePerBarClose = new System.Windows.Forms.Button();
            this.btnOncePerMinute = new System.Windows.Forms.Button();
            this.Calenderpanel = new System.Windows.Forms.Panel();
            this.imgCalender = new System.Windows.Forms.PictureBox();
            this.Timerpanel = new System.Windows.Forms.Panel();
            this.imgTimer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ConditionNumeric)).BeginInit();
            this.Calenderpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCalender)).BeginInit();
            this.Timerpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondition.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCondition.Location = new System.Drawing.Point(21, 38);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(76, 20);
            this.lblCondition.TabIndex = 0;
            this.lblCondition.Text = "Condition";
            // 
            // ddCondition1
            // 
            this.ddCondition1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddCondition1.FormattingEnabled = true;
            this.ddCondition1.Location = new System.Drawing.Point(197, 30);
            this.ddCondition1.Name = "ddCondition1";
            this.ddCondition1.Size = new System.Drawing.Size(150, 28);
            this.ddCondition1.TabIndex = 1;
            // 
            // ddCondition2
            // 
            this.ddCondition2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddCondition2.FormattingEnabled = true;
            this.ddCondition2.Location = new System.Drawing.Point(197, 64);
            this.ddCondition2.Name = "ddCondition2";
            this.ddCondition2.Size = new System.Drawing.Size(297, 28);
            this.ddCondition2.TabIndex = 2;
            // 
            // ddCondition3
            // 
            this.ddCondition3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddCondition3.FormattingEnabled = true;
            this.ddCondition3.Location = new System.Drawing.Point(197, 103);
            this.ddCondition3.Name = "ddCondition3";
            this.ddCondition3.Size = new System.Drawing.Size(149, 28);
            this.ddCondition3.TabIndex = 3;
            // 
            // ConditionNumeric
            // 
            this.ConditionNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConditionNumeric.Location = new System.Drawing.Point(363, 103);
            this.ConditionNumeric.Name = "ConditionNumeric";
            this.ConditionNumeric.Size = new System.Drawing.Size(131, 26);
            this.ConditionNumeric.TabIndex = 4;
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptions.Location = new System.Drawing.Point(21, 156);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(64, 20);
            this.lblOptions.TabIndex = 5;
            this.lblOptions.Text = "Options";
            this.lblOptions.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblExpirationTime
            // 
            this.lblExpirationTime.AutoSize = true;
            this.lblExpirationTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirationTime.Location = new System.Drawing.Point(21, 239);
            this.lblExpirationTime.Name = "lblExpirationTime";
            this.lblExpirationTime.Size = new System.Drawing.Size(113, 20);
            this.lblExpirationTime.TabIndex = 7;
            this.lblExpirationTime.Text = "Expiration time";
            // 
            // txtCalender
            // 
            this.txtCalender.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCalender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalender.Location = new System.Drawing.Point(0, 2);
            this.txtCalender.Name = "txtCalender";
            this.txtCalender.Size = new System.Drawing.Size(126, 19);
            this.txtCalender.TabIndex = 8;
            // 
            // txtTimer
            // 
            this.txtTimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimer.Location = new System.Drawing.Point(2, 2);
            this.txtTimer.Name = "txtTimer";
            this.txtTimer.Size = new System.Drawing.Size(101, 19);
            this.txtTimer.TabIndex = 9;
            // 
            // chkShowPopup
            // 
            this.chkShowPopup.AutoSize = true;
            this.chkShowPopup.BackColor = System.Drawing.SystemColors.Control;
            this.chkShowPopup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowPopup.ForeColor = System.Drawing.SystemColors.GrayText;
            this.chkShowPopup.Location = new System.Drawing.Point(198, 279);
            this.chkShowPopup.Name = "chkShowPopup";
            this.chkShowPopup.Size = new System.Drawing.Size(118, 24);
            this.chkShowPopup.TabIndex = 10;
            this.chkShowPopup.Text = "Show Popup";
            this.chkShowPopup.UseVisualStyleBackColor = false;
            // 
            // lblAlertAction
            // 
            this.lblAlertAction.AutoSize = true;
            this.lblAlertAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertAction.Location = new System.Drawing.Point(21, 280);
            this.lblAlertAction.Name = "lblAlertAction";
            this.lblAlertAction.Size = new System.Drawing.Size(99, 20);
            this.lblAlertAction.TabIndex = 11;
            this.lblAlertAction.Text = "Alert Actions";
            // 
            // chkPlaySound
            // 
            this.chkPlaySound.AutoSize = true;
            this.chkPlaySound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPlaySound.Location = new System.Drawing.Point(197, 305);
            this.chkPlaySound.Name = "chkPlaySound";
            this.chkPlaySound.Size = new System.Drawing.Size(108, 24);
            this.chkPlaySound.TabIndex = 12;
            this.chkPlaySound.Text = "Play Sound";
            this.chkPlaySound.UseVisualStyleBackColor = true;
            // 
            // ddAlertAction1
            // 
            this.ddAlertAction1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddAlertAction1.FormattingEnabled = true;
            this.ddAlertAction1.Location = new System.Drawing.Point(198, 336);
            this.ddAlertAction1.Name = "ddAlertAction1";
            this.ddAlertAction1.Size = new System.Drawing.Size(183, 28);
            this.ddAlertAction1.TabIndex = 13;
            // 
            // ddAlertAction2
            // 
            this.ddAlertAction2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddAlertAction2.FormattingEnabled = true;
            this.ddAlertAction2.Location = new System.Drawing.Point(397, 336);
            this.ddAlertAction2.Name = "ddAlertAction2";
            this.ddAlertAction2.Size = new System.Drawing.Size(97, 28);
            this.ddAlertAction2.TabIndex = 14;
            // 
            // chkSendEmail
            // 
            this.chkSendEmail.AutoSize = true;
            this.chkSendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSendEmail.Location = new System.Drawing.Point(198, 371);
            this.chkSendEmail.Name = "chkSendEmail";
            this.chkSendEmail.Size = new System.Drawing.Size(109, 24);
            this.chkSendEmail.TabIndex = 15;
            this.chkSendEmail.Text = "Send Email";
            this.chkSendEmail.UseVisualStyleBackColor = true;
            // 
            // chkEmailToSMS
            // 
            this.chkEmailToSMS.AutoSize = true;
            this.chkEmailToSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmailToSMS.Location = new System.Drawing.Point(198, 395);
            this.chkEmailToSMS.Name = "chkEmailToSMS";
            this.chkEmailToSMS.Size = new System.Drawing.Size(168, 24);
            this.chkEmailToSMS.TabIndex = 16;
            this.chkEmailToSMS.Text = "Send Email-to-SMS";
            this.chkEmailToSMS.UseVisualStyleBackColor = true;
            // 
            // chkSMS
            // 
            this.chkSMS.AutoSize = true;
            this.chkSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSMS.Location = new System.Drawing.Point(198, 420);
            this.chkSMS.Name = "chkSMS";
            this.chkSMS.Size = new System.Drawing.Size(105, 24);
            this.chkSMS.TabIndex = 17;
            this.chkSMS.Text = "Send SMS";
            this.chkSMS.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(21, 457);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(74, 20);
            this.lblMessage.TabIndex = 18;
            this.lblMessage.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(198, 457);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(297, 78);
            this.txtMessage.TabIndex = 19;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(421, 557);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 32);
            this.btnCreate.TabIndex = 20;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(338, 558);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOnlyOnce
            // 
            this.btnOnlyOnce.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOnlyOnce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnlyOnce.Location = new System.Drawing.Point(197, 151);
            this.btnOnlyOnce.Name = "btnOnlyOnce";
            this.btnOnlyOnce.Size = new System.Drawing.Size(149, 32);
            this.btnOnlyOnce.TabIndex = 4;
            this.btnOnlyOnce.Text = "Only Once";
            this.btnOnlyOnce.UseVisualStyleBackColor = false;
            this.btnOnlyOnce.Click += new System.EventHandler(this.Options_Click);
            // 
            // btnOncePerBar
            // 
            this.btnOncePerBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOncePerBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOncePerBar.Location = new System.Drawing.Point(346, 151);
            this.btnOncePerBar.Name = "btnOncePerBar";
            this.btnOncePerBar.Size = new System.Drawing.Size(148, 32);
            this.btnOncePerBar.TabIndex = 5;
            this.btnOncePerBar.Text = "Once Per Bar";
            this.btnOncePerBar.UseVisualStyleBackColor = false;
            this.btnOncePerBar.Click += new System.EventHandler(this.Options_Click);
            // 
            // btnOncePerBarClose
            // 
            this.btnOncePerBarClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOncePerBarClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOncePerBarClose.Location = new System.Drawing.Point(197, 183);
            this.btnOncePerBarClose.Name = "btnOncePerBarClose";
            this.btnOncePerBarClose.Size = new System.Drawing.Size(149, 34);
            this.btnOncePerBarClose.TabIndex = 6;
            this.btnOncePerBarClose.Text = "Once Per Bar Close";
            this.btnOncePerBarClose.UseVisualStyleBackColor = false;
            this.btnOncePerBarClose.Click += new System.EventHandler(this.Options_Click);
            // 
            // btnOncePerMinute
            // 
            this.btnOncePerMinute.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOncePerMinute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOncePerMinute.Location = new System.Drawing.Point(346, 183);
            this.btnOncePerMinute.Name = "btnOncePerMinute";
            this.btnOncePerMinute.Size = new System.Drawing.Size(148, 34);
            this.btnOncePerMinute.TabIndex = 7;
            this.btnOncePerMinute.Text = "Once Per Minute";
            this.btnOncePerMinute.UseVisualStyleBackColor = false;
            this.btnOncePerMinute.Click += new System.EventHandler(this.Options_Click);
            // 
            // Calenderpanel
            // 
            this.Calenderpanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Calenderpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Calenderpanel.Controls.Add(this.imgCalender);
            this.Calenderpanel.Controls.Add(this.txtCalender);
            this.Calenderpanel.Location = new System.Drawing.Point(197, 237);
            this.Calenderpanel.Name = "Calenderpanel";
            this.Calenderpanel.Size = new System.Drawing.Size(149, 26);
            this.Calenderpanel.TabIndex = 22;
            // 
            // imgCalender
            // 
            this.imgCalender.Image = global::ELEVEN.Properties.Resources.Calender;
            this.imgCalender.Location = new System.Drawing.Point(125, 2);
            this.imgCalender.Name = "imgCalender";
            this.imgCalender.Size = new System.Drawing.Size(20, 20);
            this.imgCalender.TabIndex = 9;
            this.imgCalender.TabStop = false;
            // 
            // Timerpanel
            // 
            this.Timerpanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Timerpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Timerpanel.Controls.Add(this.imgTimer);
            this.Timerpanel.Controls.Add(this.txtTimer);
            this.Timerpanel.Location = new System.Drawing.Point(363, 237);
            this.Timerpanel.Name = "Timerpanel";
            this.Timerpanel.Size = new System.Drawing.Size(131, 26);
            this.Timerpanel.TabIndex = 23;
            // 
            // imgTimer
            // 
            this.imgTimer.Image = ((System.Drawing.Image)(resources.GetObject("imgTimer.Image")));
            this.imgTimer.Location = new System.Drawing.Point(107, 2);
            this.imgTimer.Name = "imgTimer";
            this.imgTimer.Size = new System.Drawing.Size(20, 20);
            this.imgTimer.TabIndex = 10;
            this.imgTimer.TabStop = false;
            // 
            // frmAlertWindow
            // 
            this.ClientSize = new System.Drawing.Size(519, 602);
            this.Controls.Add(this.Timerpanel);
            this.Controls.Add(this.Calenderpanel);
            this.Controls.Add(this.btnOncePerMinute);
            this.Controls.Add(this.btnOncePerBarClose);
            this.Controls.Add(this.btnOncePerBar);
            this.Controls.Add(this.btnOnlyOnce);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.chkSMS);
            this.Controls.Add(this.chkEmailToSMS);
            this.Controls.Add(this.chkSendEmail);
            this.Controls.Add(this.ddAlertAction2);
            this.Controls.Add(this.ddAlertAction1);
            this.Controls.Add(this.chkPlaySound);
            this.Controls.Add(this.lblAlertAction);
            this.Controls.Add(this.chkShowPopup);
            this.Controls.Add(this.lblExpirationTime);
            this.Controls.Add(this.lblOptions);
            this.Controls.Add(this.ConditionNumeric);
            this.Controls.Add(this.ddCondition3);
            this.Controls.Add(this.ddCondition2);
            this.Controls.Add(this.ddCondition1);
            this.Controls.Add(this.lblCondition);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Name = "frmAlertWindow";
            ((System.ComponentModel.ISupportInitialize)(this.ConditionNumeric)).EndInit();
            this.Calenderpanel.ResumeLayout(false);
            this.Calenderpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCalender)).EndInit();
            this.Timerpanel.ResumeLayout(false);
            this.Timerpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTimer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.ComboBox ddCondition1;
        private System.Windows.Forms.ComboBox ddCondition2;
        private System.Windows.Forms.ComboBox ddCondition3;
        private System.Windows.Forms.NumericUpDown ConditionNumeric;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.Label lblExpirationTime;
        private System.Windows.Forms.TextBox txtCalender;
        private System.Windows.Forms.TextBox txtTimer;
        private System.Windows.Forms.CheckBox chkShowPopup;
        private System.Windows.Forms.Label lblAlertAction;
        private System.Windows.Forms.CheckBox chkPlaySound;
        private System.Windows.Forms.ComboBox ddAlertAction1;
        private System.Windows.Forms.ComboBox ddAlertAction2;
        private System.Windows.Forms.CheckBox chkSendEmail;
        private System.Windows.Forms.CheckBox chkEmailToSMS;
        private System.Windows.Forms.CheckBox chkSMS;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOnlyOnce;
        private System.Windows.Forms.Button btnOncePerBar;
        private System.Windows.Forms.Button btnOncePerBarClose;
        private System.Windows.Forms.Button btnOncePerMinute;
        private System.Windows.Forms.Panel Calenderpanel;
        private System.Windows.Forms.PictureBox imgCalender;
        private System.Windows.Forms.Panel Timerpanel;
        private System.Windows.Forms.PictureBox imgTimer;
    }
}