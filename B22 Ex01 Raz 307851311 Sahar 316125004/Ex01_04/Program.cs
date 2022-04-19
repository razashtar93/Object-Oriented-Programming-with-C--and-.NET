using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_04
{
    class Program
    {
        static void Main()
        {
            textAnalyzing();
        }

        private static void textAnalyzing()
        {
            while (true)
            {
                Console.WriteLine("Please enter a string that consist only letters or only numbers, 8 digits only");
                string userInput = checkInputValidation(Console.ReadLine());

                if (isNumberCheck(userInput))
                {
                    Console.WriteLine("The number is palindrome: " + isPalindrome(userInput));
                    Console.WriteLine("The number divided by 3: " + isDividedBy(int.Parse(userInput), 3));
                    Console.ReadLine();
                }

                if (isOnlyLettersCheck(userInput))
                {
                    Console.WriteLine("The string is palindrome: " + isPalindrome(userInput));
                    Console.WriteLine("The number of lower case letters in the input is: " + lowerCaseLettersCounter(userInput));
                    Console.ReadLine();
                }
            }
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
            if (i_UserInput.Length != 8)
            {
                return false;
            }
            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (i_UserInput[i] < 48 || i_UserInput[i] > 57)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool isOnlyLettersCheck(string i_UserInput)
        {
            if (i_UserInput.Length != 8)
            {
                return false;
            }
            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (!((i_UserInput[i] > 96 && i_UserInput[i] < 123) || (i_UserInput[i] > 64 && i_UserInput[i] < 91)))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool isPalindrome(string i_UserInput)
        {
            if (i_UserInput == "")
            {
                return true;
            }
            if (i_UserInput[0] != i_UserInput[i_UserInput.Length - 1])
            {
                return false;
            }
            return isPalindrome(i_UserInput.Substring(1, i_UserInput.Length - 2));
        }

        private static bool isDividedBy(int i_NumToDivide, int i_Divider)
        {
            return (i_NumToDivide / i_Divider == 0);
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
