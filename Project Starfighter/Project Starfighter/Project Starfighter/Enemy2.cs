using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Starfighter
{
    class Enemy2
    {
        AnimatedSprite asSprite;

        int aX = 0;
        int aY = 0;
        int startY;
        static int MaxYChange = 50;
        bool bActive = false;
        bool changeDirection = false;

        public Enemy2(Texture2D texture, int X, int Y, int W, int H, int Frames)
        {
            asSprite = new AnimatedSprite(texture, X, Y, W, H, Frames);
        }

        public void Deactivate()
        {
            bActive = false;
        }

        public bool IsActive
        {
            get { return bActive; }
        }

        public int X
        {
            get { return aX; }
            set { aX = value; }
        }

        public int Y
        {
            get { return aY; }
            set { aY = value; }
        }

        public void Generate(int shipNumber)
        {
            aX = 750;

            for (int a = 0; a <= shipNumber; a++)
            {
                aY = a * 75 + 75;
                startY = aY;
            }
            bActive = true;
        }

        public bool getChangeDirection
        {
            get { return changeDirection; }
        }

        public int GetDrawY()
        {
            int Y = aY;
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
                return new Rectangle(aX + 2, aY + 2, 42, 71);
            }
        }

        public void Draw(SpriteBatch sb, int iLocation)
        {
            if (bActive)
                asSprite.Draw(sb, aX, GetDrawY(), false);
        }

        public void Update(GameTime gametime)
        {
                if (changeDirection == false)
                {
                    aY += 1;
                }
                else
                {
                    aY+= -1;
                }
              
            asSprite.Update(gametime);
        }
    }
}
