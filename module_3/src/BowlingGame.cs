using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace szkola_testow.module_3.src
{
    class BowlingGame
    {
        private int score;

        public int GetScore()
        {
            return score;
        }

        public int Roll(int pins)
        {
            score += pins;
            return score;
        }
    }
}
