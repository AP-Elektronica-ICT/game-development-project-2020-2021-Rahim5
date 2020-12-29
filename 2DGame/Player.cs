using _2DGame.interfaces;
using _2DGame.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using _2DGame.Input;

namespace _2DGame
{
    public class Player : IGameObject
    {
        List<Texture2D> playerTextures;
        public Texture2D currentTexture;

        Animation animationIdle;
        Animation animationRunningLeft;
        Animation animationRunningRight;
        Animation currentAnimation;
        public Rectangle collisionRectangle;
        public  Vector2 position;
        public Vector2 gravity;
        public IInputReader inputReader;
        
        

        Rectangle border;
        public Player(List<Texture2D> textures, IInputReader reader)
        {
            playerTextures = new List<Texture2D>();
            playerTextures = textures;

            animationIdle = new Animation();
            animationRunningLeft = new Animation();
            animationRunningRight = new Animation();
            currentAnimation = new Animation();
            inputReader = reader;
            position = new Vector2(10, 500);
            
            collisionRectangle = new Rectangle((int)position.X + 35, (int)position.Y + 15, 60, 100);

            for (int i = 0; i < 10; i++)
            {
                animationIdle.AddFrame(new AnimationFrame(new Rectangle(128 * i, 0, 128, 128)));
            }
            for (int i = 0; i < 6; i++)
            {
                animationRunningLeft.AddFrame(new AnimationFrame(new Rectangle(128 * i, 384, 128, 128)));
            }
            for (int i = 0; i < 6; i++)
            {
                animationRunningRight.AddFrame(new AnimationFrame(new Rectangle(128 * i, 128, 128, 128)));
            }
            
            border = new Rectangle(0,0, 60, 100);
            gravity = new Vector2(0, 1f);


        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput(gameTime);
            if (inputReader.RunningLeft)
            {
                currentAnimation = animationRunningLeft;
                currentTexture = playerTextures[1];
            }
            else if (inputReader.RunningRight)
            {
                currentAnimation = animationRunningRight;
                currentTexture = playerTextures[1];
            }
            else
            {
                currentAnimation = animationIdle;
                currentTexture = playerTextures[0];
            }

            
            position += direction;
            position += gravity;
            collisionRectangle.X = (int)position.X+35;
            collisionRectangle.Y = (int)position.Y+15;
            border.X = (int)position.X;
            border.Y = (int)position.Y;
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch,Texture2D test)
        {

            _spriteBatch.Draw(test, new Vector2(position.X+35,position.Y+15), collisionRectangle, Color.Red*0.5f);
            _spriteBatch.Draw(currentTexture, position, currentAnimation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
