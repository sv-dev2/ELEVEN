using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Model
{
    public class clsBrokerInstrumentDetail
    {
        public int Id { get; set; }
        public int BrokerId { get; set; }
        public int InstrumentId { get; set; }
        public string BrokerCode { get; set; }
        public string InstrumentCode { get; set; }
        public string BrokerDescription { get; set; }
        public string InstrumentDescription { get; set; }
        public string BrokerInstrumentCode { get; set; }
    }
}
