using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    #region Types

    class GLoggerUnit
    {
        #region Properties

        #region Public Properties

        /// <summary>
        /// Caller
        /// </summary>
        public string Caller
        {
            get;
            set;
        }

        /// <summary>
        /// DateTimeInfo
        /// </summary>
        public System.DateTime DateTimeInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Exception
        /// </summary>
        public Exception Exception
        {
            get;
            set;
        }

        /// <summary>
        /// Message
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        #endregion Public Properties

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Now
        /// </summary>
        public override string ToString()
        {
            StringBuilder logBuffer = new StringBuilder();

            logBuffer.Append("[");
            logBuffer.Append(DateTimeInfo.ToString("yyyyMMdd-HH:mm:ss.fffff"));
            logBuffer.Append("] [");
            if (Caller != "UNKNOWN")
                logBuffer.Append(Caller.PadRight(25, ' '));
            logBuffer.Append("]");

            if (Exception == null)
            {
                logBuffer.Append(" [I] ");
                logBuffer.Append(Message);
            }
            else
            {
                logBuffer.Append(" [E] ");
                logBuffer.Append(" Exception Raised   ");
                logBuffer.Append(System.Environment.NewLine);
                logBuffer.Append("                                                    ");
                logBuffer.Append(Exception.Message);
                logBuffer.Append(System.Environment.NewLine);
                logBuffer.Append(Exception != null && Exception.StackTrace != null ? Exception.StackTrace.Replace(" at ", "                                                   at ") : "ERROR");
                logBuffer.Append(Message);
            }

            return logBuffer.ToString();
        }

        #endregion Public Methods
    }

    /// <summary>
    /// GLogger
    /// Class for logging
    /// </summary>
    public class LogManager
    {
        #region Public Members

        public static bool Active = true;

        #endregion Public Members

        #region Private Members

        private const string UNKNOWN = "UNKNOWN";

        //private EventsConsole console;
        private LogDateTime gtime = new LogDateTime();
        private TextWriter loggerWriter;
        private string logName;
        private BlockingCollection<GLoggerUnit> messages = new BlockingCollection<GLoggerUnit>();
        private ManualResetEventSlim waitUnit = new ManualResetEventSlim(false);

        #endregion Private Members

        #region Properties

        #region Public Properties

        /// <summary>
        /// Gets or sets the global log time.
        /// </summary>
        /// <value>
        /// The global log time.
        /// </value>
        public string GlobalLogTime
        {
            get
            {
                return gtime.Now.ToString("yyyyMMdd-HH:mm:ss.fffff");
            }
        }

        /// <summary>
        /// LogFileName
        /// </summary>
        public string LogFileName
        {
            get
            {
                return logName;
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Consuctor
        /// </summary>
        public LogManager(string directoryParam, string logNameParam)
        {
            if (!Directory.Exists(directoryParam))
                Directory.CreateDirectory(directoryParam);

            logName = logNameParam;

            loggerWriter = new StreamWriter(logName, true);

            Task.Factory.StartNew(() => WriteLog());
        }

        /// <summary>
        /// Consuctor
        /// </summary>
        public LogManager(string logNameParam)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + "Logs";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            logName = logNameParam;

            loggerWriter = new StreamWriter(logName, true);

            Task.Factory.StartNew(() => WriteLog());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogManager"/> class.
        /// </summary>
        protected LogManager()
        {
            // just for test
        }

        /// <summary>
        /// Distructor
        /// </summary>
        ~LogManager()
        {
            Dispose();
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (loggerWriter != null)
                {
                    loggerWriter.Flush();
                    loggerWriter.Close();
                }

            }
            catch { }
        }

        /// <summary>
        /// Logs the event.
        /// </summary>
        /// <param name="caller">The caller.</param>
        /// <param name="logMessage">The log message.</param>
        /// <param name="k">The k.</param>
        public void LogEvent(string caller, string logMessage, Exception k)
        {
            try
            {
                if (Active)
                {

                    GLoggerUnit unit = new GLoggerUnit()
                    {
                        Caller = caller,
                        Message = logMessage,
                        Exception = k,
                        DateTimeInfo = gtime.Now
                    };

                    messages.Add(unit);

                    waitUnit.Set();
                }
            }
            catch { }
        }

        /// <summary>
        /// Logs the event.
        /// </summary>
        /// <param name="caller">The caller.</param>
        /// <param name="logMessage">The log message.</param>
        public virtual void LogEvent(string caller, string logMessage)
        {
            LogEvent(caller, logMessage, null);
        }

        /// <summary>
        /// Logs the event.
        /// </summary>
        /// <param name="caller">The caller.</param>
        /// <param name="logMessage">The log message.</param>
        public virtual void LogEvent(string caller, string logMessage, bool log)
        {
            LogEvent(caller, logMessage, null);
        }

        /// <summary>
        /// Logs the event.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public virtual void LogEvent(string logMessage)
        {
            LogEvent(UNKNOWN, logMessage, null);
        }

        /// <summary>
        /// Logs the event.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public virtual void LogEvent(string logMessage, bool log)
        {
            LogEvent(UNKNOWN, logMessage, null);
        }

        /// <summary>
        /// Logs the event.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public virtual void LogEvent(Exception exception)
        {
            LogEvent(UNKNOWN, exception != null ? exception.Message : "E", exception);
        }

        /// <summary>
        /// Logs the event.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public virtual void LogEvent(Exception exception, bool log)
        {
            LogEvent(UNKNOWN, exception != null ? exception.Message : "E", exception);
        }

        ///// <summary>
        ///// Sets the console.
        ///// </summary>
        ///// <param name="consoleParam">The console parameter.</param>
        //public void SetConsole(EventsConsole consoleParam)
        //{
        //    console = consoleParam;
        //}
        /// <summary>
        /// WriteLog
        /// </summary>
        public void WriteLog()
        {
            while (true)
            {
                try
                {
                    while (messages.Count > 0)
                    {
                        GLoggerUnit unit = messages.Take();

                        if (unit != null)
                        {
                            loggerWriter.WriteLine(unit.ToString());

                            //if (console != null)
                            //    console.AddEvent(unit.ToString());
                        }
                    }

                    loggerWriter.Flush();
                    Thread.Sleep(1000);
                }
                catch (Exception)
                {

                }
            }
        }

        #endregion Public Methods
    }

    #endregion Types
}
