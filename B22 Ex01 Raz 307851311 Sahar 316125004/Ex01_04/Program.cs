using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_04
{
    class Program
    {
        public static void Main()
        {
            textAnalyzing();
        }

        private static void textAnalyzing()
        {
            Console.WriteLine("Please enter a string that consist only letters or only numbers, 8 digits only");
            string userInput = checkInputValidation(Console.ReadLine());
            string output = "";

            if (isNumberCheck(userInput))
            {
                output = String.Format(@"The number is palindrome: {0}
The number divided by 3: {1}",
                                         Convert.ToBoolean(Ex01_01.Program.IsPalindrome(userInput)),
                                         isDividedBy(int.Parse(userInput), 3));
            }
            else if (isOnlyLettersCheck(userInput))
            {
                output = String.Format(@"The string is palindrome: {0}
The number of lower case letters in the input is: {1}",
                                         Convert.ToBoolean(Ex01_01.Program.IsPalindrome(userInput)),
                                         lowerCaseLettersCounter(userInput));                
            }

            Console.WriteLine(output);
            Console.WriteLine("Press \"Enter\" to exit");
            Console.ReadLine();
        }

        private static string checkInputValidation(string i_UserInput)
        {
            while (!isNumberCheck(i_UserInput) && !isOnlyLettersCheck(i_UserInput))
            {
                Console.WriteLine("Please enter a valid input that consist only letters or only numbers, 8 digits only");
                i_UserInput = Console.ReadLine();
            }

            return i_UserInput;
        }

        private static bool isNumberCheck(string i_UserInput)
        {
            bool isNumber = false;

            if (i_UserInput.Length == 8)
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

        private static bool isOnlyLettersCheck(string i_UserInput)
        {
            bool isOnlyLetters = false;

            if (i_UserInput.Length == 8)
            {
                isOnlyLetters = true;
                for (int i = 0; i < i_UserInput.Length; i++)
                {
                    if (!((i_UserInput[i] > 96 && i_UserInput[i] < 123) || (i_UserInput[i] > 64 && i_UserInput[i] < 91)))
                    {
                        isOnlyLetters = false;
                        break;
                    }
                }
            }

            return isOnlyLetters;
        }

        private static bool isDividedBy(int i_NumToDivide, int i_Divider)
        {
            return (i_NumToDivide % i_Divider == 0);
        }

        private static int lowerCaseLettersCounter(string i_UserInput)
        {
            int lowerLettersCounter = 0;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (i_UserInput[i] > 96 && i_UserInput[i] < 123)
                {
                    lowerLettersCounter++;
                }
            }

            return lowerLettersCounter;
        }
    }
}