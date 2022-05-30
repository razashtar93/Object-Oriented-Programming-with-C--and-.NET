using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountSpaces : IActionListener
    {
        public void Run()
        {
            SpacesCounter();

        }

        private void SpacesCounter()
        {
            Console.WriteLine("Please enter your sentence:");
            string userInput = Console.ReadLine();
            int numberOfSpaces = userInput.Count(f => (f == ' '));
            Console.WriteLine(String.Format("There are {0} Spaces in your sentence.\n", numberOfSpaces));
        }
    }
}
