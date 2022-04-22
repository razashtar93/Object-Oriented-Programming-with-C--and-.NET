using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_01
{
    public class Program
    {
        public static void Main()
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
            double avgNumOfZeros = avgOfCharInStr(firstBinNumStr, secondBinNumStr, thirdBinNumStr, '0');
            double avgNumOfOnes = avgOfCharInStr(firstBinNumStr, secondBinNumStr, thirdBinNumStr, '1');
            int howManyPalindromes = IsPalindrome(firstBinNumInt.ToString()) + IsPalindrome(secondBinNumInt.ToString())
                                + IsPalindrome(thirdBinNumInt.ToString());
            int howManyPowerOfTwo = isPowerOfTwo(firstBinNumInt) + isPowerOfTwo(secondBinNumInt)
                                + isPowerOfTwo(thirdBinNumInt);
            int howManyStrictlyMonotonically = isDigitsStrictlyMonoton(firstBinNumInt)
                + isDigitsStrictlyMonoton(secondBinNumInt) + isDigitsStrictlyMonoton(thirdBinNumInt);
            string output = String.Format(@"The first binary number in decimal: {0}
The second binary number in decimal: {1}
The third binary number in decimal: {2}
The average amount of 0 digits (bits) in the binary representation of the numbers: {3}
The average amount of 1 digits (bits) in the binary representation of the numbers: {4}
How many of the binary numbers in their decimal representation is Palindrome: {5}
The Greatest number: {6} 
The smallest numbre: {7}
How many of the integers are a power of 2: {8}
How many of the integers consist of digits which are a strictly monotonically: {9}",
                                            firstBinNumInt, secondBinNumInt, thirdBinNumInt,
                                            avgNumOfZeros, avgNumOfOnes, howManyPalindromes,
                                            gratestDecNum(firstBinNumInt, secondBinNumInt, thirdBinNumInt),
                                            smallestDecNum(firstBinNumInt, secondBinNumInt, thirdBinNumInt),
                                            howManyPowerOfTwo, howManyStrictlyMonotonically);

            Console.WriteLine(output);
            Console.WriteLine("Press \"Enter\" to exit");
            Console.ReadLine();
        }

        private static string checkValidationOfInput(string io_UserInput)
        {
            while (!isLengthValid(io_UserInput, 8) || !isBinary(io_UserInput))
            {
                if (!isBinary(io_UserInput))
                {
                    Console.WriteLine("Not valid input, please enter binary number");
                    io_UserInput = Console.ReadLine();
                }
                else if (!isLengthValid(io_UserInput, 8))
                {
                    Console.WriteLine("Not valid input, please enter binary number that contain 8 digits");
                    io_UserInput = Console.ReadLine();
                }
            }

            return io_UserInput;
        }

        private static bool isLengthValid(string i_UserInput, int i_ExceptedLength)
        {
            return i_UserInput.Length == i_ExceptedLength;
        }

        private static bool isBinary(string i_UserInput)
        {
            bool binary = true;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (i_UserInput[i] != '0' && i_UserInput[i] != '1')
                {
                    binary = false;
                    break;
                }
            }

            return binary;
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

        private static float avgOfCharInStr(string i_FirstUserInput, string i_SecondUserInput,
                                                string i_ThirdUserInput, char i_CharToCheckAvgOfApear)
        {
            int counterOfCharAper = 0;

            for (int i = 0; i < i_FirstUserInput.Length; i++)
            {
                if (i_FirstUserInput[i] == i_CharToCheckAvgOfApear)
                {
                    counterOfCharAper++;
                }
            }

            for (int i = 0; i < i_SecondUserInput.Length; i++)
            {
                if (i_SecondUserInput[i] == i_CharToCheckAvgOfApear)
                {
                    counterOfCharAper++;
                }
            }

            for (int i = 0; i < i_ThirdUserInput.Length; i++)
            {
                if (i_ThirdUserInput[i] == i_CharToCheckAvgOfApear)
                {
                    counterOfCharAper++;
                }
            }

            return (counterOfCharAper / 3f);
        }

        public static int IsPalindrome(string i_DecNumStr)
        {
            if (i_DecNumStr.Length == 0 || i_DecNumStr.Length == 1)
            {
                return 1; 
            }

            if (i_DecNumStr[0] != i_DecNumStr[i_DecNumStr.Length - 1])
            {
                return 0;
            }

            return IsPalindrome((i_DecNumStr.Substring(1, i_DecNumStr.Length - 2))); 
        }

        private static int smallestDecNum(int io_Num1, int io_Num2, int io_Num3)
        {
            return Math.Min(Math.Min(io_Num1, io_Num2), io_Num3);
        }

        private static int gratestDecNum(int io_Num1, int io_Num2, int io_Num3)
        {
            return Math.Max(Math.Max(io_Num1, io_Num2), io_Num3);
        }

        private static int isPowerOfTwo(int i_DecNum)
        {
            int powerOfTwo = 1;

            if (i_DecNum == 0)
            {
                powerOfTwo = 0;
            }
            else
            {
                while (i_DecNum != 1)
                {
                    if (i_DecNum % 2 != 0)
                    {
                        powerOfTwo = 0;
                        break;
                    }

                    i_DecNum /= 2;
                }
            }

            return powerOfTwo;
        }

        private static int isDigitsStrictlyMonoton(int i_DecNum)
        {
            int strictlyMonoton = 1;
            string numStr = i_DecNum.ToString();

            for (int i = 0; i < numStr.Length - 1; i++)
            {
                if (numStr[i] >= numStr[i + 1])
                {
                    strictlyMonoton = 0;
                    break;
                }
            }

            return strictlyMonoton;
        }
    }
}