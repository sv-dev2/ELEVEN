using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Model
{
    public class clsBroker:BaseModel
    {
        private int _id;
        private string _brokerCode { get; set; }
        private string _brokerDescription { get; set; }
        public int Id { get { ConfirmOnUIThread(); return _id; } set { ConfirmOnUIThread(); if (_id != value) { _id = value; Notify("Id"); } } }
        public string BrokerCode { get { ConfirmOnUIThread(); return _brokerCode; } set { ConfirmOnUIThread(); if (_brokerCode != value) { _brokerCode = value; Notify("BrokerCode"); } } }
        public string BrokerDescription { get { ConfirmOnUIThread(); return _brokerDescription; } set { ConfirmOnUIThread(); if (_brokerDescription != value) { _brokerDescription = value; Notify("BrokerDescription"); } } }
    }

    public class clsInstrument : BaseModel
    {
        private int _id;
        private string _instrumentCode;
        private string _instrumentDescription;
        public int Id { get { ConfirmOnUIThread(); return _id; } set { ConfirmOnUIThread(); if (_id != value) { _id = value; Notify("Id"); } } }
        public string InstrumentCode { get { ConfirmOnUIThread(); return _instrumentCode; } set { ConfirmOnUIThread(); if (_instrumentCode != value) { _instrumentCode = value; Notify("InstrumentCode"); } } }
        public string InstrumentDescription { get { ConfirmOnUIThread(); return _instrumentDescription; } set { ConfirmOnUIThread(); if (_instrumentDescription != value) { _instrumentDescription = value; Notify("InstrumentDescription"); } } }
    }

    public class clsBrokerInstrumentMapping : BaseModel
    {
        private int _id;
        private int _instrumentId;
        private int _brokerId;
        private string _brokerInstrumentCode;
        private bool _feedPrices;
        private bool _feedTrades;
        public int Id { get { ConfirmOnUIThread(); return _id; } set { ConfirmOnUIThread(); if (_id != value) { _id = value; Notify("Id"); } } }
        public int InstrumentId { get { ConfirmOnUIThread(); return _instrumentId; } set { ConfirmOnUIThread(); if (_instrumentId != value) { _instrumentId = value; Notify("InstrumentId"); } } }
        public int BrokerId { get { ConfirmOnUIThread(); return _brokerId; } set { ConfirmOnUIThread(); if (_brokerId != value) { _brokerId = value; Notify("BrokerId"); } } }
        public string BrokerInstrumentCode { get { ConfirmOnUIThread(); return _brokerInstrumentCode; } set { ConfirmOnUIThread(); if (_brokerInstrumentCode != value) { _brokerInstrumentCode = value; Notify("BrokerInstrumentCode"); } } }
        public bool FeedPrices { get { ConfirmOnUIThread(); return _feedPrices; } set { ConfirmOnUIThread(); if (_feedPrices != value) { _feedPrices = value; Notify("FeedPrices"); } } }
        public bool FeedTrades { get { ConfirmOnUIThread(); return _feedTrades; } set { ConfirmOnUIThread(); if (_feedTrades != value) { _feedTrades = value; Notify("FeedTrades"); } } }
    }
}
