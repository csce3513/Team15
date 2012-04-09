using Project_Starfighter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework.Graphics;
using Project_Starfighter;
using Microsoft.Xna.Framework;
using Rhino.Mocks;
using Microsoft.Xna.Framework.Content;

namespace Project_Starfighter_Test
{
    
     [TestClass()]
    public class Enemy1Test
    {
        Enemy1 target;
        GameTime gameTime;


        /// <summary>
        ///A test for Enemy1 Constructor
        ///</summary>
        [TestMethod()]
        public void Enemy1ConstructorTest()
        {
            gameTime = MockRepository.GenerateStub<GameTime>();
            Texture2D texture = null;
            int X = 0; 
            int Y = 0; 
            int W = 45; 
            int H = 73; 
            int Frames = 1; 
            target = new Enemy1(texture, X, Y, W, H, Frames);
            //Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Deactivate
        ///</summary>
        [TestMethod()]
        public void DeactivateTest()
        {
            bool status = target.IsActive;
            bool active = true;
            target.Deactivate();
            Assert.AreNotEqual(active, status);
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

            Assert.AreEqual(expectedActive, actualActive);
            Assert.AreEqual(expectedY, calculatedY);
        }


        /// <summary>
        ///A test for Movement
        ///</summary>
        [TestMethod()]
        public void MovementTest()
        {
            target.Movement();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
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
            GameTime gametime = null; // TODO: Initialize to an appropriate value
            int iOffset = 0; // TODO: Initialize to an appropriate value
            target.Update(gametime, iOffset);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for IsActive
        ///</summary>
        [TestMethod()]
        public void IsActiveTest()
        {
            bool expected = true;
            bool actual;
            actual = target.IsActive;
            Assert.AreEqual(expected,actual);
        }

        /// <summary>
        ///A test for Motion
        ///</summary>
        [TestMethod()]
        public void MotionTest()
        {
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Offset
        ///</summary>
        [TestMethod()]
        public void OffsetTest()
        {
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Speed
        ///</summary>
        [TestMethod()]
        public void SpeedTest()
        {
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for X
        ///</summary>
        [TestMethod()]
        public void XTest()
        {
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Y
        ///</summary>
        [TestMethod()]
        public void YTest()
        {
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
