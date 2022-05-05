using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    public class Board // all the logic of a board is placed here
    {
        public enum eBoardSize
        {
            six = 6, eight = 8, ten = 10
        }


        private readonly eBoardSize m_SizeOfBoard; // from the enums i guess ...
        // add more here



        public Board(int i_BoardSize)
        {
            //constructor for board
        }

        private void initializeBoard()
        {
            /* here we need to think how to implement the board.
               the board is a matrix of special characters ('X', 'O') so maybe
               we need to use enum and the matrix will be only of type 'X' and 'O' or somthing .. */

            // maybe array of chars and validate that onlu contain 'X' 'O' 

            //todo: implement the matrix of chars where valid inputs are: {'X', 'O', ' ', 'Q', 'Z'}
        }


        public int BoardSize()
        {
            //make sure here to return the real size and not the multipication of the rows and cols
            int size;

            if (m_SizeOfBoard == eBoardSize.six)
            {
                size = 6;
            }
            else
            {
                if (m_SizeOfBoard == eBoardSize.eight)
                {
                    size = 8;
                }
                else
                {
                    size = 10;
                }
            }

            return size;
        }


    }
}
