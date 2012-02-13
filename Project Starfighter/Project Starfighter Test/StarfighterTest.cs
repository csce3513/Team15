using Project_Starfighter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace Project_Starfighter_Test
{
    
    
    /// <summary>
    ///This is a test class for StarfighterTest and is intended
    ///to contain all StarfighterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StarfighterTest
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
        ///A test for Starfighter Constructor
        ///</summary>
        [TestMethod()]
        public void StarfighterConstructorTest()
        {
            Starfighter target = new Starfighter();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Project Starfighter.exe")]
        public void DrawTest()
        {
            Starfighter_Accessor target = new Starfighter_Accessor(); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.Draw(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Project Starfighter.exe")]
        public void InitializeTest()
        {
            Starfighter_Accessor target = new Starfighter_Accessor(); // TODO: Initialize to an appropriate value
            target.Initialize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadContent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Project Starfighter.exe")]
        public void LoadContentTest()
        {
            Starfighter_Accessor target = new Starfighter_Accessor(); // TODO: Initialize to an appropriate value
            target.LoadContent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UnloadContent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Project Starfighter.exe")]
        public void UnloadContentTest()
        {
            Starfighter_Accessor target = new Starfighter_Accessor(); // TODO: Initialize to an appropriate value
            target.UnloadContent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Project Starfighter.exe")]
        public void UpdateTest()
        {
            Starfighter_Accessor target = new Starfighter_Accessor(); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.Update(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
