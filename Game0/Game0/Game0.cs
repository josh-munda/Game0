using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Game0
{
    public class Game0 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private StarSprite[] stars;
        private SpriteFont spriteFont;
        private SpriteFont exit;
        private AstroSprite astro;

        public Game0()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //System.Random random = new System.Random();
            stars = new StarSprite[]
            {
                new StarSprite(new Vector2(10,0)),
                new StarSprite(new Vector2(2,2)),
                new StarSprite(new Vector2(600,200)),
                new StarSprite(new Vector2(592,200)),
                new StarSprite(new Vector2(2,300)),
                new StarSprite(new Vector2(-6,300))
                
                /*
                new StarSprite(new Vector2((float)random.NextDouble() * GraphicsDevice.Viewport.Width, (float)random.NextDouble() * GraphicsDevice.Viewport.Height)),
                new StarSprite(new Vector2((float)random.NextDouble() * GraphicsDevice.Viewport.Width, (float)random.NextDouble() * GraphicsDevice.Viewport.Height)),
                new StarSprite(new Vector2((float)random.NextDouble() * GraphicsDevice.Viewport.Width, (float)random.NextDouble() * GraphicsDevice.Viewport.Height)),
                new StarSprite(new Vector2((float)random.NextDouble() * GraphicsDevice.Viewport.Width, (float)random.NextDouble() * GraphicsDevice.Viewport.Height))
                */
            };
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            foreach (var star in stars) star.LoadContent(Content);
            spriteFont = Content.Load<SpriteFont>("consolas");
            exit = Content.Load<SpriteFont>("exit");
            astro = new AstroSprite(Content.Load<Texture2D>("land"), Content.Load<Texture2D>("jump"))
            {
                IsJumping = true
            };
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

            if(keyboardState.IsKeyDown(Keys.Escape) || gamePadState.Buttons.B == ButtonState.Pressed)
            {
                Exit();
            }

            // TODO: Add your update logic here
            //foreach(var star in stars) star.Update(gameTime);
            astro.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Vector2 center = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            Vector2 astroSize = new Vector2(32, 32);

            Vector2 astroPosition = center - (astroSize / 2);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (var star in stars) star.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(spriteFont, $"Star Bounce", new Vector2(253, 100), Color.LightGray);
            spriteBatch.DrawString(spriteFont, $"Star Bounce", new Vector2(250, 100), Color.White);
            spriteBatch.DrawString(exit, $"Click Escape or B to Exit", new Vector2(615, 464), Color.White);
            spriteBatch.Draw(astro.Texture, astroPosition, null, Color.White, 0f, Vector2.Zero,
                             new Vector2(astroSize.X / astro.Texture.Width, astroSize.Y / astro.Texture.Height),
                             SpriteEffects.None, 0f);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}