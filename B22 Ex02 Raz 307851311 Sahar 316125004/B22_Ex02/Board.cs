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
        //public BoardCell[,] r_Board;


        public Board(int i_BoardSize) // constructor
        {
            m_SizeOfBoard = i_BoardSize;
            r_Board = new BoardCell[m_SizeOfBoard, m_SizeOfBoard];
            initializeBoard();
        }

        public BoardCell[,] GetBoard => r_Board;

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


        private void singleMove(int[] i_StartIndex, int[] i_targetIndex, int i_Player)
        {
            BoardCell startCellValue = r_Board[i_StartIndex[0], i_StartIndex[1]];
            r_Board[i_StartIndex[0], i_StartIndex[1]].CellValue = eCellValue.Empty;

            if (i_Player == 1 & i_targetIndex[0] == 0)
            {
                r_Board[i_targetIndex[0], i_targetIndex[1]].CellValue = eCellValue.Player1King;
                m_player1SoldiersCounter += 4;
            }

            else if (i_Player == 2 & i_targetIndex[0] == m_SizeOfBoard - 1)
            {
                r_Board[i_targetIndex[0], i_targetIndex[1]].CellValue = eCellValue.Player2King;
                m_player2SoldiersCounter += 4;
            }

            else
            {
                r_Board[i_targetIndex[0], i_targetIndex[1]] = startCellValue;
            }
        }

        private void eatingMove(int[] i_StartIndex, int[] i_targetIndex, int i_Player)
        {
            
            BoardCell startCellValue = r_Board[i_StartIndex[0], i_StartIndex[1]];
            r_Board[i_StartIndex[0], i_StartIndex[1]].CellValue = eCellValue.Empty;
            
            

            if (r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue == eCellValue.Player2King && (i_Player == 1))
            {
                r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue = eCellValue.Empty;
                m_player2SoldiersCounter -= 4;
            }

            else if (r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue == eCellValue.Player2Soldier && (i_Player == 1))
            {
                r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue = eCellValue.Empty;
                m_player2SoldiersCounter -= 1;
            }

            if (r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue == eCellValue.Player1King && (i_Player == 2))
            {
                r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue = eCellValue.Empty;
                m_player1SoldiersCounter -= 4;
            }

            else if (r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue == eCellValue.Player1Soldier && (i_Player == 2))
            {
                r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue = eCellValue.Empty;
                m_player1SoldiersCounter -= 1;
            }

            if (i_Player == 1 & i_targetIndex[0] == 0)
            {
                r_Board[i_targetIndex[0], i_targetIndex[1]].CellValue = eCellValue.Player1King;
                m_player1SoldiersCounter += 4;
            }

            else if (i_Player == 2 & i_targetIndex[0] == m_SizeOfBoard - 1)
            {
                r_Board[i_targetIndex[0], i_targetIndex[1]].CellValue = eCellValue.Player2King;
                m_player2SoldiersCounter += 4;

            }

            else
            {
                r_Board[i_targetIndex[0], i_targetIndex[1]] = startCellValue;
            }
        }




        /*
         * 1 - playr 1 can eat to the left
         * 2 - playr 1 can eat to the right
         * 3 - playr 1 can eat to the right and to the left
         * 4 - player 2 can eat to the left
         * 5 - player 2 can eat to the right 
         * 9 - playr 2 can eat to the right and to the left
         */

        private bool canPlayerEat(int[] i_StartIndex, int i_Player)
        {
            if (i_Player == 1)
            {
                bool upLeftEatingMove = false;
                bool upRightEatingMove = false;
                bool isPlayerCanToEat = false;


                // Can eat left
                if (i_StartIndex[0] - 2 >= 0 && i_StartIndex[1] - 2 >= 0)
                {
                    //BoardCell startCellValue = r_Board[i_StartIndex[0], i_StartIndex[1]];
                    upLeftEatingMove = ((r_Board[i_StartIndex[0] - 1, i_StartIndex[1] - 1]).CellValue == eCellValue.Player2King
                                    || (r_Board[i_StartIndex[0] - 1, i_StartIndex[1] - 1]).CellValue == eCellValue.Player2Soldier) &&
                                    (r_Board[i_StartIndex[0] - 2, i_StartIndex[1] - 2]).CellValue == eCellValue.Empty;

                    //if (upLeftEatingMove)
                    //{
                    //    // start position - empty, opponent delete and new target position - solider
                    //    // recursion call here we eat
                    //}
                }

                // Can eat right
                if (i_StartIndex[0] - 2 >= 0 && i_StartIndex[1] + 2 >= 0)
                {
                    //BoardCell startCellValue = r_Board[i_StartIndex[0], i_StartIndex[1]];
                    upRightEatingMove = (r_Board[i_StartIndex[0] - 1, i_StartIndex[1] + 1]).CellValue == eCellValue.Player2King
                                     || (r_Board[i_StartIndex[0] - 1, i_StartIndex[1] + 1]).CellValue == eCellValue.Player2Soldier &&
                                     (r_Board[i_StartIndex[0] - 2, i_StartIndex[1] + 2]).CellValue == eCellValue.Empty;
                }
                //if (upRightEatingMove)
                //{
                //    // recursion call here we eat
                //}

                
                isPlayerCanToEat = upRightEatingMove || upLeftEatingMove;

                return isPlayerCanToEat;
            }

            else
            {
                bool downLeftEatingMove = false;
                bool downRightEatingMove = false;
                bool isPlayerCanToEat = false;

                // Can eat left
                if (i_StartIndex[0] + 2 < m_SizeOfBoard && i_StartIndex[1] - 2 < m_SizeOfBoard)
                {
                    //BoardCell startCellValue = r_Board[i_StartIndex[0], i_StartIndex[1]];
                    downLeftEatingMove = ((r_Board[i_StartIndex[0] + 1, i_StartIndex[1] - 1]).CellValue == eCellValue.Player1King
                                    || (r_Board[i_StartIndex[0] + 1, i_StartIndex[1] - 1]).CellValue == eCellValue.Player1Soldier) &&
                                    (r_Board[i_StartIndex[0] + 2, i_StartIndex[1] - 2]).CellValue == eCellValue.Empty;

                    //if (upLeftEatingMove)
                    //{
                    //    // start position - empty, opponent delete and new target position - solider
                    //    // recursion call here we eat
                    //}
                }

                // Can eat right
                if (i_StartIndex[0] + 2 < m_SizeOfBoard && i_StartIndex[1] + 2 < m_SizeOfBoard)
                {
                    //BoardCell startCellValue = r_Board[i_StartIndex[0], i_StartIndex[1]];
                    downRightEatingMove = (r_Board[i_StartIndex[0] + 1, i_StartIndex[1] + 1]).CellValue == eCellValue.Player1King
                                     || (r_Board[i_StartIndex[0] + 1, i_StartIndex[1] + 1]).CellValue == eCellValue.Player1Soldier &&
                                     (r_Board[i_StartIndex[0] + 2, i_StartIndex[1] + 2]).CellValue == eCellValue.Empty;
                }
                //if (upRightEatingMove)
                //{
                //    // recursion call here we eat
                //}

                isPlayerCanToEat = downLeftEatingMove || downRightEatingMove;

                return isPlayerCanToEat;
            }
        }







        public void MakeMove(string i_playerMove, int i_Player) //TODO: implement this
        {
            bool isLeagal = true;
            string playerMove = i_playerMove;

            while (!isLeagal)
            {
               
                int[] startingPosition = { playerMove[0] - 65, playerMove[1] - 97 };
                int[] targetPosition = { playerMove[3] - 65, playerMove[4] - 97 };



                if (i_Player == 1)
                {
                    //Check if the player try to ,move his own solider
                    if ((r_Board[startingPosition[0], startingPosition[1]]).CellValue != eCellValue.Player1Soldier)
                    {
                        isLeagal = false;
                        playerMove = ConsoleInputValidation.GetUserMove(m_SizeOfBoard);
                        continue;
                    }

                    // Check if the player destination is empty
                    if ((r_Board[targetPosition[0], targetPosition[1]]).CellValue == eCellValue.Empty)
                    {
                        isLeagal = false;
                        playerMove = ConsoleInputValidation.GetUserMove(m_SizeOfBoard);
                        continue;
                    }

                    if((targetPosition[0] == startingPosition[0] - 1 && targetPosition[1] == startingPosition[1] - 1) ||
                       (targetPosition[0] == startingPosition[0] - 1 && targetPosition[1] == startingPosition[1] + 1))
                    {
                        singleMove(startingPosition, targetPosition, i_Player);
                        isLeagal = true;
                        break;
                        
                    }

                    // Eating left up
                    if ((targetPosition[0] == startingPosition[0] - 2 && targetPosition[1] == startingPosition[1] - 2) &&
                        (r_Board[startingPosition[0] - 1, startingPosition[1] - 1]).CellValue == eCellValue.Empty)
                    {
                        eatingMove(startingPosition, targetPosition, i_Player);
                        isLeagal = true;
                        break;
                    }

                    // Eating right up
                    if ((targetPosition[0] == startingPosition[0] - 2 && targetPosition[1] == startingPosition[1] + 2) &&
                        (r_Board[startingPosition[0] - 1, startingPosition[1] + 1]).CellValue == eCellValue.Empty)
                    {
                        eatingMove(startingPosition, targetPosition, i_Player);
                        isLeagal = true;
                        break;
                    }
                }


                if (i_Player == 2)
                {
                    //Check if the player try to ,move his own solider
                    if ((r_Board[startingPosition[0], startingPosition[1]]).CellValue != eCellValue.Player2Soldier)
                    {
                        isLeagal = false;
                        playerMove = ConsoleInputValidation.GetUserMove(m_SizeOfBoard);
                        continue;
                    }

                    // Check if the player destination is empty
                    if ((r_Board[targetPosition[0], targetPosition[1]]).CellValue == eCellValue.Empty)
                    {
                        isLeagal = false;
                        playerMove = ConsoleInputValidation.GetUserMove(m_SizeOfBoard);
                        continue;
                    }

                    // Single move
                    if ((targetPosition[0] == startingPosition[0] + 1 && targetPosition[1] == startingPosition[1] - 1) ||
                       (targetPosition[0] == startingPosition[0] + 1 && targetPosition[1] == startingPosition[1] + 1))
                    {
                        singleMove(startingPosition, targetPosition, i_Player);
                        isLeagal = true;
                        break;

                    }

                    // Eating left down
                    if ((targetPosition[0] == startingPosition[0] + 2 && targetPosition[1] == startingPosition[1] - 2) &&
                        (r_Board[startingPosition[0] + 1, startingPosition[1] - 1]).CellValue == eCellValue.Empty)
                    {
                        eatingMove(startingPosition, targetPosition, i_Player);
                        isLeagal = true;
                        break;
                    }

                    // Eating right down
                    if ((targetPosition[0] == startingPosition[0] + 2 && targetPosition[1] == startingPosition[1] + 2) &&
                        (r_Board[startingPosition[0] + 1, startingPosition[1] + 1]).CellValue == eCellValue.Empty)
                    {
                        eatingMove(startingPosition, targetPosition, i_Player);
                        isLeagal = true;
                        break;
                    }
                }
                playerMove = ConsoleInputValidation.GetUserMove(m_SizeOfBoard);
            }
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


        public bool IsWon(Player i_player1, Player i_player2)
        {
            bool isWon = false;
            int scoreToAdd;
            if (m_player1SoldiersCounter == 0)
            {
                isWon = true;
                ConsoleMessages.PlayerWinningMessage(i_player2.Name);
                //calculate player score
                scoreToAdd = Math.Abs(i_player1.Score - i_player2.Score);
                i_player2.Score = scoreToAdd;
                ConsoleMessages.PrintScore(i_player1, i_player2);
            }

            if (m_player2SoldiersCounter == 0)
            {
                isWon = true;
                ConsoleMessages.PlayerWinningMessage(i_player1.Name);
                scoreToAdd = Math.Abs(i_player1.Score - i_player2.Score);
                i_player1.Score = scoreToAdd;
                ConsoleMessages.PrintScore(i_player1, i_player2);
            }

            return isWon;
        }

        public bool ifIndexOutOfBounds(int row, int column)
        { 
            return row >= 0 && row < m_SizeOfBoard && column >= 0 && column < m_SizeOfBoard;
        }

    }
}