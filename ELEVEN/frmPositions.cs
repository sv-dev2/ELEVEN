using ComponentFactory.Krypton.Toolkit;
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
    public partial class frmPositions : KryptonForm
    {
        BitfinexAPI bitfinexAPI = null;
        public frmPositions()
        {
            InitializeComponent();
            bitfinexAPI = new BitfinexAPI();
        }

        private void frmPositions_FormClosing(object sender, FormClosingEventArgs e)
        {
            TabControl tabControl = this.MdiParent.Controls["tabControl1"] as TabControl;
            tabControl.TabPages.RemoveByKey(this.Name);
        }
        System.Windows.Forms.DataGridViewImageColumn buttonColumn = new System.Windows.Forms.DataGridViewImageColumn();


        private void CreateDataGridColumn()
        {
            DataGridViewPositions.DataSource = null;
            this.DataGridViewPositions.Rows.Clear();
            DataGridViewPositions.AutoGenerateColumns = false;
            DataGridViewPositions.ColumnCount = 9;

            DataGridViewPositions.Columns[0].HeaderText = "broker";
            DataGridViewPositions.Columns[0].Name = "broker";
            DataGridViewPositions.Columns[0].DataPropertyName = "broker";
            DataGridViewPositions.Columns[0].Visible = false;

            DataGridViewPositions.Columns[1].HeaderText = "Strategy";
            DataGridViewPositions.Columns[1].Name = "exchange";
            DataGridViewPositions.Columns[1].DataPropertyName = "exchange";

            DataGridViewPositions.Columns[2].HeaderText = "Symbol";
            DataGridViewPositions.Columns[2].Name = "Symbol";
            DataGridViewPositions.Columns[2].DataPropertyName = "symbol";

            DataGridViewPositions.Columns[3].Name = "Qty";
            DataGridViewPositions.Columns[3].HeaderText = "Qty";
            DataGridViewPositions.Columns[3].DataPropertyName = "original_amount";

            DataGridViewPositions.Columns[4].Name = "Cost";
            DataGridViewPositions.Columns[4].HeaderText = "Cost";
            DataGridViewPositions.Columns[4].DataPropertyName = "price";

            DataGridViewPositions.Columns[5].Name = "MarketPrice";
            DataGridViewPositions.Columns[5].HeaderText = "Market Price";
            DataGridViewPositions.Columns[5].DataPropertyName = "MarketPrice";

            DataGridViewPositions.Columns[6].Name = "MarketValue";
            DataGridViewPositions.Columns[6].HeaderText = "Market Value";
            DataGridViewPositions.Columns[6].DataPropertyName = "MarketValue";

            DataGridViewPositions.Columns[7].Name = "UnrealizedPL";
            DataGridViewPositions.Columns[7].HeaderText = "Unrealized PL";
            DataGridViewPositions.Columns[7].DataPropertyName = "UnrealizedPL";

            DataGridViewPositions.Columns[8].Name = "id";
            DataGridViewPositions.Columns[8].HeaderText = "id";
            DataGridViewPositions.Columns[8].DataPropertyName = "id";
            DataGridViewPositions.Columns[8].Visible = false;

            buttonColumn.HeaderText = "Manage";
            buttonColumn.Name = "buttonColumn";
            Image image = ELEVEN.Properties.Resources.Delete;

            buttonColumn.Image = image;
            buttonColumn.Width = 15;
            DataGridViewPositions.Columns.Insert(9, buttonColumn);

            DataGridViewPositions.DataSource = positions;
        }

        private void frmPositions_Load(object sender, EventArgs e)
        {
            ActivePostions();
           
        }
        List<ActivePositionItem> positions;
        private void ActivePostions()
        {
            var response = bitfinexAPI.GetActivePositions();
            if (response.positions.Count > 0)
            {
                positions = response.positions;
            }
            else
            {
                positions = new List<ActivePositionItem>();
            }
            CreateDataGridColumn();
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            foreach (var item in positions)
            {
                bitfinexAPI.ClosePositions(item.id);
            }           
            RefreshDataGrid();
        }
        private void RefreshDataGrid()
        {
            DataGridViewPositions.DataSource = null;
            this.DataGridViewPositions.Rows.Clear();
            var response = bitfinexAPI.GetActivePositions();
            if (response.positions.Count > 0)
            {
                positions = response.positions;
            }
            else
            {
                positions = new List<ActivePositionItem>();
            }
            DataGridViewPositions.DataSource = positions;
        }
        private void DataGridViewPositions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return; // header clicked

            if (e.ColumnIndex == DataGridViewPositions.Columns["buttonColumn"].Index)
            {
                // Your logic here. You can gain access to any cell value via DataGridViewCellEventArgs
                string positionId = DataGridViewPositions["id", e.RowIndex].Value.ToString();
                string broker = DataGridViewPositions["broker", e.RowIndex].Value.ToString();
                if (broker.ToLower() == Broker.BitFinex.ToString().ToLower())
                {
                    var response = bitfinexAPI.ClosePositions(positionId);
                    RefreshDataGrid();
                }

            }
        }
    }
}
