using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_05
{
    class Program
    {
        public static void Main()
        {
            numericStatistics();
        }

        private static void numericStatistics()
        {
            Console.WriteLine("Please enter a 7 digits integer");
            string numberTypeStr = checkInputValidation(Console.ReadLine());
            string output = String.Format(@"The minimum digit is: {0}
The avarage of the digits is: {1}
The number of the digits that divide by 2 without curry is: {2}
The number of the digits that bigger than the unity digit is: {3}",
                   minDigit(numberTypeStr), avgDigits(numberTypeStr), counterOfDividersByTwo(numberTypeStr),
                   counterOfDigitsBiggersUnity(numberTypeStr));
            
            Console.WriteLine(output);
            Console.WriteLine("Press \"Enter\" to exit");
            Console.ReadLine();
        }

        private static string checkInputValidation(string i_UserInput)
        {
            while (!isNumberCheck(i_UserInput))
            {
                Console.WriteLine("Please enter a valid input that consist only numbers, 7 digits only");
                i_UserInput = Console.ReadLine();
            }

            return i_UserInput;
        }

        private static bool isNumberCheck(string i_UserInput)
        {
            bool isNumber = false;

            if (i_UserInput.Length == 7)
            {
                isNumber = true;
                for (int i = 0; i < i_UserInput.Length; i++)
                {
                    if (i_UserInput[i] < 48 || i_UserInput[i] > 57)
                    {
                        isNumber = false;
                        break;
                    }
                }
            }

            return isNumber;
        }

        private static char minDigit(string i_UserInput)
        {
            char minDigit = '9';

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (minDigit > i_UserInput[i])
                {
                    minDigit = i_UserInput[i];
                }
            }

            return minDigit;
        }

        private static double avgDigits(string i_UserInput)
        {
            int sumOfDigits = 0;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                sumOfDigits += int.Parse(i_UserInput[i].ToString());
            }

            return ((double)sumOfDigits / (double)i_UserInput.Length);
        }

        private static int counterOfDividersByTwo(string i_UserInput)
        {
            int counterOfDividers = 0;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (int.Parse(i_UserInput[i].ToString()) % 2 == 0)
                {
                    counterOfDividers++;
                }
            }

            return counterOfDividers;
        }

        private static int counterOfDigitsBiggersUnity(string i_UserInput)
        {
            int counterOfBiggerDigitsThanUnity = 0;

            for (int i = 0; i < i_UserInput.Length - 1; i++)
            {
                if (i_UserInput[i] > i_UserInput[i_UserInput.Length - 1])
                {
                    counterOfBiggerDigitsThanUnity++;
                }
            }

            return counterOfBiggerDigitsThanUnity;
        }
    }
}