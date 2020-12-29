using _2DGame.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _2DGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D playerTextureIdle;
        private Texture2D playerTextureRunning;
        private Texture2D level1;
        private List<Texture2D> playerTextures;
        CollisionManager collisionManager;
        Player player;
        Level level;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            collisionManager = new CollisionManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            InitializeGameObjects();
            // TODO: use this.Content to load your game content here
            playerTextureIdle = Content.Load<Texture2D>("rsz_trump_iddle");
            playerTextureRunning = Content.Load<Texture2D>("rsz_trump_run");
            level1 = Content.Load<Texture2D>("level");
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
                        if (player.position.Y+128 > block.collisionRectangle.Y)
                        {
                            player.position.X = block.collisionRectangle.X - 108;
                        }
                        else if (player.position.Y + 128 < block.collisionRectangle.Y && (int)player.position.X + (player.currentTexture.Width / 6)>block.collisionRectangle.X)
                        {
                            player.position.Y = block.collisionRectangle.Y - 128;
                        }
                        
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            player.Draw(_spriteBatch);
            level.DrawWorld(_spriteBatch, level1);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
