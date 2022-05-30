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
            Console.WriteLine("Please write some sentence:");
            string userInput = Console.ReadLine();
            int numberOfSpaces = userInput.Count(f => (f == ' '));
            Console.WriteLine(String.Format("Number of spaces: {0}", numberOfSpaces));
        }
    }
}
