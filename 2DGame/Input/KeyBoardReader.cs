using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGame.Input
{
    public class KeyBoardReader : IInputReader
    {
        Player player;
        public bool RunningLeft { get; set; }
        public bool RunningRight { get; set; }
        bool HasJumped;
        Vector2 direction;

        public KeyBoardReader()
        {
            HasJumped = false;
            
            
        }

        public Vector2 ReadInput(GameTime gameTime)
        {

            direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                RunningLeft = true;
                RunningRight = false;
                direction = new Vector2(-5, 0);
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                RunningLeft = false;
                RunningRight = true;
                direction = new Vector2(5, 0);
            }
            else
            {
                RunningLeft = false;
                RunningRight = false;
            }
            if (state.IsKeyDown(Keys.Space) && HasJumped == false)
            {
                while (gameTime.ElapsedGameTime.TotalSeconds < 1)
                {
                    direction = new Vector2(0, (float)(-20f * 1 / gameTime.ElapsedGameTime.TotalSeconds));
                }
                HasJumped = true;

                
                
            }
            if (HasJumped == true)
            {
                float i = 1;
                direction.Y += 0.5f * i;
            }
            return direction;
        }

    } 
}
