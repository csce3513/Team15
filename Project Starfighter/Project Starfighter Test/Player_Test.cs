using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Starfighter;
using Microsoft.Xna.Framework;
using Rhino.Mocks;


namespace Project_Starfighter_Test
{
    [TestClass]
    public class Player_Test 
    {
        Player testplay;
        GameTime gameTime;
        //SpriteBatch sp;

        public Player_Test()
        {
            Background background = new Background();
            gameTime = MockRepository.GenerateStub<GameTime>();
            testplay = new Player();
            //sb = MockRepository.GenerateStub<SpriteBatch>();
        }


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

        [TestMethod]
        public void Facing_Test()
        {
            testplay.Facing = 1;
            Assert.IsTrue(1 == testplay.Facing);
        }

        [TestMethod]
        public void Thrusting_Test()
        {
            testplay.Thrusting = true;
            Assert.IsTrue(true == testplay.Thrusting);
        }

        [TestMethod]
        public void ScrollRate_Test()
        {
            testplay.ScrollRate = 2;
            Assert.IsTrue(2 == testplay.ScrollRate);
        }

        [TestMethod]
        public void AccelRate_Test()
        {
            testplay.AccelerationRate = 3;
            Assert.IsTrue(3 == testplay.AccelerationRate);
        }

        [TestMethod]
        public void BoundingBox_Test()
        {
            Rectangle r = new Rectangle(11, 12, 72, 16);
            testplay.X = 11;
            testplay.Y = 12;
            Assert.AreEqual(r, testplay.BoundingBox);
        }
        [TestMethod]
        public void Update_Test()
        {
            testplay.Facing = 2;
            testplay.Thrusting = true;
            testplay.Update(gameTime);

            Assert.IsTrue(3 == testplay.asSprite.Frame);
        }
        //[TestMethod]
        //public void Draw_Test()
        //{
        //    testplay.Draw(sb);
        //}
    }
}
