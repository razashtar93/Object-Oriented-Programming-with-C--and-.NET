using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    class Program
    {
        public static void Main()
        {
            //americanCheckers();


            //============================

            char[,] matrix = new char[4,4];
            for (int i=0; i< matrix.Length; i++)
            {
                for(int j=0; j< matrix.Length; j++)
                {
                    matrix[i, j] = ' ';
                }
            }

            matrix[0, 0] = 'X';
            matrix[1, 1] = 'X';
            matrix[2, 2] = 'X';
            matrix[3, 3] = 'X';

            VisualBoard.ShowBoard();



            //============================


        }

        private static void americanCheckers()
        {
            // Game game = new Game();
            // playGame(); /  Game.run / or something else ..
        }




        //check----check----check----check----check----check----check----check----check----check


        class VisualBoard
        {
            public static void ShowBoard() // i_Board game is a matrix of the board
            {

                char[,] matrix = new char[4, 4];
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        matrix[i, j] = ' ';
                    }
                }

                matrix[0, 0] = 'X';
                matrix[1, 1] = 'X';
                matrix[2, 2] = 'X';
                matrix[3, 3] = 'X';






                Ex02.ConsoleUtils.Screen.Clear();

                StringBuilder board = new StringBuilder();

                for (int i = 0; i < matrix.Length; i++)
                {
                    board.AppendFormat(" {0}", i + 'A'); // check this
                }

                board.AppendLine();

                for (int i = 0; i < matrix.Length; i++)
                {
                    board.AppendFormat(i + 'a' + " |");

                    for (int j = 0; j < matrix.Length; j++)
                    {
                        board.AppendFormat(" {0} |", matrix[i, j]);
                    }

                    board.AppendLine();
                    board.Append(" ");
                    board.Append('=', matrix.Length * 4); // make sure! that the size of the matrix is not row*col!!!
                    board.Append("\n");
                }

                Console.WriteLine(board);

            }
        }



    }

}
