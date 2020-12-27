using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGame.interfaces
{
    interface IGameObject
    {
        void Update();
        void Draw(SpriteBatch _spriteBatch);
    }
}
