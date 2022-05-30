using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVersion : IActionListener
    {
        public void Run()
        {
            Console.WriteLine("Version: 22.2.4.8950");
        }
    }
}
