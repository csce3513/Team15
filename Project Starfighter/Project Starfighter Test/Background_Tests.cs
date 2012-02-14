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
        
        private Background background = new Background();

        
        [Test]
        public void BackgroundOffsetNegative_test()
        {
            background.BackgroundOffset = -1;
            Assert.AreEqual(1919, background.BackgroundOffset);
        }

        [Test]
        public void BackgroundOffsetBiggerThanBackgroundWidth_Test()
        {
            background.BackgroundOffset = 1921;
            Assert.AreEqual(1, background.BackgroundOffset);
        }

        [Test]
        public void ParallaxOffsetNegative_test()
        {
            background.ParallaxOffset = -1;
            Assert.AreEqual(1679, background.ParallaxOffset);
        }

        [Test]
        public void ParallaxOffsetBiggerThanParallaxWidth_Test()
        {
            background.ParallaxOffset = 1681;
            Assert.AreEqual(1, background.ParallaxOffset);
        }
        

        
    }
}
