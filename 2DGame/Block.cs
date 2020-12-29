using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGame
{
    public class Block
    {
        public Texture2D blockTexture;
        public Vector2 blockPosition;
        public Rectangle rectanglePortion;
        public Block(Texture2D texture, Vector2 position, Rectangle rectangle)
        {
            blockTexture = texture;
            blockPosition = position;
            rectanglePortion = rectangle;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(blockTexture,blockPosition,rectanglePortion,Color.White);
        }
    }
}
