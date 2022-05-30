using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            excecuteTests();
        }

        private static void excecuteTests()
        {
            Tests tests = new Tests();
            tests.Run();
        }
    }
}
