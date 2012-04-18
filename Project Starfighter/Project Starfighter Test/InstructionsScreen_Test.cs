using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Starfighter;


namespace Project_Starfighter_Test
{
    /// <summary>
    /// Test class for the instruction screen
    /// </summary>
    [TestClass]
    public class InstructionsScreen_Test
    {
        /// <summary>
        /// Setup for testing
        /// </summary>
        [TestInitialize()]
        public void TestInitialize()
        {
            Starfighter game = new Starfighter();
            //InstructionsScreen testInstructionScreen = new InstructionsScreen(game, game.spriteBatch, game.spriteFont, game.bookpages);
            //From source
            //instructionsScreen = new InstructionsScreen(this, spriteBatch, Content.Load<SpriteFont>("menufont"), Content.Load<Texture2D>("InstructionBook"));
        }

        InstructionsScreen testInstructionsScreen;
        private TestContext testContextInstance;

        [TestMethod]
        public void TestScreen()
        {
            Assert.IsNotNull(testInstructionsScreen);
        }

        [TestMethod]
        public void TestType()
        {
            Assert.IsInstanceOfType(testInstructionsScreen, typeof(InstructionsScreen));
        }

    }
    /// <summary>
    ///This is a test class for InstructionsScreenTest and is intended
    ///to contain all InstructionsScreenTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InstructionsScreenTest
    {
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
    }
}

