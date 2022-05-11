using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    public class Board // All the logic of the board and the rules is placed here
    {
        public int m_Player1SoldiersCounter = 0;
        public int m_Player2SoldiersCounter = 0;
        public int m_SizeOfBoard;
        private readonly BoardCell[,] r_Board;
        public List<String> m_LeagalSingleMovesPlayer1 = new List<String>();
        public List<String> m_LeagalSingleMovesPlayer2 = new List<String>();
        public List<String> m_LeagalEatingMovesPlayer1 = new List<String>();
        public List<String> m_LeagalEatingMovesPlayer2 = new List<String>();



        public Board(int i_BoardSize) // constructor
        {
            m_SizeOfBoard = i_BoardSize;
            r_Board = new BoardCell[m_SizeOfBoard, m_SizeOfBoard];
            initializeBoard();
            UpdateAllPlayerLegalMoves();
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
            eCellValue startCellValue = r_Board[i_StartIndex[0], i_StartIndex[1]].CellValue;
            r_Board[i_StartIndex[0], i_StartIndex[1]].CellValue = eCellValue.Empty;

            // Make a king for player 1
            if (i_Player == 1 & i_targetIndex[0] == 0)
            {
                r_Board[i_targetIndex[0], i_targetIndex[1]].CellValue = eCellValue.Player1King;
                m_Player1SoldiersCounter += 3;
            }

            // Make a king for player 2
            else if (i_Player == 2 & i_targetIndex[0] == m_SizeOfBoard - 1)
            {
                r_Board[i_targetIndex[0], i_targetIndex[1]].CellValue = eCellValue.Player2King;
                m_Player2SoldiersCounter += 3;
            }

            else
            {
                r_Board[i_targetIndex[0], i_targetIndex[1]].CellValue = startCellValue;
            }

            UpdateAllPlayerLegalMoves();
        }

        private void eatingMove(int[] i_StartIndex, int[] i_targetIndex, int i_Player)
        {

            eCellValue startCellValue = r_Board[i_StartIndex[0], i_StartIndex[1]].CellValue;
            r_Board[i_StartIndex[0], i_StartIndex[1]].CellValue = eCellValue.Empty;



            if (r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue == eCellValue.Player2King && (i_Player == 1))
            {
                r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue = eCellValue.Empty;
                m_Player2SoldiersCounter -= 4;
            }

            else if (r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue == eCellValue.Player2Soldier && (i_Player == 1))
            {
                r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue = eCellValue.Empty;
                m_Player2SoldiersCounter -= 1;
            }

            if (r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue == eCellValue.Player1King && (i_Player == 2))
            {
                r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue = eCellValue.Empty;
                m_Player1SoldiersCounter -= 4;
            }

            else if (r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue == eCellValue.Player1Soldier && (i_Player == 2))
            {
                r_Board[(i_StartIndex[0] + i_targetIndex[0]) / 2, (i_StartIndex[1] + i_targetIndex[1]) / 2].CellValue = eCellValue.Empty;
                m_Player1SoldiersCounter -= 1;
            }

            if (i_Player == 1 & i_targetIndex[0] == 0)
            {
                r_Board[i_targetIndex[0], i_targetIndex[1]].CellValue = eCellValue.Player1King;
                m_Player1SoldiersCounter += 3;
            }

            else if (i_Player == 2 & i_targetIndex[0] == m_SizeOfBoard - 1)
            {
                r_Board[i_targetIndex[0], i_targetIndex[1]].CellValue = eCellValue.Player2King;
                m_Player2SoldiersCounter += 3;

            }

            else
            {
                r_Board[i_targetIndex[0], i_targetIndex[1]].CellValue = startCellValue;
            }

            UpdateAllPlayerLegalMoves();
        }



        public void MakeMove(string i_PlayerMove, int i_Player)
        {
            bool isLeagal = false;
            string playerMove = i_PlayerMove;

            while (!isLeagal)
            {
                //int[] startingPosition = { playerMove[0] - 65, playerMove[1] - 97 };
                int[] startingPosition = { playerMove[1] - 97, playerMove[0] - 65 };

                //int[] targetPosition = { playerMove[3] - 65, playerMove[4] - 97 };
                int[] targetPosition = { playerMove[4] - 97, playerMove[3] - 65 };

                if (i_Player == 1)
                {
                    if (m_LeagalEatingMovesPlayer1.Contains(playerMove))
                    {
                        eatingMove(startingPosition, targetPosition, 1);
                        isLeagal = true;
                    }
                    else if (m_LeagalSingleMovesPlayer1.Contains(playerMove) && !m_LeagalEatingMovesPlayer1.Any())
                    {
                        singleMove(startingPosition, targetPosition, 1);
                        isLeagal = true;
                    }
                    else
                    {
                        playerMove = ConsoleInputValidation.GetUserMove(m_SizeOfBoard, " ");
                    }
                }

                if (i_Player == 2)
                {
                    if (m_LeagalEatingMovesPlayer2.Contains(playerMove))
                    {
                        eatingMove(startingPosition, targetPosition, 2);
                        isLeagal = true;
                    }
                    else if (m_LeagalSingleMovesPlayer2.Contains(playerMove) && !m_LeagalEatingMovesPlayer2.Any())
                    {
                        singleMove(startingPosition, targetPosition, 2);
                        isLeagal = true;
                    }
                    else
                    {
                        playerMove = ConsoleInputValidation.GetUserMove(m_SizeOfBoard, " ");
                    }
                }
                UpdateAllPlayerLegalMoves();


            }
        }

        //    if (i_Player == 1)
        //    {
        //        //Check if the player try to ,move his own solider
        //        if ((r_Board[startingPosition[0], startingPosition[1]]).CellValue != eCellValue.Player1Soldier)
        //        {
        //            isLeagal = false;
        //            playerMove = ConsoleInputValidation.GetUserMove(m_SizeOfBoard, i_playerMove);
        //        }

        //        // Check if the player destination is empty
        //        if ((r_Board[targetPosition[0], targetPosition[1]]).CellValue != eCellValue.Empty)
        //        {
        //            isLeagal = false;
        //            playerMove = ConsoleInputValidation.GetUserMove(m_SizeOfBoard, i_playerMove);
        //        }

        //        if ((targetPosition[0] == startingPosition[0] - 1 && targetPosition[1] == startingPosition[1] - 1) ||
        //           (targetPosition[0] == startingPosition[0] - 1 && targetPosition[1] == startingPosition[1] + 1))
        //        {
        //            singleMove(startingPosition, targetPosition, i_Player);
        //            isLeagal = true;
        //            break;

        //        }

        //        // Eating left up
        //        if ((targetPosition[0] == startingPosition[0] - 2 && targetPosition[1] == startingPosition[1] - 2) &&
        //            (r_Board[startingPosition[0] - 1, startingPosition[1] - 1]).CellValue == eCellValue.Player2Soldier)
        //        {
        //            eatingMove(startingPosition, targetPosition, i_Player);
        //            isLeagal = true;
        //            break;
        //        }

        //        // Eating right up
        //        if ((targetPosition[0] == startingPosition[0] - 2 && targetPosition[1] == startingPosition[1] + 2) &&
        //            (r_Board[startingPosition[0] - 1, startingPosition[1] + 1]).CellValue == eCellValue.Player2Soldier)
        //        {
        //            eatingMove(startingPosition, targetPosition, i_Player);
        //            isLeagal = true;
        //            break;
        //        }
        //    }


        //    if (i_Player == 2)
        //    {
        //        //Check if the player try to ,move his own solider
        //        if ((r_Board[startingPosition[0], startingPosition[1]]).CellValue != eCellValue.Player2Soldier)
        //        {
        //            isLeagal = false;
        //            playerMove = ConsoleInputValidation.GetUserMove(m_SizeOfBoard, i_playerMove);
        //        }

        //        // Check if the player destination is empty
        //        if ((r_Board[targetPosition[0], targetPosition[1]]).CellValue == eCellValue.Empty)
        //        {
        //            isLeagal = false;
        //            playerMove = ConsoleInputValidation.GetUserMove(m_SizeOfBoard, i_playerMove);
        //        }

        //        // Single move
        //        if ((targetPosition[0] == startingPosition[0] + 1 && targetPosition[1] == startingPosition[1] - 1) ||
        //           (targetPosition[0] == startingPosition[0] + 1 && targetPosition[1] == startingPosition[1] + 1))
        //        {
        //            singleMove(startingPosition, targetPosition, i_Player);
        //            isLeagal = true;
        //            break;

        //        }

        //        // Eating left down
        //        if ((targetPosition[0] == startingPosition[0] + 2 && targetPosition[1] == startingPosition[1] - 2) &&
        //            (r_Board[startingPosition[0] + 1, startingPosition[1] - 1]).CellValue == eCellValue.Player1Soldier)
        //        {
        //            eatingMove(startingPosition, targetPosition, i_Player);
        //            isLeagal = true;
        //            break;
        //        }

        //        // Eating right down
        //        if ((targetPosition[0] == startingPosition[0] + 2 && targetPosition[1] == startingPosition[1] + 2) &&
        //            (r_Board[startingPosition[0] + 1, startingPosition[1] + 1]).CellValue == eCellValue.Player1Soldier)
        //        {
        //            eatingMove(startingPosition, targetPosition, i_Player);
        //            isLeagal = true;
        //            break;
        //        }
        //    }

        //    playerMove = ConsoleInputValidation.GetUserMove(m_SizeOfBoard, i_playerMove);
        //}
        //}


        public void UpdateAllPlayerLegalMoves()
        {
            m_LeagalEatingMovesPlayer1 = new List<String>();
            m_LeagalEatingMovesPlayer2 = new List<String>();
            m_LeagalSingleMovesPlayer1 = new List<String>();
            m_LeagalSingleMovesPlayer2 = new List<String>();

            for (int i = 0; i < m_SizeOfBoard; i++)
            {
                for (int j = 0; j < m_SizeOfBoard; j++)
                {
                    if (r_Board[i, j].CellValue == eCellValue.Player1Soldier
                        || r_Board[i, j].CellValue == eCellValue.Player1King)
                    {
                        m_LeagalSingleMovesPlayer1.AddRange(GetLegalSingleMovesFromCell(i, j, 1));
                        m_LeagalEatingMovesPlayer1.AddRange(GetLegalEatingMovesFromCell(i, j, 1));
                    }

                    if (r_Board[i, j].CellValue == eCellValue.Player2Soldier
                        || r_Board[i, j].CellValue == eCellValue.Player2King)
                    {
                        m_LeagalSingleMovesPlayer2.AddRange(GetLegalSingleMovesFromCell(i, j, 2));
                        m_LeagalEatingMovesPlayer2.AddRange(GetLegalEatingMovesFromCell(i, j, 2));
                    }
                }
            }
        }


        public List<string> GetLegalEatingMovesFromCell(int i_Row, int i_Col, int i_Player)
        {
            char start_row_char = Convert.ToChar(i_Row + 97);
            char start_col_char = Convert.ToChar(i_Col + 65);
            char target_row_char;
            char target_col_char;
            string leagalMove;
            List<string> leagalMovesFromIndexList = new List<string>();

            if (i_Player == 1)
            {
                // up left eating
                if ((i_Row - 2) >= 0 && (i_Col - 2) >= 0)
                {
                    if (((r_Board[i_Row - 1, i_Col - 1]).CellValue == eCellValue.Player2King
                                     || (r_Board[i_Row - 1, i_Col - 1]).CellValue == eCellValue.Player2Soldier) &&
                                     (r_Board[i_Row - 2, i_Col - 2]).CellValue == eCellValue.Empty)
                    {
                        target_row_char = Convert.ToChar(i_Row - 2 + 97);
                        target_col_char = Convert.ToChar(i_Col + -2 + 65);
                        leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }
                // up right eating
                if ((i_Row - 2) >= 0 && (i_Col + 2) < m_SizeOfBoard)
                {
                    if (((r_Board[i_Row - 1, i_Col + 1]).CellValue == eCellValue.Player2King
                                         || (r_Board[i_Row - 1, i_Col + 1]).CellValue == eCellValue.Player2Soldier) &&
                                         (r_Board[i_Row - 2, i_Col + 2]).CellValue == eCellValue.Empty)
                    {
                        target_row_char = Convert.ToChar(i_Row - 2 + 97);
                        target_col_char = Convert.ToChar(i_Col + +2 + 65);
                        leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }

                // Down left eating king player 1
                if ((i_Row + 2) < m_SizeOfBoard && (i_Col - 2) >= 0 && r_Board[i_Row, i_Col].CellValue == eCellValue.Player1King)
                {
                    if (((r_Board[i_Row + 1, i_Col - 1]).CellValue == eCellValue.Player2King
                                     || (r_Board[i_Row + 1, i_Col - 1]).CellValue == eCellValue.Player2Soldier) &&
                                     (r_Board[i_Row + 2, i_Col - 2]).CellValue == eCellValue.Empty)
                    {
                        target_row_char = Convert.ToChar(i_Row + 2 + 97);
                        target_col_char = Convert.ToChar(i_Col - 2 + 65);
                        leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }

                // Down right eating king 1
                if ((i_Row + 2) < m_SizeOfBoard && (i_Col + 2) < m_SizeOfBoard && r_Board[i_Row, i_Col].CellValue == eCellValue.Player1King)
                {
                    if (((r_Board[i_Row + 1, i_Col + 1]).CellValue == eCellValue.Player2King
                                             || (r_Board[i_Row + 1, i_Col + 1]).CellValue == eCellValue.Player2Soldier) &&
                                             (r_Board[i_Row + 2, i_Col + 2]).CellValue == eCellValue.Empty)
                    {
                        target_row_char = Convert.ToChar(i_Row + 2 + 97);
                        target_col_char = Convert.ToChar(i_Col + 2 + 65);
                        leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }
            }

            if (i_Player == 2)
            {
                // Down left eating

                if ((i_Row + 2) < m_SizeOfBoard && (i_Col - 2) >= 0)
                {
                    if (((r_Board[i_Row + 1, i_Col - 1]).CellValue == eCellValue.Player1King
                                     || (r_Board[i_Row + 1, i_Col - 1]).CellValue == eCellValue.Player1Soldier) &&
                                     (r_Board[i_Row + 2, i_Col - 2]).CellValue == eCellValue.Empty)
                    {
                        target_row_char = Convert.ToChar(i_Row + 2 + 97);
                        target_col_char = Convert.ToChar(i_Col - 2 + 65);
                        leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }

                // Down right eating
                if ((i_Row + 2) < m_SizeOfBoard && (i_Col + 2) < m_SizeOfBoard)
                {
                    if (((r_Board[i_Row + 1, i_Col + 1]).CellValue == eCellValue.Player1King
                                             || (r_Board[i_Row + 1, i_Col + 1]).CellValue == eCellValue.Player1Soldier) &&
                                             (r_Board[i_Row + 2, i_Col + 2]).CellValue == eCellValue.Empty)
                    {
                        target_row_char = Convert.ToChar(i_Row + 2 + 97);
                        target_col_char = Convert.ToChar(i_Col + 2 + 65);
                        leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }


                // up left eating king 2
                if ((i_Row - 2) >= 0 && (i_Col - 2) >= 0 && r_Board[i_Row, i_Col].CellValue == eCellValue.Player2King)
                {
                    if (((r_Board[i_Row - 1, i_Col - 1]).CellValue == eCellValue.Player1King
                                     || (r_Board[i_Row - 1, i_Col - 1]).CellValue == eCellValue.Player1Soldier) &&
                                     (r_Board[i_Row - 2, i_Col - 2]).CellValue == eCellValue.Empty)
                    {
                        target_row_char = Convert.ToChar(i_Row - 2 + 97);
                        target_col_char = Convert.ToChar(i_Col + -2 + 65);
                        leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }
                // up right eating king 2
                if ((i_Row - 2) >= 0 && (i_Col + 2) < m_SizeOfBoard && r_Board[i_Row, i_Col].CellValue == eCellValue.Player2King)
                {
                    if (((r_Board[i_Row - 1, i_Col + 1]).CellValue == eCellValue.Player1King
                                         || (r_Board[i_Row - 1, i_Col + 1]).CellValue == eCellValue.Player1Soldier) &&
                                         (r_Board[i_Row - 2, i_Col + 2]).CellValue == eCellValue.Empty)
                    {
                        target_row_char = Convert.ToChar(i_Row - 2 + 97);
                        target_col_char = Convert.ToChar(i_Col + +2 + 65);
                        leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }

            }

            return leagalMovesFromIndexList;
        }

        //public List<string> GetLegalEatingMovesFromCell(int i_Row, int i_Col, int i_Player)
        //{
        //    char start_row_char = Convert.ToChar(i_Row + 97);
        //    char start_col_char = Convert.ToChar(i_Col + 65);
        //    char target_row_char;
        //    char target_col_char;
        //    string leagalMove;
        //    List<string> leagalMovesFromIndexList = new List<string>();

        //    if (i_Player == 1)
        //    {
        //        // up left eating
        //        if ((i_Row - 2) >= 0 && (i_Col - 2) >= 0)
        //        {
        //            if (((r_Board[i_Row - 1, i_Col - 1]).CellValue == eCellValue.Player2King
        //                             || (r_Board[i_Row - 1, i_Col - 1]).CellValue == eCellValue.Player2Soldier) &&
        //                             (r_Board[i_Row - 2, i_Col - 2]).CellValue == eCellValue.Empty)
        //            {
        //                target_row_char = Convert.ToChar(i_Row - 2 + 97);
        //                target_col_char = Convert.ToChar(i_Col + -2 + 65);
        //                leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
        //                leagalMovesFromIndexList.Add(leagalMove);
        //            }
        //        }
        //        // up right eating
        //        if ((i_Row - 2) >= 0 && (i_Col + 2) < m_SizeOfBoard)
        //        {
        //            if (((r_Board[i_Row - 1, i_Col + 1]).CellValue == eCellValue.Player2King
        //                                 || (r_Board[i_Row - 1, i_Col + 1]).CellValue == eCellValue.Player2Soldier) &&
        //                                 (r_Board[i_Row - 2, i_Col + 2]).CellValue == eCellValue.Empty)
        //            {
        //                target_row_char = Convert.ToChar(i_Row - 2 + 97);
        //                target_col_char = Convert.ToChar(i_Col + +2 + 65);
        //                leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
        //                leagalMovesFromIndexList.Add(leagalMove);
        //            }
        //        }

        //        // Down left eating king player 1
        //        if ((i_Row + 2) < m_SizeOfBoard && (i_Col - 2) >= 0)
        //        {
        //            if (((r_Board[i_Row + 1, i_Col - 1]).CellValue == eCellValue.Player2King
        //                             || (r_Board[i_Row + 1, i_Col - 1]).CellValue == eCellValue.Player2Soldier) &&
        //                             (r_Board[i_Row + 2, i_Col - 2]).CellValue == eCellValue.Empty)
        //            {
        //                target_row_char = Convert.ToChar(i_Row + 2 + 97);
        //                target_col_char = Convert.ToChar(i_Col - 2 + 65);
        //                leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
        //                leagalMovesFromIndexList.Add(leagalMove);
        //            }
        //        }

        //        // Down right eating king 1
        //        if ((i_Row + 2) < m_SizeOfBoard && (i_Col + 2) < m_SizeOfBoard)
        //        {
        //            if (((r_Board[i_Row + 1, i_Col + 1]).CellValue == eCellValue.Player2King
        //                                     || (r_Board[i_Row + 1, i_Col + 1]).CellValue == eCellValue.Player2Soldier) &&
        //                                     (r_Board[i_Row + 2, i_Col + 2]).CellValue == eCellValue.Empty)
        //            {
        //                target_row_char = Convert.ToChar(i_Row + 2 + 97);
        //                target_col_char = Convert.ToChar(i_Col + 2 + 65);
        //                leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
        //                leagalMovesFromIndexList.Add(leagalMove);
        //            }
        //        }
        //    }

        //    if (i_Player == 2)
        //    {
        //        // Down left eating

        //        if ((i_Row + 2) < m_SizeOfBoard && (i_Col - 2) >= 0)
        //        {
        //            if (((r_Board[i_Row + 1, i_Col - 1]).CellValue == eCellValue.Player1King
        //                             || (r_Board[i_Row + 1, i_Col - 1]).CellValue == eCellValue.Player1Soldier) &&
        //                             (r_Board[i_Row + 2, i_Col - 2]).CellValue == eCellValue.Empty)
        //            {
        //                target_row_char = Convert.ToChar(i_Row + 2 + 97);
        //                target_col_char = Convert.ToChar(i_Col - 2 + 65);
        //                leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
        //                leagalMovesFromIndexList.Add(leagalMove);
        //            }
        //        }

        //        // Down right eating
        //        if ((i_Row + 2) < m_SizeOfBoard && (i_Col + 2) < m_SizeOfBoard)
        //        {
        //            if (((r_Board[i_Row + 1, i_Col + 1]).CellValue == eCellValue.Player1King
        //                                     || (r_Board[i_Row + 1, i_Col + 1]).CellValue == eCellValue.Player1Soldier) &&
        //                                     (r_Board[i_Row + 2, i_Col + 2]).CellValue == eCellValue.Empty)
        //            {
        //                target_row_char = Convert.ToChar(i_Row + 2 + 97);
        //                target_col_char = Convert.ToChar(i_Col + 2 + 65);
        //                leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
        //                leagalMovesFromIndexList.Add(leagalMove);
        //            }
        //        }


        //        // up left eating king 2
        //        if ((i_Row - 2) >= 0 && (i_Col - 2) >= 0)
        //        {
        //            if (((r_Board[i_Row - 1, i_Col - 1]).CellValue == eCellValue.Player1King
        //                             || (r_Board[i_Row - 1, i_Col - 1]).CellValue == eCellValue.Player1Soldier) &&
        //                             (r_Board[i_Row - 2, i_Col - 2]).CellValue == eCellValue.Empty)
        //            {
        //                target_row_char = Convert.ToChar(i_Row - 2 + 97);
        //                target_col_char = Convert.ToChar(i_Col + -2 + 65);
        //                leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
        //                leagalMovesFromIndexList.Add(leagalMove);
        //            }
        //        }
        //        // up right eating king 2
        //        if ((i_Row - 2) >= 0 && (i_Col + 2) < m_SizeOfBoard)
        //        {
        //            if (((r_Board[i_Row - 1, i_Col + 1]).CellValue == eCellValue.Player1King
        //                                 || (r_Board[i_Row - 1, i_Col + 1]).CellValue == eCellValue.Player1Soldier) &&
        //                                 (r_Board[i_Row - 2, i_Col + 2]).CellValue == eCellValue.Empty)
        //            {
        //                target_row_char = Convert.ToChar(i_Row - 2 + 97);
        //                target_col_char = Convert.ToChar(i_Col + +2 + 65);
        //                leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
        //                leagalMovesFromIndexList.Add(leagalMove);
        //            }
        //        }

        //    }

        //    return leagalMovesFromIndexList;
        //}

        public List<string> GetLegalSingleMovesFromCell(int i_Row, int i_Col, int i_Player)
        {
            char start_row_char = Convert.ToChar(i_Row + 97);
            char start_col_char = Convert.ToChar(i_Col + 65);
            char target_row_char;
            char target_col_char;
            string leagalMove;
            List<string> leagalMovesFromIndexList = new List<string>();

            //if (i_Player == 1 && r_Board[i_Row,i_Col].CellValue == eCellValue.Player1King || r_Board[i_Row, i_Col].CellValue == eCellValue.Player1Soldier)
            if (i_Player == 1 || (r_Board[i_Row, i_Col].CellValue == eCellValue.Player2King))
            {
                //// if is a king move
                //if(r_Board[i_Row - , i_Col])

                //up left
                if ((i_Row - 1) >= 0 && (i_Col - 1) >= 0)
                {
                    if (r_Board[i_Row - 1, i_Col - 1].CellValue == eCellValue.Empty)
                    {
                        target_row_char = Convert.ToChar(i_Row - 1 + 97);
                        target_col_char = Convert.ToChar(i_Col - 1 + 65);
                        leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }

                //up right
                if ((i_Row - 1) >= 0 && (i_Col + 1) < m_SizeOfBoard)
                {
                    if (r_Board[i_Row - 1, i_Col + 1].CellValue == eCellValue.Empty)
                    {
                        target_row_char = Convert.ToChar(i_Row - 1 + 97);
                        target_col_char = Convert.ToChar(i_Col + 1 + 65);
                        leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }
            }

            if (i_Player == 2 || (r_Board[i_Row, i_Col].CellValue == eCellValue.Player1King))
            {
                //Down left
                if ((i_Row + 1) < m_SizeOfBoard && (i_Col - 1) >= 0)
                {
                    if (r_Board[i_Row + 1, i_Col - 1].CellValue == eCellValue.Empty)
                    {
                        target_row_char = Convert.ToChar(i_Row + 1 + 97);
                        target_col_char = Convert.ToChar(i_Col - 1 + 65);
                        leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }

                //Down right
                if ((i_Row + 1) < m_SizeOfBoard && (i_Col + 1) < m_SizeOfBoard)
                {
                    if (r_Board[i_Row + 1, i_Col + 1].CellValue == eCellValue.Empty)
                    {
                        target_row_char = Convert.ToChar(i_Row + 1 + 97);
                        target_col_char = Convert.ToChar(i_Col + 1 + 65);
                        leagalMove = "" + start_col_char + start_row_char + '>' + target_col_char + target_row_char;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }
            }

            return leagalMovesFromIndexList;
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
                        m_Player2SoldiersCounter++;
                    }
                    else
                    {
                        if ((i % 2 == 1) && (j % 2 == 0))
                        {
                            r_Board[i, j].CellValue = eCellValue.Player2Soldier;
                            m_Player2SoldiersCounter++;
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
                        m_Player1SoldiersCounter++;
                    }
                    else
                    {
                        if ((i % 2 == 1) && (j % 2 == 0))
                        {
                            r_Board[i, j].CellValue = eCellValue.Player1Soldier;
                            m_Player1SoldiersCounter++;
                        }
                    }
                }
            }
        }

        public bool IsWon(Player i_player1, Player i_player2)
        {
            bool isWon = false;
            int scoreToAdd;

            if (m_Player1SoldiersCounter == 0)
            {
                isWon = true;
                ConsoleMessages.PlayerWinningMessage(i_player2.Name);
                scoreToAdd = Math.Abs(m_Player2SoldiersCounter - m_Player1SoldiersCounter);
                i_player2.Score = scoreToAdd;
                ConsoleMessages.PrintScore(i_player1.Name, i_player1.Score, i_player2.Name, i_player2.Score);
            }

            if (m_Player2SoldiersCounter == 0)
            {
                isWon = true;
                ConsoleMessages.PlayerWinningMessage(i_player1.Name);
                scoreToAdd = Math.Abs(m_Player2SoldiersCounter - m_Player1SoldiersCounter);
                i_player1.Score = scoreToAdd;
                ConsoleMessages.PrintScore(i_player1.Name, i_player1.Score, i_player2.Name, i_player2.Score);
            }

            return isWon;
        }

        public bool IfIndexOutOfBounds(int row, int column)
        {
            return row >= 0 && row < m_SizeOfBoard && column >= 0 && column < m_SizeOfBoard;
        }

    }
}