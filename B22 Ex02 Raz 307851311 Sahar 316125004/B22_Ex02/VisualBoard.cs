using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    public class VisualBoard
    {
        // need to change to:
        //get board of Boardcell 
        //in each boardcell check the type and print the relevant value (meaning 'O' or 'X' or 'Q' or 'Z')

        public static void ShowBoard(BoardCell[,] i_BoardGame)
        {
            int boardSize = i_BoardGame.GetLength(0);
            // char[] rowUpperLetter = new char[10] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            //char[] rowLowerLetter = new char[10] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
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
            Console.ReadLine();
        }
    }
}