using _2DGame.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGame
{
     class Coin
    {
        Texture2D coinTexture;
        Vector2 position;
        Animation coinAnimation;
        public bool isCollected;
        public Rectangle collisionRectangle;

        public Coin(Texture2D texture,Vector2 _position)
        {
            isCollected = false;
            position = _position;
            coinTexture = texture;
            coinAnimation = new Animation();
            collisionRectangle = new Rectangle((int)position.X, (int)position.Y, 40, 40);

            coinAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 563, 564)));
            coinAnimation.AddFrame(new AnimationFrame(new Rectangle(563, 0, 559, 564)));
            coinAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 564, 504, 564)));
            coinAnimation.AddFrame(new AnimationFrame(new Rectangle(504, 564, 428, 565)));
            coinAnimation.AddFrame(new AnimationFrame(new Rectangle(932, 564, 262, 564)));
            coinAnimation.AddFrame(new AnimationFrame(new Rectangle(1194, 564, 108, 564)));
            coinAnimation.AddFrame(new AnimationFrame(new Rectangle(1302, 564, 262, 564)));
            coinAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 1129, 428, 565)));
            coinAnimation.AddFrame(new AnimationFrame(new Rectangle(428, 1129, 503, 564)));
            coinAnimation.AddFrame(new AnimationFrame(new Rectangle(931, 1129, 559, 564)));
        }

        public void Update(GameTime gameTime)
        {
            
            
            coinAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {


            
             spriteBatch.Draw(texture, position, coinAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);

        }


    }
}
