using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            RunProgram();
        }

        public static void RunProgram()
        {
            RunSandClock(5);
            Console.WriteLine("Press \"Enter\" to exit");
            Console.ReadLine();
        }

        public static void RunSandClock(int i_NumOfAsterisks)
        {
            StringBuilder strOfAsterisks = new StringBuilder();

            if (i_NumOfAsterisks % 2 == 0)
            {
                i_NumOfAsterisks++;
            }

            strOfAsterisks.Append('*', i_NumOfAsterisks);
            displaySandClockMadeOfAsterisks(strOfAsterisks, i_NumOfAsterisks);
        }

        private static void displaySandClockMadeOfAsterisks(StringBuilder i_StrOfAsterisks, int i_NumOfAsterisks)
        {
            Console.WriteLine(i_StrOfAsterisks);
            if (i_NumOfAsterisks > 1)
            {
                i_StrOfAsterisks.Remove(i_StrOfAsterisks.Length - 2, 2);
                i_StrOfAsterisks.Insert(0, ' ');
                displaySandClockMadeOfAsterisks(i_StrOfAsterisks, i_NumOfAsterisks - 2);
                i_StrOfAsterisks.Remove(0, 1);
                i_StrOfAsterisks.Append("**");
                Console.WriteLine(i_StrOfAsterisks);
            }
        }
    }
}
