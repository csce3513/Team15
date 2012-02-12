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

namespace Project_Starfighter
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Starfighter : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // MenuComponent menuComponent;

        KeyboardState keyboardState;
        KeyboardState oldKeyboardState;

        PopUpScreen quitScreen;
        GameScreen activeScreen;
        StartScreen startScreen;
        ActionScreen actionScreen;
        InstructionsScreen instructionsScreen;
        CreditScreen creditScreen;
        HighScoreScreen highScoreScreen;

        public Starfighter()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            startScreen = new StartScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("alienmetal")
                , Content.Load<Texture2D>("header"));
            Components.Add(startScreen);
            startScreen.Hide();

            actionScreen = new ActionScreen(this, spriteBatch, Content.Load<Texture2D>("greenmetal"));
            Components.Add(actionScreen);
            actionScreen.Hide();

            instructionsScreen = new InstructionsScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("instruction"));
            Components.Add(instructionsScreen);
            instructionsScreen.Hide();

            creditScreen = new CreditScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("greenmetal"));
            Components.Add(creditScreen);
            creditScreen.Hide();

            highScoreScreen = new HighScoreScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("instruction"));
            Components.Add(highScoreScreen);
            highScoreScreen.Hide();

            quitScreen = new PopUpScreen(
                this,
                spriteBatch,
                Content.Load<SpriteFont>("menufont"),
                Content.Load<Texture2D>("alienmetal"));
            Components.Add(quitScreen);
            quitScreen.Hide();

            activeScreen = startScreen;
            activeScreen.Show();

            //string[] menuItems = { "Start Game", "Instructions", "High Scores", "Credit", "Quit" };

            //menuComponent = new MenuComponent(this, spriteBatch, Content.Load<SpriteFont>("menufont"), menuItems);
            //Components.Add(menuComponent);
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
            keyboardState = Keyboard.GetState();
            if (activeScreen == startScreen)
            {
                HandleStartScreen();
            }
            else if (activeScreen == actionScreen)
            {
                HandleActionScreen();
            }
            else if (activeScreen == quitScreen)
            {
                HandleQuitScreen();
            }
            else if (activeScreen == instructionsScreen)
            {
                HandleInstructionsScreen();
            }
            else if (activeScreen == creditScreen)
            {
                HandleCreditScreen();
            }
            else if (activeScreen == highScoreScreen)
            {
                HandleHighScoreScreen();
            }
            base.Update(gameTime);
            oldKeyboardState = keyboardState;
        }

        private void HandleStartScreen()
        {
            if (CheckKey(Keys.Enter))
            {
                if (startScreen.SelectedIndex == 0)
                {
                    activeScreen.Hide();
                    activeScreen = actionScreen;
                    activeScreen.Show();
                }
                if (startScreen.SelectedIndex == 1)
                {
                    activeScreen.Hide();
                    activeScreen = instructionsScreen;
                    activeScreen.Show();
                }
                if (startScreen.SelectedIndex == 2)
                {
                    activeScreen.Hide();
                    activeScreen = highScoreScreen;
                    activeScreen.Show();
                }
                if (startScreen.SelectedIndex == 3)
                {
                    activeScreen.Hide();
                    activeScreen = creditScreen;
                    activeScreen.Show();
                }
                if (startScreen.SelectedIndex == 4)
                {
                    this.Exit();
                }
            }
        }
        private void HandleInstructionsScreen()
        {
            if (CheckKey(Keys.Escape))
            {
                activeScreen.Hide();
                activeScreen = startScreen;
                activeScreen.Show();
            }
        }

        private void HandleCreditScreen()
        {
            if (CheckKey(Keys.Escape))
            {
                activeScreen.Hide();
                activeScreen = startScreen;
                activeScreen.Show();
            }
        }

        private void HandleHighScoreScreen()
        {
            if (CheckKey(Keys.Escape))
            {
                activeScreen.Hide();
                activeScreen = startScreen;
                activeScreen.Show();
            }
        }
        private void HandleActionScreen()
        {
            if (CheckKey(Keys.Escape))
            {
                activeScreen.Enabled = false;
                activeScreen = quitScreen;
                activeScreen.Show();
            }
        }

        private void HandleQuitScreen()
        {
            if (CheckKey(Keys.Enter))
            {
                if (quitScreen.SelectedIndex == 0)
                {
                    this.Exit();
                }
                if (quitScreen.SelectedIndex == 1)
                {
                    activeScreen.Hide();
                    activeScreen = actionScreen;
                    activeScreen.Show();
                }
            }
        }

        private bool CheckKey(Keys theKey)
        {
            return keyboardState.IsKeyUp(theKey) && oldKeyboardState.IsKeyDown(theKey);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null);
            base.Draw(gameTime);
            spriteBatch.End();

        }
    }
}
