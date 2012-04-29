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
        AnimatedSprite animatedSprite; // create new animated sprite
     
        // constructor 
        public AnimatedSprite_Test()
        {
            animatedSprite = new AnimatedSprite(); // initiate animated sprite
           
        }

        // test if x position is being set correctly
        [TestMethod]
        public void XPosition_Test()
        {
            animatedSprite.X = 11;
            Assert.IsTrue(11 == animatedSprite.X);
        }

        // test if y position is being set correctly
        [TestMethod]
        public void YPosition_Test()
        {
            animatedSprite.Y = 12;
            Assert.IsTrue(12 == animatedSprite.Y);
        }

        // test if bool is animating is being set properly
        [TestMethod]
        public void IsAnimating_Test()
        {
            animatedSprite.IsAnimating = false;
            Assert.IsTrue(false == animatedSprite.IsAnimating);
        }

        // test if rectangle that represents the sprite is being set properly
        [TestMethod]
        public void GetSourceRectangle_Test()
        {
            Rectangle r = new Rectangle(2, 2, 2, 2);
            Rectangle r2 = animatedSprite.GetSourceRect();
            Assert.AreEqual(r, r2);
        }

    }
}
