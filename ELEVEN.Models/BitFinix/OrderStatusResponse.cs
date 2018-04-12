using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class OrderStatusResponse
    {
        public string id;
        public string symbol;
        public string exchange;
        public string price;
        public string avg_execution_price;
        public string type;
        public string timestamp;
        public string is_live;
        public string is_cancelled;
        public string was_forced;
        public string executed_amount;
        public string remaining_amount;
        public string original_amount;
        public string broker = "bitfinex";
        public string state
        {
            get
            {
                if (is_live.ToLower() == "true")
                {
                    return "Active";
                }
                else if (is_cancelled.ToLower() == "true")
                {
                    return "Cancelled";
                }
                else
                {
                    return "";
                }
            }
        }
        public static OrderStatusResponse FromJSON(string response)
        {
            return JsonConvert.DeserializeObject<OrderStatusResponse>(response);
        }
    }
}
