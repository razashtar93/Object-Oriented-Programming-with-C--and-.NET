using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    public class Program
    {
        public static void Main()
        {          
            americanCheckers();
        }

        private static void americanCheckers()
        {
            Game game = new Game();
            game.Run();            
        }
    }
}