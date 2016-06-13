//-----------------------------------------------------------------------
// <copyright file="IDrawable.cs" company="CaptainSnake">
//     Team 1.
// </copyright>
// <summary>This is the IDrawable class.</summary>
//-----------------------------------------------------------------------
namespace CaptainSnakeClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IDrawable
    {
        void Draw(IRenderer renderer);
    }
}