//-----------------------------------------------------------------------
// <copyright file="ConsolePosition.cs" company="CaptainSnake">
//     Team 1.
// </copyright>
// <summary>This is the ConsolePosition class.</summary>
//-----------------------------------------------------------------------
namespace CaptainSnakeClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The ConsolePosition class.
    /// </summary>
    public class ConsolePosition
    {
        /// <summary>
        /// The distance from the top side of the console.
        /// </summary>
        private int top;

        /// <summary>
        /// The distance from the left side of the console.
        /// </summary>
        private int left;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsolePosition"/> class.
        /// </summary>
        /// <param name="left">The distance from the left side of the console.</param>
        /// <param name="top">The distance from the top side of the console.</param>
        public ConsolePosition(int left, int top)
        {
            this.Top = top;
            this.Left = left;
        }

        /// <summary>
        /// Gets or sets the distance from the top side of the console.
        /// </summary>
        /// <value>The distance from the top side of the console.</value>
        public int Top
        {
            get
            {
                return this.top;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The top-position is not allowed to be less than zero.");
                }

                this.top = value;
            }
        }

        /// <summary>
        /// Gets or sets the distance from the left side of the console.
        /// </summary>
        /// <value>The distance from the left side of the console.</value>
        public int Left
        {
            get
            {
                return this.left;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The left-position is not allowed to be less than zero.");
                }

                this.left = value;
            }
        }
    }
}