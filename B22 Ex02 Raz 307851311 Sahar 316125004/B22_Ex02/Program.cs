using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    public class Program
    {
        public static void Main()
        {
            //americanCheckers();


            //===============================
            //create a board of char and think later how to change it

            char[,] board = new char[8, 8];
            int boardSize = board.GetLength(0);
            

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    board[i, j] = ' ';
                }

            }

            board[0, 0] = 'X';
            board[1, 1] = 'X';
            board[2, 2] = 'X';
            board[3, 3] = 'X';
            board[4, 4] = 'X';
            board[5, 5] = 'X';


            VisualBoard.ShowBoard(board);

        }
        //===========================




    }

    /*   private static void americanCheckers()
       {
           // Game game = new Game();
           // game.playGame(); /  game.Run / or something else ..
       }*/
}

