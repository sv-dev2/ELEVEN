using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class BalancesRequest : GenericRequest
    {
        public BalancesRequest(string nonce)
        {
            this.nonce = nonce;
            this.request = "/v1/balances";
        }
    }
}
