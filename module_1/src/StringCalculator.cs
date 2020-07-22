using System;

namespace test_project
{
    class StringCalculator
    {
        public int Add(String input){
            if(String.IsNullOrEmpty(input)){
                return 0;
            }

            String[] numbers = input.Split(",");
            if(numbers.Length == 1){
                String number = numbers[0];
                return GetIntFrom(number);
            }else{
                return GetIntFrom(numbers[0]) + GetIntFrom(numbers[1]); 
            }
        }

        private int GetIntFrom(String number) {return int.Parse(number);}
    }
}
