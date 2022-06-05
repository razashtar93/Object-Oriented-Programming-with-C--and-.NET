using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex05
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

        public BoardCell[,] GetBoardCell => r_Board;

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

        private void singleMove(int[] i_StartIndex, int[] i_TargetIndex, int i_Player)
        {
            eCellValue startCellValue = r_Board[i_StartIndex[0], i_StartIndex[1]].CellValue;
            r_Board[i_StartIndex[0], i_StartIndex[1]].CellValue = eCellValue.Empty;

            // Make a king for player 1
            if (i_Player == 1 & i_TargetIndex[0] == 0)
            {
                r_Board[i_TargetIndex[0], i_TargetIndex[1]].CellValue = eCellValue.Player1King;
                m_Player1SoldiersCounter += 3;
            }

            // Make a king for player 2
            else if (i_Player == 2 & i_TargetIndex[0] == m_SizeOfBoard - 1)
            {
                r_Board[i_TargetIndex[0], i_TargetIndex[1]].CellValue = eCellValue.Player2King;
                m_Player2SoldiersCounter += 3;
            }

            else
            {
                r_Board[i_TargetIndex[0], i_TargetIndex[1]].CellValue = startCellValue;
            }

            UpdateAllPlayerLegalMoves();
        }

        private void eatingMove(int[] i_StartIndex, int[] i_TargetIndex, int i_Player)
        {

            eCellValue startCellValue = r_Board[i_StartIndex[0], i_StartIndex[1]].CellValue;
            r_Board[i_StartIndex[0], i_StartIndex[1]].CellValue = eCellValue.Empty;

            if (r_Board[(i_StartIndex[0] + i_TargetIndex[0]) / 2, (i_StartIndex[1] + i_TargetIndex[1]) / 2].CellValue == eCellValue.Player2King && (i_Player == 1))
            {
                r_Board[(i_StartIndex[0] + i_TargetIndex[0]) / 2, (i_StartIndex[1] + i_TargetIndex[1]) / 2].CellValue = eCellValue.Empty;
                m_Player2SoldiersCounter -= 4;
            }

            else if (r_Board[(i_StartIndex[0] + i_TargetIndex[0]) / 2, (i_StartIndex[1] + i_TargetIndex[1]) / 2].CellValue == eCellValue.Player2Soldier && (i_Player == 1))
            {
                r_Board[(i_StartIndex[0] + i_TargetIndex[0]) / 2, (i_StartIndex[1] + i_TargetIndex[1]) / 2].CellValue = eCellValue.Empty;
                m_Player2SoldiersCounter -= 1;
            }

            if (r_Board[(i_StartIndex[0] + i_TargetIndex[0]) / 2, (i_StartIndex[1] + i_TargetIndex[1]) / 2].CellValue == eCellValue.Player1King && (i_Player == 2))
            {
                r_Board[(i_StartIndex[0] + i_TargetIndex[0]) / 2, (i_StartIndex[1] + i_TargetIndex[1]) / 2].CellValue = eCellValue.Empty;
                m_Player1SoldiersCounter -= 4;
            }

            else if (r_Board[(i_StartIndex[0] + i_TargetIndex[0]) / 2, (i_StartIndex[1] + i_TargetIndex[1]) / 2].CellValue == eCellValue.Player1Soldier && (i_Player == 2))
            {
                r_Board[(i_StartIndex[0] + i_TargetIndex[0]) / 2, (i_StartIndex[1] + i_TargetIndex[1]) / 2].CellValue = eCellValue.Empty;
                m_Player1SoldiersCounter -= 1;
            }

            if (i_Player == 1 & i_TargetIndex[0] == 0)
            {
                r_Board[i_TargetIndex[0], i_TargetIndex[1]].CellValue = eCellValue.Player1King;
                m_Player1SoldiersCounter += 3;
            }

            else if (i_Player == 2 & i_TargetIndex[0] == m_SizeOfBoard - 1)
            {
                r_Board[i_TargetIndex[0], i_TargetIndex[1]].CellValue = eCellValue.Player2King;
                m_Player2SoldiersCounter += 3;

            }

            else
            {
                r_Board[i_TargetIndex[0], i_TargetIndex[1]].CellValue = startCellValue;
            }

            UpdateAllPlayerLegalMoves();
        }

        public void MakeMove(string i_PlayerMove, int i_Player)
        {
            bool isLeagal = false;
            string playerMove = i_PlayerMove;

            while (!isLeagal)
            {
                int[] startingPosition = { playerMove[1] - 97, playerMove[0] - 65 };
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
                        throw new ArgumentException("Ilegal move, please try again");
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
                        throw new ArgumentException("Ilegal move, please try again");
                    }
                }

                UpdateAllPlayerLegalMoves();
            }
        }

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
            char startRowChar = Convert.ToChar(i_Row + 97);
            char startColChar = Convert.ToChar(i_Col + 65);
            char targetRowChar;
            char targetColChar;
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
                        targetRowChar = Convert.ToChar(i_Row - 2 + 97);
                        targetColChar = Convert.ToChar(i_Col + -2 + 65);
                        leagalMove = "" + startColChar + startRowChar + '>' + targetColChar + targetRowChar;
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
                        targetRowChar = Convert.ToChar(i_Row - 2 + 97);
                        targetColChar = Convert.ToChar(i_Col + +2 + 65);
                        leagalMove = "" + startColChar + startRowChar + '>' + targetColChar + targetRowChar;
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
                        targetRowChar = Convert.ToChar(i_Row + 2 + 97);
                        targetColChar = Convert.ToChar(i_Col - 2 + 65);
                        leagalMove = "" + startColChar + startRowChar + '>' + targetColChar + targetRowChar;
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
                        targetRowChar = Convert.ToChar(i_Row + 2 + 97);
                        targetColChar = Convert.ToChar(i_Col + 2 + 65);
                        leagalMove = "" + startColChar + startRowChar + '>' + targetColChar + targetRowChar;
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
                        targetRowChar = Convert.ToChar(i_Row + 2 + 97);
                        targetColChar = Convert.ToChar(i_Col - 2 + 65);
                        leagalMove = "" + startColChar + startRowChar + '>' + targetColChar + targetRowChar;
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
                        targetRowChar = Convert.ToChar(i_Row + 2 + 97);
                        targetColChar = Convert.ToChar(i_Col + 2 + 65);
                        leagalMove = "" + startColChar + startRowChar + '>' + targetColChar + targetRowChar;
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
                        targetRowChar = Convert.ToChar(i_Row - 2 + 97);
                        targetColChar = Convert.ToChar(i_Col + -2 + 65);
                        leagalMove = "" + startColChar + startRowChar + '>' + targetColChar + targetRowChar;
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
                        targetRowChar = Convert.ToChar(i_Row - 2 + 97);
                        targetColChar = Convert.ToChar(i_Col + +2 + 65);
                        leagalMove = "" + startColChar + startRowChar + '>' + targetColChar + targetRowChar;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }
            }

            return leagalMovesFromIndexList;
        }

        public List<string> GetLegalSingleMovesFromCell(int i_Row, int i_Col, int i_Player)
        {
            char startRowChar = Convert.ToChar(i_Row + 97);
            char startColChar = Convert.ToChar(i_Col + 65);
            char targetRowChar;
            char targetColChar;
            string leagalMove;
            List<string> leagalMovesFromIndexList = new List<string>();

            if (i_Player == 1 || (r_Board[i_Row, i_Col].CellValue == eCellValue.Player2King))
            {

                //up left
                if ((i_Row - 1) >= 0 && (i_Col - 1) >= 0)
                {
                    if (r_Board[i_Row - 1, i_Col - 1].CellValue == eCellValue.Empty)
                    {
                        targetRowChar = Convert.ToChar(i_Row - 1 + 97);
                        targetColChar = Convert.ToChar(i_Col - 1 + 65);
                        leagalMove = "" + startColChar + startRowChar + '>' + targetColChar + targetRowChar;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }

                //up right
                if ((i_Row - 1) >= 0 && (i_Col + 1) < m_SizeOfBoard)
                {
                    if (r_Board[i_Row - 1, i_Col + 1].CellValue == eCellValue.Empty)
                    {
                        targetRowChar = Convert.ToChar(i_Row - 1 + 97);
                        targetColChar = Convert.ToChar(i_Col + 1 + 65);
                        leagalMove = "" + startColChar + startRowChar + '>' + targetColChar + targetRowChar;
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
                        targetRowChar = Convert.ToChar(i_Row + 1 + 97);
                        targetColChar = Convert.ToChar(i_Col - 1 + 65);
                        leagalMove = "" + startColChar + startRowChar + '>' + targetColChar + targetRowChar;
                        leagalMovesFromIndexList.Add(leagalMove);
                    }
                }

                //Down right
                if ((i_Row + 1) < m_SizeOfBoard && (i_Col + 1) < m_SizeOfBoard)
                {
                    if (r_Board[i_Row + 1, i_Col + 1].CellValue == eCellValue.Empty)
                    {
                        targetRowChar = Convert.ToChar(i_Row + 1 + 97);
                        targetColChar = Convert.ToChar(i_Col + 1 + 65);
                        leagalMove = "" + startColChar + startRowChar + '>' + targetColChar + targetRowChar;
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

            m_Player1SoldiersCounter = 0;
            m_Player2SoldiersCounter = 0;
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

        public eGameResult IsWon()
        {
            eGameResult gameResult = eGameResult.None;

            if (m_Player1SoldiersCounter == 0)
            {
                gameResult = eGameResult.Player2Won;
            }

            if (m_Player2SoldiersCounter == 0)
            {
                gameResult = eGameResult.Player1Won;
            }

            return gameResult;
        }
    }
}
