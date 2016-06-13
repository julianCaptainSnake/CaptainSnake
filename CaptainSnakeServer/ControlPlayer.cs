//-----------------------------------------------------------------------
// <copyright file="ControlPlayer.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <summary>Represents the ControlPlayer class.</summary>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaptainSnakeServer
{
    using System;
    using System.Threading;

    /// <summary>
    /// Represents the <see cref="ControlPlayer"/> class.
    /// </summary>
    public class ControlPlayer
    {
        /// <summary>
        /// The event fired if the user pressed a key.
        /// </summary>
        public event EventHandler<ControlPlayerOnKeyPressedEventArgs> OnKeyPressed;

        /// <summary>
        /// The thread which reads the user input.
        /// </summary>
        private Thread worker;

        /// <summary>
        /// The arguments of the thread.
        /// </summary>
        private ThreadArguments workerThreadArguments;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlPlayer"/> class.
        /// </summary>
        public ControlPlayer()
        {
            this.workerThreadArguments = new ThreadArguments();
        }

        /// <summary>
        /// Starts the player input.
        /// </summary>
        public void StartPlayerInput()
        {
            if (this.worker != null && this.worker.IsAlive)
            {
                return;
            }

            this.worker = new Thread(new ParameterizedThreadStart(ReadInput));
            this.workerThreadArguments.Exit = false;
            this.worker.Start(workerThreadArguments);
        }

        /// <summary>
        /// Stops the player input.
        /// </summary>
        public void StopPlayerInput()
        {
            if (this.worker == null || !this.worker.IsAlive)
            {
                return;
            }

            this.workerThreadArguments.Exit = true;
        }

        /// <summary>
        /// Reads input from the user.
        /// </summary>
        /// <param name="obj">The thread arguments.</param>
        private void ReadInput(object obj)
        {
            ThreadArguments localArgs = (ThreadArguments)obj;
            ConsoleKey key;

            while (!localArgs.Exit)
            {
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        FireOnKeyPressed(InputTypes.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        FireOnKeyPressed(InputTypes.Down);
                        break;
                    case ConsoleKey.Spacebar:
                        FireOnKeyPressed(InputTypes.Shoot);
                        break;
                    case ConsoleKey.C:
                        FireOnKeyPressed(InputTypes.ChangeLayer);
                        break;
                }
            }
        }

        /// <summary>
        /// Fires the event <see cref="OnKeyPressed"/>.
        /// </summary>
        /// <param name="itype">The type of the user input.</param>
        private void FireOnKeyPressed(InputTypes itype)
        {
            if (this.OnKeyPressed != null)
            {
                this.OnKeyPressed(this, new ControlPlayerOnKeyPressedEventArgs(itype));
            }
        }

        /// <summary>
        /// Represents the <see cref="ThreadArguments"/> class.
        /// </summary>
        private class ThreadArguments
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ThreadArguments"/> class.
            /// </summary>
            public ThreadArguments()
            {
                this.Exit = false;
            }

            /// <summary>
            /// Gets or sets a value indicating whether the thread should stop or not.
            /// </summary>
            /// <value>A value indicating whether the thread should stop or not.</value>
            public bool Exit
            {
                get;
                set;
            }
        }
    }
}