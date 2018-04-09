using ComponentFactory.Krypton.Toolkit;
using ELEVEN.DBConnection;
using ELEVEN.Model;
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
    public partial class frmBrokerInstrumentMapping : KryptonForm
    {
        BrokerInstrumentMapping instrumentMapping = null;
        clsBrokerInstrumentMapping brokerInstrumentMapping = null;
        List<clsInstrument> InstrumentList = null;
        List<clsBroker> brokerList = null;
        public frmBrokerInstrumentMapping()
        {
            InitializeComponent();
            instrumentMapping = new BrokerInstrumentMapping();
            brokerInstrumentMapping = new clsBrokerInstrumentMapping();
        }

        private void frmBrokerInstrumentMapping_Load(object sender, EventArgs e)
        {
            BindComboBox();
            BindProperties();
        }
        private void BindComboBox()
        {
            InstrumentList = instrumentMapping.GetInstruments();
            brokerList = instrumentMapping.GetBrokers();
            comboBroker.DataSource = brokerList;
            comboBroker.DisplayMember = "BrokerCode";
            comboBroker.ValueMember = "Id";

            comboInstrument.DataSource = InstrumentList;
            comboInstrument.DisplayMember = "InstrumentCode";
            comboInstrument.ValueMember = "Id";

        }
        private void BindProperties()
        {

            comboBroker.DataBindings.Add("SelectedValue", brokerInstrumentMapping, "BrokerId", true, DataSourceUpdateMode.OnPropertyChanged);
            comboInstrument.DataBindings.Add("SelectedValue", brokerInstrumentMapping, "InstrumentId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtBIC.DataBindings.Add("Text", brokerInstrumentMapping, "BrokerInstrumentCode", true, DataSourceUpdateMode.OnPropertyChanged);
            chkPrices.DataBindings.Add("Checked", brokerInstrumentMapping, "FeedPrices", true, DataSourceUpdateMode.OnPropertyChanged);
            chkTrades.DataBindings.Add("Checked", brokerInstrumentMapping, "FeedTrades", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnCreateMap_Click(object sender, EventArgs e)
        {
            if (brokerInstrumentMapping.BrokerId == 0)
            {
                MessageBox.Show(this, "Please select a broker.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (brokerInstrumentMapping.InstrumentId == 0)
            {
                MessageBox.Show(this, "Please select a instrument.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (brokerInstrumentMapping.BrokerInstrumentCode == null || brokerInstrumentMapping.BrokerInstrumentCode.Trim() == string.Empty)
            {
                MessageBox.Show(this, "Please fill broker instrument code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (instrumentMapping.CheckDuplicateMapping(brokerInstrumentMapping))
            {
                instrumentMapping.AddBrokerInstrumentMapping(brokerInstrumentMapping);
                MessageBox.Show(this, "Mapping created successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Mapping already present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
