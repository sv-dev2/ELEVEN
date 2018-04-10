using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class NewOrderResponse : OrderStatusResponse
    {
        public string order_id;

        public static NewOrderResponse FromJSON(string response)
        {
            NewOrderResponse resp = JsonConvert.DeserializeObject<NewOrderResponse>(response);
            return resp;
        }
    }
}
