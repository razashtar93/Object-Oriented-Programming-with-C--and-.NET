using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    public class consoleMessages
    {
        public static void OpenStatement()
        {
            Console.WriteLine("Welcome To American Cheackers.");
        }

        public static void OpponentChoosingStatement()
        {
            Console.WriteLine("Choose Opponent: ");
        }

        public static void ComputerChoosing()
        {
            Console.WriteLine("To play against the computer please press 1.");
        }

        public static void HumanChoosing()
        {
            Console.WriteLine("To play against another player please press 2.");
        }

        public static void InValideInputeError()
        {
            Console.WriteLine("The input is invalid, Please try again.");
        }

        public static void SizeOfBoardMessege()
        {
            Console.WriteLine("Please choose the size of the board: (6,8 or 10)");
        }

        public static void PointsStatementMessege()
        {
            Console.WriteLine("The points are player one: {0} and player two: {1}");
        }

        public static void PlayAgainMessege()
        {
            Console.WriteLine("Wanna play again? [y/n]");
        }

        public static void EnterName()
        {
            Console.WriteLine("Please enter your name");
        }

        public static void LetsPlay()
        {
            Console.WriteLine("Lets play!");
        }


        //// A base for a messega method
        //public static void ()
        //{
        //    Console.WriteLine();
        //}        

    }
}
