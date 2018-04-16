using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class CancelOrderResponse : OrderStatusResponse
    {
        public static new CancelOrderResponse FromJSON(string response)
        {
            return JsonConvert.DeserializeObject<CancelOrderResponse>(response);
        }
    }
}
