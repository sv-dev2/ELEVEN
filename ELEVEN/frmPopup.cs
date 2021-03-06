﻿using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELEVEN
{
    public partial class frmPopup : KryptonForm
    {
        public frmPopup()
        {
            InitializeComponent();
        }
        private string _name;
        public string WorkspaceName
        {
            get { return _name; }
            set { _name = value; }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (textName.Text.Trim() != string.Empty)
            {
                WorkspaceName = textName.Text;
                this.Close();
            }
        }
    }
}
