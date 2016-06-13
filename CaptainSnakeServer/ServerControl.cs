using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaptainSnakeServer
{
    public class ServerControl
    {
        private int clients;

        public event System.EventHandler OnInputReceived;
    }
}