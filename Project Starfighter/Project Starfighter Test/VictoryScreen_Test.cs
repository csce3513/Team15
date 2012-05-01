using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Project_Starfighter_Test
{
    [TestClass]
    public class VictoryScreen_Test
    {

        [TestMethod]
        public void UpdateScore_Test()
        {
            string score;
            int place = 100;
            score = "Your final score was: ";
            score += place.ToString();

            string expected = "Your final score was: 100";

            Assert.AreEqual(expected, score);

        }
    }
}
