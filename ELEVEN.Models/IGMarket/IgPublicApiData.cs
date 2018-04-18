using ELEVEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    public class IgPublicApiData
    {
        public class ClientSentimentModel : BaseModel
        {
            private decimal? _clientShort;
            public decimal? ClientShort
            {
                get { ConfirmOnUIThread(); return _clientShort; }
                set
                {
                    ConfirmOnUIThread();    
                    if (_clientShort != value)
                    {
                        _clientShort = value;
                        Notify("ClientShort");
                    }
                }
            }

            private decimal? _clientLong;
            public decimal? ClientLong
            {
                get { ConfirmOnUIThread(); return _clientLong; }
                set
                {
                    ConfirmOnUIThread();
                    if (_clientLong != value)
                    {
                        _clientLong = value;
                        Notify("ClientLong");
                    }
                }
            }

            private string _epic;
            public string Epic
            {
                get { ConfirmOnUIThread(); return _epic; }
                set
                {
                    ConfirmOnUIThread();
                    if ((_epic != value) && (value != null))
                    {
                        _epic = value;
                        Notify("Epic");
                    }
                }
            }
        }

        public class TradeSubscriptionModel : BaseModel
        {
            private string _tradeType;
            public string TradeType
            {
                get { ConfirmOnUIThread(); return _tradeType; }
                set
                {
                    ConfirmOnUIThread();
                    if (_tradeType != value)
                    {
                        _tradeType = value;
                        Notify("TradeType");
                    }
                }
            }

            private string _itemName;
            public string ItemName
            {
                get { ConfirmOnUIThread(); return _itemName; }
                set
                {
                    ConfirmOnUIThread();
                    if (_itemName != value)
                    {
                        _itemName = value;
                        Notify("ItemName");
                    }
                }
            }

            private string _direction;
            public string Direction
            {
                get { ConfirmOnUIThread(); return _direction; }
                set
                {
                    ConfirmOnUIThread();
                    if (_direction != value)
                    {
                        _direction = value;
                        Notify("Direction");
                    }
                }
            }
            private string _limitlevel;
            public string Limitlevel
            {
                get { ConfirmOnUIThread(); return _limitlevel; }
                set
                {
                    ConfirmOnUIThread();
                    if (_limitlevel != value)
                    {
                        _limitlevel = value;
                        Notify("Limitlevel");
                    }
                }
            }
            private string _dealId;
            public string DealId
            {
                get { ConfirmOnUIThread(); return _dealId; }
                set
                {
                    ConfirmOnUIThread();
                    if (_dealId != value)
                    {
                        _dealId = value;
                        Notify("DealId");
                    }
                }
            }
            private string _affectedDealId;
            public string AffectedDealId
            {
                get { ConfirmOnUIThread(); return _affectedDealId; }
                set
                {
                    ConfirmOnUIThread();
                    if (_affectedDealId != value)
                    {
                        _affectedDealId = value;
                        Notify("AffectedDealId");
                    }
                }
            }
            private string _stopLevel;
            public string StopLevel
            {
                get { ConfirmOnUIThread(); return _stopLevel; }
                set
                {
                    ConfirmOnUIThread();
                    if (_stopLevel != value)
                    {
                        _stopLevel = value;
                        Notify("StopLevel");
                    }
                }
            }

            private string _expiry;
            public string Expiry
            {
                get { ConfirmOnUIThread(); return _expiry; }
                set
                {
                    ConfirmOnUIThread();
                    if (_expiry != value)
                    {
                        _expiry = value;
                        Notify("Expiry");
                    }
                }
            }
            private string _size;
            public string Size
            {
                get { ConfirmOnUIThread(); return _size; }
                set
                {
                    ConfirmOnUIThread();
                    if (_size != value)
                    {
                        _size = value;
                        Notify("Size");
                    }
                }
            }
            private string _status;
            public string Status
            {
                get { ConfirmOnUIThread(); return _status; }
                set
                {
                    ConfirmOnUIThread();
                    if (_status != value)
                    {
                        _status = value;
                        Notify("Status");
                    }
                }
            }
            private string _epic;
            public string Epic
            {
                get { ConfirmOnUIThread(); return _epic; }
                set
                {
                    ConfirmOnUIThread();
                    if (_epic != value)
                    {
                        _epic = value;
                        Notify("Epic");
                    }
                }
            }
            private string _level;
            public string Level
            {
                get { ConfirmOnUIThread(); return _level; }
                set
                {
                    ConfirmOnUIThread();
                    if (_level != value)
                    {
                        _level = value;
                        Notify("Level");
                    }
                }
            }
            private bool? _guaranteedStop;
            public bool? GuaranteedStop
            {
                get { ConfirmOnUIThread(); return _guaranteedStop; }
                set
                {
                    ConfirmOnUIThread();
                    if (_guaranteedStop != value)
                    {
                        _guaranteedStop = value;
                        Notify("GuaranteedStop");
                    }
                }
            }
            private string _dealReference;
            public string DealReference
            {
                get { ConfirmOnUIThread(); return _dealReference; }
                set
                {
                    ConfirmOnUIThread();
                    if (_dealReference != value)
                    {
                        _dealReference = value;
                        Notify("DealReference");
                    }
                }
            }
            private string _dealStatus;
            public string DealStatus
            {
                get { ConfirmOnUIThread(); return _dealStatus; }
                set
                {
                    ConfirmOnUIThread();
                    if (_dealStatus != value)
                    {
                        _dealStatus = value;
                        Notify("DealStatus");
                    }
                }
            }

        }

        public class AffectedDealModel : BaseModel
        {
            private string _affectedDealStatus;
            public string AffectedDealStatus
            {
                get { ConfirmOnUIThread(); return _affectedDealStatus; }
                set
                {
                    ConfirmOnUIThread();
                    if (_affectedDealStatus != value)
                    {
                        _affectedDealStatus = value;
                        Notify("AffectedDealStatus");
                    }
                }
            }

            private string _affectedDealId;
            public string AffectedDealId
            {
                get { ConfirmOnUIThread(); return _affectedDealId; }
                set
                {
                    ConfirmOnUIThread();
                    if (_affectedDealId != value)
                    {
                        _affectedDealId = value;
                        Notify("AffectedDealId");
                    }
                }
            }
        }


        public class AccountModel : BaseModel
        {
            private string _accountId;
            public string AccountId
            {
                get { ConfirmOnUIThread(); return _accountId; }
                set
                {
                    ConfirmOnUIThread();
                    if (_accountId != value)
                    {
                        _accountId = value;
                        Notify("AccountId");
                    }
                }
            }

            private string _accountType;
            public string AccountType
            {
                get { ConfirmOnUIThread(); return _accountType; }
                set
                {
                    ConfirmOnUIThread();
                    if (_accountType != value)
                    {
                        _accountType = value;
                        Notify("AccountType");
                    }
                }
            }

            private string _accountName;
            public string AccountName
            {
                get { ConfirmOnUIThread(); return _accountName; }
                set
                {
                    ConfirmOnUIThread();
                    if (_accountName != value)
                    {
                        _accountName = value;
                        Notify("AccountName");
                    }
                }
            }
            private string _clientId;
            public string ClientId
            {
                get { ConfirmOnUIThread(); return _clientId; }
                set
                {
                    ConfirmOnUIThread();
                    if (_clientId != value)
                    {
                        _clientId = value;
                        Notify("ClientId");
                    }
                }
            }

            private string _userName;
            public string UserName
            {
                get { ConfirmOnUIThread(); return _userName; }
                set
                {
                    ConfirmOnUIThread();
                    if (_userName != value)
                    {
                        _userName = value;
                        Notify("UserName");
                    }
                }
            }

            private string _lsEndpoint;
            public string LsEndpoint
            {
                get { ConfirmOnUIThread(); return _lsEndpoint; }
                set
                {
                    ConfirmOnUIThread();
                    if (_lsEndpoint != value)
                    {
                        _lsEndpoint = value;
                        Notify("LsEndpoint");
                    }
                }
            }

            private string _password;
            public string Password
            {
                get { ConfirmOnUIThread(); return _password; }
                set
                {
                    ConfirmOnUIThread();
                    if (_password != value)
                    {
                        _password = value;
                        Notify("Password");
                    }
                }
            }

            private string _apiKey;
            public string ApiKey
            {
                get { ConfirmOnUIThread(); return _apiKey; }
                set
                {
                    ConfirmOnUIThread();
                    if (_apiKey != value)
                    {
                        _apiKey = value;
                        Notify("ApiKey");
                    }
                }
            }


            private decimal? _profitLoss;
            public decimal? ProfitLoss
            {
                get { ConfirmOnUIThread(); return _profitLoss; }
                set
                {
                    ConfirmOnUIThread();
                    if (_profitLoss != value)
                    {
                        _profitLoss = value;
                        Notify("ProfitLoss");
                    }
                }
            }

            private decimal? _deposit;
            public decimal? Deposit
            {
                get { ConfirmOnUIThread(); return _deposit; }
                set
                {
                    ConfirmOnUIThread();
                    if (_deposit != value)
                    {
                        _deposit = value;
                        Notify("Deposit");
                    }
                }
            }

            private decimal? _usedMargin;
            public decimal? UsedMargin
            {
                get { ConfirmOnUIThread(); return _usedMargin; }
                set
                {
                    ConfirmOnUIThread();
                    if (_usedMargin != value)
                    {
                        _usedMargin = value;
                        Notify("UsedMargin");
                    }
                }
            }

            private decimal? _amountDue;
            public decimal? AmountDue
            {
                get { ConfirmOnUIThread(); return _amountDue; }
                set
                {
                    ConfirmOnUIThread();
                    if (_amountDue != value)
                    {
                        _amountDue = value;
                        Notify("AmountDue");
                    }
                }
            }

            private decimal? _availableCash;
            public decimal? AvailableCash
            {
                get { ConfirmOnUIThread(); return _availableCash; }
                set
                {
                    ConfirmOnUIThread();
                    if (_availableCash != value)
                    {
                        _availableCash = value;
                        Notify("AvailableCash");
                    }
                }
            }

            private decimal? _balance;
            public decimal? Balance
            {
                get { ConfirmOnUIThread(); return _balance; }
                set
                {
                    ConfirmOnUIThread();
                    if (_balance != value)
                    {
                        _balance = value;
                        Notify("Balance");
                    }
                }
            }

        }

        public class BrowseModel : BaseModel
        {
            private InstrumentModel _model;
            public InstrumentModel Model
            {
                get { ConfirmOnUIThread(); return _model; }
                set
                {
                    ConfirmOnUIThread();
                    if ((_model != value) && (value != null))
                    {
                        _model = value;
                        Notify("Model");
                    }
                }
            }
        }

        public class WatchlistModel : BaseModel
        {
            private string _watchlistName;
            public string WatchlistName
            {
                get { ConfirmOnUIThread(); return _watchlistName; }
                set
                {
                    ConfirmOnUIThread();
                    if ((_watchlistName != value) && (value != null))
                    {
                        _watchlistName = value;
                        Notify("WatchlistName");
                    }
                }
            }

            private string _watchlistId;
            public string WatchlistId
            {
                get { ConfirmOnUIThread(); return _watchlistId; }
                set
                {
                    ConfirmOnUIThread();
                    if ((_watchlistId != value) && (value != null))
                    {
                        _watchlistId = value;
                        Notify("WatchlistId");
                    }
                }
            }

            private bool _editable;
            public bool Editable
            {
                get { ConfirmOnUIThread(); return _editable; }
                set
                {
                    ConfirmOnUIThread();
                    if (_editable != value)
                    {
                        _editable = value;
                        Notify("Editable");
                    }
                }
            }

            private bool _deletable;
            public bool Deletable
            {
                get { ConfirmOnUIThread(); return _deletable; }
                set
                {
                    ConfirmOnUIThread();
                    if (_deletable != value)
                    {
                        _deletable = value;
                        Notify("Deletable");
                    }
                }
            }

        }

        public class PositionModel : BaseModel
        {
            private string _createdDate;
            public string CreatedDate
            {
                get { ConfirmOnUIThread(); return _createdDate; }
                set
                {
                    ConfirmOnUIThread();
                    if ((_createdDate != value) && (value != null))
                    {
                        _createdDate = value;
                        Notify("CreatedDate");
                    }
                }
            }

            private decimal? _dealSize;
            public decimal? DealSize
            {
                get { ConfirmOnUIThread(); return _dealSize; }
                set
                {
                    ConfirmOnUIThread();
                    if (_dealSize != value)
                    {
                        _dealSize = value;
                        Notify("DealSize");
                    }
                }
            }

            private string _direction;
            public string Direction
            {
                get { ConfirmOnUIThread(); return _direction; }
                set
                {
                    ConfirmOnUIThread();
                    if (_direction != value)
                    {
                        _direction = value;
                        Notify("Direction");
                    }
                }
            }



            private decimal? _openLevel;
            public decimal? OpenLevel
            {
                get { ConfirmOnUIThread(); return _openLevel; }
                set
                {
                    ConfirmOnUIThread();
                    if (_openLevel != value)
                    {
                        _openLevel = value;
                        Notify("OpenLevel");
                    }
                }
            }

            private decimal? _stopLevel;
            public decimal? StopLevel
            {
                get { ConfirmOnUIThread(); return _stopLevel; }
                set
                {
                    ConfirmOnUIThread();
                    if (_stopLevel != value)
                    {
                        _stopLevel = value;
                        Notify("StopLevel");
                    }
                }
            }

            private decimal? _limitLevel;
            public decimal? LimitLevel
            {
                get { ConfirmOnUIThread(); return _limitLevel; }
                set
                {
                    ConfirmOnUIThread();
                    if (_limitLevel != value)
                    {
                        _limitLevel = value;
                        Notify("LimitLevel");
                    }
                }
            }

            private InstrumentModel _model;
            public InstrumentModel Model
            {
                get { ConfirmOnUIThread(); return _model; }
                set
                {
                    ConfirmOnUIThread();
                    if ((_model != value) && (value != null))
                    {
                        _model = value;
                        Notify("Model");
                    }
                }
            }
        }

        public class OrderModel : BaseModel
        {
            private string _dealId;
            public string DealId
            {
                get { ConfirmOnUIThread(); return _dealId; }
                set
                {
                    ConfirmOnUIThread();
                    if ((_dealId != value) && (value != null))
                    {
                        _dealId = value;
                        Notify("DealId");
                    }
                }
            }

            private decimal? _orderSize;
            public decimal? OrderSize
            {
                get { ConfirmOnUIThread(); return _orderSize; }
                set
                {
                    ConfirmOnUIThread();
                    if (_orderSize != value)
                    {
                        _orderSize = value;
                        Notify("OrderSize");
                    }
                }
            }

            private string _direction;
            public string Direction
            {
                get { ConfirmOnUIThread(); return _direction; }
                set
                {
                    ConfirmOnUIThread();
                    if (_direction != value)
                    {
                        _direction = value;
                        Notify("Direction");
                    }
                }
            }


            private string _creationDate;
            public string CreationDate
            {
                get { ConfirmOnUIThread(); return _creationDate; }
                set
                {
                    ConfirmOnUIThread();
                    if ((_creationDate != value) && (value != null))
                    {
                        _creationDate = value;
                        Notify("CreationDate");
                    }
                }
            }

            private InstrumentModel _model;
            public InstrumentModel Model
            {
                get { ConfirmOnUIThread(); return _model; }
                set
                {
                    ConfirmOnUIThread();
                    if ((_model != value) && (value != null))
                    {
                        _model = value;
                        Notify("Model");
                    }
                }
            }
        }

        public class WatchlistMarketModel : BaseModel
        {
            private string _updateTime;
            public string UpdateTime
            {
                get { ConfirmOnUIThread(); return _updateTime; }
                set
                {
                    ConfirmOnUIThread();
                    if ((_updateTime != value) && (value != null))
                    {
                        _updateTime = value;
                        Notify("UpdateTime");
                    }
                }
            }

            private InstrumentModel _model;
            public InstrumentModel Model
            {
                get { ConfirmOnUIThread(); return _model; }
                set
                {
                    ConfirmOnUIThread();
                    if ((_model != value) && (value != null))
                    {
                        _model = value;
                        Notify("Model");
                    }
                }
            }

        }

        public class ChartModel : BaseModel
        {
            private string _chartEpic;
            public string ChartEpic
            {
                get { ConfirmOnUIThread(); return _chartEpic; }
                set
                {
                    ConfirmOnUIThread();
                    if (_chartEpic != value)
                    {
                        _chartEpic = value;
                        Notify("ChartEpic");
                    }
                }
            }

            private ChartHlocModel _offer;
            public ChartHlocModel Offer
            {
                get { ConfirmOnUIThread(); return _offer; }
                set
                {
                    ConfirmOnUIThread();
                    if (_offer != value)
                    {
                        _offer = value;
                        Notify("Offer");
                    }
                }
            }

            private ChartHlocModel _bid;
            public ChartHlocModel Bid
            {
                get { ConfirmOnUIThread(); return _bid; }
                set
                {
                    ConfirmOnUIThread();
                    if (_bid != value)
                    {
                        _bid = value;
                        Notify("Bid");
                    }
                }
            }

            private ChartHlocModel _lastTradedPrice;
            public ChartHlocModel LastTradedPrice
            {
                get { ConfirmOnUIThread(); return _lastTradedPrice; }
                set
                {
                    ConfirmOnUIThread();
                    if (_lastTradedPrice != value)
                    {
                        _lastTradedPrice = value;
                        Notify("LastTradedPrice");
                    }
                }
            }

            private bool? _endOfConsolidation;
            public bool? EndOfConsolidation
            {
                get { ConfirmOnUIThread(); return _endOfConsolidation; }
                set
                {
                    ConfirmOnUIThread();
                    if (_endOfConsolidation != value)
                    {
                        _endOfConsolidation = value;
                        Notify("EndOfConsolidation");
                    }
                }
            }

            private int? _tickCount;
            public int? TickCount
            {
                get { ConfirmOnUIThread(); return _tickCount; }
                set
                {
                    ConfirmOnUIThread();
                    if (_tickCount != value)
                    {
                        _tickCount = value;
                        Notify("TickCount");
                    }
                }
            }

            /// <summary>
            /// Last traded volume
            /// </summary>
            /// 
            private decimal? _lastTradedVolume;
            public decimal? LastTradedVolume
            {
                get { ConfirmOnUIThread(); return _lastTradedVolume; }
                set
                {
                    ConfirmOnUIThread();
                    if (_lastTradedVolume != value)
                    {
                        _lastTradedVolume = value;
                        Notify("LastTradedVolume");
                    }
                }
            }

            /// <summary>
            /// Incremental trading volume
            /// </summary>
            private decimal? _incrimentalTradingVolume;
            public decimal? IncrimetalTradingVolume
            {
                get { ConfirmOnUIThread(); return _incrimentalTradingVolume; }
                set
                {
                    ConfirmOnUIThread();
                    if (_incrimentalTradingVolume != value)
                    {
                        _incrimentalTradingVolume = value;
                        Notify("IncrimentalTradingVolume");
                    }
                }
            }

            /// <summary>
            /// Update time (as milliseconds from the Epoch)
            /// </summary>
            private DateTime? _updateTime { get; set; }
            public DateTime? UpdateTime
            {
                get { ConfirmOnUIThread(); return _updateTime; }
                set
                {
                    ConfirmOnUIThread();
                    if (_updateTime != value)
                    {
                        _updateTime = value;
                        Notify("UpdateTime");
                    }
                }
            }

            /// <summary>
            /// Mid open price for the day
            /// </summary>
            private decimal? _dayMidOpenPrice;
            public decimal? DayMidOpenPrice
            {
                get { ConfirmOnUIThread(); return _dayMidOpenPrice; }
                set
                {
                    ConfirmOnUIThread();
                    if (_dayMidOpenPrice != value)
                    {
                        _dayMidOpenPrice = value;
                        Notify("DayMidOpenPrice");
                    }
                }
            }

            /// <summary>
            /// Change from open price to current (MID price)
            /// </summary>
            private decimal? _dayChange;
            public decimal? DayChange
            {
                get { ConfirmOnUIThread(); return _dayChange; }
                set
                {
                    ConfirmOnUIThread();
                    if (_dayChange != value)
                    {
                        _dayChange = value;
                        Notify("DayChange");
                    }
                }

            }

            /// <summary>
            /// Daily percentage change (MID price)
            /// </summary>
            private decimal? _dayChangePct;
            public decimal? DayChangePct
            {
                get { ConfirmOnUIThread(); return _dayChangePct; }
                set
                {
                    ConfirmOnUIThread();
                    if (_dayChangePct != value)
                    {
                        _dayChangePct = value;
                        Notify("DayChangePct");
                    }
                }
            }

            private decimal? _dayHigh;
            public decimal? DayHigh
            {
                get { ConfirmOnUIThread(); return _dayHigh; }
                set
                {
                    ConfirmOnUIThread();
                    if (_dayHigh != value)
                    {
                        _dayHigh = value;
                        Notify("DayHigh");
                    }
                }
            }

            /// <summary>
            /// Daily low price (MID)
            /// </summary>
            private decimal? _dayLow;
            public decimal? DayLow
            {
                get { ConfirmOnUIThread(); return _dayLow; }
                set
                {
                    ConfirmOnUIThread();
                    if (_dayLow != value)
                    {
                        _dayLow = value;
                        Notify("DayLow");
                    }
                }

            }
        }



        public class ChartHlocModel : BaseModel
        {
            private decimal? _high;
            public decimal? High
            {
                get { ConfirmOnUIThread(); return _high; }
                set
                {
                    ConfirmOnUIThread();
                    if (_high != value)
                    {
                        _high = value;
                        Notify("High");
                    }
                }
            }

            private decimal? _low;
            public decimal? Low
            {
                get { ConfirmOnUIThread(); return _low; }
                set
                {
                    ConfirmOnUIThread();
                    if (_low != value)
                    {
                        _low = value;
                        Notify("Low");
                    }
                }
            }

            private decimal? _open;
            public decimal? Open
            {
                get { ConfirmOnUIThread(); return _open; }
                set
                {
                    ConfirmOnUIThread();
                    if (_open != value)
                    {
                        _open = value;
                        Notify("Open");
                    }
                }
            }

            private decimal? _close;
            public decimal? Close
            {
                get { ConfirmOnUIThread(); return _close; }
                set
                {
                    ConfirmOnUIThread();
                    if (_close != value)
                    {
                        _close = value;
                        Notify("Close");
                    }
                }
            }
        }


        public class InstrumentModel : BaseModel
        {
            private ClientSentimentModel _clientSentiment;
            public ClientSentimentModel ClientSentiment
            {
                get { ConfirmOnUIThread(); return _clientSentiment; }
                set
                {
                    ConfirmOnUIThread();
                    if (_clientSentiment != value)
                    {
                        _clientSentiment = value;
                        Notify("ClientSentiment");
                    }
                }
            }

            private string _marketStatus;
            public string MarketStatus
            {
                get { ConfirmOnUIThread(); return _marketStatus; }
                set
                {
                    ConfirmOnUIThread();
                    if (_marketStatus != value)
                    {
                        _marketStatus = value;
                        Notify("MarketStatus");
                    }
                }
            }

            private string _lsItemName;
            public string LsItemName
            {
                get { ConfirmOnUIThread(); return _lsItemName; }
                set
                {
                    ConfirmOnUIThread();
                    if ((_lsItemName != value) && (value != null))
                    {
                        _lsItemName = value;
                        Notify("LsItemName");
                    }
                }
            }


            private string _epic;
            public string Epic
            {
                get { ConfirmOnUIThread(); return _epic; }
                set
                {
                    ConfirmOnUIThread();
                    if ((_epic != value) && (value != null))
                    {
                        _epic = value;
                        Notify("Epic");
                    }
                }
            }

            private decimal? _bid;
            public decimal? Bid
            {
                get { ConfirmOnUIThread(); return _bid; }
                set
                {
                    ConfirmOnUIThread();
                    if (_bid != value)
                    {
                        _bid = value;
                        Notify("Bid");
                    }
                }
            }

            private decimal? _offer;
            public decimal? Offer
            {
                get { ConfirmOnUIThread(); return _offer; }
                set
                {
                    ConfirmOnUIThread();
                    if (_offer != value)
                    {
                        _offer = value;
                        Notify("Offer");
                    }
                }
            }

            private decimal? _open;
            public decimal? Open
            {
                get { ConfirmOnUIThread(); return _open; }
                set
                {
                    ConfirmOnUIThread();
                    if (_open != value)
                    {
                        _open = value;
                        Notify("Open");
                    }
                }
            }

            private string _updateTime;

            public string UpdateTime
            {
                get { ConfirmOnUIThread(); return _updateTime; }
                set
                {
                    ConfirmOnUIThread();
                    if (value != _updateTime)
                    {
                        _updateTime = value;
                        Notify("UpdateTime");
                    }
                }
            }

            private string _instrumentName;
            public string InstrumentName
            {
                get
                {
                    ConfirmOnUIThread();
                    return _instrumentName;
                }
                set
                {
                    ConfirmOnUIThread();
                    if (_instrumentName != value)
                    {
                        _instrumentName = value;
                        Notify("InstrumentName");
                    }
                }
            }


            private decimal? _netChange;
            public decimal? NetChange
            {
                get { ConfirmOnUIThread(); return _netChange; }
                set
                {
                    ConfirmOnUIThread();
                    if (_netChange != value)
                    {
                        _netChange = value;
                        Notify("NetChange");
                    }
                }
            }

            private decimal? _pctChange;
            public decimal? PctChange
            {
                get { ConfirmOnUIThread(); return _pctChange; }
                set
                {
                    ConfirmOnUIThread();
                    if (_pctChange != value)
                    {
                        _pctChange = value;
                        Notify("PctChange");
                    }
                }
            }

            private decimal? _high;
            public decimal? High
            {
                get { ConfirmOnUIThread(); return _high; }
                set
                {
                    ConfirmOnUIThread();
                    if (_high != value)
                    {
                        _high = value;
                        Notify("High");
                    }
                }
            }

            private decimal? _low;
            public decimal? Low
            {
                get { ConfirmOnUIThread(); return _low; }
                set
                {
                    ConfirmOnUIThread();
                    if (_low != value)
                    {
                        _low = value;
                        Notify("Low");
                    }
                }
            }


            private bool? _streamingPricesAvailable;
            public bool? StreamingPricesAvailable
            {
                get { ConfirmOnUIThread(); return _streamingPricesAvailable; }
                set
                {
                    ConfirmOnUIThread();
                    if (_streamingPricesAvailable != value)
                    {
                        _streamingPricesAvailable = value;
                        Notify("StreamingPricesAvailable");
                    }
                }
            }
        }
    }
}
