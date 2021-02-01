using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGame.Input
{
    public interface IInputReader
    {
       
        
        Vector2 ReadInput(GameTime gameTime);
    }
}
