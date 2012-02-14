using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework.Content;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using Rhino.Mocks;






namespace WindowsGame1.NUnitTest
{
    
    [TestFixture] // tell NUnit that the class contains tests
    class Background_Tests
    {
        private ContentManager content;
        private Background background;
        

        [SetUp]
        public void Initialize()
        {
           
            content = MockRepository.GenerateStub<ContentManager>(); // create a mock contentManager

            

            background = new Background(    content,
                                            @"Textures\PrimaryBackground",
                                            @"Textures\ParallaxStars");

        }
        public void BackgroundOffset_test()
        {
            background.BackgroundOffset = -1;
            Assert.AreEqual(1919, background.BackgroundOffset);
        }
        

        

        
    }
}
