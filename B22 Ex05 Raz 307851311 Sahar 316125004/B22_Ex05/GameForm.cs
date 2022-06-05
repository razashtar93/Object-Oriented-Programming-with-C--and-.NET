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
        private Game m_Game;
        private int m_BoardSize;
        private Button[,] m_BoardButton;
        private readonly string r_Player1Name;
        private readonly string r_Player2Name;
        private Label m_Player1Label;
        private Label m_Player2Label;
        private int m_Player1Score;
        private int m_Player2Score;
        private string m_Move;
        private bool v_AnotherButtonClicked = false;
        private bool v_Player1Turn = true;

        public GameForm(Game i_Game, int i_BoardSize, string i_Player1Name, string i_Player2Name)
        {
            this.m_Game = i_Game;
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
                    m_BoardButton[i, j].BackColor = ((i + j) % 2 == 0) ? Color.Black : Color.White;
                    m_BoardButton[i, j].Enabled = !((i + j) % 2 == 0);
                    m_BoardButton[i, j].FlatAppearance.BorderColor = Color.Black;
                }
            }
        }

        public void UpdateGameBoard(BoardCell[,] i_Board)
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (!((i + j) % 2 == 0))
                    {
                        m_BoardButton[i, j].BackColor = Color.White;
                        string cellValue = "";

                        switch (i_Board[i, j].CellValue)
                        {
                            case eCellValue.Empty:
                                cellValue = " ";
                                break;
                            case eCellValue.Player1King:
                                cellValue = "Z";
                                break;
                            case eCellValue.Player1Soldier:
                                cellValue = "X";
                                break;
                            case eCellValue.Player2King:
                                cellValue = "Q";
                                break;
                            case eCellValue.Player2Soldier:
                                cellValue = "O";
                                break;
                        }

                        m_BoardButton[i, j].Text = cellValue;
                    }
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
                m_Game.ResetGame();
                m_Player1Label.Text = string.Format("Player 1: {0}", m_Player1Score);
                m_Player2Label.Text = string.Format("Player 2: {0}", m_Player2Score);
                UpdateGameBoard(m_Game.GetBoard.GetBoardCell);
            }
        }

        public void ErrorMessageBox(string i_ErrorMessage)
        {
            MessageBox.Show(i_ErrorMessage);
        }

        private void button_Click(object i_Sender, EventArgs e)
        {
            Button currentButtonClicked = i_Sender as Button;

            if (currentButtonClicked.Enabled)
            {
                if (v_Player1Turn) // player 1 turn ( + computer turn right after if needed
                {
                    if (v_AnotherButtonClicked) // this is the second button that clicked
                    {
                        if (m_Move.Equals(currentButtonClicked.Name))//this is the same button
                        {
                            m_Move = "";
                            currentButtonClicked.BackColor = Color.White;
                            v_AnotherButtonClicked = false;
                        }
                        else // another button pressed by the player -> make move!
                        {
                            m_Move += ">" + currentButtonClicked.Name;
                            v_AnotherButtonClicked = false;

                            try
                            {
                                m_Game.Player1Move(m_Move);
                            }
                            catch (ArgumentException x)
                            {
                                ErrorMessageBox(x.Message);
                                v_Player1Turn = !v_Player1Turn;
                            }

                            UpdateGameBoard(m_Game.GetBoard.GetBoardCell);

                            if (m_Game.isWonOrDraw() != eGameResult.None)
                            {
                                gameResult(m_Game.isWonOrDraw());
                            }

                            if (!m_Game.v_PlayerVsPlayerMode && v_Player1Turn)//play against computer
                            {
                                m_Game.Player2Move("");
                                UpdateGameBoard(m_Game.GetBoard.GetBoardCell);
                            }

                            else
                            {
                                v_Player1Turn = !v_Player1Turn;
                            }

                            //check if after move player won
                            if (m_Game.isWonOrDraw() != eGameResult.None)
                            {
                                gameResult(m_Game.isWonOrDraw());
                            }
                        }
                    }

                    else // this is the first button that was clicked
                    {
                        if (currentButtonClicked.Text.Equals("X") || currentButtonClicked.Text.Equals("Z"))
                        {
                            m_Move = currentButtonClicked.Name;
                            currentButtonClicked.BackColor = Color.LightBlue;
                            v_AnotherButtonClicked = true;
                        }
                    }
                }

                else // player 2 turn (this human turn! without computer move!)
                {
                    if (v_AnotherButtonClicked) // this is the second button that clicked
                    {
                        if (m_Move.Equals(currentButtonClicked.Name))//this is the same button
                        {
                            m_Move = "";
                            currentButtonClicked.BackColor = Color.White;
                            v_AnotherButtonClicked = false;
                        }

                        else // another button pressed by the player -> make move!
                        {
                            m_Move += ">" + currentButtonClicked.Name;
                            v_AnotherButtonClicked = false;

                            try
                            {
                                m_Game.Player2Move(m_Move);
                            }
                            catch (ArgumentException x)
                            {
                                v_Player1Turn = !v_Player1Turn;
                                ErrorMessageBox(x.Message);
                            }

                            UpdateGameBoard(m_Game.GetBoard.GetBoardCell);
                            v_Player1Turn = !v_Player1Turn;

                            //check if after move player won
                            if (m_Game.isWonOrDraw() != eGameResult.None)
                            {
                                gameResult(m_Game.isWonOrDraw());
                            }
                        }
                    }

                    else // this is the first button that was clicked
                    {
                        if (currentButtonClicked.Text.Equals("O") || currentButtonClicked.Text.Equals("Q"))
                        {
                            m_Move = currentButtonClicked.Name;
                            currentButtonClicked.BackColor = Color.LightBlue;
                            v_AnotherButtonClicked = true;
                        }
                    }
                }
            }
        }

        private void initializeComponent()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "GameForm";
            this.Text = "Damka";
            this.MaximizeBox = false;
            this.ClientSize = new Size(100 + 30 * m_BoardSize, 100 + 30 * m_BoardSize);
            Button button;
            m_BoardButton = new Button[m_BoardSize, m_BoardSize];

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    button = new Button();
                    button.Size = new Size(30, 30);

                    // each button will know his location in the matrix by a string representing as in Ex02
                    button.Name = Convert.ToChar(j + 'A').ToString() + Convert.ToChar(i + 'a').ToString();
                    button.Location = new Point(50 + j * button.Size.Width, 50 + i * button.Size.Height);//check this
                    button.Click += this.button_Click;
                    m_BoardButton[i, j] = button;
                    Controls.Add(button);
                }
            }

            initializeDisableButtonsAndBackColors();

            m_Player1Label = new Label();
            m_Player1Label.Text = string.Format("Player 1: {0}", m_Player1Score);
            m_Player1Label.Location = new Point((50 * this.m_BoardSize) / 6, 20);
            Controls.Add(m_Player1Label);

            m_Player2Label = new Label();
            m_Player2Label.Text = string.Format("Player 2: {0}", m_Player2Score);
            m_Player2Label.Location = new Point((75 * this.m_BoardSize) / 3, 20);
            Controls.Add(m_Player2Label);

            UpdateGameBoard(m_Game.GetBoard.GetBoardCell);
        }
    }
}
