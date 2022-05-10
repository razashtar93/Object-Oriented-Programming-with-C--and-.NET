using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex02
{
    public class Player
    {
        // id? or somthing like player 1 player2 or idk ...
        private int m_Score;
        // public int Sign { get; }

        public Player()// int i_sign)
        {
            m_Score = 0;
            // Sign = i_Sign
        }


        public int Score
        {
            get => m_Score;
            set => m_Score = value;
        }

    }
}
