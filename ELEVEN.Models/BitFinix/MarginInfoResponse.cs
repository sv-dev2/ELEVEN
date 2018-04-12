using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class MarginLimit
    {
        public string on_pair { get; set; }
        public string initial_margin { get; set; }
        public string margin_requirement { get; set; }
        public string tradable_balance { get; set; }
    }

    public class MarginInfoItem
    {
        public string margin_balance { get; set; }
        public string tradable_balance { get; set; }
        public string unrealized_pl { get; set; }
        public string unrealized_swap { get; set; }
        public string net_value { get; set; }
        public string required_margin { get; set; }
        public string leverage { get; set; }
        public string margin_requirement { get; set; }
        public List<MarginLimit> margin_limits { get; set; }
        public string message { get; set; }
    }
    public class MarginInfoResponse
    {
        public List<MarginInfoItem> marginInfo;
        public static MarginInfoResponse FromJSON(string response)
        {

            List<MarginInfoItem> items = JsonConvert.DeserializeObject<List<MarginInfoItem>>(response);
            return new MarginInfoResponse(items);
        }
        private MarginInfoResponse(List<MarginInfoItem> marginInfo)
        {
            this.marginInfo = marginInfo;
        }
    }
}
