//-----------------------------------------------------------------------
// <copyright file="ControlPlayerOnKeyPressedEventArgs.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <summary>Represents the ControlPlayerOnKeyPressedEventArgs class.</summary>
//-----------------------------------------------------------------------

namespace CaptainSnakeServer
{
    /// <summary>
    /// Represents the <see cref="ControlPlayerOnKeyPressedEventArgs"/> class.
    /// </summary>
    public class ControlPlayerOnKeyPressedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlPlayerOnKeyPressedEventArgs"/> class.
        /// </summary>
        public ControlPlayerOnKeyPressedEventArgs(InputTypes itype)
        {
            this.ControlInput = itype;
        }

        /// <summary>
        /// Gets or sets the input type of the user input.
        /// </summary>
        /// <value>The input type of the user input</value>
        public InputTypes ControlInput
        {
            get;
            set;
        }
    }
}