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
    public class Enemy2_Test
    {
        static Texture2D texture = null;
        static int X = 0;
        static int Y = 0;
        static int W = 45;
        static int H = 73;
        static int Frames = 1;
        Enemy2 target = new Enemy2(texture, X, Y, W, H, Frames);

        [TestMethod]
        public void Deactivate_Test()
        {
            target.Deactivate();
            Assert.IsFalse(target.IsActive);
        }

        [TestMethod]
        public void IsActive_Test()
        {
            Assert.AreEqual(false, target.IsActive);
        }

        [TestMethod]
        public void X_Test()
        {
            int xtest = 45;
            target.X = xtest;
            Assert.AreEqual(xtest, target.X);
        }

        [TestMethod]
        public void Y_Test()
        {
            int ytest = 45;
            target.Y = ytest;
            Assert.AreEqual(ytest, target.Y);
        }

        [TestMethod]
        public void Generate_Test()
        {
            target.Generate(1);
            Assert.AreEqual(750, target.X);
            Assert.AreEqual(150, target.Y);
            Assert.IsTrue(target.IsActive);
        }

        [TestMethod]
        public void GetDrawY_Test()
        {
            target.Generate(1);
            target.Y = 201;
            target.GetDrawY();
            Assert.IsTrue(target.getChangeDirection);

            target.Y = 99;
            target.GetDrawY();
            Assert.IsFalse(target.getChangeDirection);

        }

        [TestMethod]
        public void BoundingBox_Test()
        {
            Rectangle square = new Rectangle(752, 77, 42, 71);

            target.Generate(0);
            Assert.AreEqual(square, target.CollisionBox);

        }

    }
}
