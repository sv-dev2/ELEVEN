using System;
using System.Collections.Generic;

using System.Text;

namespace ELEVEN.Models
{
    public class CancelAllOrdersResponse
    {
        public string message;
        public CancelAllOrdersResponse(string message)
        {
            this.message = message;
        }
    }
}
