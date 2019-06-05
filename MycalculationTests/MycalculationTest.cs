using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculation;

namespace MycalculationTests
{
    [TestClass]
    public class MycalculationTest
    {
        [TestMethod]
        public void PlusOperation_2Plus3_Expected6()
        {
            // arrange 
            string input = "2+3";    
            string expected = "5";
            // act
            string result = MyCalc.Answer(input);
            // assert            
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LevelOperation_2Plus3Multy6_Expected20()
        {
            // arrange 
            string input = "2+3*6";
            string expected = "20";
            // act
            string result = MyCalc.Answer(input);
            // assert            
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LevelInAndOut1_I2Plus3IMulty6_Expected30()
        {
            // arrange 
            string input = "(2+3)*6";
            string expected = "30";
            // act
            string result = MyCalc.Answer(input);
            // assert            
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void LevelInAndOut2_I2Plus3IMulty6PlusI5Minus2I_Expected33()
        {
            // arrange 
            string input = "(2+3)*6+(5-2)";
            string expected = "33";
            // act
            string result = MyCalc.Answer(input);
            // assert            
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void LevelInAndOut3_I2Plus3I55Minus35IIMulty6PlusI5Minus2I_Expected375()
        {
            // arrange 
            string input = "(2+3(55-35))*6+(5-2)";
            string expected = "375";
            // act
            string result = MyCalc.Answer(input);
            // assert            
            Assert.AreEqual(expected, result);
        }
    }
}
