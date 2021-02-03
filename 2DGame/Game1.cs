using _2DGame.Input;
using _2DGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _2DGame
{   //Game is far from finished but secondversion should be better

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //private State _currentState;
        //private State _nextState;

        //public void ChangeState(State state)
        //{
        //    _nextState = state;
        //    Debug.WriteLine("THIS IS THE STATE: " + _nextState.ToString());
        //}

        private Texture2D playerTextureIdle;
        private Texture2D playerTextureRunning;
        private Texture2D levelTexture;
        private Texture2D coinTexture;
        private Texture2D background;
        private SpriteFont scoreFont;
        private SpriteFont gameOverFont;
        private SpriteFont restartGameFont;

        private int score = 0;
        private bool gameOver = false;
        private bool finishedLevel1 = false;
        private bool finishedLevel2 = false;
        private bool startLevel2 = false;
        private List<Texture2D> playerTextures;
        CollisionManager collisionManager;
        SoundEffect jumpSound;
        SoundEffect coinSound;
        SoundEffect hooraySound;
        Song themeSong;
        Player player;
        Level level;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;

            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //IsMouseVisible = true;
            collisionManager = new CollisionManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            InitializeGameObjects();
            // TODO: use this.Content to load your game content here

            //_currentState = new MenuState(this, GraphicsDevice, Content);

            playerTextureIdle = Content.Load<Texture2D>("rsz_trump_iddle");
            playerTextureRunning = Content.Load<Texture2D>("rsz_trump_run");
            levelTexture = Content.Load<Texture2D>("level");

            jumpSound = Content.Load<SoundEffect>("Sounds/jumpingSound");
            themeSong = Content.Load<Song>("Sounds/themeSound");
            scoreFont = Content.Load<SpriteFont>("Fonts/score");
            gameOverFont = Content.Load<SpriteFont>("Fonts/gameOver");
            restartGameFont = Content.Load<SpriteFont>("Fonts/restartGame");
            MediaPlayer.Play(themeSong);
            MediaPlayer.IsRepeating = true;
            coinSound = Content.Load<SoundEffect>("Sounds/coinSound");
            hooraySound = Content.Load<SoundEffect>("Sounds/hooray");
            background = Content.Load<Texture2D>("background");
            coinTexture = Content.Load<Texture2D>("Coins/coins");
            playerTextures.Add(playerTextureIdle);
            playerTextures.Add(playerTextureRunning);


        }

        private void InitializeGameObjects()
        {
            playerTextures = new List<Texture2D>();
            player = new Player(playerTextures);
            level = new Level(1);
            level.CreateWorld();
        }

        protected override void Update(GameTime gameTime)
        {
            //if (_nextState != null)
            //{
            //    _currentState = _nextState;
            //    _nextState = null;
            //}
            //_currentState.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime, jumpSound);

            if (player.position.X <= 0)
                player.position.X = 0;
            if (player.position.X + 128 >= 1600)
                player.position.X = 1472;
            if (player.position.Y <= 0)
            {
                player.velocity.Y = 0f;
                float i = 1;
                player.velocity.Y += 0.40f * i;
            }

            if (player.position.Y + 128 > 900)
            {
                gameOver = true;
                MediaPlayer.Stop();
                player.hasJumped = true;
                player.velocity = Vector2.Zero;
                player.gravity = 0f;
            }

            foreach (var block in level.blockArray)
            {
                if (block != null)
                {

                    if (collisionManager.CheckCollision(player.collisionRectangle, block.collisionRectangle))
                    {

                        if (player.collisionRectangle.Bottom > block.collisionRectangle.Top && player.collisionRectangle.Top < block.collisionRectangle.Top)
                        {
                            player.position.Y = block.blockPosition.Y - 115;
                            player.hasJumped = false;

                        }
                        else if (player.collisionRectangle.Top < block.collisionRectangle.Bottom && player.collisionRectangle.Bottom > block.collisionRectangle.Bottom)
                        {
                            player.velocity.Y = 0f;

                            player.velocity.Y += 4f;
                        }
                        else if (player.collisionRectangle.Right > block.collisionRectangle.Left && player.collisionRectangle.Left < block.collisionRectangle.Left && player.collisionRectangle.Bottom > block.collisionRectangle.Top && player.collisionRectangle.Top < block.collisionRectangle.Bottom)
                        {
                            player.velocity.X = 0f;
                        }
                        else if (player.collisionRectangle.Left < block.collisionRectangle.Right && player.collisionRectangle.Right > block.collisionRectangle.Right && player.collisionRectangle.Bottom > block.collisionRectangle.Top && player.collisionRectangle.Top < block.collisionRectangle.Bottom)
                        {
                            player.velocity.X = 0f;
                        }







                    }

                }

            }

            foreach (Block block in level.movingBlockArray)
            {
                if (block != null)
                {

                    if (collisionManager.CheckCollision(player.collisionRectangle, block.collisionRectangle))
                    {



                        player.position.Y = block.blockPosition.Y - 115;
                        player.hasJumped = false;






                    }

                }
            }
            if (collisionManager.CheckCollision(player.collisionRectangle, level.endMark.collisionRectangle))
            {
                if (finishedLevel1 == false)
                {
                    hooraySound.Play();
                    finishedLevel1 = true;
                    player.position = new Vector2(10, 600);
                    

                }
                else if (finishedLevel2 == false)
                {
                    hooraySound.Play();
                    finishedLevel2 = true;
                    startLevel2 = false;
                }
            }
            if(finishedLevel1==true && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                level = new Level(2);
                startLevel2 = true;
                level.CreateWorld();
               
                
            }
            

            //foreach (Coin coin in level.coinArray)
            //{
            //    if (coin != null)
            //    {
            //        if (collisionManager.CheckCollision(player.collisionRectangle, coin.collisionRectangle))
            //        {
            //            jumpSound.Play();
            //            coin.isCollected = true;

            //        }
            //    }
            //}

            for (int x = 0; x < 22; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    if (level.coinArray[x, y] != null)
                    {
                        if (collisionManager.CheckCollision(player.collisionRectangle, level.coinArray[x, y].collisionRectangle))
                        {
                            coinSound.Play();
                            score++;
                            level.coinArray[x, y] = null;
                        }
                    }
                }
            }

            if (gameOver == true && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {

                finishedLevel1 = false;
                finishedLevel2 = false;
                startLevel2 = false;
                level = new Level(1);
                level.CreateWorld();
                MediaPlayer.Play(themeSong);
                player.position = new Vector2(10, 600);
                score = 0;
                gameOver = false;
                

            }
            if(finishedLevel1==true && finishedLevel2==true && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                finishedLevel1 = false;
                finishedLevel2 = false;
                startLevel2 = false;
                level = new Level(1);
                level.CreateWorld();
                MediaPlayer.Play(themeSong);
                player.position = new Vector2(10, 600);
                score = 0;
            }
            if(finishedLevel1==true && finishedLevel2==true && Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }


            level.UpdateLevel(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //_currentState.Draw(gameTime, _spriteBatch);
            // TODO: Add your drawing code here


            _spriteBatch.Begin();


            if (finishedLevel1 == true && finishedLevel2 == false)
            {
                _spriteBatch.Draw(background, new Rectangle(0, 0, 1600, 900), Color.White);
                _spriteBatch.DrawString(gameOverFont, "LEVEL 1 CLEARED", new Vector2((_graphics.PreferredBackBufferWidth / 2) - gameOverFont.MeasureString("LEVEL 1 CLEARED").X / 2, (_graphics.PreferredBackBufferHeight / 2) - gameOverFont.MeasureString("LEVEL 1 CLEARED").Y / 2 - 100), Color.Black);
                _spriteBatch.DrawString(restartGameFont, "Press Enter For Next Level", new Vector2((_graphics.PreferredBackBufferWidth / 2) - restartGameFont.MeasureString("Press Enter For Next Level").X / 2, (_graphics.PreferredBackBufferHeight / 2) - restartGameFont.MeasureString("Press Enter For Next Level").Y / 2), Color.Black * 0.6f);
                _spriteBatch.DrawString(scoreFont, "Score: " + score, new Vector2((_graphics.PreferredBackBufferWidth / 2) - scoreFont.MeasureString("Score: " + score.ToString()).X / 2, (_graphics.PreferredBackBufferHeight / 2) - scoreFont.MeasureString("Score: " + score).Y / 2 + 100), Color.Black);

                
            }
            else if(finishedLevel1==true && finishedLevel2 == true)
            {
                _spriteBatch.Draw(background, new Rectangle(0, 0, 1600, 900), Color.White);
                _spriteBatch.DrawString(gameOverFont, "YOU WON!", new Vector2((_graphics.PreferredBackBufferWidth / 2) - gameOverFont.MeasureString("YOU WON!").X / 2, (_graphics.PreferredBackBufferHeight / 2) - gameOverFont.MeasureString("YOU WON!").Y / 2 - 100), Color.Black);
                _spriteBatch.DrawString(restartGameFont, "Press Enter To Play Again", new Vector2((_graphics.PreferredBackBufferWidth / 2) - restartGameFont.MeasureString("Press Enter To Play Again").X / 2, (_graphics.PreferredBackBufferHeight / 2) - restartGameFont.MeasureString("Press Enter To Play Again").Y / 2), Color.Black * 0.6f);
                _spriteBatch.DrawString(restartGameFont, "Or Press ESC To Quit", new Vector2((_graphics.PreferredBackBufferWidth / 2) - restartGameFont.MeasureString("Or Press ESC To Quit").X / 2, (_graphics.PreferredBackBufferHeight / 2) - restartGameFont.MeasureString("Or Press ESC To Quit").Y / 2+70), Color.Black * 0.6f);
                _spriteBatch.DrawString(scoreFont, "Total Score: " + score, new Vector2((_graphics.PreferredBackBufferWidth / 2) - scoreFont.MeasureString("Total Score: " + score.ToString()).X / 2, (_graphics.PreferredBackBufferHeight / 2) - scoreFont.MeasureString("Total Score: " + score).Y / 2 + 130), Color.Black);
            }
            
            if (gameOver == false && finishedLevel1 == false)
            {
                _spriteBatch.Draw(background, new Rectangle(0, 0, 1600, 900), Color.White);
                player.Draw(_spriteBatch);
                level.DrawWorld(_spriteBatch, levelTexture, coinTexture);
                _spriteBatch.DrawString(scoreFont, "Score: " + score, new Vector2(10, 10), Color.Black * 0.5f);
            }
            else if (gameOver == false && startLevel2 == true)
            {
                _spriteBatch.Draw(background, new Rectangle(0, 0, 1600, 900), Color.White);
                player.Draw(_spriteBatch);
                level.DrawWorld(_spriteBatch, levelTexture, coinTexture);
                _spriteBatch.DrawString(scoreFont, "Score: " + score, new Vector2(10, 10), Color.Black * 0.5f);
            }

            else if (gameOver == true)
            {
                _spriteBatch.Draw(background, new Rectangle(0, 0, 1600, 900), Color.White);
                _spriteBatch.DrawString(gameOverFont, "GAME OVER", new Vector2((_graphics.PreferredBackBufferWidth / 2) - gameOverFont.MeasureString("GAME OVER").X / 2, (_graphics.PreferredBackBufferHeight / 2) - gameOverFont.MeasureString("GAME OVER").Y / 2 - 100), Color.Black);
                _spriteBatch.DrawString(restartGameFont, "Press Enter To Restart", new Vector2((_graphics.PreferredBackBufferWidth / 2) - restartGameFont.MeasureString("Press Enter To Restart").X / 2, (_graphics.PreferredBackBufferHeight / 2) - restartGameFont.MeasureString("Press Enter To Restart").Y / 2), Color.Black * 0.6f);
                _spriteBatch.DrawString(scoreFont, "Score: " + score, new Vector2((_graphics.PreferredBackBufferWidth / 2) - scoreFont.MeasureString("Score: " + score.ToString()).X / 2, (_graphics.PreferredBackBufferHeight / 2) - scoreFont.MeasureString("Score: " + score).Y / 2 + 100), Color.Black);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
