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
        Vector2 blockPosition;
        Rectangle rectanglePortion;
        public Block(Texture2D texture, Vector2 position, Rectangle rectangle)
        {
            blockTexture = texture;
            blockPosition = position;
            rectanglePortion = rectangle;
        }

        public void Draw(SpriteBatch _spriteBatch, Texture2D texture)
        {
            _spriteBatch.Draw(texture, blockPosition, rectanglePortion, Color.White);
        }
    }
}
