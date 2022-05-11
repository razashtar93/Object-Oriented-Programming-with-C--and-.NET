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
        private Random m_Rand;

        public Game() // Done.
        {
            v_GameAlive = true;
            InitGame();
        }

        public void InitGame() // Done.
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
                m_Rand = new Random();
            }
            else
            {
                m_player2 = new Player(ConsoleInputValidation.GetPlayerName());
                v_playerVsPlayerMode = true;
            }
            ConsoleMessages.LetsPlay();
        }


        public void Run() // Done.
        {
            VisualBoard.ShowBoard(m_Board); 
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


        private void playerOneMove() // Done.
        {

            string userInput = Console.ReadLine();
            m_userInput = ConsoleInputValidation.GetUserMove(m_boardSize, userInput);

            if (m_userInput == "q" && m_userInput == "Q")
            {
                playerWantsToQuit(m_player1);
            }

            m_GameBoard.MakeMove(m_userInput, k_SignOfPlayer1);

        }

        private bool isWonOrDraw(Player i_Player1, Player i_Player2) //Done.
        {
            bool answer = false;

            if (m_GameBoard.IsWon(i_Player1, i_Player2)) // print won message and calculate players score
            {
                answer = true;
            }
            else
            {
                List<string> listOfPlayer1Moves = m_GameBoard.GetAllPlayerLegalMoves(k_SignOfPlayer1);
                List<string> listOfPlayer2Moves = m_GameBoard.GetAllPlayerLegalMoves(k_SignOfPlayer2);
                if (!listOfPlayer1Moves.Any() && !listOfPlayer2Moves.Any()) // both lists are empty
                { //there is a draw
                    answer = true;
                    ConsoleMessages.DrawStatement();
                }
            }

            return answer;
        }


        public void playerTwoMove() //TODO: Implement this
        {
            if (!v_playerVsPlayerMode) // play against the computer
            {
                List<string> listOfPlayer2Moves = m_GameBoard.GetAllPlayerLegalMoves(k_SignOfPlayer2);

                if (listOfPlayer2Moves.Any()) // if not empty
                {
                    int itemIndex = m_Rand.Next(listOfPlayer2Moves.Count);
                    string computerMove = listOfPlayer2Moves[itemIndex];
                    m_GameBoard.MakeMove(computerMove, k_SignOfPlayer2);
                }
                else
                {
                    //there is no legal move for the compuet => what happen next?
                }

                
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


        public void ResetGame() // Done.
        { // reset the game for another play
            m_GameBoard.ResetBoard();
            v_GameAlive = true;

        }


        public void EndGame() // TODO: Implement
        {
            v_GameAlive = false;


            // print to console goodbye or somthing 
        }


        private bool PlayAgain() // Done.
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



        private void playerWantsToQuit(Player player) // TODO: Implement
        {
            // update player soldier to zero and call isWon()

            //maybe ask if start new game or end for good
            // EndGame();
        }
    }
}