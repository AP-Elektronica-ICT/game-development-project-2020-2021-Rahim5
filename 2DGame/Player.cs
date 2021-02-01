using _2DGame.interfaces;
using _2DGame.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using _2DGame.Input;
using Microsoft.Xna.Framework.Input;

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
        public float gravity;
        
        
        public Vector2 velocity;
        public bool hasJumped;
        



        Rectangle border;
        public Player(List<Texture2D> textures)
        {
            playerTextures = new List<Texture2D>();
            playerTextures = textures;

            animationIdle = new Animation();
            animationRunningLeft = new Animation();
            animationRunningRight = new Animation();
            currentAnimation = new Animation();
           
            position = new Vector2(10, 600);
            
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
            gravity = 5f;
            hasJumped = true;


        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            position.Y += gravity;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                velocity.X = 5f;
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                velocity.X = -5f;
            else velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                
                position.Y -= 30f;
                velocity.Y = -10f;
                hasJumped = true;
            }
            
            if (hasJumped == true)
            {
                gravity = 0f;
                float i = 1;
                velocity.Y += 0.40f * i;
            }

            

            if (hasJumped == false)
            {
                gravity = 5f;
                velocity.Y = 0f;
            }



            
            if (velocity.X<0)
            {
                currentAnimation = animationRunningLeft;
                currentTexture = playerTextures[1];
            }
            else if (velocity.X>0)
            {
                currentAnimation = animationRunningRight;
                currentTexture = playerTextures[1];
            }
            else
            {
                currentAnimation = animationIdle;
                currentTexture = playerTextures[0];
            }

            
            
            
            collisionRectangle.X = (int)position.X+35;
            collisionRectangle.Y = (int)position.Y+15;
            border.X = collisionRectangle.X;
            border.Y = collisionRectangle.Y;
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            
            _spriteBatch.Draw(currentTexture, position, currentAnimation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
