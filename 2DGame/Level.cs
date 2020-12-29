using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DGame
{
    
    class Level
    {
        public Texture2D blockTexture;

        public Level(Texture2D texture)
        {
            blockTexture = texture;
            blockArray = new Block[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    blockArray[x, y] = new Block(blockTexture, new Vector2(x * 72, y * 72), new Rectangle(0, 0, 72, 72));
                }
            }
            
        }
        public Block[,] blockArray;
        public byte[,] tileArray = new Byte[,]
        {
            {0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0 },
            {0,0,1,1,1,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,1,1,1,1,0,0 },
            {0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,1,1,1,1,0,0 },
            {0,0,0,0,0,0,0,0,0,0 },
        };

        public void CreateWorld()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (tileArray[x,y]==1)
                    {
                        blockArray[x, y] = new Block(blockTexture, new Vector2(x * 72, y * 72),new Rectangle(0,0,72,72));
                    }
                }
            }
        }

        public void DrawWorld(SpriteBatch _spriteBatch)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (blockArray[x, y] != null)
                    {
                        blockArray[x, y].Draw(_spriteBatch);
                    }
                }
            }
        }
    }
}
