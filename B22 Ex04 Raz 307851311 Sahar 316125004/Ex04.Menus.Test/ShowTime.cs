using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowTime : IActionListener
    {
        public void Run()
        {
            DateTime date = DateTime.Now;
            Console.WriteLine(date.TimeOfDay);
        }
    }
}
