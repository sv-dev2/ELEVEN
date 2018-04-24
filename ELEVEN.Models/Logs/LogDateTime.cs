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

    /// <summary>
    /// GDateTime
    /// Class for date time to microseconds
    /// </summary>
    public class LogDateTime
    {
        #region Private Members

        private static readonly Stopwatch myStopwatch = new Stopwatch();

        private static System.DateTime myStopwatchStartTime;

        #endregion Private Members

        #region Properties

        #region Public Properties

        /// <summary>
        /// Now
        /// </summary>
        public System.DateTime Now
        {
            get
            {
                return myStopwatchStartTime.Add(myStopwatch.Elapsed);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Constructors

        /// <summary>
        /// GDateTime
        /// </summary>
        static LogDateTime()
        {
            Reset();

            try
            {
                // In case the system clock gets updated
                SystemEvents.TimeChanged += SystemEvents_TimeChanged;
            }
            catch (Exception)
            {
            }
        }

        #endregion Constructors

        /// <summary>
        /// Reset
        /// </summary>
        public static void Reset()
        {
            myStopwatchStartTime = System.DateTime.Now;
            myStopwatch.Restart();
        }

        /// <summary>
        /// SystemEvents_TimeChanged
        /// </summary>
        private static void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            Reset();
        }
    }

    #endregion Types
}
