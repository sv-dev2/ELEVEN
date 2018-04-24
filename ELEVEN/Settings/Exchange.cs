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

    public class Exchange
    {
        #region Properties

        #region Public Properties

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

        [XmlAttributeAttribute("GatewayMode")]
        public ConstEnum.GatewayMode GatewayMode
        {
            get;
            set;
        }

        [XmlAttributeAttribute("GatewayType")]
        public ConstEnum.GatewayType GatewayType
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
        [XmlAttributeAttribute("Ip")]
        public string Ip
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
        [XmlAttributeAttribute("Port")]
        public int Port
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
        [XmlAttributeAttribute("Url")]
        public string Url
        {
            get;
            set;
        }

        #endregion Public Properties

        #endregion Properties
    }

    #endregion Types
}
