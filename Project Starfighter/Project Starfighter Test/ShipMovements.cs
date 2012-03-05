using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Starfighter;


namespace Project_Starfighter_Test
{
    [TestClass]
    public class ShipMovements
    {
        ActionScreen bckgnd = new ActionScreen();
        Player p = new Player();

        [TestMethod]
        public void ShipMovingRight_Test()
        {
            bckgnd.BackgroundOffset = 0;
            bckgnd.BackgroundOffset += 1;
            Assert.AreEqual(1, bckgnd.BackgroundOffset);

        }

        [TestMethod]
        public void ShipMovingLeft_Test()
        {
            bckgnd.BackgroundFileWidth = 20;
            bckgnd.BackgroundOffset = 0;
            bckgnd.BackgroundOffset -= 1;
            Assert.AreEqual(19, bckgnd.BackgroundOffset);

        }


        [TestMethod]
        public void ShipMovingUp_Test()
        {
            p.Y = 0;
            p.Y += 1;
            Assert.AreEqual(1, p.Y);
        }

        [TestMethod]
        public void ShipMovingDown_Test()
        {
            p.Y = 0;
            p.Y -= 1;
            Assert.AreEqual(-1, p.Y);
        }
    }
}