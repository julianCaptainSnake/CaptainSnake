//-----------------------------------------------------------------------
// <copyright file="EnhancedTcpListenerOnClientConnectedEventArgs.cs" company="CaptainSnake">
//     Team 1.
// </copyright>
// <summary>This is the EnhancedTcpListenerOnClientConnectedEventArgs class.</summary>
//-----------------------------------------------------------------------
namespace CaptainSnakeServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;

    /// <summary>
    /// The EnhancedTcpListenerOnClientConnectedEventArgs class.
    /// </summary>
    public class EnhancedTcpListenerOnClientConnectedEventArgs : EventArgs
    {
        /// <summary>
        /// The network stream.
        /// </summary>
        private NetworkStream stream;

        /// <summary>
        /// Gets or sets a network stream.
        /// </summary>
        public NetworkStream Stream
        {
            get
            {
                return this.stream;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The stream is null.");
                }

                this.stream = value;
            }
        }
    }
}