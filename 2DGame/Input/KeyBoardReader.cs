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
        public bool HasJumped { get; set; }
        Vector2 direction;
        double timer;

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

                timer = 0;
                
                while (timer <=2)
                {
                    timer += gameTime.ElapsedGameTime.TotalSeconds;
                    direction.Y -= 1f;
                }

                if(timer>1)
                {
                    HasJumped = true;
                }
                



            }
            if (HasJumped == true)
            {
                timer = 2;
                  timer+= gameTime.ElapsedGameTime.TotalSeconds;
                direction.Y += 4f * (float)timer;
                
            }
            if (HasJumped == false)
            {
                timer = 0;
            }
            return direction;
        }

    }
}
