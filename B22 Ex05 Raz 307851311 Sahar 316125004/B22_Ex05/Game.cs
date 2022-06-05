using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace B22_Ex05
{
    public class Game
    {
        public int m_BoardSize;
        public bool v_PlayerVsPlayerMode = false;
        private Board m_GameBoard = null;
        public Player m_Player1, m_Player2;
        private const int k_SignOfPlayer1 = 1;
        private const int k_SignOfPlayer2 = 2;
        private Random m_Rand;
        private GameForm m_GameForm;

        public Game()
        {       
            InitGame();
        }

        public void InitGame()
        {
            GameSetupForm setupForm = new GameSetupForm();
            DialogResult dialogResult = setupForm.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                m_BoardSize = setupForm.GetBoardSize;
                m_GameBoard = new Board(m_BoardSize);
                m_Player1 = new Player(setupForm.GetFirstPlayerName);

                if (setupForm.PlayAgainstHuman)
                {
                    m_Player2 = new Player(setupForm.GetSecondPlayerName);
                    v_PlayerVsPlayerMode = true;
                }
                else
                {
                    m_Player2 = new Player("Computer");
                    m_Rand = new Random();
                }

                m_GameForm = new GameForm(this, m_BoardSize, m_Player1.Name, m_Player2.Name);
            }
        }

        public Board GetBoard
        {
            get { return m_GameBoard; }
        }

        public void Run()
        {
            m_GameForm.ShowDialog();
        }

        public void Player1Move(string i_Player1Move) 
        {
            try
            {
                m_GameBoard.MakeMove(i_Player1Move, k_SignOfPlayer1); 
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }

        public eGameResult isWonOrDraw()
        {
            eGameResult gameResult = m_GameBoard.IsWon();

            if (gameResult == eGameResult.None) 
            {
                if (!m_GameBoard.m_LeagalSingleMovesPlayer1.Any()
                    && !m_GameBoard.m_LeagalSingleMovesPlayer2.Any()
                    && !m_GameBoard.m_LeagalEatingMovesPlayer1.Any()
                    && !m_GameBoard.m_LeagalEatingMovesPlayer2.Any())
                {
                    gameResult = eGameResult.Tie;
                }
            }
           
            return gameResult;
        }

        public void Player2Move(string i_Player2Move)
        {
            if (!v_PlayerVsPlayerMode) // play against the computer
            {
                if (m_GameBoard.m_LeagalEatingMovesPlayer2.Any()) // if not empty
                {
                    int itemIndex = m_Rand.Next(m_GameBoard.m_LeagalEatingMovesPlayer2.Count);
                    string computerMove = m_GameBoard.m_LeagalEatingMovesPlayer2[itemIndex];
                    i_Player2Move = computerMove;
                    m_GameBoard.MakeMove(i_Player2Move, k_SignOfPlayer2);
                }
                else
                {
                    if (m_GameBoard.m_LeagalSingleMovesPlayer2.Any()) // if not empty
                    {
                        int itemIndex = m_Rand.Next(m_GameBoard.m_LeagalSingleMovesPlayer2.Count);
                        string computerMove = m_GameBoard.m_LeagalSingleMovesPlayer2[itemIndex];
                        i_Player2Move = computerMove;
                        m_GameBoard.MakeMove(i_Player2Move, k_SignOfPlayer2);
                    }
                    else // no legal moves
                    {
                        playerWantsToQuit(k_SignOfPlayer2);
                    }
                }
            }
            else // play against human
            {
                try
                {
                    m_GameBoard.MakeMove(i_Player2Move, k_SignOfPlayer2);
                }
                catch (ArgumentException e)
                {
                    throw e;
                    //throw new ArgumentException(e.Message);
                }
            }
        }

        public void ResetGame()
        { 
            m_GameBoard.ResetBoard();
            m_GameBoard.UpdateAllPlayerLegalMoves();
        }

        private void playerWantsToQuit(int i_Player) 
        {
            // update player soldier to zero and call IsWon()
            if (i_Player == k_SignOfPlayer1)
            {
                m_GameBoard.m_Player1SoldiersCounter = 0;
                m_GameBoard.IsWon();
            }
            else
            {
                m_GameBoard.m_Player2SoldiersCounter = 0;
                m_GameBoard.IsWon();
            }
        }
    }
}