using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    public class VisualBoard
    {
        public static void ShowBoard(Board i_BoardGame) // i_Board game is a matrix of the board
        {
            Ex02.ConsoleUtils.Screen.Clear();

            StringBuilder board = new StringBuilder();

            for (int i = 0; i < i_BoardGame.BoardSize(); i++)
            {
                board.AppendFormat(" {0}", i + 'A'); // check this
            }

            board.AppendLine();

            for (int i = 0; i < i_BoardGame.BoardSize(); i++)
            {
                board.AppendFormat(i + 'a' + " |");

                for (int j = 0; j < i_BoardGame.BoardSize(); j++)
                {
                    board.AppendFormat(" {0} |", i_BoardGame[i, j]);
                }

                board.AppendLine();
                board.Append(" ");
                board.Append('=', i_BoardGame.BoardSize() * 4);
                board.Append("\n");
            }

            Console.WriteLine(board);

        }
    }
}
