using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace szkola_testow.module_3.StringCalculatorKata.src
{
    class StringCalculator
    {
        private int result = 0;

        public int Add(string input)
        {
            if (input.IsNullOrEmpty())
            {
                return result;
            }

            List<int> negativesArr = new List<int>();

            foreach (string number in SplitStringInput(input))
            {
                int supportInt = ParseStringToInt(number);               
               
                if (supportInt >= 0)
                {
                    result += supportInt;
                }
                else
                {
                    negativesArr.Add(supportInt);
                }
            }

            if (negativesArr.Count > 0)
            {
                string combindedString = string.Join(",", negativesArr.ToArray());
                throw (new Exception(String.Format("Negatives not allowed: {0}", combindedString)));
            }

            return result;
        }

        private int ParseStringToInt(string number)
        {
            if(int.TryParse(number, out int n))
            {
                return int.Parse(number);
            }
            return 0;
        }

        private string[] SplitStringInput(string input)
        {
            char delim = ',';

            if (input.Substring(0, 1).ToCharArray()[0] == '/')
            {
                delim = input.Substring(0, 3).ToCharArray()[2];
            };

            char[] delims = new[] { delim, '\n' };
            return input.Split(delims);
        }
    }
}
