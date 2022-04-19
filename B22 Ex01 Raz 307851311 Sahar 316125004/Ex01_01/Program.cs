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
            Console.WriteLine("The Greatest number: " + gratesti_DecNum(firstBinNumInt, secondBinNumInt, thirdBinNumInt));
            Console.WriteLine("The smallest numbre: " + smallesti_DecNum(firstBinNumInt, secondBinNumInt, thirdBinNumInt));

            // How many of the integers are a power of 2 
            Console.WriteLine("How many of the integers are a power of 2: " + (isPowerOfTwo(firstBinNumInt) + isPowerOfTwo(secondBinNumInt) + isPowerOfTwo(thirdBinNumInt)));

            //How many of the integers consist of digits which are a "strictly monotonically"
            Console.WriteLine("How many of the integers  consist of digits which are a strictly monotonically: " + (isDigitsStrictlyMonoton(firstBinNumInt) + isDigitsStrictlyMonoton(secondBinNumInt) + isDigitsStrictlyMonoton(thirdBinNumInt)));
        }


        private static string checkValidationOfInput(string i_UserInput)
        {
            while (!isLengthValid(i_UserInput, 8) || !isBinary(i_UserInput))
            {
                if (!isBinary(i_UserInput))
                {
                    Console.WriteLine("Not valid input, please enter binary number");
                    i_UserInput = Console.ReadLine();
                }
                else if (!isLengthValid(i_UserInput, 8))
                {
                    Console.WriteLine("Not valid input, please enter binary number that contain 8 digits");
                    i_UserInput = Console.ReadLine();
                }
            }
            return i_UserInput;
        }


        private static bool isLengthValid(string i_UserInput, int i_exceptedLength)
        {
            return i_UserInput.Length == i_exceptedLength;
        }

        private static bool isBinary(string i_BinaryNumStr)
        {
            for (int i = 0; i < i_BinaryNumStr.Length; i++)
            {
                if (i_BinaryNumStr[i] != '0' && i_BinaryNumStr[i] != '1')
                {
                    return false;
                }
            }
            return true;
        }


        private static int binStrToDecInt(string i_BinStr)
        {
            int powOf2 = 1;
            int i_i_DecNumInt = 0;

            for (int i = i_BinStr.Length - 1; i >= 0; i--)
            {
                i_i_DecNumInt += (int)(i_BinStr[i] - '0') * powOf2;
                powOf2 *= 2;
            }
            return i_i_DecNumInt;
        }


        private static float avgOfCharInStr(string i_FirsBinaryNumStr, string i_SecondBinaryNumStr, string i_ThirdBinaryNumStr, char i_CharToCheckAvgOfApear)
        {
            int counterOfCharAper = 0;
            for (int i = 0; i < i_FirsBinaryNumStr.Length; i++)
            {
                if (i_FirsBinaryNumStr[i] == i_CharToCheckAvgOfApear)
                {
                    counterOfCharAper++;
                }
            }
            for (int i = 0; i < i_SecondBinaryNumStr.Length; i++)
            {
                if (i_SecondBinaryNumStr[i] == i_CharToCheckAvgOfApear)
                {
                    counterOfCharAper++;
                }
            }
            for (int i = 0; i < i_ThirdBinaryNumStr.Length; i++)
            {
                if (i_ThirdBinaryNumStr[i] == i_CharToCheckAvgOfApear)
                {
                    counterOfCharAper++;
                }
            }
            return (counterOfCharAper / 3f);
        }


        private static int isPalindrome(int i_i_DecNumInt)
        {
            string i_DecNumStr = i_i_DecNumInt.ToString();
            if (i_DecNumStr.Length == 0 || i_DecNumStr.Length == 1)
            {
                return 1;
            }
            if (i_DecNumStr[0] != i_DecNumStr[i_DecNumStr.Length - 1])
            {
                return 0;
            }
            return isPalindrome(int.Parse(i_DecNumStr.Substring(1, i_DecNumStr.Length - 2)));
        }


        private static int smallesti_DecNum(int i_Num1, int i_Num2, int i_Num3)
        {
            return Math.Min(Math.Min(i_Num1, i_Num2), i_Num3);
        }


        private static int gratesti_DecNum(int i_Num1, int i_Num2, int i_Num3)
        {
            return Math.Max(Math.Max(i_Num1, i_Num2), i_Num3);
        }


        private static int isPowerOfTwo(int i_DecNum)
        {
            if (i_DecNum == 0)
            {
                return 0;
            }
            while (i_DecNum != 1)
            {
                if (i_DecNum % 2 != 0)
                {
                    return 0;
                }
                i_DecNum = i_DecNum / 2;
            }
            return 1;
        }


        private static int isDigitsStrictlyMonoton(int i_DecNum)
        {
            string numStr = i_DecNum.ToString();
            for (int i = 0; i < numStr.Length - 1; i++)
            {
                if (numStr[i] >= numStr[i + 1])
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}