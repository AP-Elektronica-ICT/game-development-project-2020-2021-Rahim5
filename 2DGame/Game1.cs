using _2DGame.Input;
using _2DGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private Texture2D level1;
        private Texture2D red;
        private Texture2D background;
        private List<Texture2D> playerTextures;
        CollisionManager collisionManager;

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
            level1 = Content.Load<Texture2D>("level");
            red = Content.Load<Texture2D>("red");
            background = Content.Load<Texture2D>("background");
            playerTextures.Add(playerTextureIdle);
            playerTextures.Add(playerTextureRunning);


        }

        private void InitializeGameObjects()
        {
            playerTextures = new List<Texture2D>();
            player = new Player(playerTextures, new KeyBoardReader());
            level = new Level();
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
            player.Update(gameTime);
            foreach (var block in level.blockArray)
            {
                if (block != null)
                {

                    if (collisionManager.CheckCollision(player.collisionRectangle, block.collisionRectangle))
                    {




                        if (player.collisionRectangle.Top <= block.collisionRectangle.Bottom && player.collisionRectangle.Bottom > block.collisionRectangle.Bottom)
                        {
                            player.position.Y = block.blockPosition.Y - 70;
                        }
                        else if (player.collisionRectangle.Bottom >= block.collisionRectangle.Top && player.collisionRectangle.Top + 90 < block.collisionRectangle.Top)
                        {

                            player.position.Y = block.blockPosition.Y - 115;
                            player.inputReader.HasJumped = false;

                        }
                        else
                        {
                            player.inputReader.HasJumped = true;

                        }



                    }

                }

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
            _spriteBatch.Draw(background, new Rectangle(0, 0, 1600, 900), Color.White);
            player.Draw(_spriteBatch);
            level.DrawWorld(_spriteBatch, level1);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
