using System;
using System.Collections.Generic;

using System.Text;

namespace ELEVEN.Models
{
    public class ActiveOrdersRequest:GenericRequest
    {
        public ActiveOrdersRequest(string nonce)
        {
            this.nonce = nonce;
            this.request = "/v1/orders";
        }
    }
}
