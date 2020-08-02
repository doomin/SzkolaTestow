using FluentAssertions;
using NUnit.Framework;
using System;
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
        [TestCase("",0)]
        public void ShouldReturnZeroWhenPasingEmptyString(string input, int result)
        {
            stringCalculator.Add(input).Should().Be(result);
        }

        [Category("StringCalculatorKata")]
        [TestCase("1", 1)]
        public void ShouldReturnOneWhenPasingNumberOne(string input, int result)
        {
            stringCalculator.Add(input).Should().Be(result);
        }

        [Category("StringCalculatorKata")]
        [TestCase("1,2", 3)]
        [TestCase("1,2,3,4,5,6,7,8,9,0", 45)]
        public void ShouldReturnSumOfNumbersWhenPasingNumbersSeparatedByComma(string input, int result)
        {
            stringCalculator.Add(input).Should().Be(result);
        }

        [Category("StringCalculatorKata")]
        [TestCase("1\n2,3", 6)]
        public void ShouldHandleNewLinCharInInputString(string input, int result)
        {
            stringCalculator.Add(input).Should().Be(result);
        }

        [Category("StringCalculatorKata")]
        [TestCase("//;\n1;2", 3)]
        public void ShouldSumInputNumbersSplitByDelimiterPassedAsFirstChar(string input, int result)
        {
            stringCalculator.Add(input).Should().Be(result);
        }

        [Category("StringCalculatorKata")]
        [TestCase("//;\n1;2;-2", "Negatives not allowed: -2")]
        public void ShouldThrowExceptionWhenNegativeNumberPassed(string input, string msg)
        {
            Action act = () => {
                stringCalculator.Add(input);
            };

            act.Should().Throw<Exception>()
                    .WithMessage(msg);
        }

        [Category("StringCalculatorKata")]
        [TestCase("//;\n-1;2;-2", "Negatives not allowed: -1,-2")]
        public void ShouldShowNegativesInExceptionMEssageWhenNegativesPassed(string input, string msg)
        {
            Action act = () => {
                stringCalculator.Add(input);
            };

            act.Should().Throw<Exception>()
                    .WithMessage(msg);
        }

        [Category("StringCalculatorKata")]
        [TestCase("//;\n1;2;1000", 3)]
        public void ShouldIgnoreNumberLargerThan1000(string input, int result)
        {
            stringCalculator.Add(input).Should().Be(result);
        }
    }
}
