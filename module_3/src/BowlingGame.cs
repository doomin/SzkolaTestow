using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace szkola_testow.module_3.src
{
    class BowlingGame
    {
        int roll = 0;
        private int[] rolls = new int[21];

        public int GetScore()
        {
            int score = 0;
            int cursor = 0;
            for(int i = 0; i < 10; i++)
            {
                if (IsStrike(cursor))
                {
                    score += 10 + rolls[cursor + 1] + rolls[cursor + 2];
                    cursor++;
                }
                if (IsSpare(cursor))
                {
                    score += 10 + rolls[cursor + 2];
                    cursor += 2;
                }
                else
                {
                    score += rolls[cursor] + rolls[cursor + 1];
                    cursor += 2;
                }
            }
            return score;
        }

        public Array Roll(int pins)
        {
            rolls[roll++] = pins;
            return rolls;
        }
        private bool IsSpare(int cursor)
        {
            return rolls[cursor] + rolls[cursor + 1] == 10;
        }
        private bool IsStrike(int cursor)
        {
            return rolls[cursor] == 10;
        }

    }
}
