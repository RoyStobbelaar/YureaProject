using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using XRpgLibrary;
using YureaProject.GameScreens;

namespace YureaProject
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Fields & Properties
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public GameStateManager stateManager;
        public TitleScreen titleScreen;
        public StartMenuScreen startMenuScreen;
        public GamePlayScreen gamePlayScreen;
        public CharacterGeneratorScreen characterGeneratorScreen;
        public SkillScreen skillScreen;
        public LoadGameScreen loadGameScreen;

        #endregion

        #region ScreenSize Region

        const int screenWidth = 1024;
        const int screenHeight = 768;
        public readonly Rectangle gameScreen;

        private float fps;
        private float updateInterval = 1.0f;
        private float timeSinceLastUpdate = 0.0f;
        private float frameCount = 0;

        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            gameScreen = new Rectangle(0, 0, screenWidth, screenHeight);

            Content.RootDirectory = "Content";

            Components.Add(new InputHandler(this));
            stateManager = new GameStateManager(this);
            Components.Add(stateManager);
            titleScreen = new TitleScreen(this, stateManager);
            startMenuScreen = new StartMenuScreen(this, stateManager);
            gamePlayScreen = new GamePlayScreen(this, stateManager);
            characterGeneratorScreen = new CharacterGeneratorScreen(this, stateManager);
            skillScreen = new SkillScreen(this, stateManager);
            loadGameScreen = new LoadGameScreen(this, stateManager);

            stateManager.ChangeState(titleScreen);

            this.IsFixedTimeStep = false;
            graphics.SynchronizeWithVerticalRetrace = false;
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

            DataManager.ReadEntityData(Content);

            DataManager.ReadArmorData(Content);
            DataManager.ReadWeaponData(Content);
            DataManager.ReadShieldData(Content);

            DataManager.ReadChestData(Content);
            DataManager.ReadKeyData(Content);

            DataManager.ReadSkillData(Content);


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCount++;
            timeSinceLastUpdate += elapsed;

            if(timeSinceLastUpdate > updateInterval)
            {
                fps = frameCount / timeSinceLastUpdate;
#if XBOX360
                System.diagnostics.Debug.WriteLine("FPS: " + fps.ToString());
#else
                this.Window.Title = "FPS: " + fps.ToString();
#endif
                frameCount = 0;
                timeSinceLastUpdate -= updateInterval;
            }
        }
    }
}
