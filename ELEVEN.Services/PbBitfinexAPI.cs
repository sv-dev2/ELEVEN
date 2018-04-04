using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Services
{
    public class PbBitfinexAPI
    {
        public static readonly string baseAddress = "https://api.bitfinex.com/v2/";
        public static readonly string baseAddressV1 = "https://api.bitfinex.com/v1/";
        /// <summary>
        /// This method recturn comma seperated rsult
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetSymbol(string url)
        {
            try
            {
                url = baseAddressV1 + url;
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
            catch (Exception e)
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
                IWebProxy proxy = WebRequest.GetSystemWebProxy();
                httpWebRequest.Proxy = proxy;
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
      
        public static async Task<T> GetTiclers<T>(string url)
        {
            try
            {
                url = baseAddress + url;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "Foo";
                httpWebRequest.Accept = "*/*";
                IWebProxy proxy = WebRequest.GetSystemWebProxy();
                httpWebRequest.Proxy = proxy;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();
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
