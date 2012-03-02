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
        //Background background; // create a background object

        // the next 6 lines are related to the ship
        Player player;
        public int iPlayAreaTop = 30;
        public int iPlayAreaBottom = 660;
        
        Texture2D t2dGameScreen; // screen with game data
        SpriteFont spriteFont; // pericles font

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

        /// <summary>
        /// 
        /// </summary>
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
            // set display resolution
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
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

        //  background = new Background(Content,
          //                                    @"Textures\PrimaryBackground"); // call background constructor

            t2dGameScreen = Content.Load<Texture2D>(@"Textures\hud"); // load "HUB"
            spriteFont = Content.Load<SpriteFont>(@"Fonts\Pericles"); // load font

            // initialize player 
            player = new Player(Content.Load<Texture2D>(@"Textures\PlayerShip"));

            startScreen = new StartScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("menu"));
            Components.Add(startScreen);
            startScreen.Hide();

            actionScreen = new ActionScreen(this, spriteBatch, Content.Load<Texture2D>(@"Textures\PrimaryBackground"), Content, @"Textures\PrimaryBackground");
            Components.Add(actionScreen);
            actionScreen.Hide();

            instructionsScreen = new InstructionsScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("menu"));
            Components.Add(instructionsScreen);
            instructionsScreen.Hide();

            creditScreen = new CreditScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("menu"));
            Components.Add(creditScreen);
            creditScreen.Hide();

            highScoreScreen = new HighScoreScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("menu"));
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

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        private void HandleInstructionsScreen()
        {
            if (CheckKey(Keys.Escape))
            {
                activeScreen.Hide();
                activeScreen = startScreen;
                activeScreen.Show();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleCreditScreen()
        {
            if (CheckKey(Keys.Escape))
            {
                activeScreen.Hide();
                activeScreen = startScreen;
                activeScreen.Show();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleHighScoreScreen()
        {
            if (CheckKey(Keys.Escape))
            {
                activeScreen.Hide();
                activeScreen = startScreen;
                activeScreen.Show();
            }
        }

        /// <summary>
        /// 
        /// </summary>
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
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Draw(t2dGameScreen, new Rectangle(0, 0, 800, 600), Color.White); // draw game "HUB" 

            player.Draw(spriteBatch); // draw the ship
           
            base.Draw(gameTime);
            spriteBatch.End();

        }
    }
}
