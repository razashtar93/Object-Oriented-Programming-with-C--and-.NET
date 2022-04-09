using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        static void Main()
        {
            /// This is the entry point
            RunProgram();
        }

        public static void RunProgram()
        {
            RunSandClock(5);
            System.Console.WriteLine("Press \"Enter\" to exit");
            System.Console.ReadLine();
        }

        public static void RunSandClock(int i_numOfAsterisks)
        {
            StringBuilder strOfAsterisks = new StringBuilder();

            if (i_numOfAsterisks % 2 == 0)
            {
                i_numOfAsterisks++;
            }

            strOfAsterisks.Append('*', i_numOfAsterisks);
            displaySandClockMadeOfAsterisks(strOfAsterisks, i_numOfAsterisks);
        }

        private static void displaySandClockMadeOfAsterisks(StringBuilder i_strOfAsterisks, int i_numOfAsterisks)
        {
            System.Console.WriteLine(i_strOfAsterisks);
            if( i_numOfAsterisks > 1)
            {
                i_strOfAsterisks.Remove(i_strOfAsterisks.Length - 2, 2);
                i_strOfAsterisks.Insert(0, ' ');
                displaySandClockMadeOfAsterisks(i_strOfAsterisks, i_numOfAsterisks - 2);
                i_strOfAsterisks.Remove(0, 1);
                i_strOfAsterisks.Append("**");
                System.Console.WriteLine(i_strOfAsterisks);
            }

        }
    }
}
