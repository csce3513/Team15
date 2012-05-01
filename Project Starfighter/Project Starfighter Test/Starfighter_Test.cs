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
    public class Starfighter_Test
    {
        bool startMenuSong = true;
        bool startLevelOneSong = false;
        private Starfighter testGame;

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestInitialize]
        public void Initialize()
        {
            Game game = MockRepository.GenerateStub<Game>();
            testGame = new Starfighter(game);
        }

        [TestMethod]
        public void Test_Load()
        {
            string songlocation = "Menu";
            Assert.IsNotNull(songlocation);

            bool repeatSong = true;
            Assert.IsTrue(repeatSong);
            //
            // TODO: Add test logic here
            //
        }
        [TestMethod]
        public void HandleStartScreen_Test()
        {
            startMenuSong = true;
            Assert.IsTrue(startMenuSong);
            startMenuSong = false;
            Assert.IsFalse(startMenuSong);
        }
        [TestMethod]
        public void HandleActionScreen_Test()
        {
            Assert.IsFalse(startLevelOneSong);
            startLevelOneSong = true;
            Assert.IsTrue(startLevelOneSong);
            startLevelOneSong = false;
            Assert.IsFalse(startLevelOneSong);
        }

        //[TestMethod]
        //public void HandleQuitScreen_Test
        //{

        //}

        //        [TestMethod]
        //public void HandleInstructionsScreen_Test
        //{

        //}

        //        [TestMethod]
        //public void HandleCreditScreen_Test
        //{

        //}

        //        [TestMethod]
        //public void HandleGameOverScreen_Test
        //{

        //}

        //[TestMethod]
        //public void HandleVictoryScreen_Test
        //{

        //}
    }
}
