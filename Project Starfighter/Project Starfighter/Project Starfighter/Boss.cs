using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Project_Starfighter
{
    class Boss
    {
        AnimatedSprite asSprite; // sprite that will hold the boss's image

        private int xPosition = 0; // holds x position of the boss
        private int yPosition = 0; // holds y position of the boss
        private int startY = 270; // starting y position of boss - the boss moves in the vertical direction
        private static int MaxYChange = 200; // maximum range of pixels that the boss is alowed to move up or down from starting position 
        private bool isBossActive = false; // indicates if the boss is active
        private bool changeDirection = false; // indicates if the boss chould change its movement to the opposit direction
        private int life = 100; // the bosse's life

        private int bossImageWidth = 150; // define the width of the boss to be shown on the screen
        private int bossImageHeight = 104; // define the height of the boss to be shown on the screen


        private int verticalOffset = 30;   //added to boss position so it looks like it comes from front instead of back
        private static int maximumBullets = 40;      // total number of bullets
        public Ammo[] bullets = new Ammo[maximumBullets]; //array that holds the bullets
        private float fBulletDelayTimer = 0.0f;     //timer delay for spriteanimator
        private float fFireDelay = 0.15f;           //timer delay for firing rate
        

        // constructor for the Boss
        public Boss(Texture2D texture, int X, int Y, int W, int H, int Frames)
        {
            asSprite = new AnimatedSprite(texture, X, Y, W, H, Frames); // initiate sprite with texture in the correct position with correct size
        }

        // get the total number of bullets
        public int TotalOfBullets
        {
            get { return maximumBullets; }
        }

        // function for updating bullet's position
        public  void UpdateAmmo(GameTime gameTime)
        {
            // for each bullet makes sure it is in its correct position after fired
            for (int x = 0; x < maximumBullets; x++)
            {
                if (bullets[x].IsActive)
                    bullets[x].UpdateEnemyAmmo(gameTime);
            }
        }

        //Helper Function for Ammo Firing
        public void FireBullet(int iVerticalOffset, SoundEffect laserSound)
        {
            if (this.isBossActive)
            {
                // Find and fire a free bullet
                for (int x = 0; x < maximumBullets; x++)
                {
                    if (!bullets[x].IsActive)
                    {
                        bullets[x].Fire(xPosition - 15, yPosition + verticalOffset + iVerticalOffset);
                        laserSound.Play();
                        break;
                    }
                }
            }
        }

        // remove the specific bullet from screen
        public void RemoveBullet(int iBullet)
        {
            bullets[iBullet].IsActive = false;
        }

        // get the life of the boss
        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        // delay before the next bullet can be shot
        public float BulletDelayTimer
        {
            get { return fBulletDelayTimer; }
            set { fBulletDelayTimer = value; }
        }

        // draw the active bullet on the screen
        public void DrawBullets(SpriteBatch spbatch)
        {
            for (int i = 0; i < maximumBullets; i++)
            {
                // check if bullet is active before drawing
                if (bullets[i].IsActive)
                {
                    bullets[i].Draw(spbatch);
                }
            }
        }

        // deactivate (kill) the boss
        public void Deactivate()
        {
            isBossActive = false;
        }

        // return status of the Boss
        public bool IsActive
        {
            get { return isBossActive; }
        }

        // get/set x position
        public int X
        {
            get { return xPosition; }
            set { xPosition = value; }
        }

        // get/set y position
        public int Y
        {
            get { return yPosition; }
            set { yPosition = value; }
        }

        // activate the boss
        public void Generate(int enemyNumber)
        {
            xPosition = 600;
            yPosition = 300;
            isBossActive = true;
        }

        // get the value of the changeDirection variable
        public bool getChangeDirection
        {
            get { return changeDirection; }
        }

        // method returns the y position and changes the direction of the boss if it is out of the range
        public int GetDrawY()
        {
            int Y = yPosition;
            if ((Y > (MaxYChange + startY)))
                changeDirection = true;
            if ((Y < (startY - MaxYChange)))
                changeDirection = false;

            return Y;
        }

        // initialize the bullets for the boss
        public void InitializeBullets(Texture2D texture)
        {
            for (int j = 0; j < maximumBullets; j++)
            {
                bullets[j] = new Ammo(texture);
            }
        }

        // create a collision box for the boss
        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle(xPosition + 2, yPosition + 2, bossImageWidth, bossImageHeight);
            }
        }

        // draw the boss in the correct position on the screen
        public void Draw(SpriteBatch sb, int iLocation)
        {
            if (isBossActive)
            {
                asSprite.Draw(sb, xPosition, GetDrawY(), false);
            }
        }

        // method updates the y position of the boss constantly
        public void Update(GameTime gametime)
        {
                if (changeDirection == false)
                {
                    yPosition += 5;
                }
                else
                {
                    yPosition -= 5;
                }
              
            asSprite.Update(gametime);
        }
    }
}
