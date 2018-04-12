using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class ClosePositionRequest : GenericRequest
    {
        public string position_id;
        public ClosePositionRequest(string nonce, string position_id)
        {
            this.nonce = nonce;
            this.request = "/v1/positions/close";
            this.position_id = position_id;
        }
    }
}
