using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace szkola_testow.module_3.StringCalculatorKata.src
{
    class StringCalculator
    {
        private int result = 0;
        private List<int> negativesArr = new List<int>();

        public int Add(string input)
        {
            if (input.IsNullOrEmpty())
            {
                return result;
            }

            foreach (string number in SplitStringInput(input))
            {
                int supportInt = ParseStringToInt(number);

                CalculateResult(supportInt);

                CollectNegatvies(negativesArr, supportInt);
            }

            HandleNegativesException();

            return result;
        }

        private void HandleNegativesException()
        {
            if (negativesArr.Count > 0)
            {
                string combindedString = string.Join(",", negativesArr.ToArray());
                throw (new Exception(String.Format("Negatives not allowed: {0}", combindedString)));
            }
        }

        private void CalculateResult(int supportInt)
        {
            if (supportInt >= 0 && supportInt < 1000)
            {
                result += supportInt;
            }
        }

        private static void CollectNegatvies(List<int> negativesArr, int supportInt)
        {
            if (supportInt < 0)
            {
                negativesArr.Add(supportInt);
            }
        }

        private static int ParseStringToInt(string number)
        {
            if(int.TryParse(number, out int n))
            {
                return int.Parse(number);
            }
            return 0;
        }

        private static string[] SplitStringInput(string input)
        {
            char[] delims = new[] { ',', '\n' };

            Regex pattern =new Regex(@"(?<=\[)(.*?)(?=\])");

            if (input.Substring(0, 1).ToCharArray()[0] == '/')
            {
                if (pattern.Matches(input).Count>0)
                {
                    foreach (Match match in pattern.Matches(input))
                    {
                        Array.Resize(ref delims, delims.Length + 1);
                        delims[delims.Length - 1] = match.Value.ToCharArray()[0];
                    }
                }
                else
                {
                    char delim = input.Substring(0, 3).ToCharArray()[2];
                    delims = new[] { delim, '\n' };
                }
            }
            return input.Split(delims);
        }
    }
}
