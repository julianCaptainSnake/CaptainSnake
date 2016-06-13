//-----------------------------------------------------------------------
// <copyright file="InputTypes.cs" company="CaptainSnake">
//     Team 1.
// </copyright>
// <summary>This is the InputTypes class.</summary>
//-----------------------------------------------------------------------
namespace CaptainSnakeServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The InputTypes enum.
    /// </summary>
    public enum InputTypes
    {
        /// <summary>
        /// The up direction.
        /// </summary>
        Up,
        
        /// <summary>
        /// The down direction.
        /// </summary>
        Down,
        
        /// <summary>
        /// A shot.
        /// </summary>
        Shoot,

        /// <summary>
        /// The layer change.
        /// </summary>
        ChangeLayer
    }
}