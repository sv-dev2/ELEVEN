using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class BFAccountInfo:GenericRequest
    {
             
        public BFAccountInfo(string url, string nonce)
        {
            this.nonce = nonce;
            this.request = url;
        }
    }
}
