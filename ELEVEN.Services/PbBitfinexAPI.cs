using ELEVEN.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Services
{
    public class PbBitfinexAPI
    {
        #region "Bitfinix"
        public static readonly string baseAddress = "https://api.bitfinex.com/v2/";
        public static readonly string baseAddressV1 = "https://api.bitfinex.com/v1/";
        private string accountInfoUrl = "account_infos";
        #endregion
       
        static List<string> ArrayString = new List<string> { "140.82.5.180:8080", "159.65.110.167:3128", "216.32.29.46:8008" };
        static long firstTime = 1;
        public string secret = "mkbbVEa...";
        private DateTime epoch = new DateTime(1970, 1, 1);

        private HMACSHA384 hashMaker;
        private string Key;
        private int nonce = 0;
        private string Nonce
        {
            get
            {
                if (nonce == 0)
                {
                    nonce = (int)(DateTime.UtcNow - epoch).TotalSeconds;
                }
                return (nonce++).ToString();
            }
        }

        public PbBitfinexAPI()
        {
            hashMaker = new HMACSHA384(Encoding.UTF8.GetBytes(secret));
            this.Key = "190417";
        }
        private String GetHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                sb.Append(String.Format("{0:x2}", b));
            }
            return sb.ToString();
        }
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
        // static List<string> ArrayString = new List<string> { "202.137.25.53:3128" };
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

        public static async Task<T> GetTiclers<T>(string url)
        {
            try
            {
                url = baseAddress + url;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "Foo";
                httpWebRequest.Accept = "*/*";

                if (firstTime > 10000000)
                {
                    firstTime = 1;
                }
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

        public void GetAccountInfo()
        {
            var accountInfo = new BFAccountInfo(accountInfoUrl, Nonce);
            SendRequest(accountInfo, "POST");
        }
        private string SendRequest(GenericRequest request, string httpMethod)
        {
            string json = JsonConvert.SerializeObject(request);
            string json64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            byte[] data = Encoding.UTF8.GetBytes(json64);
            byte[] hash = hashMaker.ComputeHash(data);
            string signature = GetHexString(hash);

            HttpWebRequest wr = WebRequest.Create(baseAddressV1 + request.request) as HttpWebRequest;
            wr.Headers.Add("X-BFX-APIKEY", Key);
            wr.Headers.Add("X-BFX-PAYLOAD", json64);
            wr.Headers.Add("X-BFX-SIGNATURE", signature);
            wr.Method = httpMethod;

            string response = null;
            try
            {
                HttpWebResponse resp = wr.GetResponse() as HttpWebResponse;
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                response = sr.ReadToEnd();
                sr.Close();
            }
            catch (WebException ex)
            {
                StreamReader sr = new StreamReader(ex.Response.GetResponseStream());
                response = sr.ReadToEnd();
                sr.Close();
                throw new BitfinexException(ex, response);
            }
            return response;
        }
    }
}
