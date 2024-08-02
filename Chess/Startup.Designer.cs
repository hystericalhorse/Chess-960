using System.Windows.Forms;
using System;

namespace Chess
{
    partial class Startup
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Startup";

            this.playChess = new Button();
            this.playChess.Text = "Play Chess";
            this.playChess.AutoSize = true;
            this.playChess.Location = new System.Drawing.Point(340,200);
            this.playChess.Click += PlayChess;

            this.playChess960 = new Button();
            this.playChess960.Text = "Play Chess 960";
            this.playChess960.AutoSize = true;
            this.playChess960.Location = new System.Drawing.Point(322, 250);
            this.playChess960.Click += Play960;


            Controls.Add(this.playChess);
            Controls.Add(this.playChess960);
        }

        private void PlayChess(object sender, EventArgs e)
        {
            Board chessboard = new Board(Board.Mode.Chess);
            chessboard.ShowDialog();

            this.Close();
        }

        private void Play960(object sender, EventArgs e)
        {
            Board chessboard = new Board(Board.Mode.Chess960);
            chessboard.ShowDialog();

            this.Close();
        }

        #endregion

        private Button playChess;
        private Button playChess960;
    }
}