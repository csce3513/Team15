using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_Starfighter
{
    class CreditScreen : GameScreen
    {
        MenuComponent menuComponent;
        Texture2D image;
        KeyboardState keyboardState;
        Rectangle imageRectangle;

        /// <summary>
        /// 
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
        public CreditScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D image)
            : base(game, spriteBatch)
        {
            string[] menuItems = { "Credits:", "Gerald Hogue", "Ben Gooding", "Aarao Gouveia", "Mike Davis" };
             menuComponent = new MenuComponent(game, spriteBatch, spriteFont, menuItems);
              Components.Add(menuComponent);
            this.image = image;
            imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(image, imageRectangle, Color.White);
            base.Draw(gameTime);
        }
    }
}
