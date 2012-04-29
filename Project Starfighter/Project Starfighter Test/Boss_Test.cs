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
    /// <summary>
    /// Summary description for Boss_Test
    /// </summary>
    [TestClass]
    public class Boss_Test
    {
        static Texture2D texture = null;
        static int X = 0;
        static int Y = 0;
        static int W = 45;
        static int H = 73;
        static int Frames = 1;
        Boss boss = new Boss(texture, X, Y, W, H, Frames);

        // test if boss can be deactivated
        [TestMethod]
        public void Deactivate_Test()
        {
            boss.Deactivate();
            Assert.IsFalse(boss.IsActive);
        }

        // test if boss is initially set to inactive
        [TestMethod]
        public void IsActive_Test()
        {
            Assert.AreEqual(false, boss.IsActive);
        }

        // test if boss's x position can be changed
        [TestMethod]
        public void X_Test()
        {
            int xtest = 45;
            boss.X = xtest;
            Assert.AreEqual(xtest, boss.X);
        }

        // test if boss's x position can be changed
        [TestMethod]
        public void Y_Test()
        {
            int ytest = 45;
            boss.Y = ytest;
            Assert.AreEqual(ytest, boss.Y);
        }

        // test if the boss will be activated in the correct position 
        [TestMethod]
        public void Generate_Test()
        {
            boss.Generate(1);
            Assert.AreEqual(600, boss.X);
            Assert.AreEqual(300, boss.Y);
            Assert.IsTrue(boss.IsActive);
        }

        // check if the method that changes the boss's direction in case it is out of the limits is working
        [TestMethod]
        public void GetDrawY_Test()
        {
            boss.Generate(1);
            boss.Y = 500;
            boss.GetDrawY();
            Assert.IsTrue(boss.getChangeDirection);

            boss.Y = 50;
            boss.GetDrawY();
            Assert.IsFalse(boss.getChangeDirection);

        }

        // test if the bounding box is the desired size of the boss's current image
        [TestMethod]
        public void BoundingBox_Test()
        {
            Rectangle square = new Rectangle(602, 302, 150, 104);

            boss.Generate(0);
            Assert.AreEqual(square, boss.CollisionBox);

        }

    }
}
