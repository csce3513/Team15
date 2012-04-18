using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Starfighter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Project_Starfighter_Test
{
    [TestClass]
    public class Ammo_Test
    {
        Ammo testammo;
       // GameTime gameTime;

        public Ammo_Test()
        {
         //   gameTime = MockRepository.GenerateStub<GameTime>();
            testammo = new Ammo();
        }

        [TestMethod]
        public void XPosition_Test()
        {
            testammo.aLocation.X = 11f;
            Assert.IsTrue(11f == testammo.aLocation.X);
        }

        [TestMethod]
        public void YPosition_Test()
        {
            testammo.aLocation.Y = 12f;
            Assert.IsTrue(12f == testammo.aLocation.Y);
        }

        [TestMethod]
        public void createdInActive_Test()
        {
            Assert.IsTrue(false == testammo.IsActive);
        }

        [TestMethod]
        public void fired_Test()
        {
            testammo.Fire(21, 33);
            Assert.IsTrue(true == testammo.IsActive);
        }

        [TestMethod]
        public void firedXPosition_Test()
        {
            testammo.Fire(21, 33);
            Assert.AreEqual(21f, testammo.aLocation.X);
        }

        [TestMethod]
        public void firedYPosition_Test()
        {
            testammo.Fire(21, 33);
            Assert.AreEqual(33f, testammo.aLocation.Y);
        }

        //[TestMethod]
        //public void Speed_Test()
        //{
        //	testammo.Speed = 10f;
        //    Assert.IsTrue(10f == testammo.Speed);
        //}

        [TestMethod]
        public void BoundingBox_Test()
        {
            testammo.Fire(21, 33);
            Rectangle r = new Rectangle(21, 33, 16, 3);
            Assert.AreEqual(r, testammo.BoundingBox);
        }

        //[TestMethod]
        //public void Ammo_Update_Test()
        //{
        //    testammo.Fire(21, 33);
        //    testammo.Update(gameTime);
        //    Assert.AreEqual(33, testammo.aLocation.X);
        //}
    }
}


		