using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGame
{
    public class Block
    {
        Texture2D blockTexture;
        public Vector2 blockPosition;
        Rectangle rectanglePortion;
        Rectangle border;
        public Rectangle collisionRectangle;
        public Block(Texture2D texture, Vector2 position, Rectangle rectangle)
        {
            blockTexture = texture;
            blockPosition = position;
            rectanglePortion = rectangle;
            collisionRectangle = new Rectangle((int)blockPosition.X, (int)blockPosition.Y, 72, 72);
            border = new Rectangle(0, 0, 72, 72);
        }

        public void Draw(SpriteBatch _spriteBatch, Texture2D texture,Texture2D textureBorder)
        {
            _spriteBatch.Draw(textureBorder, blockPosition, border, Color.Yellow*0.5f);
            _spriteBatch.Draw(texture, blockPosition, rectanglePortion, Color.White);
        }
    }
}
