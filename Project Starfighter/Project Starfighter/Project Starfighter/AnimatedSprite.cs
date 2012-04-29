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
        ////the next two lines are used to control how fast the frames of the explosion play
        private float rateOfFrame = 0.02f; // time in seconds that each frame is displayed
        private float elapsedTime = 0.0f; // accumulates the elapsed time since the current frame started
        private Texture2D t2dTexture; //graphics for explosion - it is one row of the sprite sheet
        
        // the next two lines represents the uupperleft corner of the first frame of the sprite that will be used
        // so that we can display multiple sprites from the same sprite sheet
        private int xFrameOffset = 0;
        private int yFrameOffset = 0;
        private int widthOfFrame = 32; // specify the width of each animation frame
        private int heightOfFrame = 32; // specify the height of each animation frame
        private int numberOfFrames = 1; // is the total number of frames in the animation
        private int currentFrame = 0; // is the frame of animation that is being displayed

        // the next two lines represent the coordinates that the sprite occupies on the screen
        private int xPosition = 0;
        private int yPosition = 0;
        private bool isFrameAnimated = true; // determins if the frames in the sprite will be automatically updated or not

        // decide what sprite to chose from the sprite sheet
        public Rectangle GetSourceRect()
        {
            return new Rectangle(
            xFrameOffset + (widthOfFrame * currentFrame),
            yFrameOffset,
            widthOfFrame,
            heightOfFrame);
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

        //for testing purposes
        public float Elapsed
        {
            get { return elapsedTime; }
            set { elapsedTime = value; }
        }

        // get the current frame being used
        public int Frame
        {
            get { return currentFrame; }
        }

        
        public bool IsAnimating
        {
            get { return isFrameAnimated; }
            set { isFrameAnimated = value; }
        }

        //constructor for testing purposes
        public AnimatedSprite()
        {
            xFrameOffset = 2;
            yFrameOffset = 2;
            widthOfFrame = 2;
            heightOfFrame = 2;
            numberOfFrames = 4;
        }

        // draw the sprite
        public void Draw(SpriteBatch spriteBatch,
                            int XOffset,
                            int YOffset,
                            bool NeedBeginEnd)
        {
            if (NeedBeginEnd)
                spriteBatch.Begin();

            spriteBatch.Draw(
                t2dTexture,
                new Rectangle(
                  xPosition + XOffset,
                  yPosition + YOffset,
                  widthOfFrame,
                  heightOfFrame),
                GetSourceRect(),
                Color.White);

            if (NeedBeginEnd)
                spriteBatch.End();
        }

        // constructor
        public AnimatedSprite(  Texture2D texture,
                                int FrameOffsetX,
                                int FrameOffsetY,
                                int FrameWidth,
                                int FrameHeight,
                                int FrameCount)
        {
            t2dTexture = texture;
            xFrameOffset = FrameOffsetX;
            yFrameOffset = FrameOffsetY;
            widthOfFrame = FrameWidth;
            heightOfFrame = FrameHeight;
            numberOfFrames = FrameCount;
        }

        // update sprite animation
        public void Update(GameTime gametime)
        {
            if (isFrameAnimated)
            {
                // see what was the elapsed time
                elapsedTime += (float)gametime.ElapsedGameTime.TotalSeconds;

                // check if the time elapsed is bigger than the frame rate
                if (elapsedTime > rateOfFrame)
                {
                    // increment the current frame
                    currentFrame = (currentFrame + 1) % numberOfFrames;

                    // reset the elapsed time for the frame
                    elapsedTime = 0.0f;
                }
            }
        }
    }
    
}
