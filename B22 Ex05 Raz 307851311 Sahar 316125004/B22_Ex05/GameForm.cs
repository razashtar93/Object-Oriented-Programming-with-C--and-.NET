using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace B22_Ex05
{
    public partial class GameForm : Form
    {
        private int m_BoardSize;
        private Button[,] m_BoardButton;
        private readonly string r_Player1Name;
        private readonly string r_Player2Name;
        private Label m_Player1Label;
        private Label m_Player2Label;
        private int m_Player1Score;
        private int m_Player2Score;

        public GameForm(int i_BoardSize, string i_Player1Name, string i_Player2Name)
        {
            this.m_BoardSize = i_BoardSize;
            this.r_Player1Name = i_Player1Name;
            this.r_Player2Name = i_Player2Name;
            this.m_Player1Score = 0;
            this.m_Player2Score = 0;
            initializeComponent();
        }

        private void initializeDisableButtonsAndBackColors()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_BoardButton[i, j].Enabled = false;
                    m_BoardButton[i, j].BackColor = ((i + j) % 2 == 0) ? Color.Gray : Color.White;
                    //if (i % 2 == 0 && j % 2 == 0)
                    //{
                    //    m_BoardButton[i, j].Enabled = false;
                    //    m_BoardButton[i, j].BackColor = Color.Gray;
                    //}
                }
            }
        }

        public void UpdateGameBoard(BoardCell[,] i_Board, int i_Player1Score, int i_Player2Score)
        {
            //I think that the score will be per match .... 

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)// maybe here we need to go only on enable buttons
                {
                    m_BoardButton[i, j].Text = i_Board[i, j].CellValue.ToString();
                }
            }
        }

        private void gameResult(eGameResult i_GameResult)
        {
            DialogResult dialogResult = DialogResult.No;
            string messgae = "";

            if (i_GameResult == eGameResult.Player1Won)
            {
                m_Player1Score++;
                messgae = "Player 1 Won! \nAnother Round?";
            }

            if (i_GameResult == eGameResult.Player2Won)
            {
                m_Player2Score++;
                messgae = "Player 2 Won! \nAnother Round?";
            }

            if (i_GameResult == eGameResult.Tie)
            {
                messgae = "Tie! \nAnother Round?";
            }

            dialogResult = MessageBox.Show(messgae, "Damka", MessageBoxButtons.YesNo);


            if (dialogResult == DialogResult.No)
            {
                this.Close();
            }

            if (dialogResult == DialogResult.Yes)
            {
                //return to Game that the player want to play another round ..
            }
        }


        private void initializeComponent()
        {
            //this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(612, 484);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "GameForm";
            this.Text = "Damka";
            this.MaximizeBox = false;
            //this.ResumeLayout(false);
            this.ClientSize = new Size(30 + 50 * m_BoardSize, 80 + 50 * m_BoardSize);

            Button button;
            m_BoardButton = new Button[m_BoardSize, m_BoardSize];

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    button = new Button();
                    button.Size = new Size(30, 30);
                    //button.Location = new Point(20 + j * button.Size.Width, 50 + i * button.Size.Height);//check this
                    //TODO: How to set up the position?
                    m_BoardButton[i, j] = button;
                    Controls.Add(button);

                }
            }

            initializeDisableButtonsAndBackColors();

            m_Player1Label = new Label();
            m_Player1Label.Text = string.Format("Player 1: {0}", m_Player1Score);
            //m_Player1Label.Location = new point();
            Controls.Add(m_Player1Label);


            m_Player2Label = new Label();
            m_Player2Label.Text = string.Format("Player 2: {0}", m_Player2Score);
            //m_Player2Label.Location = 
            Controls.Add(m_Player2Label);

        }
    }
}
