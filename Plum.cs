using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace DroppingsStart
{
    /// <summary>
    /// An object of the class represents a plum.
    /// </summary>
    public class Plum
    {
        private static Texture2D texture;
        private Vector2 position;
        private float speed;
        // same gravity for all plums.
        private static float gravity = 100f;
        public static void SetTexture2D(Texture2D texture)
        {
            Plum.texture = texture;
        }
        /// <summary>
        /// Construct a plum.
        /// </summary>
        /// <param name="texture2D">The image of the plum.</param>
        /// <param name="position">The position of the plum.</param>
        public Plum(Vector2 position)
        {
            this.position = position;
            speed = 0f;
        }
        /// <summary>
        /// Read the radius of the plum.
        /// </summary>
        public float Radius
        {
            get
            {
                return (texture.Width + texture.Height) / 4;
            }
        }
        // <summary>
        /// Read the position of the plum.
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
        }
        /// <summary>
        /// Call once each frame to update the plum's internal state.
        /// </summary>
        /// <param name="gameTime">A GameTime object that represents the time in the game.</param>
        public void Update(GameTime gameTime)
        {
            speed += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        }
        /// <summary>
        /// Call once per frame to draw the plum to the screen.
        /// </summary>
        /// <param name="spriteBatch">The screen of the current frame.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,
                position,
                null,
                Color.White,
                0f,
                new Vector2(texture.Width / 2, texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);
        }
    }
}

