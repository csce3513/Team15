using Project_Starfighter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using NUnit.Framework;

namespace Project_Starfighter_Test
{
    
    
    /// <summary>
    ///This is a test class for MenuComponentTest and is intended
    ///to contain all MenuComponentTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MenuComponentTest
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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for MenuComponent Constructor
        ///</summary>
        [TestMethod()]
        public void MenuComponentConstructorTest()
        {
            Game game = null; // TODO: Initialize to an appropriate value
            SpriteBatch spriteBatch = null; // TODO: Initialize to an appropriate value
            SpriteFont spriteFont = null; // TODO: Initialize to an appropriate value
            string[] menuItems = null; // TODO: Initialize to an appropriate value
            MenuComponent target = new MenuComponent(game, spriteBatch, spriteFont, menuItems);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CheckKey
        ///</summary>
        [TestMethod()]
        public void CheckKeyTest()
        {
            Game game = null; // TODO: Initialize to an appropriate value
            SpriteBatch spriteBatch = null; // TODO: Initialize to an appropriate value
            SpriteFont spriteFont = null; // TODO: Initialize to an appropriate value
            string[] menuItems = null; // TODO: Initialize to an appropriate value
            MenuComponent target = new MenuComponent(game, spriteBatch, spriteFont, menuItems); // TODO: Initialize to an appropriate value
            Keys theKey = new Keys(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CheckKey(theKey);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        [TestMethod()]
        public void DrawTest()
        {
            Game game = null; // TODO: Initialize to an appropriate value
            SpriteBatch spriteBatch = null; // TODO: Initialize to an appropriate value
            SpriteFont spriteFont = null; // TODO: Initialize to an appropriate value
            string[] menuItems = null; // TODO: Initialize to an appropriate value
            MenuComponent target = new MenuComponent(game, spriteBatch, spriteFont, menuItems); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.Draw(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        public void InitializeTest()
        {
            Game game = null; // TODO: Initialize to an appropriate value
            SpriteBatch spriteBatch = null; // TODO: Initialize to an appropriate value
            SpriteFont spriteFont = null; // TODO: Initialize to an appropriate value
            string[] menuItems = null; // TODO: Initialize to an appropriate value
            MenuComponent target = new MenuComponent(game, spriteBatch, spriteFont, menuItems); // TODO: Initialize to an appropriate value
            target.Initialize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MeasureMenu
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Project Starfighter.exe")]
        public void MeasureMenuTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            MenuComponent_Accessor target = new MenuComponent_Accessor(param0); // TODO: Initialize to an appropriate value
            target.MeasureMenu();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Game game = null; // TODO: Initialize to an appropriate value
            SpriteBatch spriteBatch = null; // TODO: Initialize to an appropriate value
            SpriteFont spriteFont = null; // TODO: Initialize to an appropriate value
            string[] menuItems = null; // TODO: Initialize to an appropriate value
            MenuComponent target = new MenuComponent(game, spriteBatch, spriteFont, menuItems); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.Update(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Height
        ///</summary>
        [TestMethod()]
        public void HeightTest()
        {
            Game game = null; // TODO: Initialize to an appropriate value
            SpriteBatch spriteBatch = null; // TODO: Initialize to an appropriate value
            SpriteFont spriteFont = null; // TODO: Initialize to an appropriate value
            string[] menuItems = null; // TODO: Initialize to an appropriate value
            MenuComponent target = new MenuComponent(game, spriteBatch, spriteFont, menuItems); // TODO: Initialize to an appropriate value
            float actual;
            actual = target.Height;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Position
        ///</summary>
        [TestMethod()]
        public void PositionTest()
        {
            Game game = null; // TODO: Initialize to an appropriate value
            SpriteBatch spriteBatch = null; // TODO: Initialize to an appropriate value
            SpriteFont spriteFont = null; // TODO: Initialize to an appropriate value
            string[] menuItems = null; // TODO: Initialize to an appropriate value
            MenuComponent target = new MenuComponent(game, spriteBatch, spriteFont, menuItems); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 actual;
            target.Position = expected;
            actual = target.Position;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectedIndex
        ///</summary>
        [TestMethod()]
        public void SelectedIndexTest()
        {
            Game game = null; // TODO: Initialize to an appropriate value
            SpriteBatch spriteBatch = null; // TODO: Initialize to an appropriate value
            SpriteFont spriteFont = null; // TODO: Initialize to an appropriate value
            string[] menuItems = null; // TODO: Initialize to an appropriate value
            MenuComponent target = new MenuComponent(game, spriteBatch, spriteFont, menuItems); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.SelectedIndex = expected;
            actual = target.SelectedIndex;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Width
        ///</summary>
        [TestMethod()]
        public void WidthTest()
        {
            Game game = null; // TODO: Initialize to an appropriate value
            SpriteBatch spriteBatch = null; // TODO: Initialize to an appropriate value
            SpriteFont spriteFont = null; // TODO: Initialize to an appropriate value
            string[] menuItems = null; // TODO: Initialize to an appropriate value
            MenuComponent target = new MenuComponent(game, spriteBatch, spriteFont, menuItems); // TODO: Initialize to an appropriate value
            float actual;
            actual = target.Width;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
