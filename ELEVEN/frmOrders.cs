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
    public partial class frmOrders : KryptonForm
    {
        public frmOrders()
        {
            InitializeComponent();
            txtSecurity.Text = "Security";
            txtQuantity.Text = "Quantity";
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            txtSecurity.GotFocus += TxtSecurity_GotFocus;
            txtSecurity.LostFocus += TxtSecurity_LostFocus;

            txtQuantity.GotFocus += TxtQuantity_GotFocus;
            txtQuantity.LostFocus += TxtQuantity_LostFocus;
        }

        private void TxtQuantity_LostFocus(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtQuantity.Text))
                txtQuantity.Text = "Quantity";
        }

        private void TxtQuantity_GotFocus(object sender, EventArgs e)
        {
            txtQuantity.Text = string.Empty;
        }

        private void TxtSecurity_LostFocus(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSecurity.Text))
                txtSecurity.Text = "Security";
        }

        private void TxtSecurity_GotFocus(object sender, EventArgs e)
        {
            txtSecurity.Text = "";
        }

        private void frmOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            TabControl tabControl = this.MdiParent.Controls["tabControl1"] as TabControl;
            tabControl.TabPages.RemoveByKey(this.Name);
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {

        }
    }
}
