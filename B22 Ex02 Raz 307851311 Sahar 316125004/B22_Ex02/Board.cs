using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    public class Board // all the logic of a board is placed here
    {
        public int m_player1SoldiersCounter = 0;
        public int m_player2SoldiersCounter = 0;
        public int m_SizeOfBoard;
        private readonly BoardCell[,] r_Board;

        public Board(int i_BoardSize) // constructor
        {
            m_SizeOfBoard = i_BoardSize;
            r_Board = new BoardCell[m_SizeOfBoard, m_SizeOfBoard];
            initializeBoard();

        }

        private void initializeBoard()
        {
            for (int i = 0; i < m_SizeOfBoard; i++)
            {
                for (int j = 0; j < m_SizeOfBoard; j++)
                {
                    r_Board[i, j] = new BoardCell();
                }
            }

            soldiersFirstPosition();
        }



        public void MakeMove(string i_playerMove) //TODO: implement this
        {
            // get a string like "Af>Bf"
            if (checkLegalMove())
            {
                //converts the string to indexes and update the board (don't forget to print the Board again ..
            }

        }

        private bool checkLegalMove() //TODO: implement this
        {
            return true;
        }


        public void ResetBoard()
        {
            foreach (BoardCell cell in r_Board)
            {
                cell.CellValue = eCellValue.Empty;
            }

            soldiersFirstPosition();
        }


        private void soldiersFirstPosition()
        {
            int heightDivider = (m_SizeOfBoard - 1) / 2;

            for (int i = 0; i < heightDivider; i++) // player2 ( the 'O's)
            {
                for (int j = 0; j < m_SizeOfBoard; j++)
                {
                    if ((i % 2 == 0) && (j % 2 == 1))
                    {
                        r_Board[i, j].CellValue = eCellValue.Player2Soldier;
                        m_player2SoldiersCounter++;
                    }
                    else
                    {
                        if ((i % 2 == 1) && (j % 2 == 0))
                        {
                            r_Board[i, j].CellValue = eCellValue.Player2Soldier;
                            m_player2SoldiersCounter++;
                        }
                    }
                }
            }

            for (int i = heightDivider + 2; i < m_SizeOfBoard; i++) // player1 ( the 'X's)
            {
                for (int j = 0; j < m_SizeOfBoard; j++)
                {
                    if ((i % 2 == 0) && (j % 2 == 1))
                    {
                        r_Board[i, j].CellValue = eCellValue.Player1Soldier;
                        m_player1SoldiersCounter++;
                    }
                    else
                    {
                        if ((i % 2 == 1) && (j % 2 == 0))
                        {
                            r_Board[i, j].CellValue = eCellValue.Player1Soldier;
                            m_player1SoldiersCounter++;
                        }
                    }
                }
            }








        }
    }
}