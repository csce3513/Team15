using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Starfighter
{
    public class Ammo
    {
        public AnimatedSprite asBullet; //the ammo image
        public Vector2 aLocation;
        bool ammoActive;
        float fElapsed = 0f;
        float fUpdateInterval = 0.015f;
        //public int iSpeed;
        public float iSpeed = 12f;

        //Vector2 is a public object in XNA and doesn't need get/set methods
        //Remaining get/set methods:

        public bool IsActive
        {
            get { return ammoActive; }
            set { ammoActive = value; }
        }

        //Commented out after Speed test
        //public int Speed
        //{
        //    get { return iSpeed; }
        //    set { iSpeed = value; }
        //}

        // returns a box around the Ammo to check for collisions
        public Rectangle BoundingBox
        {
            get { return new Rectangle((int)aLocation.X, (int)aLocation.Y, 16, 3); }
        }

        public Ammo(Texture2D texture)
        {
            asBullet = new AnimatedSprite(texture, 0, 0, 16, 3, 1);
            //loads ammo from image: 16 pixels by 3 pixels at default location 0,0
            aLocation.X = 0f;
            aLocation.Y = 0f;
            ammoActive = false;
        }

        //empty contructor for testing 
        //and Ammo duplication (easier than calling the image over and over)
        public Ammo()
        {
            aLocation.X = 0f;
            aLocation.Y = 0f;
            ammoActive = false;
        }

        //A method for Starfighter to instantiate ammo firing from player
        public void Fire(int X, int Y)
        {
            aLocation.X = (float)X;
            aLocation.Y = (float)Y;
            ammoActive = true;
        }

        //A method to update the ammo's position in GameTime
        public void Update(GameTime gameTime)
        {
            if (ammoActive)
            {
                fElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (fElapsed > fUpdateInterval)
                {
                    fElapsed = 0f;
                    aLocation.X += iSpeed;
                    // If the bullet has moved off of the screen, 
                    // set it to inactive
                    if ((aLocation.X > 800f) || (aLocation.X < 1f))
                    {
                        ammoActive = false;
                    }
                }   //end If
            }   // end If
        }   //end method Update

        public void Draw(SpriteBatch sb)
        {
            if (ammoActive)
            {
                asBullet.Draw(sb, (int)aLocation.X, (int)aLocation.Y, false);
            }
        }


    }// end public class Ammo
}//end 

