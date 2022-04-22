using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            RunProgram();
        }

        public static void RunProgram()
        {
            Console.WriteLine("Please enter the number of lines for the sand clock:");
            string userInput = Console.ReadLine();
            int numOfLines = CheckAndGetCorrectInput(userInput);

            Ex01_02.Program.RunSandClock(numOfLines);
            Console.WriteLine("Press \"Enter\" to exit");
            Console.ReadLine();
        }

        public static int CheckAndGetCorrectInput(string i_InputToCheck)
        {
            int positiveNumOfLines = 0;

            while (!int.TryParse(i_InputToCheck, out positiveNumOfLines) || positiveNumOfLines < 1)
            {
                System.Console.WriteLine("Your input is invalid, please enter positive number of Lines for the sand clock");
                i_InputToCheck = Console.ReadLine();
            }

            return positiveNumOfLines;
        }
    }
}
