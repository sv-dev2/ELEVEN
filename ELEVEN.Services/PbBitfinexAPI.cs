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
        public static readonly string baseAddressV1 = "https://api.bitfinex.com";
        public static readonly string baseAddressV1_Back = "https://api.bitfinex.com/v1/";
        private string accountInfoUrl = "/v1/account_infos";
        #endregion
       
        static List<string> ArrayString = new List<string> { "140.82.5.180:8080", "159.65.110.167:3128", "216.32.29.46:8008" };
        static long firstTime = 1;
        public string secret = "BGT95gwA8FTfVH43dRlt0k4HRKJQq9YztrOllPfNShz";
        private DateTime epoch = new DateTime(2017, 12, 12);

        private HMACSHA384 hashMaker;
        private string Key;
        private int nonce = 0;
        private string Nonce
        {
            //get
            //{
            //    if (nonce == 0)
            //    {
            //        nonce = (int)(DateTime.UtcNow - epoch).TotalSeconds + (int)(DateTime.UtcNow - epoch).TotalSeconds + (int)(DateTime.UtcNow - epoch).TotalSeconds;
            //    }
            //    return (nonce++).ToString();
            //    //return DateTime.Now.Second.ToString();
            //}
            get
            {
                return "99999999999999" + (DateTime.UtcNow - epoch).TotalSeconds.ToString();
            }
        }

        public PbBitfinexAPI()
        {
            hashMaker = new HMACSHA384(Encoding.UTF8.GetBytes(secret));
            this.Key = "ANduQQtWW7JiTAETL6tpmWcKfvG5rsZaV2VI0boqgVV";
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
                url = baseAddressV1_Back + url;
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

        public BalancesResponse GetBalances()
        {
            BalancesRequest req = new BalancesRequest(Nonce);
            string response = SendRequest(req, "GET");
            BalancesResponse resp = BalancesResponse.FromJSON(response);

            return resp;
        }
        public CancelOrderResponse CancelOrder(int order_id)
        {
            CancelOrderRequest req = new CancelOrderRequest(Nonce, order_id);
            string response = SendRequest(req, "POST");
            CancelOrderResponse resp = CancelOrderResponse.FromJSON(response);
            return resp;
        }
        public CancelAllOrdersResponse CancelAllOrders()
        {
            CancelAllOrdersRequest req = new CancelAllOrdersRequest(Nonce);
            string response = SendRequest(req, "GET");
            return new CancelAllOrdersResponse(response);
        }
        public OrderStatusResponse GetOrderStatus(int order_id)
        {
            OrderStatusRequest req = new OrderStatusRequest(Nonce, order_id);
            string response = SendRequest(req, "POST");
            return OrderStatusResponse.FromJSON(response);
        }
        public ActiveOrdersResponse GetActiveOrders()
        {
            ActiveOrdersRequest req = new ActiveOrdersRequest(Nonce);
            string response = SendRequest(req, "POST");
            return ActiveOrdersResponse.FromJSON(response);
        }
        public ActivePositionsResponse GetActivePositions()
        {
            ActivePositionsRequest req = new ActivePositionsRequest(Nonce);
            string response = SendRequest(req, "POST");
            return ActivePositionsResponse.FromJSON(response);
        }
        public void GetAccountInfo()
        {
            var accountInfo = new BFAccountInfo(accountInfoUrl, Nonce);
            SendRequest(accountInfo, "POST");
        }
        public NewOrderResponse ExecuteBuyOrderBTC(string symbol, decimal amount, decimal price, OrderExchange exchange, OrderType type)
        {
            return ExecuteOrder(symbol, amount, price, exchange, "buy", type);
        }
        public NewOrderResponse ExecuteSellOrderBTC(string symbol,decimal amount, decimal price, OrderExchange exchange, OrderType type)
        {
            return ExecuteOrder(symbol, amount, price, exchange, "sell", type);
        }
        public NewOrderResponse ExecuteOrder(string symbol, decimal amount, decimal price, OrderExchange exchange, string side, OrderType type)
        {
            NewOrderRequest req = new NewOrderRequest(Nonce, symbol, amount, price, exchange, side, type);
            string response = SendRequest(req, "POST");
            NewOrderResponse resp = NewOrderResponse.FromJSON(response);
            return resp;
        }
        private string SendRequest(GenericRequest request, string httpMethod)
        {
            string json = JsonConvert.SerializeObject(request);
            string json64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            byte[] data = Encoding.UTF8.GetBytes(json64);
            byte[] hash = hashMaker.ComputeHash(data);
            string signature = GetHexString(hash);

            HttpWebRequest wr = WebRequest.Create("https://api.bitfinex.com" + request.request) as HttpWebRequest;
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
