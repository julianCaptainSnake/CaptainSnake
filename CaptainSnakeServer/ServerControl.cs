//-----------------------------------------------------------------------
// <copyright file="ServerControl.cs" company="CaptainSnake">
//     Team 1.
// </copyright>
// <summary>This is the ServerControl class.</summary>
//-----------------------------------------------------------------------
namespace CaptainSnakeServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ServerControl
    {
        private int clients;

        public event System.EventHandler OnInputReceived;

        public ServerControl()
        {

        }
    }
}