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
    public class Enemy1_Test
    {
        Enemy1 testEnemy;
        GameTime gameTime;

        [TestMethod]
        public void Enemy1_Test()
        {
            //Background background = new Background();
            gameTime = MockRepository.GenerateStub<GameTime>();
            testEnemy = new Enemy1();
        }
    }
}
