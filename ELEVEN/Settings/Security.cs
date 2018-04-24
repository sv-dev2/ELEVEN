using ELEVEN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ELEVEN.Settings
{
    #region Types

    public class Security
    {
        #region Properties

        #region Public Properties

        /// <summary>
        /// Gets or sets the warning mode.
        /// </summary>
        /// <value>
        /// The warning mode.
        /// </value>
        [XmlAttributeAttribute("GroupName")]
        public string GroupName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the warning mode.
        /// </summary>
        /// <value>
        /// The warning mode.
        /// </value>
        [XmlAttributeAttribute("ExchangeCode")]
        public string ExchangeCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Provider"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        [XmlAttributeAttribute("Enabled")]
        public bool Enabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the warning mode.
        /// </summary>
        /// <value>
        /// The warning mode.
        /// </value>
        [XmlAttributeAttribute("Exchange")]
        public string Exchange
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the warning mode.
        /// </summary>
        /// <value>
        /// The warning mode.
        /// </value>
        [XmlAttributeAttribute("Name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the warning mode.
        /// </summary>
        /// <value>
        /// The warning mode.
        /// </value>
        [XmlAttributeAttribute("Timeframe")]
        public ConstEnum.Timeframe Timeframe
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string UniqueKey
        {
            get { return Exchange + "." + ExchangeCode + "." + Timeframe; }
        }

        #endregion Public Properties

        #endregion Properties
    }

    #endregion Types
}
