//-------------------------------------------------------------------------------------------------------------------------------------------------
//FOR THIS GAME DEVELOPMENT THE FOLLOWING WEBSITES WERE USED AS A SOURCE OF SOUNDS : http://www.nifter.com/cartoons_looney_tunes_bugs_bunny_5.htm, http://www.audiomicro.com 
//FOR THIS GAME DEVELOPMENT THE FOLLOWING WEBSITE WAS USED AS A SOURCE OF IMAGES, AND AS A REFERENCE: http://xnaresources.com/default.asp?page=Tutorial:StarDefense:1 
// AS WELL AS http://www.google.com/imgres?hl=en&safe=active&biw=1366&bih=681&tbm=isch&tbnid=d3yQtASzGG76FM:&imgrefurl=http://mb50.wordpress.com/category/geopolitics/energy-geopolitics/wind/&docid=IsRqNQ7oJCdjPM&imgurl=http://mb50.files.wordpress.com/2011/12/image42.png&w=530&h=370&ei=_rKcT4eFJ8Wq2gWiy5zoDQ&zoom=1&iact=hc&vpx=403&vpy=313&dur=1051&hovh=187&hovw=269&tx=167&ty=107&sig=118259196024402707009&page=2&tbnh=151&tbnw=201&start=20&ndsp=24&ved=1t:429,r:13,s:20,i:146
//-------------------------------------------------------------------------------------------------------------------------------------------------

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
        private GraphicsDeviceManager graphics; // handles the configuration and management of the graphics device
        public SpriteBatch spriteBatch; // enables a group of sprites to be drawn using the same settings
        
        // creates the song 
        private Song mainMenuSong; // song for when the main menu is played
        private bool startMenuSong = true; // make start menu sound playable from start of application
        private Song levelOneSong; // song for when the level one is played
        private bool startLevelOneSong = false; // make level one sound unplayable from start of applicaion
    
        // create the instruction page stuff
        public Texture2D bookpages; //InstructionBook background

        private Texture2D t2dGameScreen; // create variable that will hold the screen with game data
        public SpriteFont spriteFont; // create a sprite font that will be initiated to pericles font

        private KeyboardState keyboardState; // represents the state of keystrokes
        private KeyboardState oldKeyboardState; // represents the state of keystrokes

        private PopUpScreen quitScreen; // create instance of popup screen that will hold the quit screen
        private GameScreen activeScreen; 
        private StartScreen startScreen; // create instance of start screen that will hold the first screen to be displayed in the game
        private ActionScreen actionScreen; // create instance of game screen that will hold the game 
        private InstructionsScreen instructionsScreen; // create instance of the instruction screen that will hold istructions for the game
        private CreditScreen creditScreen; // create instance of the credits screen that will hold the credits for the game 
        private HighScoreScreen highScoreScreen; // create instance of the high score screen that will hold the highest scores in the game


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
            // set display resolution - important for the first - menu screen
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();
            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //load song info
            mainMenuSong = Content.Load<Song>(@"Audio\Intro"); // load menu song
            levelOneSong = Content.Load<Song>(@"Audio\LevelOne"); // load level one song
            MediaPlayer.IsRepeating = true; // define that long is to restart once it is over

            
            t2dGameScreen = Content.Load<Texture2D>(@"Textures\hud"); // load hud image
            spriteFont = Content.Load<SpriteFont>(@"Fonts\Pericles"); // load font type
            

            startScreen = new StartScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("menu"));
            Components.Add(startScreen);
            startScreen.Hide();

            actionScreen = new ActionScreen(this, spriteBatch, Content.Load<Texture2D>(@"Textures\PrimaryBackground"), Content, @"Textures\PrimaryBackground");
            Components.Add(actionScreen);
            actionScreen.Hide();

            instructionsScreen = new InstructionsScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("InstructionBook"));
            Components.Add(instructionsScreen);
            instructionsScreen.Hide();

            creditScreen = new CreditScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("menu"));
            Components.Add(creditScreen);
            creditScreen.Hide();

            highScoreScreen = new HighScoreScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("InstructionBook"));
            Components.Add(highScoreScreen);
            highScoreScreen.Hide();

            quitScreen = new PopUpScreen(
                this,
                spriteBatch,
                Content.Load<SpriteFont>("menufont"),
                Content.Load<Texture2D>("alienmetal"));
            Components.Add(quitScreen);
            quitScreen.Hide();


            actionScreen.desiredHeight = 600; // set the height of the action screen
            actionScreen.desiredWidth = 800; // set the width of the action screen
            
            // set the display resolution
            graphics.PreferredBackBufferHeight = actionScreen.desiredHeight;
            graphics.PreferredBackBufferWidth = actionScreen.desiredWidth;
            graphics.ApplyChanges();
            actionScreen.lowerLimitShipPosition = actionScreen.desiredHeight - 53; // sets lowest position of the ship to be 53 pixels less than height of game because of the HUB
            actionScreen.upperLimitShipPosition = 36; // sets highest position that the ship can move 36 because of the HUB
            actionScreen.leftLimitShipPosition = 0; // does not allow ship to move outside of the screen in the left side
            actionScreen.rightLimitShipPosition = actionScreen.desiredWidth - 72; // 72 is the size of the ship sprite. 
            actionScreen.pixelsToMoveInYPosition = 3; // it is how many pixels - how fast - i want the ship to move in the y position
            actionScreen.pixelsToMoveInXPosition = 3; // it is how many pixels - how fast - i want the ship to move in the x position 
            actionScreen.pixelsToMoveBackgroundPosition = 6; // defines the speed that the background should be constantly moving
            activeScreen = startScreen; // set the active screen to the start screen - this is the first screen that will be shown for the user
            activeScreen.Show(); // show the first screen

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

            // if player is alive and boss was not defeated yet
            if (!(actionScreen.isOutOfLives || actionScreen.isBossDefeated ))
            {
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
            }
            else // if the player is out of lifes or if player defeated the boss
            {
                actionScreen.isOutOfLives = false; // set out of lives variable back to false
                activeScreen.Hide(); // hide the active screen - the game screen
                activeScreen.Enabled = false; // deseable the active screen - the game screen
                activeScreen = startScreen; // set the active screen back to the start screen
                activeScreen.Enabled = true; // enable the active screen - now start screen - back
                actionScreen.Marron.Stop(); // stop enemy 2 sound effect before playing menu sound
                actionScreen.UltraMarron.Stop(); // stop enemy 2 sound effect before playing menu sound
                actionScreen.YouFiredSound.Stop(); // stop boss's sound effect before playing menu sound
                actionScreen.AlienSound.Stop(); // stop boss's phase "song" before playing menu sound (it is not a song it is a soundEffectInstance in a loop)
                actionScreen.DealSound.Stop(); // stop boss's sound effect before playing menu sound
                LoadContent(); // reset the game 
                
                MediaPlayer.Play(mainMenuSong); // play main menu song
                activeScreen.Show(); // show screen
                
            }
            base.Update(gameTime);
            oldKeyboardState = keyboardState;

        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleStartScreen()
        {
            if (startMenuSong == true)
            {
                startMenuSong = false;
                MediaPlayer.Play(mainMenuSong);
            }
            if (CheckKey(Keys.Enter))
            {
                if (startScreen.SelectedIndex == 0)
                {
                    activeScreen.Hide();
                    startLevelOneSong = true;
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
            if (startLevelOneSong == true)
            {
                MediaPlayer.Play(levelOneSong);
                startLevelOneSong = false;
            }

            if (actionScreen.isBossActive)
            {
                MediaPlayer.Stop();
            }

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

           // spriteBatch.Draw(t2dGameScreen, new Rectangle(0, 0, 800, 600), Color.White); // draw game "HUB" 

          //  player.Draw(spriteBatch); // draw the ship
           
            base.Draw(gameTime);
            spriteBatch.End();

        }
    }
}
