using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGame.Animations
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }

        private List<AnimationFrame> frames;
        private int counter;
        private double frameMovement = 0;

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }
        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            CurrentFrame = frames[0];
        }
        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];
            frameMovement += CurrentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;
            if(frameMovement>=1000/90)
            {
                counter++;
                frameMovement = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

    }
}
