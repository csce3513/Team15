using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Starfighter
{
    class PopUpScreen : GameScreen
    {
        MenuComponent menuComponent;
        Texture2D image;
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
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="spriteFont"></param>
        /// <param name="image"></param>
        public PopUpScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D image)
            : base(game, spriteBatch)
        {
            string[] menuItems = { "Yes", "No" };
            menuComponent = new MenuComponent(game,
                spriteBatch,
                spriteFont,
                menuItems);
            Components.Add(menuComponent);
            this.image = image;
 
            imageRectangle = new Rectangle(
                (Game.Window.ClientBounds.Width - this.image.Width) / 2,
                (Game.Window.ClientBounds.Height - this.image.Height) / 2,
                this.image.Width,
                this.image.Height);
 
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
