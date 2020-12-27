using _2DGame.interfaces;
using _2DGame.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGame
{
    public class Player: IGameObject
    {
        Texture2D playerTexture;
        Animation animation;
        public Player(Texture2D texture)
        {
            playerTexture = texture;
            animation = new Animation();
            for (int i = 0; i < 5; i++)
            {
                animation.AddFrame(new AnimationFrame(new Rectangle(256 * i, 256, 256, 256)));
            }


        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(playerTexture, new Vector2(10, 10),animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
