using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Starfighter
{
    class StartScreen : GameScreen
    {
        MenuComponent menuComponent;
        Texture2D image;
        Texture2D header;
        Rectangle imageRectangle;
        Rectangle headerRectangle;

        public int SelectedIndex
        {
            get { return menuComponent.SelectedIndex; }
            set { menuComponent.SelectedIndex = value; }
        }

        public StartScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D image, Texture2D header)
            : base(game, spriteBatch)
        {
            string[] menuItems = { "Start Game", "Instructions", "High Score", "Credits", "Quit" };
            menuComponent = new MenuComponent(game, spriteBatch, spriteFont, menuItems);
            Components.Add(menuComponent);
            this.image = image;
            this.header = header;

            imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
            headerRectangle = new Rectangle(0,0, 666,224);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Draw(image, imageRectangle, Color.White);
            spriteBatch.Draw(header, headerRectangle, Color.Blue);
            base.Draw(gameTime);
        }
    }
}
