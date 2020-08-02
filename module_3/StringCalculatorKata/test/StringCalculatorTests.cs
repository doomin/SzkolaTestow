using FluentAssertions;
using NUnit.Framework;
using System.Security.Cryptography;

namespace szkola_testow.module_3.StringCalculatorKata.test
{
    class StringCalculatorTests
    {
        private src.StringCalculator stringCalculator;

        [SetUp]
        public void CreateCalculatorInstance()
        {
            stringCalculator = new src.StringCalculator();
        }

        [Category("StringCalculatorKata")]
        [Test]
        public void ShouldReturnZeroWhenPasingEmptyString()
        {
            stringCalculator.Add("").Should().Be(0);
        }

        [Category("StringCalculatorKata")]
        [Test]
        public void ShouldReturnOneWhenPasingNumberOne()
        {
            stringCalculator.Add("1").Should().Be(1);
        }

        [Category("StringCalculatorKata")]
        [TestCase("1,2", 3)]
        [TestCase("1,2,3,4,5,6,7,8,9,0", 45)]
        public void ShouldReturnSumOfNumbersWhenPasingNumbersSeparatedByComma(string input, int result)
        {
            stringCalculator.Add(input).Should().Be(result);
        }

        [Category("StringCalculatorKata")]
        [Test]
        public void ShouldHandleNewLinCharInInputString()
        {
            stringCalculator.Add("1\n2,3").Should().Be(6);
        }
    }
}
