
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
            this.BoardSize = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton6x6 = new System.Windows.Forms.RadioButton();
            this.radioButton8x8 = new System.Windows.Forms.RadioButton();
            this.radioButton10x10 = new System.Windows.Forms.RadioButton();
            this.ButtonDone = new System.Windows.Forms.Button();
            this.Player2 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BoardSize
            // 
            this.BoardSize.AutoSize = true;
            this.BoardSize.Location = new System.Drawing.Point(21, 22);
            this.BoardSize.Name = "BoardSize";
            this.BoardSize.Size = new System.Drawing.Size(91, 20);
            this.BoardSize.TabIndex = 0;
            this.BoardSize.Text = "Board Size:";
            this.BoardSize.AutoSizeChanged += new System.EventHandler(this.GameSetupForm_Load);
            this.BoardSize.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 140);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Players:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Player 1:";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // radioButton6x6
            // 
            this.radioButton6x6.AutoSize = true;
            this.radioButton6x6.Checked = true;
            this.radioButton6x6.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radioButton6x6.Location = new System.Drawing.Point(41, 54);
            this.radioButton6x6.Name = "radioButton6x6";
            this.radioButton6x6.Size = new System.Drawing.Size(67, 24);
            this.radioButton6x6.TabIndex = 4;
            this.radioButton6x6.Text = "6 x 6";
            this.radioButton6x6.UseVisualStyleBackColor = true;
            // 
            // radioButton8x8
            // 
            this.radioButton8x8.AutoSize = true;
            this.radioButton8x8.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radioButton8x8.Location = new System.Drawing.Point(124, 54);
            this.radioButton8x8.Name = "radioButton8x8";
            this.radioButton8x8.Size = new System.Drawing.Size(67, 24);
            this.radioButton8x8.TabIndex = 7;
            this.radioButton8x8.Text = "8 x 8";
            this.radioButton8x8.UseVisualStyleBackColor = true;
            // 
            // radioButton10x10
            // 
            this.radioButton10x10.AutoSize = true;
            this.radioButton10x10.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radioButton10x10.Location = new System.Drawing.Point(209, 54);
            this.radioButton10x10.Name = "radioButton10x10";
            this.radioButton10x10.Size = new System.Drawing.Size(85, 24);
            this.radioButton10x10.TabIndex = 8;
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
            // 
            // Player2
            // 
            this.Player2.AutoSize = true;
            this.Player2.Location = new System.Drawing.Point(41, 188);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(95, 24);
            this.Player2.TabIndex = 10;
            this.Player2.Text = "Player 2:";
            this.Player2.UseVisualStyleBackColor = true;
            this.Player2.CheckedChanged += new System.EventHandler(this.Player2_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(149, 188);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(170, 26);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "[Computer]";
            this.textBox2.Visible = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // GameSetupForm
            // 
            this.AcceptButton = this.ButtonDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(354, 282);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.ButtonDone);
            this.Controls.Add(this.radioButton10x10);
            this.Controls.Add(this.radioButton8x8);
            this.Controls.Add(this.radioButton6x6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BoardSize);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
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

        private System.Windows.Forms.Label BoardSize;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton6x6;
        private System.Windows.Forms.RadioButton radioButton8x8;
        private System.Windows.Forms.RadioButton radioButton10x10;
        private System.Windows.Forms.Button ButtonDone;
        private System.Windows.Forms.CheckBox Player2;
        private System.Windows.Forms.TextBox textBox2;
    }
}