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
        clsBrokerInstrumentMapping brokerUpdateMapping = null;
        List<clsInstrument> InstrumentList = null;
        List<clsBroker> brokerList = null;
        MDIParentForm parent;
        public frmBrokerInstrumentMapping(MDIParentForm parent)
        {
            InitializeComponent();
            instrumentMapping = new BrokerInstrumentMapping();
            brokerInstrumentMapping = new clsBrokerInstrumentMapping();
            brokerUpdateMapping = new clsBrokerInstrumentMapping();
            this.parent = parent;
        }
        TabPage updateTab = null;
        private void frmBrokerInstrumentMapping_Load(object sender, EventArgs e)
        {
            BindComboBox();
            BindProperties();
            updateTab = tabPageUpdateMapping;
            tabControl1.TabPages.Remove(tabPageUpdateMapping);
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
        private void BindUpdateComboBox()
        {
            InstrumentList = instrumentMapping.GetInstruments();
            brokerList = instrumentMapping.GetBrokers();
            comboUpdateBroker.DataSource = brokerList;
            comboUpdateBroker.DisplayMember = "BrokerCode";
            comboUpdateBroker.ValueMember = "Id";

            comboUpdateInstrument.DataSource = InstrumentList;
            comboUpdateInstrument.DisplayMember = "InstrumentCode";
            comboUpdateInstrument.ValueMember = "Id";

        }
        private void BindProperties()
        {

            comboBroker.DataBindings.Add("SelectedValue", brokerInstrumentMapping, "BrokerId", true, DataSourceUpdateMode.OnPropertyChanged);
            comboInstrument.DataBindings.Add("SelectedValue", brokerInstrumentMapping, "InstrumentId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtBIC.DataBindings.Add("Text", brokerInstrumentMapping, "BrokerInstrumentCode", true, DataSourceUpdateMode.OnPropertyChanged);
            chkPrices.DataBindings.Add("Checked", brokerInstrumentMapping, "FeedPrices", true, DataSourceUpdateMode.OnPropertyChanged);
            chkTrades.DataBindings.Add("Checked", brokerInstrumentMapping, "FeedTrades", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        System.Windows.Forms.DataGridViewImageColumn buttonColumn = new System.Windows.Forms.DataGridViewImageColumn();
        System.Windows.Forms.DataGridViewImageColumn buttonColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
        TextAndImageColumn column = new TextAndImageColumn();

        private void CreateDataGridColumn()
        {
            dataGridMappings.DataSource = null;
            this.dataGridMappings.Rows.Clear();
            dataGridMappings.AutoGenerateColumns = false;
            dataGridMappings.ColumnCount = 6;

            dataGridMappings.Columns[0].HeaderText = "Id";
            dataGridMappings.Columns[0].Name = "Id";
            dataGridMappings.Columns[0].DataPropertyName = "Id";
            dataGridMappings.Columns[0].Visible = false;

            dataGridMappings.Columns[1].HeaderText = "BIC";
            dataGridMappings.Columns[1].Name = "BrokerInstrumentCode";
            dataGridMappings.Columns[1].DataPropertyName = "BrokerInstrumentCode";

            dataGridMappings.Columns[2].Name = "BrokerCode";
            dataGridMappings.Columns[2].HeaderText = "Broker Code";
            dataGridMappings.Columns[2].DataPropertyName = "BrokerCode";

            dataGridMappings.Columns[3].Name = "BrokerDescription";
            dataGridMappings.Columns[3].HeaderText = "Broker Description";
            dataGridMappings.Columns[3].DataPropertyName = "BrokerDescription";

            dataGridMappings.Columns[4].Name = "InstrumentCode";
            dataGridMappings.Columns[4].HeaderText = "Instrument Code";
            dataGridMappings.Columns[4].DataPropertyName = "InstrumentCode";

            dataGridMappings.Columns[5].Name = "InstrumentDescription";
            dataGridMappings.Columns[5].HeaderText = "Instrument Description";
            dataGridMappings.Columns[5].DataPropertyName = "InstrumentDescription";

            buttonColumn.HeaderText = "";
            buttonColumn.Name = "buttonColumn";
            Image image = ELEVEN.Properties.Resources.Delete;
            buttonColumn.Image = image;
            buttonColumn.Width = 15;

            buttonColumnEdit.HeaderText = "";
            buttonColumnEdit.Name = "buttonColumnEdit";
            Image imageEdit = ELEVEN.Properties.Resources.app_edit;
            buttonColumnEdit.Image = imageEdit;
            buttonColumnEdit.Width = 15;

            dataGridMappings.Columns.AddRange(buttonColumn, buttonColumnEdit);
            dataGridMappings.Columns[6].Width = 20;
            dataGridMappings.Columns[7].Width = 30;
            var dataSource = instrumentMapping.GetBrokerInstrumentMapping();
            dataGridMappings.DataSource = dataSource;
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
                parent.RefreshFormData();
                MessageBox.Show(this, "Mapping created successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Mapping already present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(comboUpdateBroker.SelectedValue) == "" || Convert.ToInt32(comboUpdateBroker.SelectedValue) == 0)
            {
                MessageBox.Show(this, "Please select a broker.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Convert.ToString(comboUpdateInstrument.SelectedValue) == "" || Convert.ToInt32(comboUpdateInstrument.SelectedValue) == 0)
            {
                MessageBox.Show(this, "Please select a instrument.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtUpdateBIC.Text.Trim() == string.Empty)
            {
                MessageBox.Show(this, "Please fill broker instrument code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            brokerUpdateMapping.BrokerId = Convert.ToInt32(comboUpdateBroker.SelectedValue);
            brokerUpdateMapping.InstrumentId = Convert.ToInt32(comboUpdateInstrument.SelectedValue);
            brokerUpdateMapping.BrokerInstrumentCode = txtUpdateBIC.Text;
            brokerUpdateMapping.FeedPrices = chkUpdatePrices.Checked;
            brokerUpdateMapping.FeedTrades = chkUpdateTrades.Checked;
            brokerUpdateMapping.Id = result.Id;
            if (instrumentMapping.CheckDuplicateMapping(brokerUpdateMapping))
            {
                instrumentMapping.UpdateMapping(brokerUpdateMapping,false);
                MessageBox.Show(this, "Mapping updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                instrumentMapping.UpdateMapping(brokerUpdateMapping, true);
                MessageBox.Show(this, "Record updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            parent.RefreshFormData();
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var tabControl = sender as TabControl;
            var selectedTabPage = tabControl.SelectedTab;
            var tabName = selectedTabPage.Name;
            if (tabName == "tabPageMapping")
            {

                tabControl1.TabPages.Remove(tabPageUpdateMapping);
                CreateDataGridColumn();
            }
            else if (tabName == "tabPageAddMapping")
            {
                tabControl1.TabPages.Remove(tabPageUpdateMapping);
            }
        }
        clsBrokerInstrumentDetail result = null;
        private void dataGridMappings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return; // header clicked

            if (e.ColumnIndex == dataGridMappings.Columns["buttonColumn"].Index)
            {
                // Your logic here. You can gain access to any cell value via DataGridViewCellEventArgs
                int Id = Convert.ToInt32(dataGridMappings["Id", e.RowIndex].Value);
                instrumentMapping.DeleteMapping(Id);
                var dataSource = instrumentMapping.GetBrokerInstrumentMapping();
                dataGridMappings.DataSource = dataSource;
                MessageBox.Show(this, "Mapping deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.ColumnIndex == dataGridMappings.Columns["buttonColumnEdit"].Index)
            {
                // Your logic here. You can gain access to any cell value via DataGridViewCellEventArgs
                int Id = Convert.ToInt32(dataGridMappings["Id", e.RowIndex].Value);
                tabControl1.TabPages.Insert(2, updateTab);
                tabControl1.SelectedTab = updateTab;
                result = instrumentMapping.GetBrokerInstrumentMapping(Id);
                BindUpdateComboBox();
                comboUpdateBroker.SelectedValue = result.BrokerId;
                comboUpdateInstrument.SelectedValue = result.InstrumentId;
                txtUpdateBIC.Text = result.BrokerInstrumentCode;
                chkUpdatePrices.Checked = result.FeedPrices;
                chkUpdateTrades.Checked = result.FeedTrades;
            }
        }
    }
}
