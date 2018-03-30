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
    public partial class frmClosedPosition : Form
    {
        public frmClosedPosition()
        {
            InitializeComponent();
        }

        private void frmClosedPosition_FormClosing(object sender, FormClosingEventArgs e)
        {
            TabControl tabControl = this.MdiParent.Controls["tabControl1"] as TabControl;
            tabControl.TabPages.RemoveByKey(this.Name);
        }
    }
}
