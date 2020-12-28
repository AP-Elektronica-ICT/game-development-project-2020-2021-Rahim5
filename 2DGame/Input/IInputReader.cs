using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGame.Input
{
    public interface IInputReader
    {
        bool RunningLeft { get; set; }
        bool RunningRight { get; set; }
        bool HasJumped { get; set; }
        Vector2 ReadInput(GameTime gameTime);
    }
}
