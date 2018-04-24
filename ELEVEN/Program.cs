using ELEVEN.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELEVEN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo ci = new CultureInfo("en-US");
            ci.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            Control.CheckForIllegalCrossThreadCalls = false;
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 
            Application.Run(new MDIParentForm());
        }
        /// <summary>
        /// Handles the ThreadException event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ThreadExceptionEventArgs"/> instance containing the event data.</param>
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                System.IO.TextWriter writer = new StreamWriter("E-leven_ThreadException.err");
                writer.WriteLine(e.Exception.Message);
                writer.WriteLine(e.Exception.StackTrace);
                writer.Close();
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// Handles the UnhandledException event of the CurrentDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                TextWriter writer = new StreamWriter("E-leven_UnhandledException.err");
                writer.WriteLine(e.ExceptionObject.ToString());
                writer.WriteLine(e.ExceptionObject);
                writer.Close();
            }
            catch (Exception)
            { }
        }
    }
}
