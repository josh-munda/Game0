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
        private Texture2D landAstro;
        private Texture2D jumpAstro;

        private double directionTimer;

        private double animationTimer;

        private short animationFrame = 0;


        private double jumpAnimationTimer;
        private bool isJumpAnimationComplete = false;

        /// <summary>
        /// The direction of the astronaut
        /// </summary>
        public Direction Direction;

        /// <summary>
        /// The position of the astronaut
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// If the astronaut is jumping or not
        /// </summary>
        public bool IsJumping { get; set; } = true;

        /// <summary>
        /// The texture to load in Game0 Draw()
        /// </summary>
        public Texture2D Texture
        {
            get
            {
                return IsJumping ? jumpAstro : landAstro;
            }
        }


        public AstroSprite(Texture2D landAstro, Texture2D jumpAstro)
        {
            this.landAstro = landAstro;
            this.jumpAstro = jumpAstro;
        }

        /// <summary>
        /// Loads the astronaut texture
        /// </summary>
        /// <param name="content">the ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            landAstro = content.Load<Texture2D>("land");
            jumpAstro = content.Load<Texture2D>("jump");
        }

        /// <summary>
        /// Updates the astronaut sprite to jump up and down
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public void Update(GameTime gameTime)
        {
            // Update jump animation timer
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            // Update jump animation timer only when the astronaut is jumping
            if (IsJumping)
            {
                jumpAnimationTimer += gameTime.ElapsedGameTime.TotalSeconds;

                if (!isJumpAnimationComplete && jumpAnimationTimer >= 0.1)
                {
                    animationFrame = (short)((animationFrame + 1) % 4); 
                    jumpAnimationTimer = 0;

                    if (animationFrame == 0) 
                    {
                        isJumpAnimationComplete = true; 
                        jumpAnimationTimer = 0; 
                    }
                }

                // Reset jump animation when jump animation is complete
                if (isJumpAnimationComplete)
                {
                    isJumpAnimationComplete = false; 
                    animationFrame = 0; 
                    IsJumping = false; 
                }

                Position.Y -= 2;
            }
            else Position.Y += 2;

            if (!IsJumping && animationTimer > 1.0) 
            {
                IsJumping = true;
                animationTimer = 0;
            }

            // Switch Directions every .8 seconds
            if (directionTimer > 0.8)
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
                directionTimer -= 0.8;
            }

        }

        /// <summary>
        /// Draws the animated astronaut sprite
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Texture2D currentTexture = IsJumping ? jumpAstro : landAstro;

            int frameWidth = currentTexture.Width / 4;
            Rectangle sourceRect = new Rectangle(animationFrame * frameWidth, 0, frameWidth, currentTexture.Height);

            spriteBatch.Draw(currentTexture, Position, sourceRect, Color.White);
        }
    }
}
