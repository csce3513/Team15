﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Project_Starfighter
{
    class Enemy2
    {
        AnimatedSprite asSprite;

        private int xPosition = 0;
        private int yPosition = 0;
        private int startY;
        private static int MaxYChange = 50;
        private bool isEnemyActive = false;
        private bool changeDirection = false;

        
        private int verticalOffset = 30;   //added to ship position so it looks like it comes from front instead of cockpit
        private static int maximumBullets = 40;      // total number of bullets
        public Ammo[] bolts = new Ammo[maximumBullets]; //array that holds the bullets
        private float fBulletDelayTimer = 0.0f;     //timer delay for spriteanimator
        private float fFireDelay = 0.15f;           //timer delay for firing rate
        

        // Constructor for Enemy2
        public Enemy2(Texture2D texture, int X, int Y, int W, int H, int Frames)
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
                if (bolts[x].IsActive)
                    bolts[x].UpdateEnemyAmmo(gameTime);
            }
        }

        //Helper Function for Ammo Firing
        public void FireBullet(int iVerticalOffset, SoundEffect laserSound)
        {
            if (this.isEnemyActive)
            {
                // Find and fire a free bullet
                for (int x = 0; x < maximumBullets; x++)
                {
                    if (!bolts[x].IsActive)
                    {
                        bolts[x].Fire(xPosition - 15, yPosition + verticalOffset + iVerticalOffset);
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
            for (int i = 0; i < maximumBullets; i++)
            {
                // Only draw active bullets
                if (bolts[i].IsActive)
                {
                    bolts[i].Draw(spbatch);
                }
            }
        }

        public void InitializeBullets(Texture2D texture)
        {
            for (int j = 0; j < maximumBullets; j++)
            {
                bolts[j] = new Ammo(texture);
            }
        }
        public void Deactivate()
        {
            isEnemyActive = false;
        }

        public bool IsActive
        {
            get { return isEnemyActive; }
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
            xPosition = 750;

            for (int a = 0; a <= enemyNumber; a++)
            {
                yPosition = a * 75 + 75;
                startY = yPosition;
            }
            isEnemyActive = true;
        }

        public bool getChangeDirection
        {
            get { return changeDirection; }
        }

        public int GetDrawY()
        {
            int Y = yPosition;
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
                return new Rectangle(xPosition + 2, yPosition + 2, 42, 71);
            }
        }

        public void Draw(SpriteBatch sb, int iLocation)
        {
            if (isEnemyActive)
            {
                asSprite.Draw(sb, xPosition, GetDrawY(), false);
            }
        }

        public void Update(GameTime gametime)
        {
                if (changeDirection == false)
                {
                    yPosition += 1;
                }
                else
                {
                    yPosition += -1;
                }
              
            asSprite.Update(gametime);
        }
    }
}