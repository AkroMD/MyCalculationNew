using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculation;

namespace MycalculationTests
{
    [TestClass]
    public class ParseTest
    {
        [TestMethod]
        public void AddListWithCheck1_True()
        {
            // arrange 
            ListMyNumber list = new ListMyNumber();
            Char left = '1';
            Char right = '+';
            double value = 5;
            bool expected = true;
            // act
            bool result = list.AddWithCheck(value, left, right);
            // assert            
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void AddListWithCheck2_False()
        {
            // arrange 
            ListMyNumber list = new ListMyNumber();
            Char left = 'r';
            Char right = '+';
            double value = 90.2;
            bool expected = false;
            // act
            bool result = list.AddWithCheck(value, left, right);
            // assert            
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ParseCheckValisNumber1_True()
        {
            // arrange 
            Char input = '2';
            bool expected = true;
            // act
            bool result = ParseClass.CheckValid(input);
            // assert            
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ParseCheckValisNumber2_False()
        {
            // arrange 
            Char input = 'd';
            bool expected = false;
            // act
            bool result = ParseClass.CheckValid(input);
            // assert            
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Parse_2Plus3Minus5()
        {
            // arrange 
            string input = "2+3-5";
            ListMyNumber expected = new ListMyNumber();
            expected.Add(new MyNumber(2, '1', '+'));
            expected.Add(new MyNumber(3, '+', '-'));
            expected.Add(new MyNumber(5, '-', '1'));
            // act
            ListMyNumber result = ParseClass.ParseList(input);
            // assert            
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Value, result[i].Value);
                Assert.AreEqual(expected[i].Left, result[i].Left);
                Assert.AreEqual(expected[i].Right, result[i].Right);
            }
        }
    }
}
