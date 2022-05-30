using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDate : IActionListener
    {
        public void Run()
        {
            string output = DateTime.Now.Date.ToString();
            int seperatorIndex = output.IndexOf(" ");
            Console.WriteLine(output.Substring(0, seperatorIndex));
        }
    }
}
