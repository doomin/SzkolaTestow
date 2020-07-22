using NUnit.Framework;
using System;

namespace szkola_testow{

    [TestFixture]
    public class Module1{
        
        private StringCalculator calculator;

        [SetUp]
        public void Setup(){
            calculator = new StringCalculator();
        }

        [Test]
        public void ShouldReturnANumberWhenNumberGiven(){
            Assert.AreEqual(2, calculator.Add("2"));
        }
        
        [Test]
        public void ShouldReturnSumOfTwoNumbersWhenTwoNumbersGiven(){
            Assert.AreEqual(3, calculator.Add("2,1"));
        }

        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4", 10)]
        [TestCase("2,5,6,8,9,7,5,2,1,9", 54)]
        [TestCase("-1, 1", 0)]
        [TestCase("-2, -1", -3)]
        [TestCase("0", 0)]
        public void ShoudReturnSumOfNumbersWhenACommaSeparatedListOfNumbersGiven(string input, int expected)
        {
            Assert.AreEqual(expected, calculator.Add(input));
        }   
    }   
}

