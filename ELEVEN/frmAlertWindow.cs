using ComponentFactory.Krypton.Toolkit;
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
    public partial class frmAlertWindow : KryptonForm
    {
        public frmAlertWindow()
        {
            InitializeComponent();
            
        }

        private void frmAlertWindow_Load(object sender, EventArgs e)
        {
           
        }
        private void btnOnlyOnce_MouseLeave(object sender, EventArgs e)
        {
            btnOnlyOnce.ForeColor = Color.Gray;
        }

        private void btnOnlyOnce_MouseHover(object sender, EventArgs e)
        {
            btnOnlyOnce.ForeColor = SystemColors.Highlight;
        }
        private void Options_Click(object sender, EventArgs e)
        {
            btnOnlyOnce.ForeColor = SystemColors.GrayText;
            btnOncePerBar.ForeColor = SystemColors.GrayText;
            btnOncePerBarClose.ForeColor = SystemColors.GrayText;
            btnOncePerMinute.ForeColor = SystemColors.GrayText;
            Button button = sender as Button;
            button.ForeColor = SystemColors.Highlight;
        }

        private void frmAlertWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            TabControl tabControl = this.MdiParent.Controls["tabControl1"] as TabControl;
            tabControl.TabPages.RemoveByKey(this.Name);
        }
    }
}
