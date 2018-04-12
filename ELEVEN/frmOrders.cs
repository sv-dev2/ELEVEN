using ComponentFactory.Krypton.Toolkit;
using ELEVEN.DBConnection;
using ELEVEN.Models;
using ELEVEN.Services;
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
        BitfinexAPI bitfinexAPI = null;
        public frmOrders()
        {
            InitializeComponent();
            bitfinexAPI = new BitfinexAPI();
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
            FillCombobox();
        }
        private void FillCombobox()
        {
            var comboSide = OrderWindow.GetSide();
            comboBuySell.DataSource = comboSide;
            comboBuySell.DisplayMember = "Value";
            comboBuySell.ValueMember = "Value";

            var comboType = OrderWindow.GetOrderType();
            comboBoxOrderType.DataSource = comboType;
            comboBoxOrderType.DisplayMember = "Value";
            comboBoxOrderType.ValueMember = "Value";

            var comboExchange = OrderWindow.GetExchange();
            comboBoxExchange.DataSource = comboExchange;
            comboBoxExchange.DisplayMember = "Value";
            comboBoxExchange.ValueMember = "Value";

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
            var type = comboBoxOrderType.SelectedValue;
            var amount = txtQuantity.Text;
            var exchange = comboBoxExchange.SelectedValue;
            if (symbol == string.Empty || symbol == "Security")
            {
                MessageBox.Show(this, "Please fill security", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (side == null)
            {
                MessageBox.Show(this, "Please fill side", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (type == null)
            {
                MessageBox.Show(this, "Please fill type", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (amount == null || amount == "Quantity")
            {
                MessageBox.Show(this, "Please fill quantity", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (exchange == null)
            {
                MessageBox.Show(this, "Please fill exchange", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            decimal quantity;
            var isNumeric = decimal.TryParse(amount, out quantity);
            if (!isNumeric)
            {
                MessageBox.Show(this, "Please fill numeric value for quantity", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NewOrderResponse response = null;
            if (symbol.ToLower().IndexOf(Broker.BitFinex.ToString().ToLower()) > -1)
            {
                var instrumentCode = symbol.Split('.');
                 symbol = instrumentCode[1].ToUpper();
                if (side.ToString().ToLower() == "buy")
                {
                    response = bitfinexAPI.ExecuteBuyOrderBTC(symbol.ToLower(), quantity, 10, exchange.ToString().ToLower(), type.ToString().ToLower());
                }
                else
                {
                    response = bitfinexAPI.ExecuteSellOrderBTC(symbol.ToLower(), quantity, 10, exchange.ToString().ToLower(), type.ToString().ToLower());
                }
                if (response != null)
                {

                }
            }
           
        }
    }
}
