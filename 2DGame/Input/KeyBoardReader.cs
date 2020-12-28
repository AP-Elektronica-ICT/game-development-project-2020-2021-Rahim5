using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGame.Input
{
    public class KeyBoardReader : IInputReader
    {
        public bool RunningLeft { get; set; }
        public bool RunningRight { get; set; }

        public Vector2 ReadInput()
        {
            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                RunningLeft = true;
                RunningRight = false;
                direction = new Vector2(-1, 0);
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                RunningLeft = false;
                RunningRight = true;
                direction = new Vector2(1, 0);
            }
            else
            {
                RunningLeft = false;
                RunningRight = false;
            }
            return direction;
        }

    } 
}
