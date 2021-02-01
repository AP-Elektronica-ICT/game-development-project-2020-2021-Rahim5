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
            collisionRectangle = new Rectangle((int)blockPosition.X, (int)blockPosition.Y, 70, 70);
            border = new Rectangle(0, 0, 70, 70);
        }

        public void Draw(SpriteBatch _spriteBatch, Texture2D texture)
        {
            
            _spriteBatch.Draw(texture, blockPosition, rectanglePortion, Color.White);
        }
    }
}
