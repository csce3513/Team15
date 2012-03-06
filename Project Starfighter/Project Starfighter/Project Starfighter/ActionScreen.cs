using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project_Starfighter
{
    public class ActionScreen : GameScreen
    {
        KeyboardState keyboardState;
        Texture2D image;
        Rectangle imageRectangle;

        // Textures to hold the two background images
        Texture2D t2dBackground;
        Texture2D t2dGameScreen; // screen with game data
        SpriteFont spriteFont; // pericles font

        // the next 6 lines are related to the ship
        Player player;
        public int iPlayAreaTop = 30;
        public int iPlayAreaBottom = 660;

        // the next two lines determine how large the background will have when displayed
        private int widthOfBackgroundToBeDisplayed = 1280;
        private int heightOfBackgroundToBeDisplayed = 720;

        // the next four lines hold the width and height of the background images. 
        private int backgroundFileWidth = 0;
        private int backgroundFileHeight = 0;

        // aarao 3/5/2012
        public int desiredHeight; // The height of the screen which the game will be shown
        public int desiredWidth; // The width of the screen which the game will be shown
        public int leftLimitShipPosition; // The left position which the ship can't cross
        public int rightLimitShipPosition; // The right position which the ship can't cross
        public int upperLimitShipPosition; // The upper position which the ship can't cross
        public int lowerLimitShipPosition; // The lower position which the ship can't cross
        public int pixelsToMoveInYPosition; // The number of pixels the ship should move in the Y position when the up/down arrow is pressed
        public int pixelsToMoveInXPosition; // The number of pixels the ship should move in the X position when the left/right arrow is pressed
        public int pixelsToMoveBackgroundPosition; // The number of pixels that the background should constantly move

        //Mike Ammo variables
        int iBoltVerticalOffset = 12;   //added to ship position so it looks like it comes from front instead of cockpit
        static int iMaxBolts = 40;      //Maximum number of ammo
        Ammo[] bolts = new Ammo[iMaxBolts]; //array holding ammo
        float fBulletDelayTimer = 0.0f;     //timer delay for spriteanimator
        float fFireDelay = 0.15f;           //timer delay for firing rate
            
        // constructor for test purposes
        public ActionScreen()
            : base(null, null)
        {

        }
          

        // the next two lines defines how many pixels before the screen begins is the background image going to start
        private int iBackgroundOffset;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="image"></param>
        public ActionScreen(Game game, SpriteBatch spriteBatch, Texture2D image, ContentManager content, string sBackground)
            : base(game, spriteBatch)
        {
            this.image = image;
            t2dBackground = content.Load<Texture2D>(sBackground);
            backgroundFileWidth = t2dBackground.Width;
            backgroundFileHeight = t2dBackground.Height;
           // imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);

            // initialize player 
            player = new Player(content.Load<Texture2D>(@"Textures\PlayerShip"));

            t2dGameScreen = content.Load<Texture2D>(@"Textures\hud"); // load "HUB"
            spriteFont = content.Load<SpriteFont>(@"Fonts\Pericles"); // load font
            //initialize ammo
            bolts[0] = new Ammo(content.Load<Texture2D>(@"Textures\PlayerAmmo"));
            for (int x = 1; x < iMaxBolts; x++)
                bolts[x] = new Ammo();
        }

        //Helper function for updating Ammo
        protected void UpdateAmmo(GameTime gameTime)
        {
            // Updates the location of all of the active player bullets. 
            for (int x = 0; x < iMaxBolts; x++)
            {
                if (bolts[x].IsActive)
                    bolts[x].Update(gameTime);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            fBulletDelayTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //keyboardState = Keyboard.GetState();

            //if (keyboardState.IsKeyDown(Keys.Enter))
              //  game.Exit();

            BackgroundOffset += pixelsToMoveBackgroundPosition; // Automatically move background as soon as the game starts. 

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {

                if ((player.X - pixelsToMoveInXPosition) > leftLimitShipPosition) // Check if ship will be within left limit
                {
                    //BackgroundOffset -= 1;
                    player.X -= pixelsToMoveInXPosition;
                    if (pixelsToMoveBackgroundPosition > 3)
                    {
                        pixelsToMoveBackgroundPosition -= 1;
                    }

                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if ((player.X + pixelsToMoveInXPosition) < rightLimitShipPosition)// Check if ship will be within right limit
                {
                    BackgroundOffset += 1;
                    player.X += pixelsToMoveInXPosition;
                    if (pixelsToMoveBackgroundPosition < 6)
                    {
                        pixelsToMoveBackgroundPosition += 1;
                    }
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if ((player.Y - pixelsToMoveInYPosition) > upperLimitShipPosition) // Make sure ship does not go over upper part of the HUB
                {
                    player.Y -= pixelsToMoveInYPosition;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if ((player.Y + pixelsToMoveInYPosition) < lowerLimitShipPosition) // Make sure ship does not go over lower part of the HUB
                {
                    player.Y += pixelsToMoveInYPosition;
                }
            }
            CheckOtherKeys(Keyboard.GetState());

            UpdateAmmo(gameTime);


        }

        //Helper Function for Ammo Firing
        protected void FireBullet(int iVerticalOffset)
        {
            // Find and fire a free bullet
            for (int x = 0; x < iMaxBolts; x++)
            {
                if (!bolts[x].IsActive)
                {
                    bolts[x].Fire(player.X + 65, player.Y + iBoltVerticalOffset + iVerticalOffset);
                    break;
                }
            }
        }

        //Helper function for Ammo firing - player pressed the key
        protected void CheckOtherKeys(KeyboardState ksKeys)
        {

            // Space Bar or Game Pad A button fire the 
            // player's weapon.  The weapon has it's
            // own regulating delay (fBulletDelayTimer) 
            // to pace the firing of the player's weapon.
            if (ksKeys.IsKeyDown(Keys.Space))
            {
                if (fBulletDelayTimer >= fFireDelay)
                {
                    FireBullet(0);
                    fBulletDelayTimer = 0.0f;
                }
            }
        }


        public override void Draw(GameTime gameTime)
        {
            // Draw the background panel, offset by the player's location
            spriteBatch.Draw(t2dBackground,
                                new Rectangle(-1 * iBackgroundOffset,
                                0, backgroundFileWidth,
                                heightOfBackgroundToBeDisplayed),
                                Color.White);

            // If the right edge of the background panel will end 
            // within the bounds of the display, draw a second copy 
            // of the background at that location.
            if (iBackgroundOffset > backgroundFileWidth - widthOfBackgroundToBeDisplayed)
            {
                spriteBatch.Draw(t2dBackground,
                                    new Rectangle(
                                    (-1 * iBackgroundOffset) + backgroundFileWidth,
                                    0,
                                    backgroundFileWidth,
                                    heightOfBackgroundToBeDisplayed),
                                    Color.White);
            }
            //spriteBatch.Draw(image, imageRectangle, Color.White);
            spriteBatch.Draw(t2dGameScreen, new Rectangle(0, 0, 800, 600), Color.White); // draw game "HUB" 

            player.Draw(spriteBatch); // draw the ship

            // Draw any active player ammo on the screen
            for (int i = 0; i < iMaxBolts; i++)
            {
                // Only draw active bullets
                if (bolts[i].IsActive)
                {
                    bolts[i].Draw(spriteBatch);
                }
            }

            base.Draw(gameTime);
        }

        public int BackgroundOffset
        {
            get { return iBackgroundOffset; }
            set
            {
                iBackgroundOffset = value;
                if (iBackgroundOffset < 0)
                {
                    iBackgroundOffset += backgroundFileWidth;
                }
                if (iBackgroundOffset > backgroundFileWidth)
                {
                    iBackgroundOffset -= backgroundFileWidth;
                }
            }
        }

        public int BackgroundWidth
        {
            get { return widthOfBackgroundToBeDisplayed; }
            set { widthOfBackgroundToBeDisplayed = value; }
        }

        public int BackgroundHeight
        {
            get { return heightOfBackgroundToBeDisplayed; }
            set { heightOfBackgroundToBeDisplayed = value; }
        }

        public int BackgroundFileWidth
        {
            get { return backgroundFileWidth; }
            set { backgroundFileWidth = value; }
        }

        public int BackgroundFileHeight
        {
            get { return backgroundFileHeight; }
            set { backgroundFileHeight = value; }
        }


    }
}
