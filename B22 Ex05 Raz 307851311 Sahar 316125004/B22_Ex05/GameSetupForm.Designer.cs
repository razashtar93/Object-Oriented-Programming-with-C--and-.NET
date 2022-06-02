
namespace B22_Ex05
{
    partial class GameSetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelBoardSize = new System.Windows.Forms.Label();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.LabelPlayers = new System.Windows.Forms.Label();
            this.LabelPlayer1 = new System.Windows.Forms.Label();
            this.radioButton6x6 = new System.Windows.Forms.RadioButton();
            this.radioButton8x8 = new System.Windows.Forms.RadioButton();
            this.radioButton10x10 = new System.Windows.Forms.RadioButton();
            this.ButtonDone = new System.Windows.Forms.Button();
            this.CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LabelBoardSize
            // 
            this.LabelBoardSize.AutoSize = true;
            this.LabelBoardSize.Location = new System.Drawing.Point(21, 22);
            this.LabelBoardSize.Name = "LabelBoardSize";
            this.LabelBoardSize.Size = new System.Drawing.Size(91, 20);
            this.LabelBoardSize.TabIndex = 0;
            this.LabelBoardSize.Text = "Board Size:";
            this.LabelBoardSize.AutoSizeChanged += new System.EventHandler(this.GameSetupForm_Load);
            this.LabelBoardSize.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(149, 140);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(170, 26);
            this.textBoxPlayer1.TabIndex = 6;
            // 
            // LabelPlayers
            // 
            this.LabelPlayers.AutoSize = true;
            this.LabelPlayers.Location = new System.Drawing.Point(21, 107);
            this.LabelPlayers.Name = "LabelPlayers";
            this.LabelPlayers.Size = new System.Drawing.Size(64, 20);
            this.LabelPlayers.TabIndex = 4;
            this.LabelPlayers.Text = "Players:";
            // 
            // LabelPlayer1
            // 
            this.LabelPlayer1.AutoSize = true;
            this.LabelPlayer1.Location = new System.Drawing.Point(37, 146);
            this.LabelPlayer1.Name = "LabelPlayer1";
            this.LabelPlayer1.Size = new System.Drawing.Size(69, 20);
            this.LabelPlayer1.TabIndex = 5;
            this.LabelPlayer1.Text = "Player 1:";
            this.LabelPlayer1.Visible = false;
            this.LabelPlayer1.Click += new System.EventHandler(this.label2_Click);
            // 
            // radioButton6x6
            // 
            this.radioButton6x6.AutoSize = true;
            this.radioButton6x6.Checked = true;
            this.radioButton6x6.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radioButton6x6.Location = new System.Drawing.Point(41, 54);
            this.radioButton6x6.Name = "radioButton6x6";
            this.radioButton6x6.Size = new System.Drawing.Size(67, 24);
            this.radioButton6x6.TabIndex = 1;
            this.radioButton6x6.TabStop = true;
            this.radioButton6x6.Text = "6 x 6";
            this.radioButton6x6.UseVisualStyleBackColor = true;
            this.radioButton6x6.CheckedChanged += new System.EventHandler(this.radioButton6x6_CheckedChanged);
            // 
            // radioButton8x8
            // 
            this.radioButton8x8.AutoSize = true;
            this.radioButton8x8.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radioButton8x8.Location = new System.Drawing.Point(124, 54);
            this.radioButton8x8.Name = "radioButton8x8";
            this.radioButton8x8.Size = new System.Drawing.Size(67, 24);
            this.radioButton8x8.TabIndex = 2;
            this.radioButton8x8.Text = "8 x 8";
            this.radioButton8x8.UseVisualStyleBackColor = true;
            this.radioButton8x8.CheckedChanged += new System.EventHandler(this.radioButton8x8_CheckedChanged);
            // 
            // radioButton10x10
            // 
            this.radioButton10x10.AutoSize = true;
            this.radioButton10x10.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radioButton10x10.Location = new System.Drawing.Point(209, 54);
            this.radioButton10x10.Name = "radioButton10x10";
            this.radioButton10x10.Size = new System.Drawing.Size(85, 24);
            this.radioButton10x10.TabIndex = 3;
            this.radioButton10x10.Text = "10 x 10";
            this.radioButton10x10.UseVisualStyleBackColor = true;
            this.radioButton10x10.CheckedChanged += new System.EventHandler(this.radioButton10x10_CheckedChanged);
            // 
            // ButtonDone
            // 
            this.ButtonDone.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ButtonDone.FlatAppearance.BorderSize = 5;
            this.ButtonDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ButtonDone.Location = new System.Drawing.Point(165, 232);
            this.ButtonDone.Name = "ButtonDone";
            this.ButtonDone.Size = new System.Drawing.Size(154, 38);
            this.ButtonDone.TabIndex = 9;
            this.ButtonDone.Text = "Done";
            this.ButtonDone.UseVisualStyleBackColor = true;
            this.ButtonDone.Click += new System.EventHandler(this.ButtonDone_Click);
            // 
            // CheckBoxPlayer2
            // 
            this.CheckBoxPlayer2.AutoSize = true;
            this.CheckBoxPlayer2.Location = new System.Drawing.Point(41, 188);
            this.CheckBoxPlayer2.Name = "CheckBoxPlayer2";
            this.CheckBoxPlayer2.Size = new System.Drawing.Size(95, 24);
            this.CheckBoxPlayer2.TabIndex = 7;
            this.CheckBoxPlayer2.Text = "Player 2:";
            this.CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.Player2_CheckedChanged);
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Location = new System.Drawing.Point(149, 188);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(170, 26);
            this.textBoxPlayer2.TabIndex = 8;
            this.textBoxPlayer2.Text = "[Computer]";
            this.textBoxPlayer2.Visible = false;
            this.textBoxPlayer2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // GameSetupForm
            // 
            this.AcceptButton = this.ButtonDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(355, 290);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.CheckBoxPlayer2);
            this.Controls.Add(this.ButtonDone);
            this.Controls.Add(this.radioButton10x10);
            this.Controls.Add(this.radioButton8x8);
            this.Controls.Add(this.radioButton6x6);
            this.Controls.Add(this.LabelPlayer1);
            this.Controls.Add(this.LabelPlayers);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.LabelBoardSize);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSetupForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.GameSetupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelBoardSize;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.Label LabelPlayers;
        private System.Windows.Forms.Label LabelPlayer1;
        private System.Windows.Forms.RadioButton radioButton6x6;
        private System.Windows.Forms.RadioButton radioButton8x8;
        private System.Windows.Forms.RadioButton radioButton10x10;
        private System.Windows.Forms.Button ButtonDone;
        private System.Windows.Forms.CheckBox CheckBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer2;
    }
}