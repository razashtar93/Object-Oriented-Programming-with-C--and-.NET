using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    public class Game
    {
        //private
        public bool v_GameAlive;
        public int sizeOfBoard;
        //agains computer or player
        private Board m_GameBoard = null;


        private readonly String r_OpenStatement = "Welcome To American Cheackers.";
        private readonly String r_OpponentChoosingStatement = "Choose Opponent: ";
        private readonly String r_ComputerChoosing = "To play against the computer please press 1.";
        private readonly String r_HumanChoosing = "To play against another player please press 2.";
        private readonly String r_InValideInputeError = "The input is invalid, Please try again.";
        private readonly String r_SizeOfBoardMessege = "Please choose the size of the board: (6,8 or 10)";
        private readonly String r_PointsStatementMessege = "The points are player one: {0} and player two: {1}";
        private readonly String r_PlayAgainMessege = "Wanna play again? [y/n]";


        public Game()
        {
            v_GameAlive = true;
            InitGame();
        }

        public void InitGame()
        {
            // welcome message
            // initialize all the fields ... (size of board and more)
            // create player object 
            //create another player object or computer object depand on user chice

        }


        public void Run()
        {
            while (v_GameAlive)
            {

            }
        }


        public void ResetGame() // reset the game for another play
        {
            // call it when PlayAgain() return true
        }


        public void EndGame()
        {
            // call it when PlayAgain() return false


            v_GameAlive = false;
            // print to console goodbye or somthing 
        }


        private bool PlayAgain()
        {

            Console.WriteLine(r_PlayAgainMessege);
            string userResponse = Console.ReadLine();
            bool userAnswer;

            while (userResponse.ToLower() != "y" && userResponse.ToLower() != "n")
            {
                Console.WriteLine(r_InValideInputeError);
                userResponse = Console.ReadLine();
            }

            if (userResponse.ToLower() == "y")
            {
                userAnswer = true;
            }
            else
            {
                userAnswer = false;
            }

            return userAnswer;
        }
    }
}
