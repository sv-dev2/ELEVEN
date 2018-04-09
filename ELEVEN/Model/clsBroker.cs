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
}
