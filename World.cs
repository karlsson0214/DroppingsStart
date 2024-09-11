using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DroppingsStart
{
    /// <summary>
    /// This class represents the game window and its contents.
    /// </summary>
    public class World
    {

        private Snake snake;
        private System.Random random;
        private List<Plum> plums;
        private Score score;
        private float minTimeToNextPlum = 2f;
        private float timeToNextPlum = 0f;
        private int width;
        private int height;

        /// <summary>
        /// Construct a game world.
        /// </summary>
        /// 
        /// <param name="width">The width of the game window.</param>
        /// <param name="height">The height of the game window.</param>
        public World(int width, int height)
        {
            random = new System.Random();
            plums = new List<Plum>();
            this.width = width;
            this.height = height;
        }
        /// <summary>
        /// Called by the Game instance when the game is initialized.
        /// </summary>

        public void Initialize()
        {
            Vector2 snakePosition = new Vector2(width / 2, height * 7 / 8);
            snake = new Snake(snakePosition);
            Vector2 scorePosition = new Vector2(50, 100);
            score = new Score(scorePosition);
        }

        /// <summary>
        /// Called by the Game instance when the game is loaded.
        /// </summary>
        /// 
        /// <param name="graphics">A GraphicsDeviceManager object that represents the graphics device.</param>
        /// <param name="content">A ContentManager object that represents the content manager.</param>
        public void LoadContent(GraphicsDeviceManager graphics, ContentManager content)
        {
            // TODO: use content to load your game content here
            Snake.SetTexture2D(content.Load<Texture2D>("snake"));
            Plum.SetTexture2D(content.Load<Texture2D>("plum"));
            Score.SetSpriteFont(content.Load<SpriteFont>("Score"));

        }
        /// <summary>
        /// Called by MonoGame once per frame to update the game.
        /// 
        /// Update your game objects here.
        /// </summary>
        /// <param name="gameTime"> A GameTime object is passed by MonoGame when this method is called.</param>
        public void Update(GameTime gameTime)
        {
            // Call Update on all game objects.
            UpdatePlums(gameTime);           
            snake.Update(gameTime);
        }



        private void UpdatePlums(GameTime gameTime)
        {
            // Add random plums to the screen.
            if (timeToNextPlum < 0)
            {
                float x = (float)(random.NextDouble() * width);
                plums.Add(new Plum(new Vector2(x, 0)));
                timeToNextPlum = minTimeToNextPlum + (float)random.NextDouble() * minTimeToNextPlum;
                minTimeToNextPlum *= 0.99f;
            }
            timeToNextPlum -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            // Update all plums.
            List<Plum> plumsToRemove = new List<Plum>();
            foreach (var plum in plums)
            {
                plum.Update(gameTime);
                if (plum.Position.Y > width + plum.Radius)
                {
                    plumsToRemove.Add(plum);
                }
            }
            foreach (var plum in plumsToRemove)
            {
                plums.Remove(plum);
            }

            // Check for collisions between the snake and the plums.
            for (int i = plums.Count - 1; i >= 0; i--)
            {
                if (snake.CollidesWith(plums[i]))
                {
                    plums.RemoveAt(i);
                    score.Add(1);
                }
            }
        }


        /// <summary>
        /// This method is called by MonoGame once per frame to draw the game.
        /// 
        /// Call Draw on all game objects here.
        /// </summary>
        /// <param name="gameTime">A GameTime object is passed by MonoGame when this method is called.</param>
        /// <param name="spriteBatch">A SpriteBatch object is passed by MonoGame when this method is called. 
        /// It represents the screen.</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            snake.Draw(spriteBatch);
            foreach (var plum in plums)
            {
                plum.Draw(spriteBatch);
            }
            score.Draw(spriteBatch);



            
        }
    }
}
