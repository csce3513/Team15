using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Starfighter
{
    public class HudValues
    {
        private int numbOFlives;
        private int scoreValue;
        private int levelNumber;

        public int lives
        {
            get { return numbOFlives; }
            set { numbOFlives = value; }
        }
        public int score
        {
            get { return scoreValue; }
            set
            {
                if (scoreValue + value >= 0)
                    scoreValue = value;
            }
        }
        public int level
        {
            get { return levelNumber; }
            set
            {
                if (levelNumber + value >= 0)
                    levelNumber = value;
            }
        }

        public HudValues()
        {
            lives = 3;
            score = 0;
            level = 1;
        }

        public Vector2 livesPosition = new Vector2(75, 574);
        public Vector2 scorePosition = new Vector2(480, 4);
        public Vector2 levelPosition = new Vector2(700, 4);

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            spriteBatch.DrawString(spriteFont, score.ToString("000000"), scorePosition, Color.Black);
            spriteBatch.DrawString(spriteFont, level.ToString("00"), levelPosition, Color.Black);
            spriteBatch.DrawString(spriteFont, lives.ToString("00"), livesPosition, Color.Black);
        }
    }
}
