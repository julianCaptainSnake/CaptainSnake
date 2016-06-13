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
    /// Represents the EnhancedTcpListener class.
    /// </summary>
    public class EnhancedTcpListener
    {
        /// <summary>
        /// The worker thread arguments.
        /// </summary>
        private TcpListenerArguments workerThreadArguments;

        /// <summary>
        /// The worker thread.
        /// </summary>
        private Thread worker;

        /// <summary>
        /// This event gets fired when a client connects.
        /// </summary>
        public event EventHandler<EnhancedTcpListenerOnClientConnectedEventArgs> OnClientConnected;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnhancedTcpListener"/> class.
        /// </summary>
        public EnhancedTcpListener()
        {
            this.workerThreadArguments = new TcpListenerArguments();
        }

        /// <summary>
        /// Starts the thread for tcp listening.
        /// </summary>
        public void Start()
        {
            if (this.worker != null && this.worker.IsAlive)
            {
                return;
            }

            this.worker = new Thread(new ThreadStart(Listener));
            this.workerThreadArguments.Exit = false;
            this.worker.Start();
        }

        /// <summary>
        /// Stops the thread for tcp listening.
        /// </summary>
        public void Stop()
        {
            if (this.worker == null || !this.worker.IsAlive)
            {
                return;
            }

            this.workerThreadArguments.Exit = true;
            this.worker.Join();
        }

        /// <summary>
        /// The method waits for clients to connect and puts the network stream in an event.
        /// </summary>
        private void Listener()
        {
            EnhancedTcpListenerOnClientConnectedEventArgs clientConnectedEvent = new EnhancedTcpListenerOnClientConnectedEventArgs();

            TcpListener tcpListener = new TcpListener(IPAddress.Any, 80);
            tcpListener.Start();
            
            while (!workerThreadArguments.Exit)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                clientConnectedEvent.Stream = client.GetStream();
                FireOnClientConnected(this, clientConnectedEvent);
            }
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

        /// <summary>
        /// Represents the TcpListenerArguments class.
        /// </summary>
        private class TcpListenerArguments
        {
            /// <summary>
            /// Gets or sets whether the listener is stoped or not.
            /// </summary>
            public bool Exit
            {
                get;
                set;
            }
        }
    }
}