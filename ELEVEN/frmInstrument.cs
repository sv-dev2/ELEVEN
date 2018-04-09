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
        clsInstrument result = null;
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
        TabPage updateTab = null;
        private void frmInstrument_Load(object sender, EventArgs e)
        {
            BindProperties();
            updateTab = tabPageUpdateInstrument;
            tabControl1.TabPages.Remove(tabPageUpdateInstrument);
        }
        private void BindProperties()
        {
            txtInstrumentCode.DataBindings.Add("Text", instrument, "InstrumentCode", true, DataSourceUpdateMode.OnPropertyChanged);
            txtInstrumentDescription.DataBindings.Add("Text", instrument, "InstrumentDescription", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        System.Windows.Forms.DataGridViewImageColumn buttonColumn = new System.Windows.Forms.DataGridViewImageColumn();
        System.Windows.Forms.DataGridViewImageColumn buttonColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
        TextAndImageColumn column = new TextAndImageColumn();

        private void CreateDataGridColumn()
        {
            dataGridInstruments.DataSource = null;
            this.dataGridInstruments.Rows.Clear();
            dataGridInstruments.AutoGenerateColumns = false;
            dataGridInstruments.ColumnCount = 3;
          
            dataGridInstruments.Columns[0].HeaderText = "Id";
            dataGridInstruments.Columns[0].Name = "Id";
            dataGridInstruments.Columns[0].DataPropertyName = "Id";
            dataGridInstruments.Columns[0].Visible = false;
           
            dataGridInstruments.Columns[1].HeaderText = "Instrument Code";
            dataGridInstruments.Columns[1].Name = "InstrumentCode";
            dataGridInstruments.Columns[1].DataPropertyName = "InstrumentCode";
          
            dataGridInstruments.Columns[2].Name = "Instrument Description";
            dataGridInstruments.Columns[2].HeaderText = "InstrumentDescription";
            dataGridInstruments.Columns[2].DataPropertyName = "InstrumentDescription";

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

            dataGridInstruments.Columns.AddRange(buttonColumn, buttonColumnEdit);
            dataGridInstruments.Columns[3].Width = 20;
            dataGridInstruments.Columns[4].Width = 30;
            var dataSource = instrumentMapping.GetInstruments();
            dataGridInstruments.DataSource = dataSource;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUpdateInstrumentCode.Text != null && txtUpdateInstrumentCode.Text.Trim() != string.Empty)
            {
                result.InstrumentCode = txtUpdateInstrumentCode.Text;
                result.InstrumentDescription = txtUpdateDescription.Text;
                if (instrumentMapping.CheckDuplicateInstrument(result))
                {
                    instrumentMapping.UpdateInstrument(result);
                    MessageBox.Show(this, "Instrument updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Instrument code already present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Please enter a valid code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridInstruments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return; // header clicked

            if (e.ColumnIndex == dataGridInstruments.Columns["buttonColumn"].Index)
            {
                // Your logic here. You can gain access to any cell value via DataGridViewCellEventArgs
                int Id = Convert.ToInt32(dataGridInstruments["Id", e.RowIndex].Value);
                instrumentMapping.DeleteInstrument(Id);
                var dataSource = instrumentMapping.GetInstruments();
                dataGridInstruments.DataSource = dataSource;
                MessageBox.Show(this, "Instrument deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.ColumnIndex == dataGridInstruments.Columns["buttonColumnEdit"].Index)
            {
                // Your logic here. You can gain access to any cell value via DataGridViewCellEventArgs
                int Id = Convert.ToInt32(dataGridInstruments["Id", e.RowIndex].Value);
                tabControl1.TabPages.Insert(2, updateTab);
                tabControl1.SelectedTab = updateTab;

                result = instrumentMapping.GetInstrument(Id);

                txtUpdateInstrumentCode.Text = result.InstrumentCode;
                txtUpdateDescription.Text = result.InstrumentDescription;
            }
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var tabControl = sender as TabControl;
            var selectedTabPage = tabControl.SelectedTab;
            var tabName = selectedTabPage.Name;
            if (tabName == "tabPageInstruments")
            {
                tabControl1.TabPages.Remove(tabPageUpdateInstrument);
                CreateDataGridColumn();
            }
            else if (tabName == "tabPageAddInstrument")
            {
                tabControl1.TabPages.Remove(tabPageUpdateInstrument);
            }
        }
    }
}
