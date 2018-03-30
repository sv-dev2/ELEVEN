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
                string name = Guid.NewGuid().ToString();
                frmOrders order = new frmOrders();
                order.MdiParent = this;
                order.Name = name;

                AddContextMenuTabControlItem(name, order);

                order.Show();
            }

        }
        ContextMenuStrip menuStrip1;
        private void AddContextMenuTabControlItem(string name, Form frm)
        {
            TabPage tabPage = new TabPage();
            tabPage.Text = frm.Text;
            tabPage.Name = name;

            menuStrip1 = new ContextMenuStrip();

            ToolStripItem item1 = menuStrip1.Items.Add("Close", ELEVEN.Properties.Resources.close_x);
            item1.Tag = tabPage;
            this.menuStrip1.Items.Add(new ToolStripSeparator());
            ToolStripItem item2 = menuStrip1.Items.Add("Minimize", ELEVEN.Properties.Resources.minimize);
            item2.Tag = tabPage;
            ToolStripItem item3 = menuStrip1.Items.Add("Maximize", ELEVEN.Properties.Resources.maximize);
            item3.Tag = tabPage;
            ToolStripItem item4 = this.menuStrip1.Items.Add("Restore", ELEVEN.Properties.Resources.red_img);
            item4.Tag = tabPage;
            this.menuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenuStrip1_ItemClicked);

            tabPage.ContextMenuStrip = menuStrip1;

            this.tabControl1.TabPages.Add(tabPage);
        }
        void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // TabPage tabPage = e.ClickedItem.Tag as TabPage;
            TabPage tabPage = selectedTabPage;
            string selectedItem = e.ClickedItem.Text;
            if (tabPage != null)
            {
                //this.tabControl1.SelectedTab = page;
                string Id = tabPage.Name;
                switch (selectedItem)
                {
                    case "Close":
                        var result = Application.OpenForms.OfType<Form>().Where(m => m.Name == Id).FirstOrDefault();
                        if (result != null)
                        {
                            result.Close();
                        }
                        break; /* optional */
                    case "Minimize":
                        var result2 = Application.OpenForms.OfType<Form>().Where(m => m.Name == Id).FirstOrDefault();
                        if (result2 != null)
                        {
                            result2.WindowState = FormWindowState.Minimized;
                        }
                        break; /* optional */
                    case "Maximize":
                        var result3 = Application.OpenForms.OfType<Form>().Where(m => m.Name == Id).FirstOrDefault();
                        if (result3 != null)
                        {
                            result3.WindowState = FormWindowState.Maximized;
                        }
                        break; /* optional */
                    case "Restore":
                        var result4 = Application.OpenForms.OfType<Form>().Where(m => m.Name == Id).FirstOrDefault();
                        if (result4 != null)
                        {
                            result4.WindowState = FormWindowState.Normal;
                        }
                        break; /* optional */
                    default:
                        break;
                }

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
                        frmCharts charts = new frmCharts(this);
                        OpenWindows(charts, item);
                        break;
                    case "frmOrders":
                        frmOrders orders = new frmOrders();
                        OpenWindows(orders, item);
                        break;
                    case "frmPositions":
                        frmPositions positions = new frmPositions();
                        OpenWindows(positions, item);
                        break;
                    case "frmClosedPosition":
                        frmClosedPosition closedPosition = new frmClosedPosition();
                        OpenWindows(closedPosition, item);
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
            string name = Guid.NewGuid().ToString();


            AddContextMenuTabControlItem(name, window);

            window.Location = new Point(item.LocationX, item.LocationY);
            window.Size = new Size(item.SizeX, item.SizeY);
            window.Name = name;
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
            string name = Guid.NewGuid().ToString();
            frmCharts chart = new frmCharts(this);
            chart.MdiParent = this;
            chart.Name = name;
            AddContextMenuTabControlItem(name, chart);
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
            var name = Guid.NewGuid().ToString();
            frmMarketWatchWin watch = new frmMarketWatchWin();
            watch.MdiParent = this;
            watch.Name = name;

            AddContextMenuTabControlItem(name, watch);

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
                model.formName = childForm.Tag.ToString();
                model.LocationX = location.X;
                model.LocationY = location.Y;
                model.SizeX = size.Width;
                model.SizeY = size.Height;
                model.WindowState = winState.ToString();
                SQLiteDBOperation.AddFormsLocation(model);
            }
        }

        private void positionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms.OfType<frmPositions>().Count() == 1)
            {
                Application.OpenForms.OfType<frmPositions>().First().Activate();
            }
            else
            {
                var name = Guid.NewGuid().ToString();
                frmPositions positions = new frmPositions();
                positions.MdiParent = this;
                positions.Name = name;

                AddContextMenuTabControlItem(name, positions);

                positions.Show();
            }
        }

        private void closedPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmClosedPosition>().Count() == 1)
            {
                Application.OpenForms.OfType<frmClosedPosition>().First().Activate();
            }
            else
            {
                var name = Guid.NewGuid().ToString();
                frmClosedPosition positions = new frmClosedPosition();
                positions.MdiParent = this;
                positions.Name = name;

                AddContextMenuTabControlItem(name, positions);

                positions.Show();
            }
        }
        TabPage selectedTabPage;
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var tabControl = sender as TabControl;
            selectedTabPage = tabControl.SelectedTab;
            string Id = selectedTabPage.Name;
            Application.OpenForms.OfType<Form>().Where(m => m.Name == Id).FirstOrDefault().Activate();

            if (e.Button == MouseButtons.Right)
            {
                this.menuStrip1.Show(Cursor.Position);
            }
        }
    }
}
