using ComponentFactory.Krypton.Toolkit;
using ELEVEN.DBConnection;
using ELEVEN.Model;
using ELEVEN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELEVEN
{
    public partial class MDIParentForm : KryptonForm
    {

        /// <summary>
        /// Gets or sets the supervisor.
        /// </summary>
        /// <value>
        /// The supervisor.
        /// </value>
        public Supervisor Supervisor
        {
            get; set;
        }
        public MDIParentForm()
        {
            InitializeComponent();
            var windowHeight = Screen.PrimaryScreen.Bounds.Height;
            var windowWidth = Screen.PrimaryScreen.Bounds.Width;

            try
            {
                Supervisor = new Supervisor(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit(true);
            }

        }
        /// <summary>
        /// Exits the specified force exit.
        /// </summary>
        /// <param name="forceExit">if set to <c>true</c> [force exit].</param>
        /// <returns></returns>
        private bool Exit(bool forceExit)
        {
            if (forceExit)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                return true;
            }

            if (MessageBox.Show("Do you want to exit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                return true;
            }

            return false;
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
            //this.Invoke((Action)delegate ()
            //{
            //    frmMarketWatch m_toolbox = new frmMarketWatch();
            //    dockPanel.Height = Screen.PrimaryScreen.Bounds.Height - 135;
            //    m_toolbox.Show(dockPanel);
            //});
            this.Text = "Account Configuration | Broker: Activtrades, Account: 123456, Balance: $1000.00";
            toolStrip.Renderer = new MainFormToolStripRenderer();
            ReteriveWorkSpace();
            BindCurrencies();
            //LoginIGMarket();
        }
        private void LoginIGMarket()
        {
            var applicationViewModel = new ApplicationViewModel();
            applicationViewModel.Login();
        }
        /// <summary>
        /// Reterive first workspace that exist in the DB.
        /// </summary>
        private void ReteriveWorkSpace()
        {
            var result = SQLiteDBOperation.ReteriveWorkspace();
            var toolStripeMenu = workspaceToolStripMenuItem;
            bool firstTime = true;
            workspaceToolStripMenuItem.DropDownItems.Clear();
            AddFixedWorkspace();
            foreach (var item in result)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Name = item.Id.ToString();
                menuItem.Text = item.WorkspaceName;

                menuItem.Click += MenuItem_Click;
                if (firstTime)
                {
                    menuItem.Checked = true;
                    firstTime = false;
                }

                workspaceToolStripMenuItem.DropDownItems.Add(menuItem);
            }
            if (result.Count > 0)
            {
                currentWorkspaceId = result[0].Id;
                ReteriveWindowLocations(result[0].Id);
                lblShowActiveWorkspace.Text = result[0].WorkspaceName;
            }
        }
        private void BindCurrencies()
        {
            BrokerInstrumentMapping instrumentMapping = new BrokerInstrumentMapping(); ;
            var result = instrumentMapping.SearchMapping();
            foreach (var item in result)
            {
                if (item.BrokerCode.ToLower() == "bitfinex")
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                    toolStripMenuItem.Text = item.BrokerInstrumentCode;
                    toolStripMenuItem.Name = item.BrokerCode + "." + item.BrokerInstrumentCode;
                    toolStripMenuItem.Click += ToolStripMenuItem_Click;
                    BitFinexToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                }
                else if (item.BrokerCode.ToLower() == "mt")
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                    toolStripMenuItem.Text = item.BrokerInstrumentCode;
                    toolStripMenuItem.Name = item.BrokerCode + "." + item.BrokerInstrumentCode;
                    toolStripMenuItem.Click += ToolStripMenuItem_Click;
                    MetaTraderToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            string nameStrip = toolStripMenuItem.Name;

            string name = Guid.NewGuid().ToString();
            var arrayStrip = nameStrip.Split('.');
            if (arrayStrip.Count() > 1)
            {
                string symbol = arrayStrip[1];
                if (arrayStrip[0].ToLower() == "bitfinex")
                {
                    symbol = "t" + symbol;
                }
                frmCharts chart = new frmCharts(this, arrayStrip[0], symbol);
                chart.MdiParent = this;
                chart.Name = name;
                AddContextMenuTabControlItem(name, chart);
                chart.Show();
            }


        }

        private void AddFixedWorkspace()
        {
            ////Save workspace menu
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            //menuItem.Name = "menuSaveWorkspace";
            //menuItem.Text = "Save";
            //menuItem.Click += btnSaveWorkspace_Click;
            //workspaceToolStripMenuItem.DropDownItems.Add(menuItem);

            menuItem = new ToolStripMenuItem();
            menuItem.Name = "menuUpdateWorkspace";
            menuItem.Text = "Save";
            menuItem.Click += toolStripUpdateWorkspace_Click;
            workspaceToolStripMenuItem.DropDownItems.Add(menuItem);

            menuItem = new ToolStripMenuItem();
            menuItem.Name = "menuRemoveWorkspace";
            menuItem.Text = "Remove";
            menuItem.Click += toolStripRemoveWorkspace_Click;
            workspaceToolStripMenuItem.DropDownItems.Add(menuItem);
            workspaceToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
        }
        /// <summary>
        /// Event the handle workspace click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;

            if (currentWorkspaceId != Convert.ToInt32(menuItem.Name))
            {

                foreach (var item in workspaceToolStripMenuItem.DropDownItems)
                {
                    try
                    {
                        // Seperator is throwing exception
                        ToolStripMenuItem stripmenu = item as ToolStripMenuItem;
                        stripmenu.Checked = false;
                    }
                    catch
                    {

                        continue;
                    }

                }

                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                menuItem.Checked = true;
                lblShowActiveWorkspace.Text = menuItem.Text;
                ReteriveWindowLocations(Convert.ToInt32(menuItem.Name));
            }

        }
        private int currentWorkspaceId = 0;//Mantain record of selected workspace
        private void ReteriveWindowLocations(int workSpaceId)
        {
            currentWorkspaceId = workSpaceId;
            var result = SQLiteDBOperation.ReteriveFormLocation(workSpaceId);
            foreach (var item in result)
            {
                switch (item.formName)
                {
                    case "frmMarketWatch":
                        this.Invoke((Action)delegate ()
                        {
                            frmMarketWatchWin marketWatch = new frmMarketWatchWin();
                            OpenWindows(marketWatch, item);
                        });
                        break; /* optional */
                    case "frmMarketWatchWin":
                        this.Invoke((Action)delegate ()
                        {
                            frmMarketWatchWin WatchWindow = new frmMarketWatchWin();
                            OpenWindows(WatchWindow, item);
                        });
                        break; /* optional */
                    case "frmCharts":
                        string title = item.formTitle;
                        string broker = string.Empty;
                        string symbol = string.Empty;
                        if (!string.IsNullOrEmpty(title))
                        {
                            broker = title.Split('.')[0];
                            symbol = title.Split('.')[1];
                            if (broker.ToLower() == Broker.BitFinex.ToString().ToLower())
                            {
                                symbol = "t" + symbol;
                            }
                        }
                        frmCharts charts = new frmCharts(this, broker, symbol);
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
                    case "frmAlertWindow":
                        frmAlertWindow alertWindow = new frmAlertWindow();
                        OpenWindows(alertWindow, item);
                        break;
                    case "frmTransaction":
                        frmTransaction transaction = new frmTransaction();
                        OpenWindows(transaction, item);
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
            // string name = Guid.NewGuid().ToString();
            string formTitle = Convert.ToString(item.formTitle);
            if (!string.IsNullOrEmpty(formTitle))
            {
                window.Text = item.formTitle;
            }
            AddContextMenuTabControlItem(item.formUniqueName, window);
            window.Location = new Point(item.LocationX, item.LocationY);
            window.Size = new Size(item.SizeX, item.SizeY);
            window.Name = item.formUniqueName;
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

            //string name = Guid.NewGuid().ToString();
            //frmCharts chart = new frmCharts(this);
            //chart.MdiParent = this;
            //chart.Name = name;
            //AddContextMenuTabControlItem(name, chart);
            //chart.Show();

            //}

        }
        /// <summary>
        /// Event to call Alert window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            string name = Guid.NewGuid().ToString();
            frmAlertWindow AlertWindow = new frmAlertWindow();
            AlertWindow.MdiParent = this;
            AlertWindow.Name = name;
            AddContextMenuTabControlItem(name, AlertWindow);
            AlertWindow.Show();
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
            var frm = new frmPopup();
            frm.ShowDialog();
            if (string.IsNullOrEmpty(frm.WorkspaceName))
            {
                return;
            }
            else
            {
                this.Invoke((Action)delegate ()
                {
                    var name = Guid.NewGuid().ToString();
                    frmMarketWatchWin watch = new frmMarketWatchWin();
                    watch.MdiParent = this;
                    watch.Name = name;
                    watch.Text = frm.WorkspaceName;
                    AddContextMenuTabControlItem(name, watch);
                    watch.Show();
                });
            }

        }

        private void MDIParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {


        }
        /// <summary>
        /// Open OpenPosition forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void positionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (Application.OpenForms.OfType<frmPositions>().Count() == 1)
            //{
            //    Application.OpenForms.OfType<frmPositions>().First().Activate();
            //}
            //else
            //{
            var name = Guid.NewGuid().ToString();
            frmPositions positions = new frmPositions();
            positions.MdiParent = this;
            positions.Name = name;

            AddContextMenuTabControlItem(name, positions);

            positions.Show();
            //}
        }
        /// <summary>
        /// Open closed position form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Tabcontrol event to activate the form that is binded with the tab
        /// </summary>
        TabPage selectedTabPage;
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var tabControl = sender as TabControl;
            selectedTabPage = tabControl.SelectedTab;
            string Id = selectedTabPage.Name;
            var result = Application.OpenForms.OfType<Form>().Where(m => m.Name == Id).FirstOrDefault();
            if (result != null)
            {
                result.Activate();
            }

            if (e.Button == MouseButtons.Right)
            {
                this.menuStrip1.Show(Cursor.Position);
            }
        }
        /// <summary>
        /// Event to save new workspace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveWorkspace_Click(object sender, EventArgs e)
        {
            var childCount = MdiChildren.Count();
            if (childCount < 1)
            {
                MessageBox.Show(this, "Please add element to your workspace", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var frm = new frmPopup();
            frm.ShowDialog();
            if (frm.WorkspaceName != null && frm.WorkspaceName.Trim() != string.Empty)
            {

                if (SQLiteDBOperation.DuplicateWorkspace(frm.WorkspaceName.Trim().ToLower()))
                {
                    //Add new workspace
                    int workSpaceid = SQLiteDBOperation.AddWorkspace(frm.WorkspaceName);
                    //Add forms for the respective workspace
                    AddWorkspaceForm(workSpaceid);
                    //uncheck all menu items
                    //foreach (ToolStripMenuItem item in workspaceToolStripMenuItem.DropDownItems)
                    //{
                    //    item.Checked = false;
                    //}
                    foreach (var item in workspaceToolStripMenuItem.DropDownItems)
                    {
                        try
                        {
                            // Seperator is throwing exception
                            ToolStripMenuItem stripmenu = item as ToolStripMenuItem;
                            stripmenu.Checked = false;
                        }
                        catch { continue; }
                    }
                    //Add new menu strip and mark it as active/checked
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Name = workSpaceid.ToString();
                    menuItem.Text = frm.WorkspaceName;
                    menuItem.Checked = true;
                    menuItem.Click += MenuItem_Click;
                    workspaceToolStripMenuItem.DropDownItems.Add(menuItem);
                    currentWorkspaceId = workSpaceid;
                }
                else
                {
                    MessageBox.Show(this, "Workspace already exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        /// <summary>
        /// Method to add form for the workspace
        /// </summary>
        /// <param name="workSpaceid"></param>
        private void AddWorkspaceForm(int workSpaceid)
        {
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
                model.formUniqueName = childForm.Name;
                model.WorkspaceId = workSpaceid;
                model.formTitle = childForm.Text;
                SQLiteDBOperation.AddFormsLocation(model);
            }

        }
        /// <summary>
        /// Remove active workspace and it forms from DB also
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripRemoveWorkspace_Click(object sender, EventArgs e)
        {
            SQLiteDBOperation.RemoveWorkspace(currentWorkspaceId);
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            workspaceToolStripMenuItem.DropDownItems.RemoveByKey(currentWorkspaceId.ToString());
            ReteriveWorkSpace();
        }
        /// <summary>
        /// Update existing workspace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripUpdateWorkspace_Click(object sender, EventArgs e)
        {
            if (currentWorkspaceId < 1)
            {
                MessageBox.Show(this, "Workspace does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SQLiteDBOperation.TruncatePreviousLocation(currentWorkspaceId);
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
                if(model.formName== "frmCharts")
                {
                    SaveChartParamters(childForm as frmCharts);
                }
                model.LocationX = location.X;
                model.LocationY = location.Y;
                model.SizeX = size.Width;
                model.SizeY = size.Height;
                model.WindowState = winState.ToString();
                model.formUniqueName = childForm.Name;
                model.WorkspaceId = currentWorkspaceId;
                model.formTitle = childForm.Text;
                SQLiteDBOperation.AddFormsLocation(model);
            }
        }
        private void SaveChartParamters(frmCharts chart)
        {
            var zoomList = chart.zoomList;
            if(zoomList!=null && zoomList.Count>0)
            {
                SQLiteDBOperation.DeleteZoomList(chart.Name);
                foreach (var item in zoomList)
                {
                    SQLiteDBOperation.SaveZoomList(item, chart.Name);
                }
            }
            var annotations = chart.annotationList;
            if(annotations!=null && annotations.Count>0)
            {
                SQLiteDBOperation.DeleteAnnotation(chart.Name);
                foreach (var item in chart.annotationList)
                {
                    SQLiteDBOperation.SaveAnnotation(item, chart.Name);
                }
            }
        }
        private void workspaceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new frmPopup();
            form.ShowDialog();
            if (form.WorkspaceName != null && form.WorkspaceName.Trim() != string.Empty)
            {
                if (SQLiteDBOperation.DuplicateWorkspace(form.WorkspaceName.Trim().ToLower()))
                {
                    currentWorkspaceId = 0;
                    foreach (Form childForm in MdiChildren)
                    {
                        childForm.Close();
                    }
                    int workSpaceid = SQLiteDBOperation.AddWorkspace(form.WorkspaceName);
                    //uncheck all menu items                    
                    foreach (var item in workspaceToolStripMenuItem.DropDownItems)
                    {
                        try
                        {
                            // Seperator is throwing exception
                            ToolStripMenuItem stripmenu = item as ToolStripMenuItem;
                            stripmenu.Checked = false;
                        }
                        catch { continue; }
                    }
                    //Add new menu strip and mark it as active/checked
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Name = workSpaceid.ToString();
                    menuItem.Text = form.WorkspaceName;
                    menuItem.Checked = true;
                    menuItem.Click += MenuItem_Click;
                    workspaceToolStripMenuItem.DropDownItems.Add(menuItem);
                    currentWorkspaceId = workSpaceid;
                    lblShowActiveWorkspace.Text = form.WorkspaceName;
                }
                else
                {
                    MessageBox.Show(this, "Workspace already exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = Guid.NewGuid().ToString();
            frmTransaction transaction = new frmTransaction();
            transaction.MdiParent = this;
            transaction.Name = name;
            AddContextMenuTabControlItem(name, transaction);
            transaction.Show();
        }

        private void brokerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBroker broker = new frmBroker();
            broker.ShowDialog();
        }

        private void instrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInstrument instrument = new frmInstrument();
            instrument.ShowDialog();
        }

        private void linkInstrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrokerInstrumentMapping instrumentMapping = new frmBrokerInstrumentMapping(this);
            instrumentMapping.ShowDialog();
        }
        public void RefreshFormData()
        {
            foreach (Form childForm in MdiChildren)
            {
                switch (childForm.Tag)
                {
                    case "frmMarketWatchWin":
                        var marketWatch = childForm as frmMarketWatchWin;
                        marketWatch.AutoCompletetxtAddRow();
                        break;
                }
            }
        }

    }
}
