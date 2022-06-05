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
    public partial class GameSetupForm : Form
    {
        private int m_BoardSize = 6;

        public GameSetupForm()
        {
            InitializeComponent();
        }

        private void GameSetupForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Player2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            this.textBoxPlayer2.Enabled = checkbox.Checked;

            if (checkbox.Checked)
            {
                this.textBoxPlayer2.Text = "";
            }
            else
            {
                this.textBoxPlayer2.Text = "[Computer]";
            }
        }

        private void ButtonDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        public string GetFirstPlayerName
        {
            get { return this.textBoxPlayer1.Text; }
        }

        public string GetSecondPlayerName
        {
            get { return this.textBoxPlayer2.Text; }
        }

        public bool PlayAgainstHuman
        {
            get { return this.CheckBoxPlayer2.Checked; }
        }

        private void radioButton6x6_CheckedChanged(object sender, EventArgs e)
        {
            this.m_BoardSize = 6;
        }

        private void radioButton8x8_CheckedChanged(object sender, EventArgs e)
        {
            this.m_BoardSize = 8;
        }

        private void radioButton10x10_CheckedChanged(object sender, EventArgs e)
        {
            this.m_BoardSize = 10;
        }

        public int GetBoardSize
        {
            get { return m_BoardSize; }
        }

        private void textBoxPlayer1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
