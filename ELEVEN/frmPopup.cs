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
    public partial class frmPopup : Form
    {
        public frmPopup()
        {
            InitializeComponent();
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (textName.Text.Trim() != string.Empty)
            {
                Name = textName.Text;
                this.Close();
            }
        }
    }
}
