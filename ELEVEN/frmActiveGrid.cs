using ActiveGrid;
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
    public partial class frmActiveGrid : Form
    {
        #region --- Class Data -------------------------------

        private static int MAX_FEEDS = 10;
        private string[] currencies = { "USD", "EUR", "GBP", "JPY", "AUD", "CAD", "ZAR", "SEK",
                                        "CHF", "CYP", "DKK", "HKD", "INR", "ILS", "ISK", "MAD"  };

        private object syncRoot = new object();
        private int _previousSpeed = 0;
        private int _dataFeedCount = 0;
        private List<RandomDataFeed> dataFeeds = new List<RandomDataFeed>(MAX_FEEDS);
        private Random rand = new Random((int)DateTime.Now.Ticks);

        #endregion

        #region --- Constructor ------------------------------

        public frmActiveGrid()
        {
            InitializeComponent();

            PopulateColumns();

            PopulateRows();

            this.marketSpeed.Maximum = MAX_FEEDS;
            this.cbUseFlash.Checked = this.lvBalances.AllowFlashing;
            this.cbFadeOut.Checked = this.lvBalances.UseFlashFadeOut;
            this.cbAlternating.Checked = this.lvBalances.UseAlternateRowColors;

            // Populate the array of random-data feeds
            for (int i = 0; i <= MAX_FEEDS; i++)
            {
                RandomDataFeed rdf = new RandomDataFeed(this.lvBalances.Items.Count, this.lvBalances.Columns.Count);
                rdf.OnCellUpdate += new RandomDataFeed.OnCellUpdateHandler(rdf_OnCellUpdate);
                rdf.OnStarted += new RandomDataFeed.OnStartedHandler(rdf_OnStarted);
                rdf.OnStopped += new RandomDataFeed.OnStoppedHandler(rdf_OnStopped);
                dataFeeds.Add(rdf);
            }
        }

        #endregion

        #region --- Data Feed Event Handlers -----------------

        /// <summary>
        /// Handles the STOP-event on a random-data feed instance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void StoppedEventHandler(object sender, EventArgs e);
        private void rdf_OnStopped(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new StoppedEventHandler(this.rdf_OnStopped), new object[] { sender, e });
                return;
            }

            Interlocked.Decrement(ref _dataFeedCount);
            this.labelDataFeedCount.Text = this._dataFeedCount.ToString();
        }

        /// <summary>
        /// Handles the START-event on a random-data feed instance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void StartedEventHandler(object sender, EventArgs e);
        private void rdf_OnStarted(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new StartedEventHandler(this.rdf_OnStarted), new object[] { sender, e });
                return;
            }

            Interlocked.Increment(ref _dataFeedCount);
            this.labelDataFeedCount.Text = this._dataFeedCount.ToString();
        }

        /// <summary>
        /// Handles the CELL UPDATE-event on a random-data feed instance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void UpdateEventHandler(object sender, CellUpdateEventArgs e);
        private void rdf_OnCellUpdate(object sender, CellUpdateEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateEventHandler(this.rdf_OnCellUpdate), new object[] { sender, e });
                return;
            }

            CellUpdate(e);
        }

        #endregion

        #region --- Private methods --------------------------

        /// <summary>
        /// Creates the columns in the data-grid
        /// </summary>
        private void PopulateColumns()
        {
            this.lvBalances.SuspendLayout();

            // Add the row header column
            SKACERO.ActiveColumnHeader column = new SKACERO.ActiveColumnHeader();
            column.Text = "";
            column.Name = "CCY";
            column.CellFormat = "";
            column.CellHorizontalAlignment = System.Drawing.StringAlignment.Center;
            column.SortOrder = SKACERO.SortOrderEnum.Unsorted;
            column.Text = "";
            column.Width = 70;
            this.lvBalances.Columns.Add(column);

            foreach (string ccy in this.currencies)
            {
                column = new SKACERO.ActiveColumnHeader();
                column.Text = ccy;
                column.Name = ccy;
                column.CellFormat = "N";
                column.CellHorizontalAlignment = System.Drawing.StringAlignment.Far;
                column.DisplayZeroValues = false;
                column.SortOrder = SKACERO.SortOrderEnum.Unsorted;
                column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                column.Width = 55;
                this.lvBalances.Columns.Add(column);
            }

            this.lvBalances.ResumeLayout();
        }

        /// <summary>
        /// Creates the rows in the data-grid
        /// </summary>
        private void PopulateRows()
        {
            // This is essential as it will prevent the 'flashing' functionality
            // from being triggered while the grid is being initialised.
            this.lvBalances.SuspendLayout();

            // Create a list to hold all of the row items.
            List<SKACERO.ActiveRow> items = new List<SKACERO.ActiveRow>(20);

            foreach (string ccy in this.currencies)
            {
                // Create a new row.
                SKACERO.ActiveRow item = new SKACERO.ActiveRow();
                item.Text = ccy;
                item.Name = ccy;

                // Add the cells to the row, one for each column.
                // N.B. Starting from column ONE not column ZERO as this is
                //      reserved for the row header.
                for (int i = 1; i < this.lvBalances.Columns.Count; i++)
                {
                    SKACERO.ActiveRow.ActiveCell cell = new SKACERO.ActiveRow.ActiveCell(item, String.Empty);
                    cell.Name = String.Format("{0}_{1}", ccy, this.lvBalances.Columns[i].Name);
                    cell.DecimalValue = Decimal.Zero;
                    cell.PreTextFont = new Font("Arial", cell.Font.Size);
                    cell.PostTextFont = new Font("Arial", cell.Font.Size);
                    item.SubItems.Add(cell);
                }

                items.Add(item);
            }

            // Add all of the rows to the list view.
            this.lvBalances.Items.AddRange(items.ToArray());

            this.lvBalances.ResumeLayout();
        }


        /// <summary>
        /// Handles changes to an individual cell within the grid
        /// </summary>
        /// <param name="e"></param>
        private void CellUpdate(CellUpdateEventArgs e)
        {
            lock (syncRoot)
            {
                try
                {
                    // There are three options for locating the cell we wish to update.

                    // OPTION 1
                    // In this simulation, the data-feed generates a random cell based on 
                    // column-index and row-index. This makes life very easy when locating
                    // the cell we need to update but it's not very realistic in a real-world
                    // application.
                    //
                    // SKACERO.ActiveRow.ActiveCell cell = this.lvBalances[e.Row, e.Column];


                    // OPTION 2
                    // In the real world it's unlikely that we'll know the cell indices;
                    // we're more likely to know the row key and the column-header key values which
                    // means that we have to actually find the cell instead of going straight
                    // to it.
                    // string keyRow = currencies[e.Row];
                    // string keyColumn = currencies[e.Column-1];
                    // SKACERO.ActiveRow.ActiveCell cell = this.lvBalances.FindCell(keyRow, keyColumn);


                    // OPTION 3
                    // If every cell is assigned a unique name then we can use it to locate
                    // the cell within the grid. In this example, the unique key was simply generated
                    // as a composite of the row name and column name but it could just as well have
                    // been an integer or a guid.
                    string keyCell = String.Format("{0}_{1}", currencies[e.Row], currencies[e.Column - 1]);
                    SKACERO.ActiveRow.ActiveCell cell = this.lvBalances.FindCell(keyCell);

                    if (cell != null)
                    {
                        // Create a new value for the cell.
                        decimal newValue = Decimal.Add(cell.DecimalValue, e.Increment);

                        // Has the value been reduced, increased, or left unchanged?
                        if (newValue < cell.DecimalValue)
                        {
                            // Reduced
                            cell.FlashBackColor = this.cbColourful.Checked ? Color.LightGreen : Color.Yellow;
                            cell.FlashPreTextForeColor = Color.Red;
                            cell.FlashPostTextForeColor = Color.Red;
                            cell.FlashPreText = "▼";
                            cell.FlashPostText = String.Empty;
                        }
                        else if (newValue > cell.DecimalValue)
                        {
                            // Increased
                            cell.FlashBackColor = this.cbColourful.Checked ? Color.PowderBlue : Color.Yellow;
                            cell.FlashPreTextForeColor = Color.Blue;
                            cell.FlashPostTextForeColor = Color.Blue;
                            cell.FlashPreText = "▲";
                            cell.FlashPostText = String.Empty;
                        }
                        else
                        {
                            // Unchanged
                            cell.FlashBackColor = Color.Yellow;
                            cell.FlashPreText = String.Empty;
                            cell.FlashPostText = String.Empty;
                        }

                        cell.DecimalValue = newValue;
                    }

                }
                catch (IndexOutOfRangeException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        /// <summary>
        /// Handle changes to the speed at which random market data is generated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void marketSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (this._previousSpeed > this.marketSpeed.Value)
            {
                for (int i = this._previousSpeed; i > this.marketSpeed.Value; i--)
                {
                    if (dataFeeds[i].IsRunning)
                        dataFeeds[i].StopAsync();
                }
            }
            else if (this._previousSpeed < this.marketSpeed.Value)
            {
                for (int i = this._previousSpeed; i < this.marketSpeed.Value; i++)
                {
                    if (!dataFeeds[this.marketSpeed.Value].IsRunning)
                        dataFeeds[this.marketSpeed.Value].Start();
                }
            }

            this._previousSpeed = this.marketSpeed.Value;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            // Fetch the metrics.
            int maxThreads;
            int availableThreads;
            int portThreads;

            ThreadPool.GetMaxThreads(out maxThreads, out portThreads);
            ThreadPool.GetAvailableThreads(out availableThreads, out portThreads);

            int activeThreads = maxThreads - availableThreads;
            this.labelActiveThreads.Text = activeThreads.ToString();
            this.labelAvailableThreads.Text = availableThreads.ToString();
            this.labelFlashedCells.Text = this.lvBalances.FlashedCellCount.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lvBalances.FlashDuration = this.flashDuration.Value;
            this.timer1.Start();
        }

        private void rbPlain_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbPlain.Checked)
            {
                this.lvBalances.UseGradient = false;
                this.lvBalances.UseFlashGradient = false;
                this.lvBalances.Invalidate();
            }
        }

        private void rbGradient_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbGradient.Checked)
            {
                this.lvBalances.UseGradient = true;
                this.lvBalances.UseFlashGradient = true;
                this.lvBalances.Invalidate();
            }
        }

        private void flashDuration_ValueChanged(object sender, EventArgs e)
        {
            this.lvBalances.FlashDuration = this.flashDuration.Value;
        }

        private void lvBalances_OnRowHeaderLeftMouseClick(object sender, SKACERO.RowHeaderEventArgs e)
        {
            WebBrowser wb = new WebBrowser();
            wb.Navigate("http://www.themoneyconverter.com/" + e.RowName, true);
        }

        private void lvBalances_OnRowHeaderRightMouseClick(object sender, SKACERO.RowHeaderEventArgs e)
        {
            WebBrowser wb = new WebBrowser();
            wb.Navigate("http://www.themoneyconverter.com/Default.aspx?from=USD&to=" + e.RowName, true);
        }

        private void cbUseFlash_CheckedChanged(object sender, EventArgs e)
        {
            this.lvBalances.AllowFlashing = this.cbUseFlash.Checked;
            this.cbFadeOut.Enabled = this.lvBalances.AllowFlashing;
            this.flashDuration.Enabled = this.lvBalances.AllowFlashing;
        }

        private void cbFadeOut_CheckedChanged(object sender, EventArgs e)
        {
            this.lvBalances.UseFlashFadeOut = this.cbFadeOut.Checked;
        }

        private void cbAlternating_CheckedChanged(object sender, EventArgs e)
        {
            this.lvBalances.UseAlternateRowColors = this.cbAlternating.Checked;
            this.lvBalances.Invalidate();
        }

        private void lvBalances_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SKACERO.ActiveColumnHeader header = this.lvBalances.Columns[e.Column];

            // Reset all of the columns except the one that was clicked.
            foreach (SKACERO.ActiveColumnHeader hdr in this.lvBalances.Columns)
            {
                if (!hdr.Equals(header))
                    hdr.Reset();
            }

            // Set the ListViewItemSorter property to a new ListViewItemComparer 
            // object. Setting this property immediately sorts the 
            // ListView using the ListViewItemComparer object.
            this.lvBalances.ListViewItemSorter = new SKACERO.ActiveGridItemComparer(header);

            header.SwitchSortOrder();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            this.dataFeeds[0].Burst(0);
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= MAX_FEEDS; i++)
            {
                this.dataFeeds[i].RandomBurst();
            }
        }

        #endregion
    }
}
