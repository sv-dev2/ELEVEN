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
    public partial class frmBroker : KryptonForm
    {
        clsBroker broker = null;
        BrokerInstrumentMapping instrumentMapping = null;
        public frmBroker()
        {
            InitializeComponent();
            broker = new clsBroker();
            instrumentMapping = new BrokerInstrumentMapping();
        }

        private void BtnCreateBroker_Click(object sender, EventArgs e)
        {
            if (broker.BrokerCode != null && broker.BrokerCode.Trim() != string.Empty)
            {
                if (instrumentMapping.CheckDuplicateBroker(broker))
                {
                    instrumentMapping.AddBroker(broker);
                    MessageBox.Show(this, "Broker added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Broker code already present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Please enter a valid broker code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmBroker_Load(object sender, EventArgs e)
        {
            BindProperties();
        }
        private void BindProperties()
        {
            txtBrokerCode.DataBindings.Add("Text", broker, "BrokerCode", true, DataSourceUpdateMode.OnPropertyChanged);
            txtBrokerDescription.DataBindings.Add("Text", broker, "BrokerDescription", true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
