using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class  Background
    {
        // Textures to hold the two background images
        Texture2D t2dBackground, t2dParallax;

        // the next two lines determine how large the background will have when displayed
        int iViewportWidth = 1280;
        int iViewportHeight = 720;

        // the next four lines hold the width and height of the background images. 
        int iBackgroundWidth = 1920;
        int iBackgroundHeight = 720;

        int iParallaxWidth = 1680;
        int iParallaxHeight = 480;

        // the next two lines defines how many pixels before the screen begins is the background image going to start
        int iBackgroundOffset;
        int iParallaxOffset;

        public int BackgroundOffset
        {
            get { return iBackgroundOffset; }
            set
            {
                iBackgroundOffset = value;
                if (iBackgroundOffset < 0)
                {
                    iBackgroundOffset += iBackgroundWidth;
                }
                if (iBackgroundOffset > iBackgroundWidth)
                {
                    iBackgroundOffset -= iBackgroundWidth;
                }
            }
        }

        public int ParallaxOffset
        {
            get { return iParallaxOffset; }
            set
            {
                iParallaxOffset = value;
                if (iParallaxOffset < 0)
                {
                    iParallaxOffset += iParallaxWidth;
                }
                if (iParallaxOffset > iParallaxWidth)
                {
                    iParallaxOffset -= iParallaxWidth;
                }
            }
        }

        // Determines if we will draw the Parallax overlay.
        bool drawParallax = true;

        public bool DrawParallax
        {
            get { return drawParallax; }
            set { drawParallax = value; }
        }

        // Constructor when passed a Content Manager and two strings
        public Background(ContentManager content,
                          string sBackground,
                          string sParallax)
        {

            t2dBackground = content.Load<Texture2D>(sBackground);
            iBackgroundWidth = t2dBackground.Width;
            iBackgroundHeight = t2dBackground.Height;
            t2dParallax = content.Load<Texture2D>(sParallax);
            iParallaxWidth = t2dParallax.Width;
            iParallaxHeight = t2dParallax.Height;
        }

        // Constructor when passed a content manager and a single string
        public Background(ContentManager content, string sBackground)
        {

            t2dBackground = content.Load<Texture2D>(sBackground);
            iBackgroundWidth = t2dBackground.Width;
            iBackgroundHeight = t2dBackground.Height;
            t2dParallax = t2dBackground;
            iParallaxWidth = t2dParallax.Width;
            iParallaxHeight = t2dParallax.Height;
            drawParallax = false;
        }

        // constructor for testing
        public Background()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the background panel, offset by the player's location
            spriteBatch.Draw(   t2dBackground,
                                new Rectangle(-1 * iBackgroundOffset,
                                0, iBackgroundWidth,
                                iViewportHeight),
                                Color.White);

            // If the right edge of the background panel will end 
            // within the bounds of the display, draw a second copy 
            // of the background at that location.
            if (iBackgroundOffset > iBackgroundWidth - iViewportWidth)
            {
                spriteBatch.Draw(   t2dBackground,
                                    new Rectangle(
                                    (-1 * iBackgroundOffset) + iBackgroundWidth,
                                    0,
                                    iBackgroundWidth,
                                    iViewportHeight),
                                    Color.White);
            }

            if (drawParallax)
            {
                // Draw the parallax star field
                spriteBatch.Draw(   t2dParallax,
                                    new Rectangle(-1 * iParallaxOffset,
                                    0, iParallaxWidth,
                                    iViewportHeight),
                                    Color.SlateGray);
                // if the player is past the point where the star 
                // field will end on the active screen we need 
                // to draw a second copy of it to cover the 
                // remaining screen area.
                if (iParallaxOffset > iParallaxWidth - iViewportWidth)
                {
                    spriteBatch.Draw(   t2dParallax,
                                        new Rectangle(
                                        (-1 * iParallaxOffset) + iParallaxWidth,
                                        0,
                                        iParallaxWidth,
                                        iViewportHeight),
                                        Color.SlateGray);
                }
            }
        }
    }
}
