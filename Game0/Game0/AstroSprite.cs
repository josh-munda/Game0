using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game0
{
    public enum Direction
    {
        Down = 0,
        Up = 1,
    }

    /// <summary>
    /// A class representing an astronaut sprite
    /// </summary>
    public class AstroSprite
    {
        private Texture2D texture;

        private double directionTimer;

        private double animationTimer;

        private short animationFrame = 1;

        /// <summary>
        /// The direction of the astronaut
        /// </summary>
        public Direction Direction;

        /// <summary>
        /// The position of the astronaut
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Loads the astronaut texture
        /// </summary>
        /// <param name="content">the ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("astro");
        }

        /// <summary>
        /// Updates the astronaut sprite to jump up and down
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public void Update(GameTime gameTime)
        {
            // Update direction timer
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;

            // Switch Directions every .5 seconds
            if(directionTimer > 0.5)
            {
                switch (Direction)
                {
                    case Direction.Up:
                        Direction = Direction.Down;
                        break;

                    case Direction.Down:
                        Direction = Direction.Up;
                        break;
                }
                directionTimer -= 0.5;
            }
        }

        /// <summary>
        /// Draws the animated astronaut sprite
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Update animation timer
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            // Update animation frame
            if(animationTimer > 0.5)
            {
                animationFrame++;
                if (animationFrame > 3) animationFrame = 1;
                animationTimer -= 0.5;
            }

            // draw the sprite
            var rect = new Rectangle(animationFrame * 32, (int)Direction * 32, 32, 32);
            spriteBatch.Draw(texture, Position, rect, Color.White);
        }
    }
}
