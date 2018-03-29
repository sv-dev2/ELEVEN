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
    public partial class MDIParentForm : Form
    {


        public MDIParentForm()
        {
            InitializeComponent();
            var windowHeight = Screen.PrimaryScreen.Bounds.Height;
            var windowWidth = Screen.PrimaryScreen.Bounds.Width;


            frmMarketWatch m_toolbox = new frmMarketWatch();
            dockPanel.Height = Screen.PrimaryScreen.Bounds.Height - 135;
            m_toolbox.Show(dockPanel);

            frmTransaction transaction = new frmTransaction();
            dockPanelBottom.Width = Screen.PrimaryScreen.Bounds.Width;
            dockPanelBottom.Height = 225;
            dockPanelBottom.Location = new Point(0, windowHeight - 310);

            transaction.Show(dockPanelBottom);

        }


        private void ShowNewForm(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmOrders>().Count() == 1)
            {
                Application.OpenForms.OfType<frmOrders>().First().Activate();
            }
            else
            {
                frmOrders order = new frmOrders();
                order.MdiParent = this;
                order.Show();
            }

        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monitorningToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MDIParentForm_Load(object sender, EventArgs e)
        {
            this.Text = "Account Configuration | Broker: Activtrades, Account: 123456, Balance: $1000.00";
            ReteriveWindowLocations();
        }
        private void ReteriveWindowLocations()
        {
            var result = SQLiteDBOperation.ReteriveFormLocation();
            foreach (var item in result)
            {
                switch (item.formName)
                {
                    case "frmMarketWatch":
                        frmMarketWatchWin marketWatch = new frmMarketWatchWin();
                        OpenWindows(marketWatch, item);
                        break; /* optional */
                    case "frmMarketWatchWin":
                        frmMarketWatchWin WatchWindow = new frmMarketWatchWin();
                        OpenWindows(WatchWindow, item);
                        break; /* optional */
                    case "frmCharts":
                        frmCharts charts = new frmCharts();
                        OpenWindows(charts, item);
                        break;
                    case "frmOrders":
                        frmOrders orders = new frmOrders();
                        OpenWindows(orders, item);
                        break;
                    default: /* Optional */

                        break;
                }

            }
        }
        private void OpenWindows(Form window, LocationModel item)
        {
            if (item.WindowState == "Minimized")
            {
                window.WindowState = FormWindowState.Normal;
            }
            else if (item.WindowState == "Maximized")
            {
                window.WindowState = FormWindowState.Maximized;
            }
            window.Location = new Point(item.LocationX, item.LocationY);
            window.Size = new Size(item.SizeX, item.SizeY);
            window.MdiParent = this;
            window.Show();
        }
        private void ChartToolStripButton_Click(object sender, EventArgs e)
        {
            //if (Application.OpenForms.OfType<frmCharts>().Count() == 1)
            //{
            //    Application.OpenForms.OfType<frmCharts>().First().Activate();
            //}
            //else
            //{
            frmCharts chart = new frmCharts();
            chart.MdiParent = this;
            chart.Show();

            //}


        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void marketWatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (Application.OpenForms.OfType<frmMarketWatch>().Count() == 1)
            //{
            //    Application.OpenForms.OfType<frmMarketWatch>().First().Activate();
            //}
            //else
            //{
            frmMarketWatchWin watch = new frmMarketWatchWin();
            watch.MdiParent = this;
            watch.Show();
            //dockPanel.Height = Screen.PrimaryScreen.Bounds.Height - 135;
            //m_toolbox.Show(dockPanel);
            //}
            //dockPanel.Width = 330;
        }

        private void MDIParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQLiteDBOperation.TruncatePreviousLocation();
            foreach (Form childForm in MdiChildren)
            {
                //childForm.Close();
                var winState = childForm.WindowState;
                Point location;
                Size size;
                if (childForm.WindowState == FormWindowState.Normal)
                {
                    // save location and size if the state is normal
                    location = childForm.Location;
                    size = childForm.Size;
                }
                else
                {
                    // save the RestoreBounds if the form is minimized or maximized!
                    location = childForm.RestoreBounds.Location;
                    size = childForm.RestoreBounds.Size;
                }
                LocationModel model = new LocationModel();
                model.formName = childForm.Name;
                model.LocationX = location.X;
                model.LocationY = location.Y;
                model.SizeX = size.Width;
                model.SizeY = size.Height;
                model.WindowState = winState.ToString();
                SQLiteDBOperation.AddFormsLocation(model);
            }
        }
    }
}
