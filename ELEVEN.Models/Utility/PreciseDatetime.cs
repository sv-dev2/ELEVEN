using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    #region Types

    public class PreciseDatetime
    {
        #region Private Members

        private static readonly Stopwatch myStopwatch = new Stopwatch();

        private static System.DateTime myStopwatchStartTime;

        #endregion Private Members

        #region Properties

        #region Public Properties

        /// <summary>
        /// Gets the now.
        /// </summary>
        /// <value>
        /// The now.
        /// </value>
        public System.DateTime Now
        {
            get { return myStopwatchStartTime.Add(myStopwatch.Elapsed); }
        }

        #endregion Public Properties

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes the <see cref="PreciseDatetime"/> class.
        /// </summary>
        static PreciseDatetime()
        {
            Reset();
            try
            {
                SystemEvents.TimeChanged += SystemEvents_TimeChanged;
            }
            catch (Exception)
            {
            }
        }

        #endregion Constructors

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public static void Reset()
        {
            myStopwatchStartTime = System.DateTime.Now;
            myStopwatch.Restart();
        }

        /// <summary>
        /// Handles the TimeChanged event of the SystemEvents control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        static void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            Reset();
        }
    }

    #endregion Types
}
