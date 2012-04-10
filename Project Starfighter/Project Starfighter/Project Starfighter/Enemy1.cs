using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Starfighter
{
    class Enemy1
    {
        AnimatedSprite asSprite;

        int aX = 0;
        int aY = -100;
        int iBackgroundOffset = 0;
        static int MapWidth = 800;
        Vector2 vmotion = new Vector2(0f, 0f);
        float fSpeed = 1f;
        float enemyMoveCount = 0.0f;
        float enemyDelay = 0.01f;
        bool bActive = false;

        public Enemy1(Texture2D texture, int X, int Y, int W, int H, int Frames)
        {
            asSprite = new AnimatedSprite(texture, X, Y, W, H, Frames);
        }

        public void newGame()
        {
            aX = 0;
            aY = -100;
            fSpeed = 1f;
            enemyMoveCount = 0.0f;
            enemyDelay = 0.01f;
            bActive = false;
            iBackgroundOffset = 0;
            vmotion.X = 0f;
            vmotion.Y = 0f;
        }

        public void Deactivate()
        {
            bActive = false;
        }

        private int GetDrawX()
        {
            int X = aX - iBackgroundOffset;
            if (X > MapWidth)

                X -= MapWidth;
            if (X < 0)
                X += MapWidth;

            return X;
        }

        public void Movement()
        {
            vmotion.X = -5;
            vmotion.Y = 0;
            vmotion.Normalize();
            fSpeed = .5f;
        }

        public void Generate(int shipNumber)
        {
            aX = 750;

            for (int a = 0; a <= shipNumber; a++)
            {
                aY = a * 50 + 50;
            }
            
            Movement();
            bActive = true;
        }

        public Rectangle CollisionBox
        {
            get
            {
                int X = aX - iBackgroundOffset;
                if (X > MapWidth)
                    X -= MapWidth;
                if (X < 0)
                    X += MapWidth;
                return new Rectangle(X+2, aY+2, 69, 41);
            }
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

        public bool IsActive
        {
            get { return bActive; }
        }

        public int Offset
        {
            get { return iBackgroundOffset; }
            set { iBackgroundOffset = value; }
        }

        public float Speed
        {
            get { return fSpeed; }
        }

        public Vector2 Motion
        {
            get { return vmotion; }
            set { vmotion = value; }
        }

        public void Draw(SpriteBatch sb, int iLocation)
        {
            if (bActive)
                asSprite.Draw(sb, GetDrawX(), aY, false);
        }

        public void Update(GameTime gametime, int iOffset)
        {
            iBackgroundOffset = iOffset;
 
            enemyMoveCount += (float)gametime.ElapsedGameTime.TotalSeconds;
            if (enemyMoveCount > enemyDelay)
            {
                aX += (int)((float)vmotion.X * fSpeed);
                aY += (int)((float)vmotion.Y * fSpeed);
 
                //if (rndGen.Next(200) == 1)
                //{
                    Movement();
                //}
 
                if (aX < 0)
                    Deactivate();
 
                if (aX > MapWidth)
                    aX -= MapWidth;
 
                enemyMoveCount = 0f;
            }
            asSprite.Update(gametime);
        }
    }
}
