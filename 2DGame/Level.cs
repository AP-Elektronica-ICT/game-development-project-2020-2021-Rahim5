using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace _2DGame
{

    class Level
    {
        Texture2D blockTexture;
        
        

        public Level()
        {
            blockArray = new Block[22, 12];
            movingBlockArray = new Block[22, 13];
            



        }
        public Block[,] blockArray;
        public Block[,] movingBlockArray;

        int[,] tileArray = new int[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,2},
            {0,0,0,0,1,0,0,0,0,0,0,3},
            {0,0,0,0,2,0,0,0,0,0,0,0},
            {0,0,0,0,3,0,0,0,0,1,0,0},
            {0,0,0,0,0,0,0,0,0,2,0,0},
            {0,0,0,0,0,0,4,0,0,3,0,0},
            {0,0,0,0,0,0,5,0,0,0,0,0},
            {0,0,0,0,0,0,5,0,0,0,0,1},
            {0,0,0,0,0,0,5,0,0,0,0,2},
            {0,0,0,0,0,0,5,0,0,0,0,3},
            {0,0,0,0,0,0,6,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,1,0,0},
            {0,0,0,0,0,0,0,0,0,2,0,0},
            {0,0,0,0,0,0,0,0,0,3,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,2},
            {0,0,0,0,0,0,0,0,0,0,0,3},
            {0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0},
        };

        public void CreateWorld()
        {

            for (int x = 0; x < 22; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    if (tileArray[x, y] == 1)
                    {
                        blockArray[x, y] = new Block(blockTexture, new Vector2(x * 70, y * 70), new Rectangle(576, 648, 70, 70));
                    }
                    else if (tileArray[x, y] == 2)
                    {
                        blockArray[x, y] = new Block(blockTexture, new Vector2(x * 70 , y * 70), new Rectangle(504, 576, 70, 70));
                    }
                    else if (tileArray[x, y] == 3)
                    {
                        blockArray[x, y] = new Block(blockTexture, new Vector2(x * 70, y * 70), new Rectangle(576, 504, 70, 70));
                    }
                    else if (tileArray[x, y] == 4)
                    {
                        blockArray[x, y] = new Block(blockTexture, new Vector2(x * 70, y * 70), new Rectangle(504, 648, 70, 70));
                    }
                    else if (tileArray[x, y] == 5)
                    {
                        blockArray[x, y] = new Block(blockTexture, new Vector2(x * 70, y * 70), new Rectangle(504, 576, 70, 70));
                    }
                    else if (tileArray[x, y] == 6)
                    {
                        blockArray[x, y] = new Block(blockTexture, new Vector2(x * 70, y * 70), new Rectangle(504, 504, 70, 70));
                    }

                }
            }
        }

        public void DrawWorld(SpriteBatch _spriteBatch, Texture2D texture)
        {
            for (int x = 0; x < 22; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    if (blockArray[x, y] != null)
                    {
                        blockArray[x, y].Draw(_spriteBatch, texture);
                        
                    }
                    if (movingBlockArray[x, y] != null)
                    {
                        movingBlockArray[x, y].Draw(_spriteBatch, texture);
                        
                    }

                }
            }
        }
        public void UpdateLevel(GameTime gameTime)
        {
            

            foreach(Block block in movingBlockArray)
            {
                if (block != null)
                {
                    
                }
            }
            
        }







    }
}


