using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    public class VisualBoard
    {
        public static void ShowBoard(BoardCell[,] i_BoardGame)
        {
            int boardSize = i_BoardGame.GetLength(0);
            string lineDivider = " ";

            for (int i = 0; i < boardSize; i++)
            {
                lineDivider += "====";
            }

            Ex02.ConsoleUtils.Screen.Clear();

            StringBuilder board = new StringBuilder();

            board.Append(" ");

            for (int i = 0; i < boardSize; i++)
            {
                board.AppendFormat("  {0} ", Convert.ToChar('A' + i));
            }

            board.AppendLine();
            board.Append(lineDivider);
            board.AppendLine();

            for (int i = 0; i < boardSize; i++)
            {
                board.AppendFormat("{0}|", Convert.ToChar('a' + i));

                for (int j = 0; j < boardSize; j++)
                {
                    board.AppendFormat(" {0} |", ((char)i_BoardGame[i, j].CellValue)); // check this
                }

                board.AppendLine();
                board.Append(lineDivider);
                board.AppendLine();
            }

            Console.WriteLine(board);
        }
    }
}