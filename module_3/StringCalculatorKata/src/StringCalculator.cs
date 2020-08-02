using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace szkola_testow.module_3.StringCalculatorKata.src
{
    class StringCalculator
    {
        private int result;

        public int Add(string input)
        {
            if (input.IsNullOrEmpty())
            {
                return 0;
            }
            
            foreach (string number in SplitStringInput(input))
            {
                result += ParseStringToInt(number);
            }
            return result;
        }

        private static int ParseStringToInt(string number)
        {
            return int.Parse(number);
        }

        private string[] SplitStringInput(string input)
        {
            char[] delims = new[] {',', '\n' };
            return input.Split(delims);
        }
    }
}
