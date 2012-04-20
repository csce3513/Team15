using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Project_Starfighter
{
    class Enemy2
    {
        AnimatedSprite asSprite;

        int aX = 0;
        int aY = 0;
        int startY;
        static int MaxYChange = 50;
        bool bActive = false;
        bool changeDirection = false;

        //aarao 4/19/2012
        int verticalOffset = 30;   //added to ship position so it looks like it comes from front instead of cockpit
        static int iMaxBolts = 40;      //Maximum number of ammo
        public Ammo[] bolts = new Ammo[iMaxBolts]; //array holding ammo
        private float fBulletDelayTimer = 0.0f;     //timer delay for spriteanimator
        private float fFireDelay = 0.15f;           //timer delay for firing rate
        


        public Enemy2(Texture2D texture, int X, int Y, int W, int H, int Frames)
        {
            asSprite = new AnimatedSprite(texture, X, Y, W, H, Frames);
        }

        // get the total of bullets
        public int TotalOfBullets
        {
            get { return iMaxBolts; }
        }

        //Helper function for updating Ammo
        public  void UpdateAmmo(GameTime gameTime)
        {
            // Updates the location of all of the active player bullets. 
            for (int x = 0; x < iMaxBolts; x++)
            {
                if (bolts[x].IsActive)
                    bolts[x].UpdateEnemyAmmo(gameTime);
            }
        }

        //Helper Function for Ammo Firing
        public void FireBullet(int iVerticalOffset, SoundEffect laserSound)
        {
            if (this.bActive)
            {
                // Find and fire a free bullet
                for (int x = 0; x < iMaxBolts; x++)
                {
                    if (!bolts[x].IsActive)
                    {
                        bolts[x].Fire(aX - 15, aY + verticalOffset + iVerticalOffset);
                        laserSound.Play();
                        break;
                    }
                }
            }
        }

        public void RemoveBullet(int iBullet)
        {
            bolts[iBullet].IsActive = false;
        }

        public float FireDelay
        {
            get { return fFireDelay; }
            set { fFireDelay = value; }
        }

        public float BulletDelayTimer
        {
            get { return fBulletDelayTimer; }
            set { fBulletDelayTimer = value; }
        }

        // Draw any active enemy2 ammo on the screen
        public void DrawBullets(SpriteBatch spbatch)
        {
            for (int i = 0; i < iMaxBolts; i++)
            {
                // Only draw active bullets
                if (bolts[i].IsActive)
                {
                    bolts[i].Draw(spbatch);
                }
            }
        }

        public void Deactivate()
        {
            bActive = false;
        }

        public bool IsActive
        {
            get { return bActive; }
        }


        public int X
        {
            get { return aX; }
            set { aX = value; }
        }

        public int Y
        {
            get { return aY; }
            set { aY = value; }
        }

        public void Generate(int shipNumber)
        {
            aX = 750;

            for (int a = 0; a <= shipNumber; a++)
            {
                aY = a * 75 + 75;
                startY = aY;
            }
            bActive = true;
        }

        public bool getChangeDirection
        {
            get { return changeDirection; }
        }

        public int GetDrawY()
        {
            int Y = aY;
            if (Y > (MaxYChange + startY))
                changeDirection = true;
            if (Y < (startY - MaxYChange))
                changeDirection = false;

            return Y;
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle(aX + 2, aY + 2, 42, 71);
            }
        }

        public void Draw(SpriteBatch sb, int iLocation)
        {
            if (bActive)
                asSprite.Draw(sb, aX, GetDrawY(), false);
        }

        public void Update(GameTime gametime)
        {
                if (changeDirection == false)
                {
                    aY += 1;
                }
                else
                {
                    aY+= -1;
                }
              
            asSprite.Update(gametime);
        }
    }
}
