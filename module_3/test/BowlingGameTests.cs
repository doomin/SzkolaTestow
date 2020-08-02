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

        [Category("BowlingKata")]
        [Test]
        public void ShouldReturnZeroWhenNoRollsDone()
        {           
            game.GetScore().Should().Be(0);
        }

        [Category("BowlingKata")]
        [TestCase(20, 0)]
        public void ShouldReturn0WhenNoPinsDown(int pins, int numberOfThrows)
        {
            TestRollForWholeGame(0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);
            game.GetScore().Should().Be(0);
        }

        [Category("BowlingKata")]
        [Test]
        public void ShouldReturn20When20PinsDown()
        {
            TestRollForWholeGame(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            game.GetScore().Should().Be(20);
        }

        [Category("BowlingKata")]
        [Test]
        public void ShouldReturnSpare()
        {
            TestRollForWholeGame(5, 5, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            game.GetScore().Should().Be(18);
        }

        [Category("BowlingKata")]
        [Test]
        public void ShouldScoreStrike()
        {
            TestRollForWholeGame(10, 4,4, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0);
            game.GetScore().Should().Be(26);
        }

        [Category("BowlingKata")]
        [Test]
        public void ShouldScoreMasterStrike()
        {
            TestRollForWholeGame(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10);
            game.GetScore().Should().Be(300);
        }

        private void TestRollForWholeGame(params int[] pins)
        {
            foreach (int pin in pins)
            {
                game.Roll(pin);
            };
        }

        private void TestRoll(int pins, int numberOfThrows)
        {
            for (int i = 0; i < numberOfThrows; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
