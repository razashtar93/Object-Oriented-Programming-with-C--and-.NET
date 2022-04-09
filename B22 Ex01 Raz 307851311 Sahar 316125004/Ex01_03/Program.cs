using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_03
{
    class Program
    {
        static void Main()
        {
            /// This is the entry point
            RunProgram();
        }

        public static void RunProgram()
        {
            System.Console.WriteLine("Please enter the number of lines for the sand clock:");
            string userInput = System.Console.ReadLine();
            int numOfLines = CheckAndGetCorrectInput(userInput);

            Ex01_02.Program.RunSandClock(numOfLines);
            System.Console.WriteLine("Press \"Enter\" to exit");
            System.Console.ReadLine();
        }

        public static int CheckAndGetCorrectInput(string inputToCheck)
        {
            int positivenumOfLines = 0;

            while (!int.TryParse(inputToCheck, out positivenumOfLines) || positivenumOfLines < 1)
            {
                System.Console.WriteLine("Your input is invalid, please enter positive number of Lines for the sand clock");
                inputToCheck = System.Console.ReadLine();
            }

            return positivenumOfLines;
        }
    }
}
