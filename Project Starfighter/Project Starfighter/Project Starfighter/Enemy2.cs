using System;
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
        AnimatedSprite asSprite; // sprite that will hold enemy's position

        private int xPosition = 0; // enemy's x position
        private int yPosition = 0; // enemy's y position
        private int startY; // enemy's starting y position
        private static int MaxYChange = 50; // maximum value in pixels that enemy is allowed to move away from initial position
        private bool isEnemyActive = false; // holds value that tells if enemy is active
        private bool changeDirection = false; // indicates if the enemy should change the direction that it is moving

        
        private int verticalOffset = 30;   //added to ship position so it looks like bullet comes from front instead of cockpit
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

        //Helper Function for firing the bullets
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

        // deactivate specific bullet
        public void RemoveBullet(int iBullet)
        {
            bolts[iBullet].IsActive = false;
        }

        // gets the time that the next bullet can be shot
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
                // check if the bullet is active before drawing it
                if (bolts[i].IsActive)
                {
                    bolts[i].Draw(spbatch);
                }
            }
        }

        // initialize all the enemy's bullets image
        public void InitializeBullets(Texture2D texture)
        {
            for (int j = 0; j < maximumBullets; j++)
            {
                bolts[j] = new Ammo(texture);
            }
        }

        // deactivate - kill - enemy
        public void Deactivate()
        {
            isEnemyActive = false;
        }

        // check if enemy is active
        public bool IsActive
        {
            get { return isEnemyActive; }
        }

        // return the enemy's x position
        public int X
        {
            get { return xPosition; }
            set { xPosition = value; }
        }

        // return the enemy's y position
        public int Y
        {
            get { return yPosition; }
            set { yPosition = value; }
        }

        // define enemy's position and activate it
        public void Generate(int enemyNumber)
        {
            xPosition = 750; // x position of enemies

            // make sure enemyes are above each other this loop will make sure that each enemy will be in its correct position 
            for (int a = 0; a <= enemyNumber; a++)
            {
                yPosition = a * 75 + 75;
                startY = yPosition;
            }
            isEnemyActive = true;
        }

        // get variable changeDirection
        public bool getChangeDirection
        {
            get { return changeDirection; }
        }

        // return y position of the enemy and modify value of the variable changeDirection if the enemy is out of bounds
        public int GetDrawY()
        {
            int Y = yPosition;
            if (Y > (MaxYChange + startY))
                changeDirection = true;
            if (Y < (startY - MaxYChange))
                changeDirection = false;

            return Y;
        }

        // create collision box for the enemy
        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle(xPosition + 2, yPosition + 2, 42, 71);
            }
        }

        // draw the enemy
        public void Draw(SpriteBatch sb, int iLocation)
        {
            if (isEnemyActive)
            {
                asSprite.Draw(sb, xPosition, GetDrawY(), false);
            }
        }

        // update the enemy's position on screen
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
