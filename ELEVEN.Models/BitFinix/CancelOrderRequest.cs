using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class CancelOrderRequest : GenericRequest
    {
        public int order_id;
        public CancelOrderRequest(string nonce, int order_id)
        {
            this.nonce = nonce;
            this.order_id = order_id;
            this.request = "/v1/order/cancel";
        }
    }
}
