using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Models
{
    #region Types

    public interface IToggleGateway
    {
        /// <summary>
        /// Gets the gateway parameters.
        /// </summary>
        /// <value>
        /// The gateway parameters.
        /// </value>
        GatewayParameters GatewayParameters
        {
            get;
        }

        /// <summary>
        /// Gets or sets the type of the gateway.
        /// </summary>
        /// <value>
        /// The type of the gateway.
        /// </value>
        ConstEnum.GatewayType GatewayType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        bool IsConnected
        {
            get;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Starts the gateway.
        /// </summary>
        void StartGateway();

        /// <summary>
        /// Stops the gateway.
        /// </summary>
        void StopGateway();
    }

    #endregion Types
}
