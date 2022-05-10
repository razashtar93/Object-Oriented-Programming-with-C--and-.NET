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




        public Game()
        {
            v_GameAlive = true;
            InitGame();
        }

        public void InitGame()
        {
            consoleMessages.OpenStatement();
            string playerOneName = ConsoleInputValidation.GetPlayerName();
            int boardSize = ConsoleInputValidation.GetSizeOfBoard(); 
            int opponentChoise = ConsoleInputValidation.GetOpponentChoise();
            consoleMessages.LetsPlay();
        }


        public void Run()
        {
            while (v_GameAlive)
            {
                //playerOneMove();
                //isWonOrDraw(player); //
                //playerTwoMove(); // player2 or computer ...
                //isWonOrDraw(player);
            }
        }


        private void playerOneMove() //TODO: Implement this
        {
            
        }

        private void isWonOrDraw(Player player) //TODO: Implement this
        {
            
        }

        public void playerTwoMove() //TODO: Implement this
        {
            //if (computer) ... else ...

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


        private bool PlayAgain() // change that all console messages go to anothe class and use calls to that class
        {
            string userResponseForPlayAgain = ConsoleInputValidation.GetUserResponseForPlayAgaine();
            bool userAnswer;
 
            if (userResponseForPlayAgain.ToLower() == "y")
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
