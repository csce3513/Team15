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
        public AnimatedSprite shipSprite; // sprite object that will hold the ship's image

        // the next two lines determin the location of the ship on the screen
        private int xPosition = 350;
        private int yPosition = 300;

        // get or set X position value of the ship
        public int X
        {
            get { return xPosition; }
            set { xPosition = value; }
        }

        // get or set Y position value of the ship
        public int Y
        {
            get { return yPosition; }
            set { yPosition = value; }
        }

        // rectangle determining the boundings of the ship for collition reasons
        public Rectangle BoundingBox
        {
            get { return new Rectangle(xPosition, yPosition, 72, 16); }
        }

        // constructor
        public Player(Texture2D texture)
        {
            shipSprite = new AnimatedSprite(texture, 0, 0, 72, 16, 4);
            shipSprite.IsAnimating = false;
        }

        // constructor for testing 
        public Player()
        {
            shipSprite = new AnimatedSprite();
        }

        // Draw player on screen
        public void Draw(SpriteBatch sb)
        {
            shipSprite.Draw(sb, xPosition, yPosition, false);
        }
    }
}
