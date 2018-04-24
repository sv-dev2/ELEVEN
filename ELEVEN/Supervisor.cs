using ELEVEN.Models;
using ELEVEN.Services;
using ELEVEN.Settings;
using ELEVEN.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ELEVEN
{
    #region Types

    public class Supervisor
    {
        #region Public Members

        public string C_CLASS_NAME = "Supervisor";

        #endregion Public Members

        #region Private Members

        private MDIParentForm frmMain;
        private Gateway gateway;
        private PreciseDatetime preciseDateTime = new PreciseDatetime();
        private string securityKey = "E-LEVEN";
        private TaskPerformer taskPerformer;
        public const string telegramBotToken = "";


        #endregion Private Members

        #region Properties

        #region Public Properties

        ///// <summary>
        ///// Gets the engine.
        ///// </summary>
        ///// <value>
        ///// The engine.
        ///// </value>
        //[XmlIgnore]
        //public Engine Engine
        //{
        //    get;
        //    private set;
        //}

        /// <summary>
        /// Gets the engine.
        /// </summary>
        /// <value>
        /// The engine.
        /// </value>
        [XmlIgnore]
        public Gateway Gateway
        {
            get { return gateway; }
        }

        /// <summary>
        /// Gets or sets the global settings.
        /// </summary>
        /// <value>
        /// The global settings.
        /// </value>
        [XmlIgnore]
        public ElevenSettings GlobalSettings
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the log.
        /// </summary>
        /// <value>
        /// The log.
        /// </value>
        [XmlIgnore]
        public LogManager Log
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the DateTime Advanced
        /// </summary>
        /// <value>DateTime Advanced</value>
        [XmlIgnore]
        public PreciseDatetime PreciseDateTime
        {
            get { return preciseDateTime; }
        }

        /// <summary>
        /// Gets or sets the task performer.
        /// </summary>
        /// <value>
        /// The task performer.
        /// </value>
        [XmlIgnore]
        public TaskPerformer TaskPerformer
        {
            get
            {
                return taskPerformer;
            }
            set
            {
                taskPerformer = value;
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Supervisor"/> class.
        /// </summary>
        /// <param name="fMainParam">The f main parameter.</param>
        public Supervisor(MDIParentForm fMainParam)
        {
            frmMain = fMainParam;
            var fileName = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + @"\Config\ElevenSettings.xml";
            GlobalSettings = ElevenSettings.Load(fileName);

            if (string.IsNullOrEmpty(GlobalSettings.FolderSettings.Logs))
                GlobalSettings.FolderSettings.Logs = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + "Logs";

            //Path Log - Creazione
            if (!Directory.Exists(GlobalSettings.FolderSettings.Logs))
                Directory.CreateDirectory(GlobalSettings.FolderSettings.Logs);

            Log = new LogManager(GlobalSettings.FolderSettings.Logs + Path.DirectorySeparatorChar + "Eleven_" + PreciseDateTime.Now.ToString("yyyyMMdd") + ".log");

            Log.LogEvent("[---------------------------------------------]");
            Log.LogEvent("[E-LEVEN][" + Assembly.GetExecutingAssembly().GetName().Version + "]");

            //Creazione Task
            taskPerformer = new TaskPerformer(this);

            //Gatewqay
            gateway = new Gateway(1, 1);

            InitExchanges();

            //Engine  e = new Engine(
           // Engine = new Engine(frmMain, gateway);

            //InitSecurities();

            System.Threading.Tasks.Task.Factory.StartNew(() => InitSecuritiesDelay());
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Initializes the securities delay.
        /// </summary>
        private void InitSecuritiesDelay()
        {
            Thread.Sleep(2000);
            //Engine.GenerateInstruments();
        }

      

        /// <summary>
        /// Initializes the exchanges.
        /// </summary>
        public void InitExchanges()
        {
            foreach (Exchange e in GlobalSettings.Exchanges.Where(p => p.Enabled).ToList())
            {
                try
                {
                    InitExchange(e);
                }
                catch (Exception ex)
                {
                    Log.LogEvent(C_CLASS_NAME, "[INIT EXCHANGE " + e.Name + "FAILED ! " + ex.Message);
                }
            }
        }

    

      

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Initializes the exchange.
        /// </summary>
        /// <param name="e">The e.</param>
        private void InitExchange(Exchange e)
        {
            Log.LogEvent(C_CLASS_NAME, "[" + e.Name + " GATEWAY STARTING...]");
            try
            {
                //Inizializzazione Gateway
                GatewayParameters gDefault = new GatewayParameters()
                {
                    Ip = e.Ip,
                    Port = e.Port,
                    Url = e.Url
                    //ActivateLog = true,
                    //DontFilterExecutedPrices = true,
                    //DontSubscribeOrders = true,
                    //NumberOfThreadForWebPooling = p.Threads,
                    //StartTime = p.StartTime,
                    //StopTime = p.StopTime,
                    //ClientId = settings.UniqueId,
                    //Ip = p.DataServerIp,
                    //PriceIp = p.SubscriptionServerIp,
                    //PricePort = p.DataServerPort,
                    //Port = p.SubscriptionServerPort,
                    //BaseURL = p.BaseURL,
                };

                gateway.AddGateway(e.Name,
                                   e.GatewayType,
                                   e.GatewayMode,
                                   gDefault,
                                   //frmMain.WebBrowser
                                   null
                                   );

                //if (!providerKeyToInternalKey.ContainsKey(p.Name))
                //    providerKeyToInternalKey.TryAdd(p.Name, new ConcurrentDictionary<string, ProviderKeyEntity>());

                Thread tStartGateway = new Thread(new ParameterizedThreadStart(StartGatewayInternal));
                tStartGateway.Start(e.Name);
            }
            catch (Exception ex)
            {
                Log.LogEvent(C_CLASS_NAME, "[INIT STANDARD PROVIDER FAILED ! " + ex.Message);
            }
        }

        /// <summary>
        /// Starts the gateway internal.
        /// </summary>
        /// <param name="providerParam">The provider parameter.</param>
        private void StartGatewayInternal(object providerParam)
        {
            try
            {
                gateway.StartGateway((string)providerParam);
                //Thread.Sleep(2000);
                Log.LogEvent(C_CLASS_NAME, "[" + (string)providerParam + " GATEWAY STARTED]");
            }
            catch (Exception ex)
            {
                Log.LogEvent(C_CLASS_NAME, "[START GATEWAY INTERNAL " + (string)providerParam + "FAILED ! " + ex.Message);
            }
        }

        #endregion Private Methods
    }

    #endregion Types
}
