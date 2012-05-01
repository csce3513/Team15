using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Starfighter
{
    class GameOverScreen : GameScreen
    {
        MenuComponent menuComponent;
        Texture2D image;
        Rectangle imageRectangle;
        SpriteFont fontation;
        Vector2 position;
        Vector2 position2;
        Color normal = Color.White;
        string score = "0";

        /// <summary>
        /// Allows the game component to set and return which menu item was selected.
        /// </summary>
        public int SelectedIndex
        {
            get { return menuComponent.SelectedIndex; }
            set { menuComponent.SelectedIndex = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="spriteFont"></param>
        /// <param name="image"></param>
        public GameOverScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D image)
            : base(game, spriteBatch)
        {
            string[] menuItems = { "Quit", "New Game" };
            menuComponent = new MenuComponent(game,
                spriteBatch,
                spriteFont,
                menuItems);
            Components.Add(menuComponent);
            this.image = image;

            fontation = spriteFont;

            position.X = 275;
            position.Y = 250;

            position2.X = 275;
            position2.Y = 300;

            imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);

            menuComponent.Position = new Vector2(
                (imageRectangle.Width - menuComponent.Width) / 2,
                imageRectangle.Bottom - menuComponent.Height - 10);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void updateScore(int scoreCard)
        {
            int place = scoreCard;
            score = "Your final score was: ";
            score += place.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(image, imageRectangle, Color.White);
            spriteBatch.DrawString(fontation,"Game Over",position,normal);
            spriteBatch.DrawString(fontation, score, position2, normal);
            base.Draw(gameTime);
        }
    }
}
