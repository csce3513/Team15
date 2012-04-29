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
        ActionScreen bckgnd = new ActionScreen(); // create an instance of ActionScreen
        Player p = new Player();// create a new player

        // test that the ship can move to the right by simulating what happens when the right arrow key is clicked - background moves
        [TestMethod]
        public void ShipMovingRight_Test()
        {
            bckgnd.BackgroundOffset = 0;
            bckgnd.BackgroundOffset += 1;
            Assert.AreEqual(1, bckgnd.BackgroundOffset);

        }

        // test that the ship can move to the left by simulating what happens when the left arrow key is clicked - background moves
        [TestMethod]
        public void ShipMovingLeft_Test()
        {
            bckgnd.BackgroundFileWidth = 20;
            bckgnd.BackgroundOffset = 0;
            bckgnd.BackgroundOffset -= 1;
            Assert.AreEqual(19, bckgnd.BackgroundOffset);

        }

        // test that the ship can move up by simulating what happens when the up arrow is clicked - background moves
        [TestMethod]
        public void ShipMovingUp_Test()
        {
            p.Y = 0;
            p.Y += 1;
            Assert.AreEqual(1, p.Y);
        }

        // test that the ship can move down by simulating what happens when the down arrow is clicked - background moves
        [TestMethod]
        public void ShipMovingDown_Test()
        {
            p.Y = 0;
            p.Y -= 1;
            Assert.AreEqual(-1, p.Y);
        }
    }
}