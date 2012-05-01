using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Starfighter;

namespace Project_Starfighter_Test
{
    [TestClass]
    public class MenuComponent_Test
    {
        static Starfighter testGame = new Starfighter();
        static string[] menuItems = { "Quit", "New Game" };
        MenuComponent menu = new MenuComponent(testGame, testGame.spriteBatch, testGame.spriteFont, menuItems);

        [TestMethod]
        public void SelectedIndex_Test()
        {
            
            menu.MeasureMenu();
            menu.SelectedIndex = 1;
            Assert.AreEqual(1, menu.SelectedIndex);
        }
    }
}
