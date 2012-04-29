using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Starfighter
{
    public class Background
    {
        // Textures to hold the two background images
        Texture2D t2dBackground;

        // the next two lines hold the width and height of the background images. 
        private int backgroundFileWidth = 0;
        private int backgroundFileHeight = 0;

        private int backgroundOffset;// will hold the initial background offset

        // the next two lines determine how large the background will have when displayed
        private int widthOfBackgroundToBeDisplayed = 1280;
        private int heightOfBackgroundToBeDisplayed = 720;

        // draw the background
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the background panel, offset by the player's location
            spriteBatch.Draw(t2dBackground,
                                new Rectangle(-1 * backgroundOffset,
                                0, backgroundFileWidth,
                                heightOfBackgroundToBeDisplayed),
                                Color.White);

            // If the right edge of the background panel will end 
            // within the bounds of the display, draw a second copy 
            // of the background at that location.
            if (backgroundOffset > backgroundFileWidth - widthOfBackgroundToBeDisplayed)
            {
                spriteBatch.Draw(t2dBackground,
                                    new Rectangle(
                                    (-1 * backgroundOffset) + backgroundFileWidth,
                                    0,
                                    backgroundFileWidth,
                                    heightOfBackgroundToBeDisplayed),
                                    Color.White);
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

        // get/set the background offset
        public int BackgroundOffset
        {
            get { return backgroundOffset; }

            set
            {
                backgroundOffset = value;
                if (backgroundOffset < 0) // if background offset is negative add the size of the file to the backgorund in order for the background to be continuously shown
                {
                    backgroundOffset += backgroundFileWidth;
                }
                if (backgroundOffset > backgroundFileWidth)// if background offset is bigger thatn the size of the background file subtract the size of the file from the backgorund in order for the background to be continuously shown
                {
                    backgroundOffset -= backgroundFileWidth;
                }
            }
        }

        // constructor for testing 
        public Background()
        {

        }

        // constructor
        public Background(ContentManager content, string sBackground)
        {

            t2dBackground = content.Load<Texture2D>(sBackground);
            backgroundFileWidth = t2dBackground.Width;
            backgroundFileHeight = t2dBackground.Height;
        }

    
    }
}
