using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Starfighter
{
    public class Player
    {
        public AnimatedSprite asSprite; // the ship image

        // the next two lines determin the location of the ship on the screen
        int iX = 604;
        int iY = 260;

        int iFacing = 0; // what direction the player is facing right = 0, left = 1

        bool bThrusting = false; // represents if the ship is moving in a direction

        int iScrollRate = 0; // speed and direction that ship is moving positive value = right negative value = left
                             // the bigger the number more pixels per update frame the screen will move

        int iShipAccelerationRate = 1; // how fast iScrollRate can change

        int iShipVerticalMoveRate = 3; // number of pixels the ship moves vertically when the player presses up/down

        // the next two lines determin how fast iShipAccelerationRate can be applied.
        float fSpeedChangeCount = 0.0f; // accumulates the time since the last speed change When it is greater than fSpeedChangeDelay, 
        // the speed is allowed to change and will be reset to 0 if it does.
        float fSpeedChangeDelay = 0.1f;

        // the next two lines work in the same way that fSpeedChangeCounnt/Delay work except that they serve to limit how quickly the player 
        // can move vertically. The value we have set here (0.01 seconds) is very, very low so we are basically just using this to keep the ship 
        // moving at a consistant speed on fast computers.
        float fVerticalChangeCount = 0.0f;
        float fVerticalChangeDelay = 0.01f;


        public int X
        {
            get { return iX; }
            set { iX = value; }
        }

        public int Y
        {
            get { return iY; }
            set { iY = value; }
        }

        public int Facing
        {
            get { return iFacing; }
            set { iFacing = value; }
        }

        public bool Thrusting
        {
            get { return bThrusting; }
            set { bThrusting = value; }
        }

        public int ScrollRate
        {
            get { return iScrollRate; }
            set { iScrollRate = value; }
        }

        public int AccelerationRate
        {
            get { return iShipAccelerationRate; }
            set { iShipAccelerationRate = value; }
        }

        // returns a new rectangle based on the position and size of our ship.
        public Rectangle BoundingBox
        {
            get { return new Rectangle(iX, iY, 72, 16); }
        }

        // constructor
        public Player(Texture2D texture)
        {
            asSprite = new AnimatedSprite(texture, 0, 0, 72, 16, 4);
            asSprite.IsAnimating = false;
        }

        // constructor for testing 
        public Player()
        {
            asSprite = new AnimatedSprite();
        }

        public void Draw(SpriteBatch sb)
        {
            asSprite.Draw(sb, iX, iY, false);
        }

        // update animation frames based on the values of iFacing and bThrusting.
        public void Update(GameTime gametime)
        {
            if (iFacing == 0)
            {
                if (bThrusting)
                    asSprite.Frame = 1;
                else
                    asSprite.Frame = 0;
            }
            else
            {
                if (bThrusting)
                    asSprite.Frame = 3;
                else
                    asSprite.Frame = 2;
            }
        }
    }
}
