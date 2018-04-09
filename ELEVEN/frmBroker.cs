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
        TabPage updateTab = null;
        clsBroker result = null;
        public frmBroker()
        {
            InitializeComponent();
            broker = new clsBroker();
            instrumentMapping = new BrokerInstrumentMapping();
            result = new clsBroker();
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
            updateTab = tabPageUpdateBroker;
            tabControl1.TabPages.Remove(tabPageUpdateBroker);
        }
        private void BindProperties()
        {
            txtBrokerCode.DataBindings.Add("Text", broker, "BrokerCode", true, DataSourceUpdateMode.OnPropertyChanged);
            txtBrokerDescription.DataBindings.Add("Text", broker, "BrokerDescription", true, DataSourceUpdateMode.OnPropertyChanged);

            txtUpdateBroker.DataBindings.Add("Text", result, "BrokerCode", true, DataSourceUpdateMode.OnPropertyChanged);
            txtUpdateDescription.DataBindings.Add("Text", result, "BrokerDescription", true, DataSourceUpdateMode.OnPropertyChanged);

        }


        System.Windows.Forms.DataGridViewImageColumn buttonColumn = new System.Windows.Forms.DataGridViewImageColumn();
        System.Windows.Forms.DataGridViewImageColumn buttonColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
        TextAndImageColumn column = new TextAndImageColumn();

        private void CreateDataGridColumn()
        {
            dataGridBrokers.DataSource = null;
            this.dataGridBrokers.Rows.Clear();
            dataGridBrokers.AutoGenerateColumns = false;
            dataGridBrokers.ColumnCount = 3;

            dataGridBrokers.Columns[0].HeaderText = "Id";
            dataGridBrokers.Columns[0].Name = "Id";
            dataGridBrokers.Columns[0].DataPropertyName = "Id";
            dataGridBrokers.Columns[0].Visible = false;

            dataGridBrokers.Columns[1].HeaderText = "Broker Code";
            dataGridBrokers.Columns[1].Name = "BrokerCode";
            dataGridBrokers.Columns[1].DataPropertyName = "BrokerCode";

            dataGridBrokers.Columns[2].Name = "Broker Description";
            dataGridBrokers.Columns[2].HeaderText = "BrokerDescription";
            dataGridBrokers.Columns[2].DataPropertyName = "BrokerDescription";

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

            dataGridBrokers.Columns.AddRange(buttonColumn, buttonColumnEdit);
            dataGridBrokers.Columns[3].Width = 20;
            dataGridBrokers.Columns[4].Width = 30;
            var dataSource = instrumentMapping.GetBrokers();
            dataGridBrokers.DataSource = dataSource;
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {

            var tabControl = sender as TabControl;
            var selectedTabPage = tabControl.SelectedTab;
            var tabName = selectedTabPage.Name;
            if (tabName == "tabPageBroker")
            {
                tabControl1.TabPages.Remove(tabPageUpdateBroker);
                CreateDataGridColumn();
            }
            else if (tabName == "tabPageAddBroker")
            {
                tabControl1.TabPages.Remove(tabPageUpdateBroker);
            }

        }

        private void dataGridBrokers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return; // header clicked

            if (e.ColumnIndex == dataGridBrokers.Columns["buttonColumn"].Index)
            {
                // Your logic here. You can gain access to any cell value via DataGridViewCellEventArgs
                int Id = Convert.ToInt32(dataGridBrokers["Id", e.RowIndex].Value);
                instrumentMapping.DeleteBroker(Id);
                var dataSource = instrumentMapping.GetBrokers();
                dataGridBrokers.DataSource = dataSource;
                MessageBox.Show(this, "Broker deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.ColumnIndex == dataGridBrokers.Columns["buttonColumnEdit"].Index)
            {
                // Your logic here. You can gain access to any cell value via DataGridViewCellEventArgs
                int Id = Convert.ToInt32(dataGridBrokers["Id", e.RowIndex].Value);
                tabControl1.TabPages.Insert(2, updateTab);
                tabControl1.SelectedTab = updateTab;

                result = instrumentMapping.GetBroker(Id);

                txtUpdateBroker.Text = result.BrokerCode;
                txtUpdateDescription.Text = result.BrokerDescription;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUpdateBroker.Text != null && txtUpdateBroker.Text.Trim() != string.Empty)
            {
                result.BrokerCode = txtUpdateBroker.Text;
                result.BrokerDescription = txtUpdateDescription.Text;
                if (instrumentMapping.CheckDuplicateBroker(result))
                {
                    instrumentMapping.UpdateBroker(result);
                    MessageBox.Show(this, "Broker updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Broker code already present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Please enter a valid code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
