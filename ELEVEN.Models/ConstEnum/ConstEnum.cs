using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    #region Types

    public class ConstEnum
    {
        /// <summary>
        /// GatewayMode
        /// </summary>
        public enum GatewayMode
        {
            MarketData,
            Order,
            Both,
        }

        /// <summary>
        /// GatewayType
        /// </summary>
        public enum GatewayType
        {
            MT4Lib,
            BitFinex,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum YesNo
        {
            [Description("All")]
            ALL,
            [Description("Yes")]
            Y,
            [Description("No")]
            N
        }
        /// <summary>
        /// 
        /// </summary>
        public enum Timeframe
        {
            RT = 0,
            M1 = 1,
            M5 = 5,
            M15 = 15,
            M30 = 30,
            H1 = 60,
            H4 = 240,
            D1 = 1440,
        }

        public enum Sign
        {
            [Description("Buy")]
            B,
            [Description("Sell")]
            S,
            [Description("Bubble Buy")]
            BB,
            [Description("Possible Buy")]
            PB,
            [Description("Bubble Sell")]
            BS,
            [Description("Invalid")]
            ND,

        }

        public enum HeikenAshiState
        {
            [Description("Idle")]
            IDLE,
            [Description("Pattern Long")]
            PATTERN_LONG,
            [Description("Long")]
            LONG,
            [Description("Pattern Short")]
            PATTERN_SHORT,
            [Description("Short")]
            SHORT,
        }

        public enum UpDown
        {
            Up,
            Down,
        }
    }

    #endregion Types
}
