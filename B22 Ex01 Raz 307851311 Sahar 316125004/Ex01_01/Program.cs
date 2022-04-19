using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_01
{
    class Program
    {
        static void Main()
        {
            binarySeries();
        }

        private static void binarySeries()
        {
            Console.WriteLine("Please enter 3 binary numbers that contain 8 digits each");
            Console.WriteLine("First binary number:");
            string firstBinNumStr = checkValidationOfInput(Console.ReadLine());
            Console.WriteLine("Second binary number:");
            string secondBinNumStr = checkValidationOfInput(Console.ReadLine());
            Console.WriteLine("Third binary number:");
            string thirdBinNumStr = checkValidationOfInput(Console.ReadLine());
            int firstBinNumInt = binStrToDecInt(firstBinNumStr);
            int secondBinNumInt = binStrToDecInt(secondBinNumStr);
            int thirdBinNumInt = binStrToDecInt(thirdBinNumStr);

            // Show the numbers in decimal
            Console.WriteLine("The first binary number in decimal: " + firstBinNumInt);
            Console.WriteLine("The second binary number in decimal: " + secondBinNumInt);
            Console.WriteLine("The third binary number in decimal: " + thirdBinNumInt);

            // avg of 1 & 0            
            double avgNumOfZeros = avgOfCharInStr(firstBinNumStr, secondBinNumStr, thirdBinNumStr, '0');
            double avgNumOfOnes = avgOfCharInStr(firstBinNumStr, secondBinNumStr, thirdBinNumStr, '1');
            Console.WriteLine("The average amount of 0 digits (bits) in the binary representation of the numbers: " + avgNumOfZeros);
            Console.WriteLine("The average amount of 1 digits (bits) in the binary representation of the numbers: " + avgNumOfOnes);

            // palindrom
            Console.WriteLine("How many of the binary number are Palindrome: " + (isPalindrome(firstBinNumInt) + isPalindrome(secondBinNumInt) + isPalindrome(thirdBinNumInt)));

            // Greatest and smallest numbers
            Console.WriteLine("The Greatest number: " + gratestDecNum(firstBinNumInt, secondBinNumInt, thirdBinNumInt));
            Console.WriteLine("The smallest numbre: " + smallestDecNum(firstBinNumInt, secondBinNumInt, thirdBinNumInt));

            // How many of the integers are a power of 2 
            Console.WriteLine("How many of the integers are a power of 2: " + (isPowerOfTwo(firstBinNumInt) + isPowerOfTwo(secondBinNumInt) + isPowerOfTwo(thirdBinNumInt)) );

            //How many of the integers consist of digits which are a "strictly monotonically"
            Console.WriteLine("How many of the integers  consist of digits which are a strictly monotonically: " + (isDigitsStrictlyMonoton(firstBinNumInt) + isDigitsStrictlyMonoton(secondBinNumInt) + isDigitsStrictlyMonoton(thirdBinNumInt)));
        }


        private static string checkValidationOfInput(string i_UserInput)
        {
            while (!isLengthValid(i_UserInput,8) || !isBinary(i_UserInput))
            {
                if (!isBinary(i_UserInput))
                {
                    Console.WriteLine("Not valid input, please enter binary number");
                    i_UserInput = Console.ReadLine();
                }
                else if (!isLengthValid(i_UserInput,8))
                {
                    Console.WriteLine("Not valid input, please enter binary number that contain 8 digits");
                    i_UserInput = Console.ReadLine();
                }
            }
            return i_UserInput;
        }


        private static bool isLengthValid(string i_UserInput , int exceptedLength)
        {
            return i_UserInput.Length == exceptedLength;
        }

        private static bool isBinary(string i_UserInput)
        {
            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (i_UserInput[i] != '0' && i_UserInput[i] != '1')
                    return false;
            }
            return true;
        }


        private static int binStrToDecInt(string i_BinStr)
        {
            int powOf2 = 1;
            int decNumInt = 0;

            for (int i = i_BinStr.Length - 1; i >= 0; i--)
            {
                decNumInt += (int)(i_BinStr[i] - '0') * powOf2;
                powOf2 *= 2;
            }
            return decNumInt;
        }


        private static float avgOfCharInStr(string i_firstUserInput, string i_secondUserInput, string i_thirdUserInput, char charToCheckAvgOfApear)
        {
            int counterOfCharAper = 0;
            for (int i = 0; i < i_firstUserInput.Length; i++)
            {
                if (i_firstUserInput[i] == charToCheckAvgOfApear)
                {
                    counterOfCharAper++;
                }
            }
            for (int i = 0; i < i_secondUserInput.Length; i++)
            {
                if (i_secondUserInput[i] == charToCheckAvgOfApear)
                {
                    counterOfCharAper++;
                }
            }
            for (int i = 0; i < i_thirdUserInput.Length; i++)
            {
                if (i_thirdUserInput[i] == charToCheckAvgOfApear)
                {
                    counterOfCharAper++;
                }
            }
            return (counterOfCharAper / 3f);
        }


        private static int isPalindrome(int decNumInt)
        {
            string decNumStr = decNumInt.ToString();
            if (decNumStr.Length == 0 || decNumStr.Length == 1)
                return 1;
      
                if (decNumStr[0] != decNumStr[decNumStr.Length - 1])
                {
                    return 0;
                }
            return isPalindrome(int.Parse(decNumStr.Substring(1,decNumStr.Length - 2)));
        }


        private static int smallestDecNum(int i_num1, int i_num2, int i_num3)
        {
            return Math.Min(Math.Min(i_num1, i_num2), i_num3);
        }


        private static int gratestDecNum(int i_num1, int i_num2, int i_num3)
        {
            return Math.Max(Math.Max(i_num1, i_num2), i_num3);
        }


        private static int isPowerOfTwo(int decNum)
        {
            if (decNum == 0)
                return 0;
            while (decNum != 1)
            {
                if (decNum % 2 != 0)
                    return 0;
                decNum = decNum / 2;
            }
            return 1;
        }


        private static int isDigitsStrictlyMonoton(int decNum) 
        {
            string numStr = decNum.ToString();
            for(int i = 0; i < numStr.Length - 1; i++)
            {
                if(numStr[i] >= numStr[i+1])
                    return 0;
            }
            return 1;
        }
    }
}