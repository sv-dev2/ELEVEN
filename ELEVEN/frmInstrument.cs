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
    public partial class frmInstrument : KryptonForm
    {
        clsInstrument instrument = null;
        BrokerInstrumentMapping instrumentMapping = null;
        public frmInstrument()
        {
            InitializeComponent();
            instrument = new clsInstrument();
            instrumentMapping = new BrokerInstrumentMapping();
        }

        private void BtnCreateInstrument_Click(object sender, EventArgs e)
        {
            if (instrument.InstrumentCode != null && instrument.InstrumentCode.Trim() != string.Empty)
            {
                if (instrumentMapping.CheckDuplicateInstrument(instrument))
                {
                    instrumentMapping.AddInstrument(instrument);
                    MessageBox.Show(this, "Instrument added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Instrument code already present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Please enter a valid Instrument code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmInstrument_Load(object sender, EventArgs e)
        {
            BindProperties();
        }
        private void BindProperties()
        {
            txtInstrumentCode.DataBindings.Add("Text", instrument, "InstrumentCode", true, DataSourceUpdateMode.OnPropertyChanged);
            txtInstrumentDescription.DataBindings.Add("Text", instrument, "InstrumentDescription", true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
