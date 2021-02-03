using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGame
{
    public class EndMark
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectanglePortion;
        public Rectangle collisionRectangle;


        public EndMark(Texture2D _texture, Vector2 _position, Rectangle _rectanglePortion)
        {
            texture = _texture;
            position = _position;
            rectanglePortion = _rectanglePortion;
            collisionRectangle= new Rectangle((int)position.X, (int)position.Y, 70, 70);
        }

        public void Draw(SpriteBatch _spriteBatch, Texture2D texture)
        {
            _spriteBatch.Draw(texture, position, rectanglePortion, Color.White);
        }
    }
}
