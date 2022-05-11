using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    public class Game
    {
        public bool v_GameAlive;
        public int m_boardSize;
        public bool v_playerVsPlayerMode = false;
        private Board m_GameBoard = null;
        private BoardCell[,] m_Board = null;
        public Player m_player1, m_player2;
        private string m_userInput;
        private const int k_SignOfPlayer1 = 1;
        private const int k_SignOfPlayer2 = 2;


        public Game()
        {
            v_GameAlive = true;
            InitGame();
        }

        public void InitGame()
        {
            ConsoleMessages.OpenStatement();

            m_boardSize = ConsoleInputValidation.GetSizeOfBoard();
            m_GameBoard = new Board(m_boardSize);
            m_Board = m_GameBoard.GetBoard;

            string playerOneName = ConsoleInputValidation.GetPlayerName();
            m_player1 = new Player(playerOneName);

            int opponentChoise = ConsoleInputValidation.GetOpponentChoise();


            if (opponentChoise == 1)
            {
                m_player2 = new Player("Computer");
            }
            else
            {
                m_player2 = new Player(ConsoleInputValidation.GetPlayerName());
                v_playerVsPlayerMode = true;
            }
            ConsoleMessages.LetsPlay();
        }


        public void Run()
        {
            VisualBoard.ShowBoard(m_Board); // don't forget to change visual board to accepts Boards!
            ConsoleMessages.PrintPlayerTurn(m_player1.Name, k_SignOfPlayer1);

            while (v_GameAlive)
            {
                playerOneMove();
                VisualBoard.ShowBoard(m_Board);
                ConsoleMessages.PrintPlayerMove(m_userInput, m_player1.Name, k_SignOfPlayer1);
                ConsoleMessages.PrintPlayerTurn(m_player2.Name, k_SignOfPlayer2);
                if (isWonOrDraw(m_player1, m_player2))
                {
                    break;
                }

                playerTwoMove(); // player2 or computer 
                VisualBoard.ShowBoard(m_Board);
                ConsoleMessages.PrintPlayerMove(m_userInput, m_player2.Name, k_SignOfPlayer2);
                ConsoleMessages.PrintPlayerTurn(m_player1.Name, k_SignOfPlayer1);
                if (isWonOrDraw(m_player1, m_player2))
                {
                    break;
                }
            }

            if (PlayAgain())
            {
                ResetGame();
                Run();
            }
            else
            {
                EndGame();
            }

        }


        private void playerOneMove() //TODO: Implement this
        {

            string userInput = Console.ReadLine();
            m_userInput = ConsoleInputValidation.GetUserMove(m_boardSize, userInput);

            if (m_userInput == "q" && m_userInput == "Q")
            {
                playerWantsToQuit(m_player1);
            }

            m_GameBoard.MakeMove(m_userInput, k_SignOfPlayer1);

        }

        private bool isWonOrDraw(Player i_Player1, Player i_Player2) //TODO: Implement this
        {
            bool answer = false;
            if (m_GameBoard.IsWon(i_Player1, i_Player2)) // print won message and caculate player score
            {
                answer = true;
            }
            else
            {// draw
             // list l = GetLegalMoves() // how to implement this shit
             //if list.length == 0
             //output draw statement
             //answer = true;
             //List<BoardCell> cellsList = new List<BoardCell>();

            }

            return answer;

        }

        public void playerTwoMove() //TODO: Implement this
        {
            if (!v_playerVsPlayerMode) // play against the computer
            {
                //choose random player2 cell
                //get array of legal move
                // choose random move from legal move
            }
            else
            {
                string userInput = Console.ReadLine();
                m_userInput = ConsoleInputValidation.GetUserMove(m_boardSize, userInput);

                if (m_userInput == "q" && m_userInput == "Q")
                {
                    playerWantsToQuit(m_player2);
                }

                m_GameBoard.MakeMove(m_userInput, k_SignOfPlayer2);

            }


        }


        public void ResetGame()
        { // reset the game for another play
            m_GameBoard.ResetBoard();
            v_GameAlive = true;

        }


        public void EndGame() // TODO: Implement
        {
            v_GameAlive = false;


            // print to console goodbye or somthing 
        }


        private bool PlayAgain()
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



        private void playerWantsToQuit(Player player) // quit the game
        {
            // update player soldier to zero and call isWon()

            //maybe ask if start new game or end for good
            // EndGame();
        }
    }
}