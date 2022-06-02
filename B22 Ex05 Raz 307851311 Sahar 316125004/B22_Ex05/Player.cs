using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B22_Ex05
{
    public class Player
    {
        private string m_Name;
        private int m_Score;


        public Player(string i_Name)
        {
            m_Name = i_Name;
            m_Score = 0;
        }

        public string Name
        {
            get { return m_Name; }
        }
        public int Score
        {
            get => m_Score;
            set => m_Score = value;
        }
    }
}