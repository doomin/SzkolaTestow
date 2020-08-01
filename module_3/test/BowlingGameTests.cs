using FluentAssertions;
using szkola_testow.module_3.src;
using NUnit.Framework;
using System;
using FluentAssertions.Types;

namespace szkola_testow.module_3.test
{
    class BowlingGameTests
    {
        BowlingGame game;

        [SetUp]
        public void NewGame()
        {
            game = new BowlingGame();
        }

        [Category("module3")]
        [Test]
        public void ShouldReturnZeroWhenNoRollsDone()
        {           
            game.GetScore().Should().Be(0);
        }

        [Category("module3")]
        [TestCase(20, 0)]
        public void ShouldReturn0WhenNoPinsDown(int pins, int numberOfThrows)
        {
            Roll(pins, numberOfThrows);
            game.GetScore().Should().Be(0);
        }

        [Category("module3")]
        [TestCase(1, 20)]
        public void ShouldReturn20When20PinsDown(int pins, int numberOfThrows)
        {
            Roll(pins, numberOfThrows);
            game.GetScore().Should().Be(20);
        }


        private void Roll(int pins, int numberOfThrows)
        {
            for (int i = 0; i < numberOfThrows; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
