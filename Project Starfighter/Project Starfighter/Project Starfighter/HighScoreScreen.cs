using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_Starfighter
{
    class HighScoreScreen : GameScreen
    {
        MenuComponent menuComponent;
        Texture2D image;
        KeyboardState keyboardState;
        Rectangle imageRectangle;


        public int SelectedIndex
        {
            get { return menuComponent.SelectedIndex; }
            set { menuComponent.SelectedIndex = value; }
        }

        public HighScoreScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D image)
            : base(game, spriteBatch)
        {
            //string[] menuItems = { "How To Play:", "bob", "Test", "Forever" };
            // menuComponent = new MenuComponent(game, spriteBatch, spriteFont, menuItems);
            //  Components.Add(menuComponent);
            this.image = image;
            imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(image, imageRectangle, Color.White);
            base.Draw(gameTime);
        }
    }
}
