//-----------------------------------------------------------------------
// <copyright file="Client.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <summary>Represents the Client class.</summary>
//-----------------------------------------------------------------------

namespace CaptainSnakeServer
{
    /// <summary>
    /// Represents the <see cref="Client"/> class.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="enhancedNetworkStream"></param>
        public Client(EnhancedNetworkStream enhancedNetworkStream)
        {
            this.EnhancedNetworkStream = enhancedNetworkStream;
        }

        /// <summary>
        /// Gets or sets the enhanced network stream of the client.
        /// </summary>
        /// <value>
        /// The enhanced network stream of the client.
        /// </value>
        public int EnhancedNetworkStream
        {
            get;
            set;
        }
    }
}