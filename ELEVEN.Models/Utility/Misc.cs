using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ELEVEN.Models
{
    #region Types

    public static class Misc
    {
        #region Private Members

        private static readonly double MAX_CHART_VALUE = Convert.ToDouble(Decimal.MaxValue) / SCALE_FACTOR;
        private static readonly double MIN_CHART_VALUE = Convert.ToDouble(Decimal.MinValue) / SCALE_FACTOR;
        private static readonly double SCALE_FACTOR = 10;

        private static CultureInfo cultureSource = new CultureInfo("en-US", false);
        private static System.DateTime defaultdateTime = System.DateTime.MinValue;

        #endregion Private Members

        /// <summary>
        /// Gets the minutes time frame.
        /// </summary>
        /// <param name="timeFrame">The time frame.</param>
        /// <returns></returns>
        public static int GetMinutesTimeFrame(ConstEnum.Timeframe timeFrame)
        {
            switch (timeFrame)
            {
                case ConstEnum.Timeframe.RT:
                    return 0;
                case ConstEnum.Timeframe.M1:
                    return 1;
                case ConstEnum.Timeframe.M15:
                    return 15;
                case ConstEnum.Timeframe.M30:
                    return 30;
                case ConstEnum.Timeframe.M5:
                    return 5;
                case ConstEnum.Timeframe.H1:
                    return 60;
                case ConstEnum.Timeframe.H4:
                    return 240;
                case ConstEnum.Timeframe.D1:
                    return 1440;
            }

            return 0;
        }

      

        /// <summary>
        /// Adds the business days.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="days">The days.</param>
        /// <returns></returns>
        public static System.DateTime AddBusinessDays(System.DateTime date, int days)
        {
            if (days == 0 || date.Year == 9999) return date.Date;
            int i = 0;
            while (i < days)
            {
                if (!(date.AddDays(1).DayOfWeek == DayOfWeek.Saturday || date.AddDays(1).DayOfWeek == DayOfWeek.Sunday))
                    i++;

                date = date.AddDays(1);

            }
            return date.Date;
        }

    
        /// <summary>
        /// Handles the DateTime event of the binding_Format control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ConvertEventArgs"/> instance containing the event data.</param>
        public static void Binding_Format_DateTime(object sender, ConvertEventArgs e)
        {
            e.Value = (System.DateTime)e.Value <= new System.DateTime(1970, 1, 1) ? string.Empty : ((System.DateTime)e.Value).ToString("dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Handles the DateTimeShort event of the Binding_Format control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ConvertEventArgs"/> instance containing the event data.</param>
        public static void Binding_Format_DateTimeShort(object sender, ConvertEventArgs e)
        {
            e.Value = (System.DateTime)e.Value <= new System.DateTime(1970, 1, 1) ? string.Empty : ((System.DateTime)e.Value).ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Handles the Double event of the binding_Format control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ConvertEventArgs"/> instance containing the event data.</param>
        public static void Binding_Format_Double(object sender, ConvertEventArgs e)
        {
            e.Value = (e.Value == null || double.IsNaN((double)e.Value) || ((double)e.Value) == 0) ? string.Empty : ((double)e.Value).ToString("###,###,###,##0.###");
        }

        /// <summary>
        /// Handles the Double event of the binding_Format control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ConvertEventArgs"/> instance containing the event data.</param>
        public static void Binding_Format_Double_EUR(object sender, ConvertEventArgs e)
        {
            e.Value = (e.Value == null || double.IsNaN((double)e.Value) || ((double)e.Value) == 0) ? string.Empty : ((double)e.Value).ToString("#,###,###.### €");
        }

        /// <summary>
        /// Handles the Double event of the binding_Format control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ConvertEventArgs"/> instance containing the event data.</param>
        public static void Binding_Format_Double_WithZero(object sender, ConvertEventArgs e)
        {
            e.Value = (e.Value == null || double.IsNaN((double)e.Value) || ((double)e.Value) == 0) ? "0" : ((double)e.Value).ToString("###,###,###,##0.###");
        }

        /// <summary>
        /// Handles the Double event of the binding_Format control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ConvertEventArgs"/> instance containing the event data.</param>
        public static void Binding_Format_Perc(object sender, ConvertEventArgs e)
        {
            e.Value = (e.Value == null || double.IsNaN((double)e.Value) || ((double)e.Value) == 0) ? string.Empty : ((double)e.Value).ToString("P3");
        }

        /// <summary>
        /// Handles the 2dec event of the Binding_Format_Perc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ConvertEventArgs"/> instance containing the event data.</param>
        public static void Binding_Format_Perc_2dec(object sender, ConvertEventArgs e)
        {
            e.Value = (e.Value == null || double.IsNaN((double)e.Value) || ((double)e.Value) == 0) ? string.Empty : ((double)e.Value).ToString("P2");
        }

        /// <summary>
        /// Handles the Double event of the binding_Format control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ConvertEventArgs"/> instance containing the event data.</param>
        public static void Binding_Format_Perc_WithZero(object sender, ConvertEventArgs e)
        {
            e.Value = (e.Value == null || double.IsNaN((double)e.Value) || ((double)e.Value) == 0) ? ((double)0).ToString("P3") : ((double)e.Value).ToString("P3");
        }

        /// <summary>
        /// Calculates the rate.
        /// </summary>
        /// <param name="currentTime">The current time.</param>
        /// <param name="lastRateCheck">The last rate check.</param>
        /// <param name="DownloadedPrices">The downloaded prices.</param>
        /// <returns></returns>
        public static double CalculateRate(System.DateTime currentTime, System.DateTime lastRateCheck, double DownloadedPrices)
        {
            if (currentTime.Subtract(lastRateCheck).TotalSeconds > 1)
            {
                //Calcolo del Rate/Sec
                double upd = (DownloadedPrices / currentTime.Subtract(lastRateCheck).TotalSeconds);
                return Math.Round(upd, 2);
            }
            return -1;
        }

        /// <summary>
        /// Copies to clipboard.
        /// </summary>
        /// <param name="textParam">The text parameter.</param>
        public static void CopyToClipboard(string textParam)
        {
            try
            {
                Clipboard.SetText(textParam, TextDataFormat.Text);
            }
            catch { }
        }

        /// <summary>
        /// Deserializes the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static T Deserialize<T>(string fileName)
        {
            var f_fileStream = File.OpenRead(fileName);
            var f_binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var objReturn = (T)f_binaryFormatter.Deserialize(f_fileStream);
            //main.Supervisor.ScanFilters = (Dictionary<ScanFilterKey, Dictionary<int, ScanFilter>>)f_binaryFormatter.Deserialize(f_fileStream);
            f_fileStream.Close();
            return objReturn;
        }

        /// <summary>
        /// Finds the control recursive.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="holder">The holder.</param>
        /// <param name="controlID">The control identifier.</param>
        /// <returns></returns>
        public static T FindControlRecursive<T>(Control holder, string controlID)
            where T : Control
        {
            Control foundControl = null;
            foreach (Control ctrl in holder.Controls)
            {
                if (ctrl.GetType().Equals(typeof(T)) &&
                  (string.IsNullOrEmpty(controlID) || (!string.IsNullOrEmpty(controlID) && ctrl.Name.Equals(controlID))))
                {
                    foundControl = ctrl;
                }
                else if (ctrl.Controls.Count > 0)
                {
                    foundControl = FindControlRecursive<T>(ctrl, controlID);
                }
                if (foundControl != null)
                    break;
            }
            return (T)foundControl;
        }

        /// <summary>
        /// Gets the color of the barrier type fore.
        /// </summary>
        /// <param name="barrierType">Type of the barrier.</param>
        /// <returns></returns>
        public static Color GetBarrierTypeForeColor(string barrierType)
        {
            if (barrierType == "D")
                return Color.Red;
            else
                return Color.Blue;
        }

        /// <summary>
        /// Gets the boolean.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public static bool GetBoolean(DataRow row, string fieldName)
        {
            try
            {
                bool value = row[fieldName] == DBNull.Value ? false : bool.Parse(row[fieldName].ToString());
                return value;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the currency from string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetCurrencyFromString(string value)
        {
            try
            {
                if (value.Length > 2 && (value.ToUpper().Contains("EURO") || value.Substring(value.Length - 3, 3) == "EUR"))
                    return "EUR";
                if (value.Length > 2 && (value.ToUpper().Contains("US-DOLLAR") || value.ToUpper().Contains("USD")))
                    return "USD";
                if (value.Length > 2 && (value.ToUpper().Contains("ZLOTY") || value.Substring(value.Length - 3, 3) == "PLN"))
                    return "PLN";
                if (value.Length > 2 && (value.ToUpper().Contains("RUBEL") || value.Substring(value.Length - 3, 3) == "RUB"))
                    return "RUB";
                if (value.Length > 2 && (value.ToUpper().Contains("PUNKTE") || value.ToUpper().Contains("POINTS")))
                    return "POINTS";
                if (value.Length > 2 && (value.Substring(value.Length - 3, 3) == "TRY"))
                    return "TRY";
                if (value.Length > 2 && (value.Substring(value.Length - 3, 3) == "NOK"))
                    return "NOK";
                if (value.Length > 2 && (value.ToUpper().Contains("STERLING") || value.Substring(value.Length - 3, 3) == "GBP"))
                    return "GBP";
                if (value.Length > 2 && (value.Substring(value.Length - 3, 3) == "CHF"))
                    return "CHF";
                if (value.Length > 2 && (value.Substring(value.Length - 3, 3) == "SEK"))
                    return "SEK";
                if (value.Length > 2 && (value.Substring(value.Length - 3, 3) == "HKD"))
                    return "HKD";
                if (value.Length > 0 && value.ToUpper().Contains("%"))
                    return "PERC";

                Console.WriteLine("DIVISA VUOTA [" + value + "]");

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public static System.DateTime GetDateTime(DataRow row, string fieldName)
        {
            try
            {
                System.DateTime value = row[fieldName] == DBNull.Value ? defaultdateTime : System.DateTime.Parse(row[fieldName].ToString());
                return value;
            }
            catch
            {
                return defaultdateTime;
            }
        }

        /// <summary>
        /// Gets the date time from string.
        /// </summary>
        /// <param name="dtParam">The dt parameter.</param>
        /// <param name="formatParam">The format parameter.</param>
        /// <returns></returns>
        public static System.DateTime? GetDateTimeFromString(string dtParam, string formatParam)
        {
            try
            {
                return System.DateTime.ParseExact(dtParam, formatParam, CultureInfo.InvariantCulture);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the color of the distance back.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <returns></returns>
        public static Color GetDistanceBackColor(double distance)
        {
            if (distance < 0.10)
                return Color.Red;
            else if (distance < 0.25)
                return Color.Orange;
            else if (distance < 0.40)
                return Color.Yellow;
            else
                return Color.Lime;
        }

        /// <summary>
        /// Gets the color of the distance fore.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <returns></returns>
        public static Color GetDistanceForeColor(double distance)
        {
            if (distance < 0.10)
                return Color.White;
            else if (distance < 0.25)
                return Color.Black;
            else if (distance < 0.40)
                return Color.Black;
            else
                return Color.Black;
        }

        /// <summary>
        /// Gets the double.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public static double GetDouble(DataRow row, string fieldName)
        {
            //return Convert.ToDouble(row[fieldName].ToString());

            try
            {
                double value = row[fieldName] == DBNull.Value ? 0 : double.Parse(row[fieldName].ToString());
                return value;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the digit from string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static double GetDoubleFromString(string value)
        {
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            string numeric = "";
            char[] mychar = value.ToCharArray();

            foreach (char ch in mychar)
            {
                if ((char.IsDigit(ch) || char.IsPunctuation(ch)) && ch != '%')
                {

                    numeric = numeric + ch.ToString();
                }
            }
            try
            {
                double result = 0;
                double.TryParse(numeric, style, cultureSource, out result);
                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the digit from string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static double GetDoubleFromString(string value, CultureInfo cultureSourceParam)
        {
            //Taccone per yahoo
            if (value != null && value.Contains("react-text"))
            {
                value = value.Substring(value.IndexOf("-->") + 3);
                value = value.Substring(0, value.IndexOf("<"));
            }

            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            string numeric = "";
            char[] mychar = value.ToCharArray();

            foreach (char ch in mychar)
            {
                if ((char.IsDigit(ch) || char.IsPunctuation(ch)) && ch != '%')
                {

                    numeric = numeric + ch.ToString();
                }
            }
            try
            {
                double result = 0;
                double.TryParse(numeric, style, cultureSourceParam, out result);
                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the enum description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        /// <summary>
        /// Gets the file name to load.
        /// </summary>
        /// <param name="initialDirectory">The initial directory.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public static string GetFileNameToLoad(string initialDirectory, string filter, string title)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (!string.IsNullOrEmpty(initialDirectory))
                dialog.InitialDirectory = Path.GetFullPath(initialDirectory);
            dialog.Filter = filter;
            dialog.Title = title;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            else
                return null;
        }

        /// <summary>
        /// Gets the file name to load.
        /// </summary>
        /// <param name="initialDirectory">The initial directory.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public static void GetFileNameToLoad(string initialDirectory, string filter, string title, ref string fileNamePath, ref string fileName)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Path.GetFullPath(initialDirectory);
            dialog.Filter = filter;
            dialog.Title = title;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileNamePath = dialog.FileName;
                fileName = dialog.SafeFileName;
            }
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="initialDirectory">The initial directory.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="title">The title.</param>
        public static string GetFileNameToSave(string initialDirectory, string filter, string title)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Path.GetFullPath(initialDirectory);
            dialog.RestoreDirectory = true;
            dialog.Filter = filter;
            dialog.Title = title;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            else
                return null;
        }

        /// <summary>
        /// Gets the folder.
        /// </summary>
        /// <returns></returns>
        public static string GetFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            return fbd.SelectedPath;
        }

        public static string GetHtmlPage(string urlParam)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlParam);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Timeout = 5000;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var row = reader.ReadToEnd();
                    //row = row.Replace("\"", "");
                    //row = row.Replace("\\", "\"");
                    //var document = new HtmlAgilityPack.HtmlDocument();
                    //document.LoadHtml(row);
                    return row;
                }
                //var xmlReader = XmlReader.Create(new StringReader(html));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the image currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <param name="images">The images.</param>
        /// <returns></returns>
        public static Image GetImageGeneric(string code, Dictionary<string, Image> images)
        {
            switch (code)
            {
                case "BTN_CLOSE": return images["BTN_CLOSE"];
                case "BTN_RED": return images["BTN_RED"];
                case "BTN_GREEN": return images["BTN_GREEN"];
                case "BTN_YELLOW": return images["BTN_YELLOW"];
                case "QUOTE": return images["QUOTE"];
                case "IDLE": return images["IDLE"];
                case "RSS": return images["RSS"];
                default: return images["ND"];
            }
        }

        /// <summary>
        /// Gets the image platform check result.
        /// </summary>
        /// <param name="isPassed">if set to <c>true</c> [is passed].</param>
        /// <returns></returns>
        public static Image GetImagePlatformCheckResult(bool isPassed, Dictionary<string, Image> images)
        {
            switch (isPassed)
            {
                case true: return images["BTN_GREEN"];
                case false: return images["BTN_RED"];
            }
            return images["BTN_RED"];
        }

        /// <summary>
        /// Gets the image quote status.
        /// </summary>
        /// <param name="quoteStatus">The quote status.</param>
        /// <returns></returns>
        public static Image GetImageQuoteStatus(string quoteStatus, Dictionary<string, Image> images)
        {
            return images[quoteStatus];
            //switch (quoteStatus)
            //{
            //    case "QUOTE": return Properties.Resources.Play;
            //    case "IDLE": return Properties.Resources.Idle;
            //}
            //return Properties.Resources.ND;
        }

        /// <summary>
        /// Gets the image RSS feed.
        /// </summary>
        /// <param name="hasFeed">if set to <c>true</c> [has feed].</param>
        /// <returns></returns>
        public static Image GetImageRSSFeed(bool hasFeed, Dictionary<string, Image> images)
        {
            if (hasFeed)
                //return Properties.Resources.RSS_icon;
                return images["RSS"];
            else
                return null;
        }

        /// <summary>
        /// Gets the top position form.
        /// </summary>
        /// <param name="formParam">The form parameter.</param>
        /// <returns></returns>
        public static int GetLeftPositionForm(Form formParam)
        {
            //Screen mainScreen = Screen.AllScreens.Where(r => r.Primary).FirstOrDefault();
            Screen screen = GetScreen(formParam);
            if (screen == null)
                return 0;

            if (formParam.WindowState == FormWindowState.Minimized)
                return 0;

            return formParam != null ? formParam.Left : 0;
        }

        public static System.DateTime GetNextWorkingDay(System.DateTime date)
        {
            do
            {
                date = date.AddDays(1);
            } while (IsWeekEnd(date));
            return date;
        }

        /// <summary>
        /// Gets the open form.
        /// </summary>
        /// <param name="formName">Name of the form.</param>
        /// <returns></returns>
        public static Form GetOpenForm(string formName)
        {
            Form fc = Application.OpenForms[formName];
            if (fc != null)
                return fc;
            return null;
        }

        public static System.DateTime GetPreviousWorkingDay(System.DateTime date)
        {
            do
            {
                date = date.AddDays(-1);
            } while (IsWeekEnd(date));
            return date;
        }

        /// <summary>
        /// Gets the color of the probability back.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <returns></returns>
        public static Color GetProbabilityBackColor(double distance)
        {
            if (distance < 0)
                return Color.Black;
            else if (distance < 0.10)
                return Color.Green;
            else if (distance < 0.20)
                return Color.Yellow;
            else if (distance < 0.30)
                return Color.Orange;
            else
                return Color.Red;
        }

        /// <summary>
        /// Gets the color of the probability fore.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <returns></returns>
        public static Color GetProbabilityForeColor(double distance)
        {
            if (distance < 0.10)
                return Color.White;
            else if (distance < 0.30)
                return Color.Black;
            else
                return Color.White;
        }

        /// <summary>
        /// Gets the screen.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <returns></returns>
        public static Screen GetScreen(Form form)
        {
            foreach (Screen screen in Screen.AllScreens)
                if (screen.Bounds.Contains(form.Location))
                    return screen;
            return null;
        }

        /// <summary>
        /// Gets the time from est to local.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static System.DateTime GetTimeFromESTToLocal(string value)
        {
            try
            {
                string valueIn = value;
                string time = value.Replace("EST", string.Empty);
                time = value.Replace("EDT", string.Empty);
                if (valueIn.IndexOf(',') > 0)
                {
                    time = time.Substring(0, value.IndexOf(',')) + " " + System.DateTime.Now.Year + ", " + time.Substring(value.IndexOf(',') + 1, time.Length - time.IndexOf(',') - 1);
                }
                else
                {
                    if (time.ToUpper().Contains("PM") || time.ToUpper().Contains("AM"))
                    {
                        //
                        time = System.DateTime.Now.ToString("dd/MM/yyyy") + " " + time;
                    }
                    else
                    {
                        time = value + " " + System.DateTime.Now.Year + ", 4:00PM";
                    }
                }

                /*int pos = time.IndexOf(":");
                if (pos > 0)
                {
                    time = time.Substring(pos - 2, 2) + ":" + time.Substring(pos + 1, 2);
                    if (value.ToUpper().Contains("PM"))
                        time = time + "PM";
                    if (value.ToUpper().Contains("AM"))
                        time = time + "AM";
                }
                else
                {
                    time = "23:59";
                }

                DateTime userTime;
                if (valueIn.IndexOf(',') > 0)
                {
                    time = value.Substring(0, value.IndexOf(',')) + " " + DateTime.Now.Year + " " + time;
                }
                */
                System.DateTime userTime;

                System.DateTime.TryParse(time, out userTime);

                //DateTime userTime = DateTime.SpecifyKind(dt, DateTimeKind.Unspecified);
                TimeZoneInfo UserTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                TimeZoneInfo TargetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
                System.DateTime newTime = TimeZoneInfo.ConvertTime(userTime, UserTimeZone, TargetTimeZone);
                return newTime;
            }
            catch
            {
                return new System.DateTime(1970, 1, 1);
            }
        }

        /// <summary>
        /// Gets the top position form.
        /// </summary>
        /// <param name="formParam">The form parameter.</param>
        /// <returns></returns>
        public static int GetTopPositionForm(Form formParam)
        {
            //Screen mainScreen = Screen.AllScreens.Where(r => r.Primary).FirstOrDefault();
            Screen screen = GetScreen(formParam);
            if (screen == null)
                return 0;

            if (formParam.WindowState == FormWindowState.Minimized || formParam.Top > screen.WorkingArea.Height / 2)
                return screen.WorkingArea.Top;

            return formParam != null ? formParam.Top + formParam.Height + 0 : 0;
        }

        /// <summary>
        /// Gets the type and icon.
        /// </summary>
        /// <returns></returns>
        public static Hashtable GetTypeAndIcon()
        {
            try
            {
                RegistryKey icoRoot = Registry.ClassesRoot;
                string[] keyNames = icoRoot.GetSubKeyNames();
                Hashtable iconsInfo = new Hashtable();

                foreach (string keyName in keyNames)
                {
                    if (String.IsNullOrEmpty(keyName)) continue;
                    int indexOfPoint = keyName.IndexOf(".");

                    if (indexOfPoint != 0) continue;

                    RegistryKey icoFileType = icoRoot.OpenSubKey(keyName);
                    if (icoFileType == null) continue;

                    object defaultValue = icoFileType.GetValue("");
                    if (defaultValue == null) continue;

                    string defaultIcon = defaultValue.ToString() + "\\DefaultIcon";
                    RegistryKey icoFileIcon = icoRoot.OpenSubKey(defaultIcon);
                    if (icoFileIcon != null)
                    {
                        object value = icoFileIcon.GetValue("");
                        if (value != null)
                        {
                            string fileParam = value.ToString().Replace("\"", "");
                            iconsInfo.Add(keyName, fileParam);
                        }
                        icoFileIcon.Close();
                    }
                    icoFileType.Close();
                }
                icoRoot.Close();
                return iconsInfo;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="ticker">The ticker.</param>
        /// <returns></returns>
        public static string GetUrl(string code, string ticker)
        {
            switch (code)
            {
                case "Guru": return "https://www.gurufocus.com/stock/" + ticker;
                case "Google": return "http://www.google.com/search?q=" + ticker;
                case "Yahoo": return "https://it.finance.yahoo.com/echarts?s=" + ticker + "#symbol=" + ticker + ";range=5y";
                //case "YahooChart": return "https://it.finance.yahoo.com/echarts?s=" + ticker + "#symbol=" + ticker + ";range=5y";
                case "Frankfurt": return string.Format("http://en.boerse-frankfurt.de/searchresults?_search={0}", ticker);
                case "Stuttgard": return string.Format("https://www.boerse-stuttgart.de/de/rd/erweiterte_kurssuche/suchergebnis/?searchterm={0}", ticker);
                case "Finanzen": return string.Format("http://www.finanzen.net/suchergebnis.asp?frmAktiensucheTextfeld={0}", ticker);
                case "Six": return string.Format("http://www.six-structured-products.com/en/zertifikat/-{0}", ticker);
                case "BorsaItaliana": return string.Format("http://www.borsaitaliana.it/borsa/cw-e-certificates/scheda/{0}.html?lang=it{0}", ticker);
                case "BorsaItalianaBond": return string.Format("http://www.borsaitaliana.it/borsa/obbligazioni/mot/obbligazioni-in-euro/scheda/{0}.html?lang=it", ticker);
                case "EuroTlx": return string.Format("http://www.eurotlx.com/it/strumenti/dettaglio/{0}", ticker);
                case "CertificatiDerivati": return string.Format("http://www.certificatiederivati.it/db_bs_scheda_certificato.asp?isin={0}", ticker);
                case "FinancialTimes": return string.Format("https://markets.ft.com/data/equities/tearsheet/forecasts?s={0}", ticker);
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the value from description.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentException">Not found.;description</exception>
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }

        public static bool IsWeekEnd(System.DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Json2s the tree.
        /// </summary>
        /// <param name="jsonString">The json string.</param>
        /// <returns></returns>
        public static TreeNode Json2Tree(string jsonString)
        {
            Dictionary<int, TreeNode> depthToNodes = new Dictionary<int, TreeNode>();

            TreeNode parent = new TreeNode();
            TreeNode currentNode = parent;

            int currentDepth = 0;
            bool newArrayToPopulate = false;

            if (!depthToNodes.ContainsKey(currentDepth))
                depthToNodes.Add(currentDepth, parent);

            JsonTextReader reader = new JsonTextReader(new StringReader(jsonString));

            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    TreeNode child = new TreeNode();

                    //Here we have a new group
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        currentDepth = reader.Depth;

                        currentNode.Nodes.Add(child);

                        if (!depthToNodes.ContainsKey(currentDepth))
                            depthToNodes.Add(currentDepth, child);

                    }
                    else if (reader.TokenType == JsonToken.PropertyName)
                    {
                        if (reader.Depth > currentDepth)
                        {
                            child.Text = reader.Value.ToString();
                            currentNode.Nodes.Add(child);

                            currentNode = child;

                            currentDepth = reader.Depth;

                            if (!depthToNodes.ContainsKey(currentDepth))
                                depthToNodes.Add(currentDepth, child);
                            else
                                depthToNodes[currentDepth] = child;
                        }
                        else if (reader.Depth == currentDepth)
                        {
                            child.Text = reader.Value.ToString();
                            currentNode = depthToNodes[currentDepth - 1];
                            currentNode.Nodes.Add(child);
                            currentDepth = reader.Depth;
                            currentNode = child;
                        }
                        else if (reader.Depth < currentDepth)
                        {
                            child.Text = reader.Value.ToString();
                            currentNode = depthToNodes[currentDepth - 2];
                            currentNode.Nodes.Add(child);
                            currentDepth = reader.Depth;
                            currentNode = child;

                            depthToNodes[currentDepth] = child;
                        }
                    }
                    else
                    {
                        if (newArrayToPopulate == true)
                        {
                            child.Text = reader.Value.ToString();
                            currentNode.Nodes.Add(child);
                        }
                        else
                            currentNode.Text += " : " + reader.Value.ToString();
                    }

                }
                else
                {

                    if (reader.TokenType == JsonToken.StartArray)
                        newArrayToPopulate = true;
                    else if (reader.TokenType == JsonToken.EndArray)
                        newArrayToPopulate = false;
                }
            }

            return parent;
        }

        /// <summary>
        /// Jsons to dictionary.
        /// </summary>
        /// <param name="jsonString">The json string.</param>
        /// <returns></returns>
        public static Dictionary<string, string> JsonToDictionary(string jsonString)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            Dictionary<int, string> openedLevel = new Dictionary<int, string>();

            JsonTextReader reader = new JsonTextReader(new StringReader(jsonString));
            values = new Dictionary<string, string>();
            while (reader.Read())
            {
                try
                {
                    if (reader.Value != null)
                    {
                        if (reader.TokenType == JsonToken.PropertyName)
                        {
                            if (!openedLevel.ContainsKey(reader.Depth))
                                openedLevel.Add(reader.Depth, reader.Value.ToString());
                            else
                            {
                                var levels = openedLevel.Where(k => k.Key < reader.Depth);

                                var key = openedLevel[reader.Depth];

                                foreach (var k in levels.Where(k => k.Value != "general" && k.Value != "summary"))
                                    key = k.Value + "_" + key;

                                //Console.WriteLine(key + " " + reader.Value.ToString());
                                openedLevel.Remove(reader.Depth);

                                if (!values.ContainsKey(key))
                                    values.Add(key, reader.Value.ToString());
                            }
                        }
                        else
                        {
                            if (openedLevel.ContainsKey(reader.Depth))
                            {
                                var levels = openedLevel.Where(k => k.Key < reader.Depth);

                                var key = openedLevel[reader.Depth];

                                foreach (var k in levels.Where(k => k.Value != "general" && k.Value != "summary"))
                                    key = k.Value + "_" + key;

                                //Console.WriteLine(key + " " + reader.Value.ToString());

                                openedLevel.Remove(reader.Depth);

                                if (!values.ContainsKey(key))
                                    values.Add(key, reader.Value.ToString());

                            }
                        }
                    }
                }
                catch (Exception k)
                {
                    Console.WriteLine(k);
                }
            }

            return values;
        }

        /// <summary>
        /// Normalizes the string.
        /// </summary>
        /// <param name="textParam">The text parameter.</param>
        /// <returns></returns>
        public static string NormalizeString(string textParam)
        {
            var map = new Dictionary<char, string>() {
                  { 'ä', "ae" },
                  { 'ö', "oe" },
                  { 'ü', "ue" },
                  { 'Ä', "Ae" },
                  { 'Ö', "Oe" },
                  { 'Ü', "Ue" },
                  { 'ß', "ss" },
                  { '�', "I" },
                  { 'Ã',"i"}
                };

            var res = textParam.Aggregate(
                          new StringBuilder(),
                          (sb, c) =>
                          {
                              string r;
                              if (map.TryGetValue(c, out r))
                                  return sb.Append(r);
                              else
                                  return sb.Append(c);
                          }).ToString();

            return res;
        }

        /// <summary>
        /// Objects to XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objParam">The object parameter.</param>
        /// <returns></returns>
        public static string ObjectToXML<T>(object objParam)
        {
            StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, ((T)objParam));
            return writer.ToString();
        }

        /// <summary>
        /// Reflections the filter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="property">The property.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IEnumerable<T> ReflectionFilter<T>(IEnumerable<T> collection, string property, object value)
        {
            if (collection.Count() == 0)
                return new List<T>();
            PropertyInfo pInfo = collection.First().GetType().GetProperty(property);

            return collection.Where(c => object.Equals(pInfo.GetValue(c), value)).ToList();
        }

        /// <summary>
        /// Reflections the filter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="property">The property.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IEnumerable<T> ReflectionFilterHasValues<T>(IEnumerable<T> collection, string property, object valueCheck, Type castType)
        {
            if (collection.Count() == 0)
                return new List<T>();
            PropertyInfo pInfo = collection.First().GetType().GetProperty(property);
            if (castType == typeof(double))
                return collection.Where(c => !object.Equals(Convert.ToDouble(pInfo.GetValue(c, null)), Convert.ToDouble(valueCheck))).ToList();
            else
                return collection.Where(c => !object.Equals(pInfo.GetValue(c, null), valueCheck)).ToList();
        }


        /// <summary>
        /// Rounds down.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="places">The places.</param>
        /// <returns></returns>
        public static double RoundDown(double value, double places)
        {
            if (double.IsInfinity(value) || double.IsNaN(value))
                return double.MinValue;

            return Convert.ToDouble(RoundDown(Convert.ToDecimal(value), Convert.ToInt32(places)));
        }

        /// <summary>
        /// Rounds down.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="places">The places.</param>
        /// <returns></returns>
        public static decimal RoundDown(decimal number, int places)
        {
            decimal factor = RoundFactor(places);
            number *= factor;
            number = Math.Floor(number);
            number /= factor;
            return number;
        }

        /// <summary>
        /// Rounds down by tick.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        public static double RoundDownByTick(double value, double step)
        {
            var multiplicand = Math.Floor(value / step);
            return Math.Round((step * multiplicand), 4);
        }

        /// <summary>
        /// Rounds up.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="places">The places.</param>
        /// <returns></returns>
        public static decimal RoundUp(decimal number, int places)
        {
            decimal factor = RoundFactor(places);
            number *= factor;
            number = Math.Ceiling(number);
            number /= factor;
            return number;
        }

        /// <summary>
        /// Rounds up.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="places">The places.</param>
        /// <returns></returns>
        public static double RoundUp(double number, int places)
        {
            double factor = (double)RoundFactor(places);
            number *= factor;
            number = Math.Ceiling(number);
            number /= factor;
            return number;
        }

        /// <summary>
        /// Rounds up by tick.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        public static double RoundUpByTick(double value, double step)
        {
            var multiplicand = Math.Floor(value / step);
            if ((decimal)value % (decimal)step != 0)
                return Math.Round((step * multiplicand) + step, 4);
            else
                return Math.Round(value, 4);
        }

    

        /// <summary>
        /// Serializes the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="objToSerialize">The object to serialize.</param>
        public static void Serialize(string fileName, object objToSerialize)
        {
            var f_fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            var f_binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            f_binaryFormatter.Serialize(f_fileStream, objToSerialize);
            f_fileStream.Close();
        }


        /// <summary>
        /// Sets the color of the combo yes no back.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        public static void SetComboYesNoBackColor(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index == -1)
                return;

            // Get the item text
            string text = ((ComboBox)sender).Items[e.Index].ToString();

            Brush brush;
            if (text.Contains("No"))// compare data
            {
                text = Misc.GetEnumDescription(ConstEnum.YesNo.N);
                brush = Brushes.White;
                ((ComboBox)sender).BackColor = Color.Red;
            }
            else
            {
                text = Misc.GetEnumDescription(ConstEnum.YesNo.Y);
                brush = Brushes.Black;
                ((ComboBox)sender).BackColor = Color.Lime;
            }

            e.Graphics.DrawString(text, ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
        }

        /// <summary>
        /// Sets the culture.
        /// </summary>
        /// <param name="tThreadParam">The t thread parameter.</param>
        public static void SetCulture(Thread tThreadParam)
        {
            CultureInfo ci = new CultureInfo("en-US");
            ci.NumberFormat.NumberDecimalSeparator = ".";
            tThreadParam.CurrentCulture = ci;
            tThreadParam.CurrentUICulture = ci;
        }

 

        /// <summary>
        /// Stronglies the name filter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static IEnumerable<T> StronglyNameFilter<T>(IEnumerable<T> collection, Func<T, bool> filter)
        {
            return collection.Where(filter).ToList();
        }

        /// <summary>
        /// Suspends the two way binding.
        /// </summary>
        /// <param name="bindingManager">The binding manager.</param>
        /// <exception cref="ArgumentNullException">bindingManager</exception>
        public static void SuspendTwoWayBinding(BindingManagerBase bindingManager)
        {
            if (bindingManager == null)
            {
                throw new ArgumentNullException("bindingManager");
            }

            foreach (Binding b in bindingManager.Bindings)
            {
                b.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            }
        }

        ///// <summary>
        ///// Updates the data bound object.
        ///// </summary>
        ///// <param name="bindingManager">The binding manager.</param>
        ///// <exception cref="ArgumentNullException">bindingManager</exception>
        public static void UpdateDataBoundObject(BindingManagerBase bindingManager)
        {
            if (bindingManager == null)
            {
                throw new ArgumentNullException("bindingManager");
            }

            foreach (Binding b in bindingManager.Bindings)
            {
                PropertyInfo prop = ((System.Windows.Forms.BindingSource)b.DataSource).Current.GetType().GetProperty(b.BindingMemberInfo.BindingField, BindingFlags.Public | BindingFlags.Instance);
                if (null != prop && prop.CanWrite && prop.CustomAttributes.Count() > 0) //salvo solo se hanno custom attr.
                {
                    if (b.Control.GetType() == typeof(MaskedTextBox))
                    {
                        var value = ((MaskedTextBox)b.Control).Text.Trim();
                        if (value != "/  /")
                        {
                            System.DateTime? dt = System.DateTime.ParseExact(((MaskedTextBox)b.Control).Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            prop.SetValue(((System.Windows.Forms.BindingSource)b.DataSource).Current, dt, null);
                        }
                        else
                            prop.SetValue(((System.Windows.Forms.BindingSource)b.DataSource).Current, System.DateTime.MinValue, null);
                    }
                    else
                        b.WriteValue();
                }
            }
        }

        /// <summary>
        /// XMLs to object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml">The XML.</param>
        /// <returns></returns>
        public static T XMLToObject<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var textReader = new StringReader(xml))
            {
                using (var xmlReader = XmlReader.Create(textReader))
                {
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
        }

        /// <summary>
        /// Rounds the factor.
        /// </summary>
        /// <param name="places">The places.</param>
        /// <returns></returns>
        internal static decimal RoundFactor(int places)
        {
            decimal factor = 1m;

            if (places < 0)
            {
                places = -places;
                for (int i = 0; i < places; i++)
                    factor /= 10m;
            }

            else
            {
                for (int i = 0; i < places; i++)
                    factor *= 10m;
            }

            return factor;
        }
        

        /// <summary>
        /// Gets the new image.
        /// </summary>
        /// <param name="bitMap">The bit map.</param>
        /// <returns></returns>
        private static Image GetNewImage(Bitmap bitMap)
        {
            Bitmap myBitmap = new Bitmap(bitMap);
            Image myImage = (Image)myBitmap.Clone();
            return myImage;
        }

        /// <summary>
        /// Sends the telegram.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void SendTelegram(string message, string telegramBotToken, string telegramChatID)
        {
            //System.Diagnostics.Process.Start(string.Format("https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}", telegramBotToken, telegramChatID, message));

            using (var client = new WebClient())
            {
                try
                {
                    string html = client.DownloadString(string.Format("https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}", telegramBotToken, telegramChatID, message));
                }
                catch
                { }
            }
        }
    }

    #endregion Types
}
