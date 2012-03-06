using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_Starfighter
{
   
    public class InstructionsScreen : GameScreen
    {
        MenuComponent menuComponent;
        Texture2D image;
        KeyboardState keyboardState;
        Rectangle imageRectangle;

        /// <summary>
        /// Allows the game component to set and return which menu item was selected.
        /// </summary>
        public int SelectedIndex
        {
            get { return menuComponent.SelectedIndex; }
            set { menuComponent.SelectedIndex = value; }
        }
        
        /// <summary>
        /// Constructor for the Instructions Screen
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="spriteFont"></param>
        /// <param name="image"></param>
        public InstructionsScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D image)
            : base(game, spriteBatch)
        {
            string[] menuItems = { "W - move up", "S - move down", "A - move left", "D - move right", "Space - shoot laser" };
            menuComponent = new MenuComponent(game, spriteBatch, spriteFont, menuItems);
            Components.Add(menuComponent);
            this.image = image;
            imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);

        }

        /// <summary>
        /// Draws and updates the game screen.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            //spriteBatch.Begin();
            //words to draw on screen
            //string instructions = "W - move up\nS - move down\nA - move left\nD - move right";
            //Find the center of the text
            //Vector2 FontOrigin = spriteFont.MeasureString(instructions) / 2;
            //Draw the string
            //spriteBatch.DrawString(spriteFont, instructions, FontOrigin, Color.LightGreen, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            //spriteBatch.End();

            spriteBatch.Draw(image, imageRectangle, Color.White);
            base.Draw(gameTime);
        }
    }
}
    