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
        public List<Texture2D> playerTextures;
        public Texture2D currentTexture;
        
        public Animation animationIdle;
        public Animation animationRunningLeft;
        public Animation animationRunningRight;
        public Animation currentAnimation;
        private Vector2 position;
        IInputReader inputReader;
        KeyBoardReader keyboard;
        public Player(List<Texture2D> textures, IInputReader reader)
        {
            playerTextures = new List<Texture2D>();
            playerTextures = textures;
            
            animationIdle = new Animation();
            animationRunningLeft = new Animation();
            animationRunningRight = new Animation();
            currentAnimation = new Animation();
            inputReader = reader;
            position = new Vector2(10, 10);
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
           
            


        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput() * 3;
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
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            
            _spriteBatch.Draw(currentTexture, position, currentAnimation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
