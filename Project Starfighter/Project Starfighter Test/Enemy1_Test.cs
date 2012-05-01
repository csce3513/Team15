using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Starfighter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Project_Starfighter_Test
{

    [TestClass]
    public class Enemy1_Test
    {
        
      
           static Texture2D texture = null;
           static int X = 0;
           static int Y = 0;
           static int W = 45;
           static int H = 73;
           static int Frames = 1;
            Enemy1 target = new Enemy1(texture, X, Y, W, H, Frames);


        /// <summary>
        ///A test for Deactivate
        ///</summary>
        [TestMethod()]
        public void DeactivateTest()
        {
            bool status = target.IsActive;
            bool active = false;
            target.Deactivate();
            Assert.AreEqual(active, status);
        }


        /// <summary>
        ///A test for Generate
        ///</summary>
        [TestMethod()]
        public void GenerateTest()
        {
            int shipNumber = 1;
            int expectedY = 100;
            bool expectedActive = true;
            target.Generate(shipNumber);
            bool actualActive = target.IsActive;
            int calculatedY = target.Y;
            int expectedX = 750;
            int calculatedX = target.X;

            Assert.AreEqual(expectedX, calculatedX);
            Assert.AreEqual(expectedActive, actualActive);
            Assert.AreEqual(expectedY, calculatedY);
        }


        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            int X = 0; // TODO: Initialize to an appropriate value
            int Y = 0; // TODO: Initialize to an appropriate value
            int W = 0; // TODO: Initialize to an appropriate value
            int H = 0; // TODO: Initialize to an appropriate value
            int Frames = 0; // TODO: Initialize to an appropriate value
            Enemy1 target = new Enemy1(texture, X, Y, W, H, Frames); // TODO: Initialize to an appropriate value
            //GameTime gametime = null; // TODO: Initialize to an appropriate value
            int iOffset = 0; // TODO: Initialize to an appropriate value
           // target.Update(gametime, iOffset);
          //  Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for IsActive
        ///</summary>
        [TestMethod()]
        public void IsActiveTest()
        {
            bool expected = false;
            bool actual;
            actual = target.IsActive;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Offset
        ///</summary>
        [TestMethod()]
        public void OffsetTest()
        {
            int expectedOffset = 50;
            target.Offset = 50;
            Assert.AreEqual(50, target.Offset);
        }

        /// <summary>
        ///A test for X
        ///</summary>
        [TestMethod()]
        public void XTest()
        {
            int x = 50;
            target.X = 50;
            Assert.AreEqual(x, target.X);
        }

        /// <summary>
        ///A test for Y
        ///</summary>
        [TestMethod()]
        public void YTest()
        {
            int y = 50;
            target.Y = 50;
            Assert.AreEqual(y, target.Y);
        }
    }
}
