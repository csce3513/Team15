using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Starfighter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rhino.Mocks;
using Microsoft.Xna.Framework.Content;

namespace Project_Starfighter_Test
{
    [TestClass]
    public class ActionScreen_Test
    {

        private Starfighter testGame;
        private readonly GameTime gameTime = new GameTime();
        private ActionScreen action;
        

        [TestInitialize]
        public void Initialize()
        {
            Game game = MockRepository.GenerateStub<Game>();
            testGame = MockRepository.GenerateStub<Starfighter>(game);

            action = new ActionScreen(game,testGame.spriteBatch);
        }

        [TestMethod]
        public void CheckIntersection_Test()
        {
            Initialize();
            Rectangle test1 = new Rectangle(0,10,25,35);
            Rectangle test2 = new Rectangle(4, 3, 22, 53);
            Assert.IsTrue(action.Intersects(test1,test2));
        }

        [TestMethod]
        public void CheckEndofWave1_Test()
        {
            Initialize();
            action.endofWave1Status = 10;
            action.CheckEndofWave1();
            Assert.IsTrue(action.isWave1Over);
        }

        [TestMethod]
        public void CheckEndofWave2_Test()
        {
            Initialize();
            action.endofWave2Status = 10;
            action.CheckEndOfWave2();
            Assert.IsTrue(action.isWave2Over);
        }

        [TestMethod]
        public void BackgroundOffset_Test()
        {
            Initialize();
            action.BackgroundFileWidth = 20;

            action.BackgroundOffset = 10;
            Assert.AreEqual(10, action.BackgroundOffset);

            //test for background offset less than 0
             action.BackgroundOffset = -10;
             Assert.AreEqual(10, action.BackgroundOffset);

            //test for background offset greater than background width
            action.BackgroundOffset = 31;
            Assert.AreEqual(11, action.BackgroundOffset);
        }

        [TestMethod]
        public void BackgroundFileHeight_Test()
        {
            Initialize();
            action.BackgroundFileHeight = 10;
            Assert.AreEqual(10, action.BackgroundFileHeight);
        }

        [TestMethod]
        public void BackgroundFileWidth_Test()
        {
            Initialize();
            action.BackgroundFileWidth = 10;
            Assert.AreEqual(10, action.BackgroundFileWidth);
        }

        [TestMethod]
        public void BackgroundHeight_Test()
        {
            Initialize();
            action.BackgroundHeight = 10;
            Assert.AreEqual(10, action.BackgroundHeight);
        }

        [TestMethod]
        public void BackgroundWidth_Test()
        {
            Initialize();
            action.BackgroundWidth = 10;
            Assert.AreEqual(10, action.BackgroundWidth);
        }

    }
}
