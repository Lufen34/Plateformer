using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Plateformer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public GameState gameState;
        KeyboardState oldKeyState;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameState = new GameState(this);
            oldKeyState = Keyboard.GetState();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            AssetManager.Load(Content);
            gameState.ChangeScene(GameState.SceneType.Menu);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (gameState.CurrentScene != null)
            {
                gameState.CurrentScene.Update(gameTime);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F1) && !oldKeyState.IsKeyDown(Keys.F1))
                gameState.ChangeScene(GameState.SceneType.Menu);
            if (Keyboard.GetState().IsKeyDown(Keys.F2) && !oldKeyState.IsKeyDown(Keys.F2))
                gameState.ChangeScene(GameState.SceneType.Game);
            if (Keyboard.GetState().IsKeyDown(Keys.F3) && !oldKeyState.IsKeyDown(Keys.F3))
                gameState.ChangeScene(GameState.SceneType.GameOver);

            oldKeyState = Keyboard.GetState();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (gameState.CurrentScene.CurrentType == GameState.SceneType.Menu)
                GraphicsDevice.Clear(Color.CornflowerBlue);
            else if (gameState.CurrentScene.CurrentType == GameState.SceneType.Game)
                GraphicsDevice.Clear(Color.Black);
            else if (gameState.CurrentScene.CurrentType == GameState.SceneType.GameOver)
                GraphicsDevice.Clear(Color.IndianRed);
            else
                GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            if (gameState.CurrentScene != null)
                gameState.CurrentScene.Draw(gameTime);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
