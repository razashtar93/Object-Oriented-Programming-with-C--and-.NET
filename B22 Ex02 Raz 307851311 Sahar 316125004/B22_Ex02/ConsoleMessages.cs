using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    public class ConsoleMessages
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

        public static void PointsStatementMessege() // need to use this instead of PrintScore(Player i_Player1, Player i_Player2)
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

        public static void PlayerWinningMessage(string i_Name)
        {
            Console.WriteLine("Congrats! {0} is won\n", i_Name);
        }

        public static void DrawStatement() // or change here to "Its a Tie!" ...
        {
            Console.WriteLine("It's a draw! No other legal moves");
        }


        public static void PrintScore(string i_Player1Name, int i_Player1Score, string i_Player2Name, int i_Player2Score)
        {
            Console.WriteLine("The Score is:\n{0}: {1} \n{2}: {3}",
                i_Player1Name, i_Player1Score, i_Player2Name, i_Player2Score);  
        }




        public static void PrintPlayerTurn(string i_playerName, int playerNumber)
        {
            if (playerNumber == 1)
            {
                Console.WriteLine(i_playerName + " Turn (X) :");
            }
            else
            {
                Console.WriteLine(i_playerName + " Turn (O) :");
            }
        }

        public static void PrintPlayerMove(string i_playerMove, string i_playerName, int playerNumber)
        {
            if (playerNumber == 1)
            {
                Console.WriteLine(i_playerName + " move was (X) : " + i_playerMove);
            }
            else
            {
                Console.WriteLine(i_playerName + " move was (O) : " + i_playerMove);
            }
        }


        //// A base for a messega method
        //public static void ()
        //{
        //    Console.WriteLine();
        //}        

    }
}