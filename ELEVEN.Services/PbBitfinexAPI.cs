using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Services
{
    public class PbBitfinexAPI
    {
        public static readonly string baseAddress = "https://api.bitfinex.com/v2/";
        /// <summary>
        /// This method recturn comma seperated rsult
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetSymbol(string url)
        {
            try
            {
                url = baseAddress + url;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "Foo";
                httpWebRequest.Accept = "*/*";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result;
                }
            }
            catch (Exception)
            {


            }

            return "";
        }

        public static T Get<T>(string url)
        {
            try
            {
                url = baseAddress + url;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "Foo";
                httpWebRequest.Accept = "*/*";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var tmp = JsonConvert.DeserializeObject<T>(result);
                    return tmp;
                }

            }
            catch (Exception ex)
            {


            }

            return default(T);
        }
    }
}
