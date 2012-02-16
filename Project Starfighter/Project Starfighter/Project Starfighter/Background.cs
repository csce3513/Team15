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
        Texture2D t2dBackground;//, t2dParallax;

        // the next two lines determine how large the background will have when displayed
        //int iViewportWidth = 1280;
        private int widthOfBackgroundToBeDisplayed = 1280;

        //int iViewportHeight = 720;
        private int heightOfBackgroundToBeDisplayed = 720;

        // the next four lines hold the width and height of the background images. 
        //int iBackgroundWidth = 1920;
        private int backgroundFileWidth = 0;
        //int iBackgroundHeight = 720;
        private int backgroundFileHeight = 0;

        //private int iParallaxWidth = 1680;
        //private int iParallaxHeight = 480;

        // the next two lines defines how many pixels before the screen begins is the background image going to start
        private int iBackgroundOffset;
        private int iParallaxOffset;

        public int BackgroundOffset
        {
            get { return iBackgroundOffset; }
            set
            {
                iBackgroundOffset = value;
                if (iBackgroundOffset < 0)
                {
                    iBackgroundOffset += backgroundFileWidth;
                }
                if (iBackgroundOffset > backgroundFileWidth)
                {
                    iBackgroundOffset -= backgroundFileWidth;
                }
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




        //public int ParallaxOffset
        //{
        //    get { return iParallaxOffset; }
        //    set
        //    {
        //        iParallaxOffset = value;
        //        if (iParallaxOffset += iParallaxWidth;
        //        }
        //        if (iParallaxOffset > iParallaxWidth)
        //        {
        //            iParallaxOffset -= iParallaxWidth;
        //        }
        //    }
        //}


        // Determines if we will draw the Parallax overlay.
        //bool drawParallax = true;

        //public bool DrawParallax
        //{
        //    get { return drawParallax; }
        //    set { drawParallax = value; }
        //}

        // Constructor when passed a Content Manager and two strings
        public Background(ContentManager content,
                          string sBackground,
                          string sParallax)
        {

            t2dBackground = content.Load<Texture2D>(sBackground);
            backgroundFileWidth = t2dBackground.Width;
            backgroundFileHeight = t2dBackground.Height;
            //t2dParallax = content.Load<Texture2D>(sParallax);
            //iParallaxWidth = t2dParallax.Width;
            //iParallaxHeight = t2dParallax.Height;
        }

        // constructor for testing 
        public Background()
        {

        }
        // Constructor when passed a content manager and a single string
        public Background(ContentManager content, string sBackground)
        {

            t2dBackground = content.Load<Texture2D>(sBackground);
            backgroundFileWidth = t2dBackground.Width;
            backgroundFileHeight = t2dBackground.Height;
            //t2dParallax = t2dBackground;
            //iParallaxWidth = t2dParallax.Width;
            //iParallaxHeight = t2dParallax.Height;
            //drawParallax = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the background panel, offset by the player's location
            spriteBatch.Draw(t2dBackground,
                                new Rectangle(-1 * iBackgroundOffset,
                                0, backgroundFileWidth,
                                heightOfBackgroundToBeDisplayed),
                                Color.White);

            // If the right edge of the background panel will end 
            // within the bounds of the display, draw a second copy 
            // of the background at that location.
            if (iBackgroundOffset > backgroundFileWidth - widthOfBackgroundToBeDisplayed)
            {
                spriteBatch.Draw(t2dBackground,
                                    new Rectangle(
                                    (-1 * iBackgroundOffset) + backgroundFileWidth,
                                    0,
                                    backgroundFileWidth,
                                    heightOfBackgroundToBeDisplayed),
                                    Color.White);
            }

            //if (drawParallax)
            //{
            //    // Draw the parallax star field
            //    spriteBatch.Draw(   t2dParallax,
            //                        new Rectangle(-1 * iParallaxOffset,
            //                        0, iParallaxWidth,
            //                        heightOfBackgroundToBeDisplayed),
            //                        Color.SlateGray);
            //    // if the player is past the point where the star 
            //    // field will end on the active screen we need 
            //    // to draw a second copy of it to cover the 
            //    // remaining screen area.
            //    if (iParallaxOffset > iParallaxWidth - widthOfBackgroundToBeDisplayed)
            //    {
            //        spriteBatch.Draw(   t2dParallax,
            //                            new Rectangle(
            //                            (-1 * iParallaxOffset) + iParallaxWidth,
            //                            0,
            //                            iParallaxWidth,
            //                            heightOfBackgroundToBeDisplayed),
            //                            Color.SlateGray);
            //    }
            //}
        }
    }
}
