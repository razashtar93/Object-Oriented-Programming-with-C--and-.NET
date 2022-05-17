using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            openGarage();
        }

        private static void openGarage()
        {
            GarageConsoleUI garageUI = new GarageConsoleUI();
            garageUI.Run();
        }
    }
}
