using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Starfighter;
using Microsoft.Xna.Framework;

namespace Project_Starfighter_Test
{
    [TestClass]
    public class AnimatedSprite_Test
    {
        AnimatedSprite animatedSprite;
     

        public AnimatedSprite_Test()
        {
            animatedSprite = new AnimatedSprite();
           
        }
        [TestMethod]
        public void XPosition_Test()
        {
            animatedSprite.X = 11;
            Assert.IsTrue(11 == animatedSprite.X);
        }

        [TestMethod]
        public void YPosition_Test()
        {
            animatedSprite.Y = 12;
            Assert.IsTrue(12 == animatedSprite.Y);
        }

        [TestMethod]
        public void Frame_Test()
        {
            animatedSprite.Frame = 3;
            Assert.IsTrue(3 == animatedSprite.Frame);
        }

        [TestMethod]
        public void FrameLength_Test()
        {
            animatedSprite.FrameLength = 2;
            Assert.IsTrue(2 == animatedSprite.FrameLength);
        }

        [TestMethod]
        public void IsAnimating_Test()
        {
            animatedSprite.IsAnimating = false;
            Assert.IsTrue(false == animatedSprite.IsAnimating);
        }

        [TestMethod]
        public void GetSourceRectangle_Test()
        {
            Rectangle r = new Rectangle(2, 2, 2, 2);
            Rectangle r2 = animatedSprite.GetSourceRect();
            Assert.AreEqual(r, r2);
        }

        [TestMethod]
        public void Update_Test()
        {
            animatedSprite.IsAnimating = true;
            animatedSprite.Elapsed = 1;
            animatedSprite.Frame = 2;
         
            Assert.IsTrue(2 == animatedSprite.Frame);

        }
    }
}
