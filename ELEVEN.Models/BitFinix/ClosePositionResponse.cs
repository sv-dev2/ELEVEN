using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class ClosePositionItem
    {
        public string message { get; set; }
        public Order order { get; set; }
        public Position position { get; set; }
    }
    public class Order
    {
    }
    public class Position
    {
    }
    public class ClosePositionResponse
    {      

        public ClosePositionItem closePositions;
        public static ClosePositionResponse FromJSON(string response)
        {

            ClosePositionItem items = JsonConvert.DeserializeObject<ClosePositionItem>(response);
            return new ClosePositionResponse(items);
        }
        private ClosePositionResponse(ClosePositionItem closePositions)
        {
            this.closePositions = closePositions;
        }
    }
}
