using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Starfighter;
using Microsoft.Xna.Framework;



namespace Project_Starfighter_Test
{
    [TestClass]
    public class Player_Test 
    {
        // Create a variable of type player
        Player testplay;

        // constructor for the test class
        public Player_Test()
        {
            //create a new player instance and invoke constructor 
            testplay = new Player();
          
        }

        // The next two tests make sure we can initiate the player position.
        [TestMethod]
        public void XPosition_Test()
        {
            testplay.X = 11;
            Assert.IsTrue(11 == testplay.X);
        }

        [TestMethod]
        public void YPosition_Test()
        {
            testplay.Y = 12;
            Assert.IsTrue(12 == testplay.Y);
        }

        // makes sure the bounding box is working properly
        [TestMethod]
        public void BoundingBox_Test()
        {
            Rectangle r = new Rectangle(11, 12, 72, 16);
            testplay.X = 11;
            testplay.Y = 12;
            Assert.AreEqual(r, testplay.BoundingBox);
        }

    }
}
