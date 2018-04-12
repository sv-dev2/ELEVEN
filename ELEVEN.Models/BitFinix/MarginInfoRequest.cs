using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class MarginInfoRequest : GenericRequest
    {

        public MarginInfoRequest(string nonce)
        {
            this.nonce = nonce;
            this.request = "/v1/margin_infos";
        }
    }
}
