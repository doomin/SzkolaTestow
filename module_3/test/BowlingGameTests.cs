using FluentAssertions;
using szkola_testow.module_3.src;
using NUnit.Framework;

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
        [Test]
        public void ShouldReturn20When20PinsDown()
        {
            for (int i = 0; i < 20; i++)
            {
                game.Roll(1);
            }
            game.GetScore().Should().Be(20);
        }
    }
}
