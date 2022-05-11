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

        public static void DrawStatement() 
        {
            Console.WriteLine("It's a Tie!");
        }

        public static void PrintScore(string i_Player1Name, int i_Player1Score, string i_Player2Name, int i_Player2Score)
        {
            Console.WriteLine("The Score is:\n{0}: {1} \n{2}: {3}",
                i_Player1Name, i_Player1Score, i_Player2Name, i_Player2Score);  
        }

        public static void PrintPlayerTurn(string i_PlayerName, int i_PlayerNumber)
        {
            if (i_PlayerNumber == 1)
            {
                Console.WriteLine(i_PlayerName + " Turn (X) :");
            }
            else
            {
                Console.WriteLine(i_PlayerName + " Turn (O) :");
            }
        }

        public static void PrintPlayerMove(string i_PlayerMove, string i_PlayerName, int i_PlayerNumber)
        {
            if (i_PlayerNumber == 1)
            {
                Console.WriteLine(i_PlayerName + " move was (X) : " + i_PlayerMove);
            }
            else
            {
                Console.WriteLine(i_PlayerName + " move was (O) : " + i_PlayerMove);
            }
        }

        public static void HowToPlayMessage()
        {
            Console.WriteLine("In order to make a move,\n" +
                "write as a string the starting cell then '>' and then the target cell.\n" +
                "for example: De>Cd\n");
        }

        public static void GoodByeMessage()
        {
            Console.WriteLine("Thank You for Playing American Cheackers \n\nPress 'Enter' to exit");
        }
    }
}