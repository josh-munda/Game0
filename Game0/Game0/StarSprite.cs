using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game0
{
    /// <summary>
    /// A class for the star sprite
    /// </summary>
    public class StarSprite
    {
        //private const float animationSpeed = 0.1f;

        //private double animationTimer;

        //private int animationFrame;

        private Vector2 position;

        private Texture2D texture;

        private bool flipped;

        /// <summary>
        /// Creates a new star sprite
        /// </summary>
        /// <param name="position">The position of the sprite on the screen</param>
        public StarSprite(Vector2 position)
        {
            this.position = position;
        }

        /// <summary>
        /// Loads the sprite texture using the provided ContentManager
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("star");
        }

        /*
        /// <summary>
        /// Updates the star sprite to spin
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {

        }
        */

        /// <summary>
        /// Draws the animated sprite using the supplied SpriteBatch
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">the spritebatch to render with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            /*
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if(animationTimer > animationSpeed)
            {
                animationFrame++;
                if(animationFrame > 8) animationFrame = 0;
                animationTimer -= animationSpeed;
            }
            */
            SpriteEffects spriteEffects = (flipped) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(texture, position, null, Color.White, 0, new Vector2(32,32), .5f, spriteEffects, 0);
        }
    }
}
