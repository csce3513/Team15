using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Project_Starfighter
{
    public class ActionScreen : GameScreen
    {
        //create sound effects
        private SoundEffect laserFire;
        private SoundEffect sorry;
        private SoundEffect maroon;
        private SoundEffect ultraMaroon;
        private SoundEffect playerDestroyed;
        private SoundEffect enemy1Destroyed;
        private SoundEffect youFired;
        private SoundEffect alien;
        private SoundEffect deal;
        private SoundEffectInstance maroonSoundInstance; // the type SoundEffectInstance gives options to modify values such as pitch and volume
        private SoundEffectInstance ultraMaroonSoundInstance; // the type SoundEffectInstance gives options to modify values such as pitch and volume
        private SoundEffectInstance sorrySoundInstance; // the type SoundEffectInstance gives options to modify values such as pitch and volume
        public SoundEffectInstance youFiredSoundInstance;
        private SoundEffectInstance alienSoundInstance;
        private SoundEffectInstance dealSoundInstance;
        
        private TimeSpan maroonSoundDuration; // used to check the duration of the sound maroon. 
        private DateTime maroonTimeControll; // holds the datetime when the maroon sound is played

        private TimeSpan youFiredSoundDuration;
        //private DateTime youFiredTimeControll;

        private int startNewWaveCounter = 0; // Counter used to start the first wave
        //KeyboardState keyboardState;
        //private Texture2D image;
        //Rectangle imageRectangle;

        
        private Texture2D gameBackgroundImage; // texture to hold background image
        private Texture2D gameHudImage; // texture to hold screen with game data
        private SpriteFont spriteFont; // pericles font

        // the next two lines determine how large the background should be when displayed
        private int widthOfBackgroundToBeDisplayed = 1280;
        private int heightOfBackgroundToBeDisplayed = 720;

        // the next two lines hold the original width and height of the background image files. 
        private int backgroundFileWidth = 0;
        private int backgroundFileHeight = 0;

        // defines how many pixels before the screen begins is the background image going to start
        private int gameBackgroundOffset;
 

        public int desiredHeight; // The height of the screen in which the game will be shown
        public int desiredWidth; // The width of the screen in which the game will be shown
        public int leftLimitShipPosition; // The left position which the ship can't cross
        public int rightLimitShipPosition; // The right position which the ship can't cross
        public int upperLimitShipPosition; // The upper position which the ship can't cross
        public int lowerLimitShipPosition; // The lower position which the ship can't cross
        public int pixelsToMoveInYPosition; // The number of pixels the ship should move in the Y position when the up/down arrow is pressed
        public int pixelsToMoveInXPosition; // The number of pixels the ship should move in the X position when the left/right arrow is pressed
        public int pixelsToMoveBackgroundPosition; // The number of pixels that the background should constantly move

        // Create an instance of the class HudValues that will hold the values to be displayed on the screen
        public HudValues hud = new HudValues(); // creates new hud values (lives, credits...)

        //Mike Ammo variables
        private int iBoltVerticalOffset = 12;   //added to ship position so it looks like it comes from front instead of cockpit
        private static int iMaxBolts = 40;      //Maximum number of ammo
        private Ammo[] bolts = new Ammo[iMaxBolts]; //array holding ammo
        private float fBulletDelayTimer = 0.0f;     //timer delay for spriteanimator
        private float fFireDelay = 0.15f;           //timer delay for firing rate

        //For enemy type 1
        private int numberOfEnemiesType1 = 10; // define the number of enemies of type 1 to create
        private int numberOfActiveEnemiesType1 = 10; // holds the number of active enemies of type 1
        private static int iTotalMaxEnemies = 10;
        private Enemy1[] EnemiesType1 = new Enemy1[iTotalMaxEnemies]; // create an array of enemies type 1

        //For enemy type 2
        private int numberOfEnemiesType2 = 6; // define the number of enemies of type 2 to create
        private int numberOfActiveEnemiesType2 = 6; // holds the number of active enemies of type 1
        private static int iTotalMaxEnemies2 = 6;
        private Enemy2[] EnemiesType2 = new Enemy2[iTotalMaxEnemies2];

        //for keeping track of the end of a wave
        private int endOfWave1 = 0;
        private int endOfWave2 = 0;
        private bool isWave1Over = false;
        private bool isWave2Over = false;

        // create an instance of the class player
        private Player player;

        private Boss boss; // create a boss
        public bool isBossActive = false;
        private int hitsByBoss = 0;
        private bool isPlayerHitTwiceByBoss = false;
        
        public bool isOutOfLives = false; // used to restart menu screen in case player is out of lives.
        public bool isBossDefeated = false;

        // generate a random number to control when enemy shoots
        private int numb;
        private Random randomNumber = new Random();
        private int hitsByEnemy2 = 0;
        public bool isPlayerHitTwiceByEnemy2 = false; // tells if player is hit twice by enemy2
               
        // constructor for test purposes
        public ActionScreen()
            : base(null, null)
        {

        }

        // Constructor
        public ActionScreen(Game game, SpriteBatch spriteBatch, Texture2D background, ContentManager content, string sBackground)
            : base(game, spriteBatch)
        {
            gameBackgroundImage = background; // give an image to the background
            backgroundFileWidth = gameBackgroundImage.Width; // give the width to the background
            backgroundFileHeight = gameBackgroundImage.Height; // give the height to the background

            player = new Player(content.Load<Texture2D>(@"Textures\PlayerShip")); // initialize player 

            // fill EnemiesType1 array with enemies of type 1
            for (int i = 0; i < iTotalMaxEnemies; i++)
            {
                EnemiesType1[i] = new Enemy1(content.Load<Texture2D>(@"Textures\TurtleRobot"), 0, 0, 73, 45, 1);
            }

            // fill EnemiesType2 array with enemies of type 2
            for (int i = 0; i < iTotalMaxEnemies2; i++)
            {
                EnemiesType2[i] = new Enemy2(content.Load<Texture2D>(@"Textures\spacerabbit"), 0, 0, 46, 75, 1);
                EnemiesType2[i].InitializeBullets(content.Load<Texture2D>(@"Textures\PlayerAmmo"));
            }

            boss = new Boss(content.Load<Texture2D>(@"Textures\donald2"), 0, 0, 150, 104, 1); // Create boss
            boss.InitializeBullets(content.Load<Texture2D>(@"Textures\PlayerAmmo")); // 4/27 innitialize sprites for the boss's bullets

            // set boss's limits in y axes to limits of the ship
            boss.lowerLimitPosition = lowerLimitShipPosition;
            boss.upperLimitPosition = upperLimitShipPosition;

            gameHudImage = content.Load<Texture2D>(@"Textures\hud"); // load "HUD"
            spriteFont = content.Load<SpriteFont>(@"Fonts\Pericles"); // load font
            
            //initialize ammo
            bolts[0] = new Ammo(content.Load<Texture2D>(@"Textures\PlayerAmmo"));

            for (int x = 1; x < iMaxBolts; x++)
                bolts[x] = new Ammo(content.Load<Texture2D>(@"Textures\PlayerAmmo"));

            // load content for sound effects
            laserFire = content.Load<SoundEffect>(@"Audio\Laser");
            enemy1Destroyed = content.Load<SoundEffect>(@"Audio\Enemy1Explosion");
            playerDestroyed = content.Load<SoundEffect>(@"Audio\ShipExplosion");
            sorry = content.Load<SoundEffect>(@"Audio\sorryLouder");
            maroon = content.Load<SoundEffect>(@"Audio\maroonLouder");
            ultraMaroon = content.Load<SoundEffect>(@"Audio\ultraMaroonLouder");
            
            youFired = content.Load<SoundEffect>(@"Audio\YouFiredLoud");
            youFiredSoundInstance = youFired.CreateInstance();
            youFiredSoundInstance.Volume = 1;
            youFiredSoundInstance.Pitch = 0.1f;

            alien = content.Load<SoundEffect>(@"Audio\Alien");
            alienSoundInstance = alien.CreateInstance();
            alienSoundInstance.Volume = 1;

            deal = content.Load<SoundEffect>(@"Audio\deal");
            dealSoundInstance = deal.CreateInstance();
            dealSoundInstance.Volume = 1;

            youFiredSoundDuration = alien.Duration;

            maroonSoundInstance = maroon.CreateInstance(); // Create maroon sound instance
            ultraMaroonSoundInstance = ultraMaroon.CreateInstance(); // create ultra maroon sound instance
            sorrySoundInstance = sorry.CreateInstance(); // create sorry sound instance
            
            maroonSoundDuration = maroon.Duration; // get duration of maroon effect

            maroonSoundInstance.Volume = 1; // set volume 0 - 1
            ultraMaroonSoundInstance.Volume = 1; // set volume 0 - 1 
        }

        //Helper function for updating Ammo
        protected void UpdateAmmo(GameTime gameTime)
        {
            // Updates the location of all of the active player bullets. 
            for (int x = 0; x < iMaxBolts; x++)
            {
                if (bolts[x].IsActive)
                {
                    bolts[x].Update(gameTime);
                }
            }
        }

        // check if player hits any of the enemies
        protected void CheckPlayerHits()
        {
            //check only if wave 1 is not over
            if (!isWave1Over)
            {
                // check for all enemies
                for (int x = 0; x < iTotalMaxEnemies; x++)
                {
                    // check if enemy type 1 is active
                    if (EnemiesType1[x].IsActive)
                    {
                        // If the enemy and ship sprites  collide...
                        if (Intersects(player.BoundingBox, EnemiesType1[x].CollisionBox))
                        {
                            DestroyEnemy(x); // destroy enemy 
                            UpdateLives(); // update lives to -= 1
                            playerDestroyed.Play(); // play sound that represents player being hit
                            return;
                        }

                    }
                }
            }

            // check if boss is active
            if (isBossActive)
            {
                // check if boss is in contact with player
                if (Intersects(player.BoundingBox, boss.CollisionBox))
                {
                    boss.Life -= 10; // subtract 10 from the life of the boss

                    // check if boss has no life if so destroy boss
                    if (boss.Life <= 0)
                    {
                        DestroyBoss(); // destroy boss
                    }

                    UpdateLives(); // update user lives

                    return;
                }
            }

            // only check collision with enemy in wave 2 if wave is not over
            if (!isWave2Over)
            {
                // check each enemy in wave 2
                for (int x = 0; x < iTotalMaxEnemies2; x++)
                {
                    // check if the enemy is active
                    if (EnemiesType2[x].IsActive)
                    {
                        // If the enemy2 and ship sprites  collide...
                        if (Intersects(player.BoundingBox, EnemiesType2[x].CollisionBox))
                        {
                            DestroyEnemy2(x); // destroy enemy 2
                            UpdateLives(); // update lives
                            playerDestroyed.Play(); // play sound
                            return;
                        }
                    }
                }
            }
        }
      
        // update player lives
        private void UpdateLives()
        {
            // check if player has any life left
            if (hud.lives > 0)
            {
                hud.lives -= 1;  // subtract one life from player.
            }
            else
            {
                isOutOfLives = true; // allow starfighter driver class to change screen to menu CALL GAME OVER SCREEN FROM HERE TOO
                hud.resetHud(); // reset values in hud
            }
        }
       
        public void newGame()
        {
            for (int x = 0; x < numberOfEnemiesType1; x++)
                EnemiesType1[x].newGame();
            
        }
        
        // method used to stop enemy 2 sound in case screen has to change to game over screen or any other screen. It is called from starfighter
        public SoundEffectInstance Marron
        {
            get { return maroonSoundInstance; }
            set { maroonSoundInstance = value; }
        }

        // method used to stop enemy 2 sound in case screen has to change to game over screen or any other screen. It is called from starfighter
        public SoundEffectInstance UltraMarron
        {
            get { return ultraMaroonSoundInstance; }
            set { ultraMaroonSoundInstance = value; }
        }

        public SoundEffectInstance YouFiredSound
        {
            get { return youFiredSoundInstance; }
            set { youFiredSoundInstance = value; }
        }

        public SoundEffectInstance AlienSound
        {
            get { return alienSoundInstance; }
            set { alienSoundInstance = value; }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime); // allows the game component to update itself

            fBulletDelayTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
       
            BackgroundOffset += pixelsToMoveBackgroundPosition; // Automatically move background as soon as the game starts. 

            // decides what happens when left arrow key is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if ((player.X - pixelsToMoveInXPosition) > leftLimitShipPosition) // Check if ship will be within left limit
                {
                    player.X -= pixelsToMoveInXPosition; //  move ship to the left
                }
            }

            // decides what happens when right arrow key is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if ((player.X + pixelsToMoveInXPosition) < rightLimitShipPosition)// Check if ship will be within right limit
                {
                    BackgroundOffset += 1; // gives the impression that the ship is moving faster by moving background faster
                    player.X += pixelsToMoveInXPosition; // moves ship to the right
                }
            }

            // decides what happens when up arrow key is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if ((player.Y - pixelsToMoveInYPosition) > upperLimitShipPosition) // Make sure ship does not go over upper part of the HUB
                {
                    player.Y -= pixelsToMoveInYPosition;
                }
            }

            // decides what happens when down arrow key is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if ((player.Y + pixelsToMoveInYPosition) < lowerLimitShipPosition) // Make sure ship does not go over lower part of the HUB
                {
                    player.Y += pixelsToMoveInYPosition;
                }
            }
            CheckOtherKeys(Keyboard.GetState());

            UpdateAmmo(gameTime); // update position of active player bullets

            // Update position of enemy 2 bullets and randomly shoot from enemy 2
            if (isWave1Over) // enemy will shoot only after wave 2 is over
            {
                //4/19/2012 update position of bullets sent from enemy 2
                for (int i = 0; i < iTotalMaxEnemies2; i++)
                {
                    EnemiesType2[i].UpdateAmmo(gameTime); // update position of enemy 2 bullets
                    
                    // check if wave 2 is not over if so enemy 2 need to shoot
                    if(!isWave2Over)
                    {
                        numb = (int)randomNumber.Next(1000);
                        if (numb % 49 == 0) // shoot only if random number is a divisible by 49
                        {
                            EnemiesType2[i].FireBullet(0, laserFire); // fire
                            EnemiesType2[i].BulletDelayTimer = 0.0f; // delay between bullets
                        }
                    }
                }
            }

            // Only need to update and shoot bullets if boss is active
            if (boss.IsActive)
            {
                boss.UpdateAmmo(gameTime);// 4/27 update position of bullets sent from boss

                // shoot code below
                numb = (int)randomNumber.Next(1000);
                if (numb % 10  == 0)
                {
                    boss.FireBullet(0, laserFire);
                    boss.BulletDelayTimer = 0.0f;
                }
            }

            CheckBulletHits();// check if any bullets are hittin anybody
            
            CheckPlayerHits(); // check if player is colliding with any enemy

            //update values necessary to start wave 2
            if (!isWave1Over)
            {
                CheckEndofWave1();
            }

            //update values necessary to start boss
            if (!isWave2Over)
            {
                CheckEndOfWave2();
            }

            // check if it is beginning of game
            if (startNewWaveCounter == 0)
            {
                StartNewWave();
                startNewWaveCounter = 1;
            }

            // update enemies 1 positions
            if (!isWave1Over)
            {
                for (int i = 0; i < iTotalMaxEnemies; i++)
                {
                    if (EnemiesType1[i].IsActive)
                    {
                        EnemiesType1[i].Update(gameTime,
                          BackgroundOffset);
                    }
                }
            }

            // update enemies 2 positions
            if (!isWave2Over)
            {
                for (int i = 0; i < iTotalMaxEnemies2; i++)
                {
                    if (EnemiesType2[i].IsActive)
                        EnemiesType2[i].Update(gameTime);
                }
            }

            // Update boss
            if (boss.IsActive)
                boss.Update(gameTime);

        }

        // update values for wave 1, and check if it is over
        public void CheckEndofWave1()
        {
            if (endOfWave1 == 10)
            {
                isWave1Over = true;
                endOfWave1++;
                sorrySoundInstance.Volume = 1;
                sorrySoundInstance.Play();
                StartSecondWave();
                

            }
        }

        //update values for wave 2, and check if it is over
        public void CheckEndOfWave2()
        {
            if (endOfWave2 == 6)
            {
                isWave2Over = true;
                endOfWave2++;
                alienSoundInstance.IsLooped = true;
                alienSoundInstance.Play();
                StartBoss();
            }
        }

        // start the boss
        private void StartBoss()
        {
            isBossActive = true;
            boss.Generate(0);
        }

        // generate enemies of type 1
        protected void GenerateEnemies1()
        {
            if (numberOfEnemiesType1 < iTotalMaxEnemies)
                numberOfEnemiesType1++;

            numberOfActiveEnemiesType1 = 0;

            for (int x = 0; x < numberOfEnemiesType1; x++)
            {
                EnemiesType1[x].Generate(x);
                numberOfActiveEnemiesType1 += 1;
            }
        }

        // generate enemies of type 2
        protected void GenerateEnemies2()
        {
            if (numberOfEnemiesType2 < iTotalMaxEnemies2)
                numberOfEnemiesType2++;

            numberOfActiveEnemiesType2 = 0;

            for (int x = 0; x < numberOfEnemiesType2; x++)
            {
                EnemiesType2[x].Generate(x);
                numberOfActiveEnemiesType2 += 1;
            }
        }

        // start wave 1
        public void StartNewWave()
        {
            GenerateEnemies1();
        }


        //Start wave 2
        public void StartSecondWave()
        {
            GenerateEnemies2();
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
                    laserFire.Play();
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

        // method for detecting item collisions
        protected bool Intersects(Rectangle rectA, Rectangle rectB)
        {
            // Returns True if rectA and rectB contain any overlapping points
            return (rectA.Right > rectB.Left && rectA.Left < rectB.Right &&
                    rectA.Bottom > rectB.Top && rectA.Top < rectB.Bottom);
        }
   
        // method called to destroy enemy type 1
        protected void DestroyEnemy(int iEnemy)
        {
            hud.score += 100;// update score if enemy type 1 is destroyed
            enemy1Destroyed.Play(); // play enemy destroyed sound
            endOfWave1++; // increment variable endOfWave1
            EnemiesType1[iEnemy].Deactivate(); // deactivate destroyed enemy
            
        }

        // destroy enemy of type 2
        protected void DestroyEnemy2(int iEnemy)
        {
            hud.score += 200;// update score
            enemy1Destroyed.Play(); // play sound
            endOfWave2++;
            EnemiesType2[iEnemy].Deactivate();
        }

        // destroy boss
        protected void DestroyBoss()
        {
             hud.score += 500;
            //bossDestroyed.Play();
            isBossActive = false;
            boss.Deactivate();
            isBossDefeated =  true;
            //CALL FOR GAME OVER SOUND AND SCREEN
        }
           
        //remove bullet
        protected void RemoveBullet(int iBullet)
        {
            bolts[iBullet].IsActive = false;
        }
       
        //Method to check for bullet - enemy hits
        protected void CheckBulletHits()
        {
            // Check to see of any of the players bullets have 
            // impacted any of the enemies.
            for (int i = 0; i < iMaxBolts; i++)
            {
                if (bolts[i].IsActive)
                {
                    // check first if enemy 1 still exists
                    if (!isWave1Over)
                    {
                        for (int x = 0; x < iTotalMaxEnemies; x++)
                            if (EnemiesType1[x].IsActive)
                                if (Intersects(bolts[i].BoundingBox,
                                               EnemiesType1[x].CollisionBox))
                                {
                                    DestroyEnemy(x);
                                    RemoveBullet(i);
                                }
                    }
                    
                    // check first if enemy 2 still exists
                    if (!isWave2Over)
                    {
                        for (int x = 0; x < iTotalMaxEnemies2; x++)
                            if (EnemiesType2[x].IsActive)
                                if (Intersects(bolts[i].BoundingBox, EnemiesType2[x].CollisionBox))
                                {
                                    DestroyEnemy2(x);
                                    RemoveBullet(i);
                                }
                    }
                        // check first if the boss exists
                        if (boss.IsActive)
                        {
                            if (Intersects(bolts[i].BoundingBox, boss.CollisionBox))
                            {
                                youFiredSoundInstance.Play();
                                boss.Life -= 10; // update boss's life

                                // if boss has no life left destroy it
                                if (boss.Life <= 0)
                                {
                                    DestroyBoss();
                                }
                                
                                RemoveBullet(i);
                            }
                        }

                }
            }

            //check if boss's bullets hits player check if boss is active
            if (boss.IsActive)
            {
                for (int k = 0; k < boss.TotalOfBullets; k++)
                {
                    //check only for valid bullets
                    if (boss.bullets[k].IsActive)
                    {
                        if (Intersects(boss.bullets[k].BoundingBox, player.BoundingBox))
                        {
                            UpdateLives(); // subtract one life if player is hit by bullet

                            if (!isOutOfLives) // in case player is hit and has life left
                            {
                                hitsByBoss += 1; // increase counter for sound purposes

                                dealSoundInstance.Play();
                                //// if player has been hit twice by boss do something
                                //if (hitsByBoss == 2)
                                //    isPlayerHitTwiceByBoss = true;

                                //// make sure that boss will only say second sound effect if first sound effect is over - in case player gets hit my bullets in short time.
                                //if (isPlayerHitTwiceByBoss && (DateTime.Now > youFiredTimeControll + youFiredSoundDuration))
                                //{
                                //    youFired.Play();
                                //}
                                //else
                                //{
                                //    youFired.Play();
                                //    youFiredTimeControll = DateTime.Now;
                                //}
                            }
                            boss.RemoveBullet(k);


                        }
                    }
                }
            }
            
            
            //check if enemy2's bullet collides with player 5/19/2012
            for (int j = 0; j < iTotalMaxEnemies2; j++)
            {
                //check only for valid enemies
                if (EnemiesType2[j].IsActive)
                {
                    for (int k = 0; k < EnemiesType2[j].TotalOfBullets; k++)
                    {   
                        //check only for valid bullets
                        if (EnemiesType2[j].bolts[k].IsActive)
                        { 
                            if(Intersects(EnemiesType2[j].bolts[k].BoundingBox, player.BoundingBox))
                            {
                                UpdateLives();

                                if (!isOutOfLives)
                                {
                                    hitsByEnemy2 += 1;
                                    if (hitsByEnemy2 == 2)
                                        isPlayerHitTwiceByEnemy2 = true;
                                    // make sure that enemy will only say second sound effect if first sound effect is over - in case player gets hit my bullets in short time.
                                    if (isPlayerHitTwiceByEnemy2 && (DateTime.Now > maroonTimeControll + maroonSoundDuration))
                                    {
                                        ultraMaroonSoundInstance.Play();
                                    }
                                    else
                                    {
                                        maroonSoundInstance.Play();
                                        maroonTimeControll = DateTime.Now;                                        
                                    }
                                }
                                EnemiesType2[j].RemoveBullet(k);
                                

                            }
                        }
                    }
                }
            }
        }

        // method that draws the sprites 
        public override void Draw(GameTime gameTime)
        {
            // draw the background
            spriteBatch.Draw(gameBackgroundImage,
                                new Rectangle(-1 * gameBackgroundOffset,
                                0, backgroundFileWidth,
                                heightOfBackgroundToBeDisplayed),
                                Color.White);

            // keep background constant 
            if (gameBackgroundOffset > backgroundFileWidth - widthOfBackgroundToBeDisplayed)
            {
                spriteBatch.Draw(gameBackgroundImage,
                                    new Rectangle(
                                    (-1 * gameBackgroundOffset) + backgroundFileWidth,
                                    0,
                                    backgroundFileWidth,
                                    heightOfBackgroundToBeDisplayed),
                                    Color.White);
            }

            spriteBatch.Draw(gameHudImage, new Rectangle(0, 0, 800, 600), Color.White); // draw game "HUD" 

            // Pass drawing style to hud function
            hud.Draw(spriteBatch, spriteFont);
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

            for (int i = 0; i < numberOfEnemiesType1; i++)
            {
                if (EnemiesType1[i].IsActive)
                    EnemiesType1[i].Draw(spriteBatch,
                      BackgroundOffset);
            }

            // if wave 1 is over make sure enemy 2 bullets will be drawn
            if (isWave1Over)
            {
                for (int i = 0; i < numberOfEnemiesType2; i++)
                {
                    EnemiesType2[i].DrawBullets(spriteBatch); //5/19/2012

                    if (EnemiesType2[i].IsActive)
                    {
                        EnemiesType2[i].Draw(spriteBatch, BackgroundOffset);
                    }
                }
            }

            // draw boss, and bosses bullets 
            if (boss.IsActive)
            {
                boss.DrawBullets(spriteBatch);
                boss.Draw(spriteBatch, BackgroundOffset);
            }


            base.Draw(gameTime);
        }

        // get and set the background offset
        public int BackgroundOffset
        {
            get { return gameBackgroundOffset; }
            set
            {
                gameBackgroundOffset = value;

                // make sure that screen will never be without a background
                if (gameBackgroundOffset < 0)
                {
                    gameBackgroundOffset += backgroundFileWidth;
                }
                if (gameBackgroundOffset > backgroundFileWidth)
                {
                    gameBackgroundOffset -= backgroundFileWidth;
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
