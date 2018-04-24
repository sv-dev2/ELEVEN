using ELEVEN.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Services
{
    public class Gateway
    {
        private const string C_CLASS_NAME = "Gateway";
        private const int DEFAULT_MAX_MARKETDATA_QUEUES = 80;
        private const int DEFAULT_MAX_ORDERS_QUEUES = 50;
        private LogManager log;
        public Gateway(int securityToHandle, int ordersToHandle)
        {

            InitGateway();
        }


        /// <summary>
        /// Initializes the gateway.
        /// </summary>
        private void InitGateway()
        {
            //var logPath = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + "Logs" + Path.DirectorySeparatorChar + "Gateway_" + (!string.IsNullOrEmpty(uniqueId) ? uniqueId + "_" : string.Empty) + System.DateTime.Now.ToString("yyyyMMdd") + ".log";
            var logPath = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + "Logs" + Path.DirectorySeparatorChar + "Gateway_" + System.DateTime.Now.ToString("yyyyMMdd") + ".log";
            log = new LogManager(logPath);



            log.LogEvent(C_CLASS_NAME, "-----------GATEWAY FACTORY BUILT-----------");
        }


        /// <summary>
        /// Starts the gateway.
        /// </summary>
        /// <param name="gatewayName">Name of the gateway.</param>
        public void StartGateway(string gatewayName)
        {
            log.LogEvent(C_CLASS_NAME, "Init Gateway --> " + gatewayName);

            //if (priceGateways.ContainsKey(gatewayName))
            //{
            //    log.LogEvent(C_CLASS_NAME, "PriceGateway --> " + gatewayName + " starting ....");
            //    ((IToggleGateway)priceGateways[gatewayName]).StartGateway();
            //    log.LogEvent(C_CLASS_NAME, "PriceGateway --> " + gatewayName + " started !");
            //}

            //if (tradeGateways.ContainsKey(gatewayName))
            //{
            //    log.LogEvent(C_CLASS_NAME, "TradeGateway --> " + gatewayName + " starting ....");
            //    ((IToggleGateway)tradeGateways[gatewayName]).StartGateway();
            //    log.LogEvent(C_CLASS_NAME, "TradeGateway --> " + gatewayName + " started !");
            //}
        }


        /// <summary>
        /// Adds the gateway.
        /// </summary>
        /// <param name="gatewayName">Name of the gateway.</param>
        /// <param name="gatewayType">Type of the gateway.</param>
        /// <param name="gatewayMode">The gateway mode.</param>
        /// <param name="gatewayParam">The gateway parameter.</param>
        /// <param name="objectParam">The object parameter.</param>
        public void AddGateway(string gatewayName, ConstEnum.GatewayType gatewayType, ConstEnum.GatewayMode gatewayMode, GatewayParameters gatewayParam, Object objectParam)
        {
            log.LogEvent(C_CLASS_NAME, "Adding gateway " + gatewayName + " " + gatewayType + " " + gatewayMode + " " + gatewayParam);

            IToggleGateway newGateway = null;

            //MT4 Gateway
            if (gatewayType == ConstEnum.GatewayType.MT4Lib)
            {
                newGateway = new MT4API(this, gatewayParam)
                {
                    Name = gatewayName,
                    GatewayType = gatewayType
                };

                //gateways.TryAdd(gatewayName, newGateway);
                //priceGateways.TryAdd(gatewayName, (IPriceGateway)newGateway);
            }
            //BitFinex
            if (gatewayType == ConstEnum.GatewayType.BitFinex)
            {
                //newGateway = new BitFinexGateway(this, gatewayParam)
                //{
                //    Name = gatewayName,
                //    GatewayType = gatewayType
                //};

                //gateways.TryAdd(gatewayName, newGateway);
                //priceGateways.TryAdd(gatewayName, (IPriceGateway)newGateway);
            }

        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        public LogManager Log
        {
            get { return log; }
        }
    }
}
