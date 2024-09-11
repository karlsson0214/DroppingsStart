using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace DroppingsStart
{
    /// <summary>
    /// An object of the class represents a snake.
    /// </summary>
    internal class Snake
    {
        // Same image for all snakes.
        private static Texture2D texture;
        // Containts thes direction the snake is facing.
        private SpriteEffects spriteEffect;
        // The center of the snake.
        private Vector2 position;
        private float speed;
        private const int RIGHT = 1;
        private const int LEFT = 2;
        private int lastDirection = RIGHT;



        /// <summary>
        /// Create a snake object.
        /// </summary>
        /// <param name="position">The position of the snake, the postion of its center.</param>
        public Snake(Vector2 position)
        {
            // Look right by default.
            spriteEffect = SpriteEffects.None;

            this.position = position;
            speed = 200f;
        }
        /// <summary>
        /// Get the radius of the snake.
        /// </summary>
        public float Radius
        {
            get
            {
                return (texture.Width + texture.Height) / 4;
            }
        }
        /// <summary>
        /// Call this method once to set the texture for all snakes.
        /// </summary>
        /// <param name="texture"></param>
        public static void SetTexture2D(Texture2D texture)
        {
            Snake.texture = texture;
        }
        /// <summary>
        /// Call once per frame to update the snake's internal state.
        /// </summary>
        /// <param name="gameTime">A GameTime object that represents the time in the game.</param>
        public void Update(GameTime gameTime)
        {
            // Move the snake based on input.
            var keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Left))
            {
                // If the snake face a new direction, flip it.
                if (lastDirection == RIGHT)
                {
                    spriteEffect = SpriteEffects.FlipHorizontally;
                    lastDirection = LEFT;
                }
                position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                // If the snake face a new direction, flip it.
                if (lastDirection == LEFT)
                {
                    spriteEffect = SpriteEffects.None;
                    lastDirection = RIGHT;
                }
                position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            // Wrap the snake around the screen.
            if (position.X < 0)
            {
                position.X += 800;
            }
            else if (position.X > 800)
            {
                position.X -= 800;
            }
        }
        /// <summary>
        /// Call once per frame to draw the snake to the screen.
        /// </summary>
        /// <param name="spriteBatch">The screen of the current frame.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the snake, centered on the position.
            spriteBatch.Draw(texture, 
                position, 
                null,
                Color.White,
                0f,
                new Vector2(texture.Width / 2, texture.Height / 2),
                Vector2.One,
                spriteEffect,
                0f);
        }

        public bool CollidesWith(Plum plum)
        {
            return Vector2.Distance(position, plum.Position) < Radius + plum.Radius;
        }
    }
}
