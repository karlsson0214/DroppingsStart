using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DroppingsStart
{
    /// <summary>
    /// An object of the class represents a score in the game.
    /// </summary>
    internal class Score
    {
        private int score;
        private Vector2 position;
        private static SpriteFont font;

        public static void SetSpriteFont(SpriteFont font)
        {
            Score.font = font;
        }
        /// <summary>
        /// Construct a score table, to show in the game.
        /// </summary>
        /// <param name="font">A SpriteFont object.</param>
        /// <param name="position">The position of the score display.</param>
        public Score(Vector2 position)
        {
            this.position = position;
            score = 0;
        }
        /// <summary>
        /// Add points to the score.
        /// </summary>
        /// <param name="points">Point ta add.</param>
        public void Add(int points)
        {
            score += points;
        }

        /// <summary>
        /// Call once per frame to draw the score to the screen.
        /// </summary>
        /// <param name="spriteBatch">The screen of the current frame.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Score: " + score.ToString(), position, Color.White);
        }
    }
}
