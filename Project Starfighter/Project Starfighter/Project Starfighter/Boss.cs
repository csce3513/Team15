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
        AnimatedSprite asSprite;

        private int xPosition = 0;
        private int yPosition = 0;
        private int startY = 270;
        private static int MaxYChange = 200;
        private bool isBossActive = false;
        private bool changeDirection = false;
        private int life = 100;

        public int lowerLimitPosition;
        public int upperLimitPosition;

        
        private int verticalOffset = 30;   //added to boss position so it looks like it comes from front instead of back
        private static int maximumBullets = 40;      // total number of bullets
        public Ammo[] bullets = new Ammo[maximumBullets]; //array that holds the bullets
        private float fBulletDelayTimer = 0.0f;     //timer delay for spriteanimator
        private float fFireDelay = 0.15f;           //timer delay for firing rate
        

        // Constructor for Boss
        public Boss(Texture2D texture, int X, int Y, int W, int H, int Frames)
        {
            asSprite = new AnimatedSprite(texture, X, Y, W, H, Frames);
        }

        // get the total number of bullets
        public int TotalOfBullets
        {
            get { return maximumBullets; }
        }

        // function for updating ammo
        public  void UpdateAmmo(GameTime gameTime)
        {
            // makes sure the bullets are in its correct position after fired
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

        public void RemoveBullet(int iBullet)
        {
            bullets[iBullet].IsActive = false;
        }

        public float FireDelay
        {
            get { return fFireDelay; }
            set { fFireDelay = value; }
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }
        public float BulletDelayTimer
        {
            get { return fBulletDelayTimer; }
            set { fBulletDelayTimer = value; }
        }

        // Draw any active enemy2 ammo on the screen
        public void DrawBullets(SpriteBatch spbatch)
        {
            for (int i = 0; i < maximumBullets; i++)
            {
                // Only draw active bullets
                if (bullets[i].IsActive)
                {
                    bullets[i].Draw(spbatch);
                }
            }
        }

        public void Deactivate()
        {
            isBossActive = false;
        }

        public bool IsActive
        {
            get { return isBossActive; }
        }


        public int X
        {
            get { return xPosition; }
            set { xPosition = value; }
        }

        public int Y
        {
            get { return yPosition; }
            set { yPosition = value; }
        }

        public void Generate(int enemyNumber)
        {
            xPosition = 600;
            yPosition = 300;
            //for (int a = 0; a <= enemyNumber; a++)
            //{
            //    yPosition = a * 75 + 75;
            //    startY = yPosition;
            //}
            isBossActive = true;
        }

        public bool getChangeDirection
        {
            get { return changeDirection; }
        }

        // modify y position
        public int GetDrawY()
        {
            int Y = yPosition;
            if ((Y > (MaxYChange + startY)))
                changeDirection = true;
            if ((Y < (startY - MaxYChange)))
                changeDirection = false;

            return Y;
        }

        private bool isBossCrossingUpperBount()
        {
            if (yPosition >= upperLimitPosition)
                return true;
            else
                return false;
        }

        private bool isBossCrossingLowerBount()
        {
            if (yPosition <= lowerLimitPosition)
                return true;
            else
                return false;
        }

        public void InitializeBullets(Texture2D texture)
        {
            for (int j = 0; j < maximumBullets; j++)
            {
                bullets[j] = new Ammo(texture);
            }
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle(xPosition + 2, yPosition + 2, 150, 104);
            }
        }

        public void Draw(SpriteBatch sb, int iLocation)
        {
            if (isBossActive)
            {
                asSprite.Draw(sb, xPosition, GetDrawY(), false);
            }
        }

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
