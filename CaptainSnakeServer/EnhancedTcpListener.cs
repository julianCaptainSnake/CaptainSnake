//-----------------------------------------------------------------------
// <copyright file="EnhancedTcpListener.cs" company="CaptainSnake">
//     Team 1.
// </copyright>
// <summary>This is the EnhancedTcpListener class.</summary>
//-----------------------------------------------------------------------
namespace CaptainSnakeServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    /// <summary>
    /// The EnhancedTcpListener class.
    /// </summary>
    public class EnhancedTcpListener
    {
        /// <summary>
        /// This event gets fired when a client connects.
        /// </summary>
        public event EventHandler<EnhancedTcpListenerOnClientConnectedEventArgs> OnClientConnected;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnhancedTcpListener"/> class.
        /// </summary>
        public EnhancedTcpListener()
        {
            Thread listener = new Thread(new ThreadStart(Listener));
            listener.Start();
        }

        /// <summary>
        /// The method waits for clients to connect and puts the network stream in an event.
        /// </summary>
        private void Listener()
        {
            EnhancedTcpListenerOnClientConnectedEventArgs clientConnectedEvent = new EnhancedTcpListenerOnClientConnectedEventArgs();

            TcpListener tcpListener = new TcpListener(IPAddress.Any, 80);
            tcpListener.Start();

            do
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                clientConnectedEvent.Stream = client.GetStream();
                FireOnClientConnected(this, clientConnectedEvent);
            }
            while (true);
        }

        /// <summary>
        /// The method to fire the OnClientConnected event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The event.</param>
        protected void FireOnClientConnected(object sender, EnhancedTcpListenerOnClientConnectedEventArgs args)
        {
            if (OnClientConnected != null)
            {
                OnClientConnected(sender, args);
            }
        }
    }
}