using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex05
{
    public class Game
    {
        public bool v_GameAlive;
        public int m_BoardSize;
        public bool v_PlayerVsPlayerMode = false;
        private Board m_GameBoard = null;
        private BoardCell[,] m_Board = null;
        public Player m_Player1, m_Player2;
        private string m_UserInput;
        private const int k_SignOfPlayer1 = 1;
        private const int k_SignOfPlayer2 = 2;
        private Random m_Rand;

        public Game()
        {
            v_GameAlive = true;
            InitGame();
        }

        public void InitGame()
        {
            ConsoleMessages.OpenStatement();

            m_BoardSize = ConsoleInputValidation.GetSizeOfBoard();
            m_GameBoard = new Board(m_BoardSize);
            m_Board = m_GameBoard.GetBoard;

            string playerOneName = ConsoleInputValidation.GetPlayerName();
            m_Player1 = new Player(playerOneName);

            int opponentChoise = ConsoleInputValidation.GetOpponentChoise();

            if (opponentChoise == 1)
            {
                m_Player2 = new Player("Computer");
                m_Rand = new Random();
            }
            else
            {
                m_Player2 = new Player(ConsoleInputValidation.GetPlayerName());
                v_PlayerVsPlayerMode = true;
            }

            ConsoleMessages.LetsPlay();
        }

        public void Run()
        {
            bool playerWantToQuit = false;
            VisualBoard.ShowBoard(m_Board);
            ConsoleMessages.HowToPlayMessage();
            ConsoleMessages.PrintPlayerTurn(m_Player1.Name, k_SignOfPlayer1);

            while (v_GameAlive)
            {
                playerWantToQuit = playerOneMove();
                VisualBoard.ShowBoard(m_Board);
                ConsoleMessages.PrintPlayerMove(m_UserInput, m_Player1.Name, k_SignOfPlayer1);
                ConsoleMessages.PrintPlayerTurn(m_Player2.Name, k_SignOfPlayer2);

                if (isWonOrDraw(m_Player1, m_Player2) || playerWantToQuit)
                {
                    break;
                }

                playerWantToQuit = playerTwoMove(); // player2 or computer 
                VisualBoard.ShowBoard(m_Board);
                ConsoleMessages.PrintPlayerMove(m_UserInput, m_Player2.Name, k_SignOfPlayer2);
                ConsoleMessages.PrintPlayerTurn(m_Player1.Name, k_SignOfPlayer1);

                if (isWonOrDraw(m_Player1, m_Player2) || playerWantToQuit)
                {
                    break;
                }
            }

            if (playAgain())
            {
                resetGame();
                Run();
            }
            else
            {
                endGame();
            }
        }

        private bool playerOneMove()
        {
            bool playerWantToQuit = false;
            string userInput = Console.ReadLine();
            m_UserInput = ConsoleInputValidation.GetUserMove(m_BoardSize, userInput);

            if (m_UserInput == "q" || m_UserInput == "Q")
            {
                playerWantsToQuit(k_SignOfPlayer1);
                playerWantToQuit = true;
            }
            else
            {
                m_GameBoard.MakeMove(m_UserInput, k_SignOfPlayer1);
            }

            return playerWantToQuit;
        }

        private bool isWonOrDraw(Player i_Player1, Player i_Player2)
        {
            bool answer = false;

            if (m_GameBoard.IsWon(i_Player1, i_Player2)) // print won message and calculate players score
            {
                answer = true;
            }
            else
            {
                if (!m_GameBoard.m_LeagalSingleMovesPlayer1.Any()
                    && !m_GameBoard.m_LeagalSingleMovesPlayer2.Any()
                    && !m_GameBoard.m_LeagalEatingMovesPlayer1.Any()
                    && !m_GameBoard.m_LeagalEatingMovesPlayer2.Any()) // all lists are empty
                { //there is a draw
                    answer = true;
                    ConsoleMessages.DrawStatement();
                }
            }

            return answer;
        }

        private bool playerTwoMove()
        {
            bool playerWantToQuit = false;

            if (!v_PlayerVsPlayerMode) // play against the computer
            {
                if (m_GameBoard.m_LeagalEatingMovesPlayer2.Any()) // if not empty
                {
                    int itemIndex = m_Rand.Next(m_GameBoard.m_LeagalEatingMovesPlayer2.Count);
                    string computerMove = m_GameBoard.m_LeagalEatingMovesPlayer2[itemIndex];
                    m_UserInput = computerMove;
                    m_GameBoard.MakeMove(m_UserInput, k_SignOfPlayer2);
                }
                else
                {
                    if (m_GameBoard.m_LeagalSingleMovesPlayer2.Any())
                    {
                        int itemIndex = m_Rand.Next(m_GameBoard.m_LeagalSingleMovesPlayer2.Count);
                        string computerMove = m_GameBoard.m_LeagalSingleMovesPlayer2[itemIndex];
                        m_UserInput = computerMove;
                        m_GameBoard.MakeMove(m_UserInput, k_SignOfPlayer2);
                    }
                    else
                    {
                        playerWantsToQuit(k_SignOfPlayer2);
                        playerWantToQuit = true;
                    }
                }
            }
            else
            {
                string userInput = Console.ReadLine();
                m_UserInput = ConsoleInputValidation.GetUserMove(m_BoardSize, userInput);

                if (m_UserInput == "q" || m_UserInput == "Q")
                {
                    playerWantsToQuit(k_SignOfPlayer2);
                    playerWantToQuit = true;
                }
                else
                {
                    m_GameBoard.MakeMove(m_UserInput, k_SignOfPlayer2);
                }
            }

            return playerWantToQuit;
        }

        private void resetGame()
        { // reset the game for another play
            m_GameBoard.ResetBoard();
            v_GameAlive = true;
        }

        private void endGame()
        {
            v_GameAlive = false;
            ConsoleMessages.GoodByeMessage();
            Console.ReadLine();
        }

        private bool playAgain()
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

        private void playerWantsToQuit(int i_Player)
        {
            // update player soldier to zero and call IsWon()
            if (i_Player == k_SignOfPlayer1)
            {
                m_GameBoard.m_Player1SoldiersCounter = 0;
                m_GameBoard.IsWon(m_Player1, m_Player2);
            }
            else
            {
                m_GameBoard.m_Player2SoldiersCounter = 0;
                m_GameBoard.IsWon(m_Player1, m_Player2);
            }
        }
    }
}