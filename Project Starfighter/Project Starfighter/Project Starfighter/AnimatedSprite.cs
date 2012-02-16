using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Starfighter
{
    public class AnimatedSprite
    {
        Texture2D t2dTexture; //graphics for explosion - it is one row of the sprite sheet

        //the next two lines are used to control how fast the frames of the explosion play
        float fFrameRate = 0.02f; // time in seconds that each frame is displayed
        float fElapsed = 0.0f; // accumulates the elapsed time since the current frame started

        // the next two lines represents the uupperleft corner of the first frame of the sprite that will be used
        // so that we can display multiple sprites from the same sprite sheet
        int iFrameOffsetX = 0;
        int iFrameOffsetY = 0;

        int iFrameWidth = 32; // specify the width of each animation frame
        int iFrameHeight = 32; // specify the height of each animation frame

        int iFrameCount = 1; // is the total number of frames in the animation
        int iCurrentFrame = 0; // is the frame of animation that is being displayed

        // the next two lines represent the coordinates that the sprite occupies on the screen
        int iScreenX = 0;
        int iScreenY = 0;

        bool bAnimating = true; // determins if the frames in the sprite will be automatically updated or not

        //for testing purposes
        public float Elapsed
        {
            get { return fElapsed; }
            set { fElapsed = value; }
        }

        public int X
        {
            get { return iScreenX; }
            set { iScreenX = value; }
        }

        public int Y
        {
            get { return iScreenY; }
            set { iScreenY = value; }
        }

        public int Frame
        {
            get { return iCurrentFrame; }
            set { iCurrentFrame = (int)MathHelper.Clamp(value, 0, iFrameCount); }
        }

        public float FrameLength
        {
            get { return fFrameRate; }
            set { fFrameRate = (float)Math.Max(value, 0f); } // make sure fFrameRate is not negative
        }

        public bool IsAnimating
        {
            get { return bAnimating; }
            set { bAnimating = value; }
        }

        //constructor for testing purposes
        public AnimatedSprite()
        {
            iFrameOffsetX = 2;
            iFrameOffsetY = 2;
            iFrameWidth = 2;
            iFrameHeight = 2;
            iFrameCount = 4;
        }
        public AnimatedSprite(  Texture2D texture,
                                int FrameOffsetX,
                                int FrameOffsetY,
                                int FrameWidth,
                                int FrameHeight,
                                int FrameCount)
        {
            t2dTexture = texture;
            iFrameOffsetX = FrameOffsetX;
            iFrameOffsetY = FrameOffsetY;
            iFrameWidth = FrameWidth;
            iFrameHeight = FrameHeight;
            iFrameCount = FrameCount;
        }

        // decide what sprote to chose from the sprite sheet
        public Rectangle GetSourceRect()
        {
            return new Rectangle(
            iFrameOffsetX + (iFrameWidth * iCurrentFrame),
            iFrameOffsetY,
            iFrameWidth,
            iFrameHeight);
        }



        // update sprite animation
        public void Update(GameTime gametime)
        {
            if (bAnimating)
            {
                // Accumulate elapsed time...
                fElapsed += (float)gametime.ElapsedGameTime.TotalSeconds;

                // Until it passes our frame length
                if (fElapsed > fFrameRate)
                {
                    // Increment the current frame, wrapping back to 0 at iFrameCount
                    iCurrentFrame = (iCurrentFrame + 1) % iFrameCount;

                    // Reset the elapsed frame time.
                    fElapsed = 0.0f;
                }
            }
        }

        public void Draw(   SpriteBatch spriteBatch,
                            int XOffset,
                            int YOffset,
                            bool NeedBeginEnd)
        {
            if (NeedBeginEnd)
                spriteBatch.Begin();

            spriteBatch.Draw(
                t2dTexture,
                new Rectangle(
                  iScreenX + XOffset,
                  iScreenY + YOffset,
                  iFrameWidth,
                  iFrameHeight),
                GetSourceRect(),
                Color.White);

            if (NeedBeginEnd)
                spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch, int XOffset, int YOffset)
        {
            Draw(spriteBatch, XOffset, YOffset, true);
        }
    }
    
}
