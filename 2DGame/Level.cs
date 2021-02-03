﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace _2DGame
{

    class Level
    {
        Texture2D blockTexture;
        Texture2D coinTexture;

        
        

        public Level()
        {
            blockArray = new Block[22, 12];
            movingBlockArray = new Block[22, 12];
            coinArray = new Coin[22, 12];
            



        }
        public Block[,] blockArray;
        public Block[,] movingBlockArray;
        public Coin[,] coinArray;

        int[,] tileArray = new int[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,2},
            {0,0,0,0,1,0,0,0,0,0,0,3},
            {0,0,0,0,2,0,0,0,0,0,0,0},
            {0,0,0,0,3,0,0,0,0,1,0,0},
            {0,0,0,0,0,0,0,0,9,2,0,0},
            {0,0,0,0,0,0,4,0,0,3,0,0},
            {0,0,4,0,0,9,5,0,0,0,0,0},
            {0,0,5,0,0,0,5,0,0,0,0,1},
            {0,0,6,0,0,0,5,0,0,0,0,2},
            {0,0,0,0,0,9,5,0,0,0,0,3},
            {0,0,0,0,0,0,6,0,0,0,0,0},
            {0,0,9,0,0,0,0,0,0,1,0,0},
            {0,0,0,0,0,0,0,0,0,2,0,0},
            {0,0,0,0,0,0,0,0,0,3,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,1,0,0,0,0,0,0,0,1},
            {0,0,9,2,0,0,0,8,0,0,9,2},
            {0,0,0,3,0,0,0,0,0,0,0,3},
            {0,0,0,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,7,0,0,0,0,0,0,2},
            {0,0,0,0,0,0,0,0,0,0,0,3},
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
                    else if (tileArray[x, y] == 7)
                    {
                        movingBlockArray[x, y] = new Block(blockTexture, new Vector2(x * 70, y * 70), new Rectangle(576, 432, 70, 70));
                    }
                    else if (tileArray[x, y] == 8)
                    {
                        blockArray[x, y] = new Block(blockTexture, new Vector2(x * 70, y * 70), new Rectangle(576, 432, 70, 70));
                    }
                    else if (tileArray[x, y] == 9)
                    {
                        coinArray[x, y] = new Coin(coinTexture, new Vector2(x * 70, y * 70));
                    }

                }
            }
        }

        public void DrawWorld(SpriteBatch _spriteBatch, Texture2D levelTexture, Texture2D coinTexture)
        {
            for (int x = 0; x < 22; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    if (blockArray[x, y] != null)
                    {
                        blockArray[x, y].Draw(_spriteBatch, levelTexture);
                        
                    }
                    if (movingBlockArray[x, y] != null)
                    {
                        movingBlockArray[x, y].Draw(_spriteBatch, levelTexture);
                        
                    }
                    if (coinArray[x, y] != null)
                    {
                        coinArray[x, y].Draw(_spriteBatch, coinTexture);
                    }

                }
            }
        }
        double totalSeconds = 0;
        public void UpdateLevel(GameTime gameTime)
        {

            foreach(Coin coin in coinArray)
            {
                if (coin != null)
                {
                    coin.Update(gameTime);
                }
            }
            var movement = 1.75f;
            totalSeconds += gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Block block in movingBlockArray)
            {
                if (block != null)
                {

                    
                    Debug.WriteLine("TOTAL SECONDS" + totalSeconds.ToString());
                    if (totalSeconds <= 2)
                    {
                        block.blockPosition.Y += movement;
                        
                    }
                    if (totalSeconds>=2 && totalSeconds <= 4)
                    {
                        block.blockPosition.Y -= movement;
                    }
                    if (totalSeconds >= 4)
                    {
                        totalSeconds = 0;
                    }
                }
            }
            
        }







    }
}


