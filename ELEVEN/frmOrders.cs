using ComponentFactory.Krypton.Toolkit;
using ELEVEN.DBConnection;
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
        BrokerInstrumentMapping instrumentMapping = null;
        public frmOrders()
        {
            InitializeComponent();
            instrumentMapping = new BrokerInstrumentMapping();
            txtSecurity.Text = "Security";
            txtQuantity.Text = "Quantity";
            AutoCompletetxtAddRow();
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
        public void AutoCompletetxtAddRow()
        {
            AutoCompleteStringCollection SymbolCollection = new AutoCompleteStringCollection();
            var result = instrumentMapping.SearchMapping();
           
            foreach (var item in result)
            {
                SymbolCollection.Add(item.BrokerCode + "." + item.InstrumentCode);
            }
            txtSecurity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSecurity.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSecurity.AutoCompleteCustomSource = SymbolCollection;

        }
        private void btnDetails_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var symbol = txtSecurity.Text;
            var side = comboBuySell.SelectedValue;
            var type = comboBoxMarket.SelectedValue;
            var amount = txtQuantity.Text;
            var exchange = comboBoxStocks.SelectedValue;
        }
    }
}
