namespace Tetris
{
    partial class HighScoresForm
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
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblThird = new System.Windows.Forms.Label();
            this.lblScores = new System.Windows.Forms.Label();
            this.lblNames = new System.Windows.Forms.Label();
            this.lblFirstScore = new System.Windows.Forms.Label();
            this.lblSecondScore = new System.Windows.Forms.Label();
            this.lblThirdScore = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(43, 53);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(0, 13);
            this.lblFirst.TabIndex = 0;
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(43, 79);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(0, 13);
            this.lblSecond.TabIndex = 1;
            // 
            // lblThird
            // 
            this.lblThird.AutoSize = true;
            this.lblThird.Location = new System.Drawing.Point(43, 101);
            this.lblThird.Name = "lblThird";
            this.lblThird.Size = new System.Drawing.Size(0, 13);
            this.lblThird.TabIndex = 2;
            // 
            // lblScores
            // 
            this.lblScores.AutoSize = true;
            this.lblScores.Location = new System.Drawing.Point(130, 25);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(40, 13);
            this.lblScores.TabIndex = 3;
            this.lblScores.Text = "Scores";
            // 
            // lblNames
            // 
            this.lblNames.AutoSize = true;
            this.lblNames.Location = new System.Drawing.Point(38, 25);
            this.lblNames.Name = "lblNames";
            this.lblNames.Size = new System.Drawing.Size(40, 13);
            this.lblNames.TabIndex = 4;
            this.lblNames.Text = "Names";
            // 
            // lblFirstScore
            // 
            this.lblFirstScore.AutoSize = true;
            this.lblFirstScore.Location = new System.Drawing.Point(129, 53);
            this.lblFirstScore.Name = "lblFirstScore";
            this.lblFirstScore.Size = new System.Drawing.Size(0, 13);
            this.lblFirstScore.TabIndex = 5;
            // 
            // lblSecondScore
            // 
            this.lblSecondScore.AutoSize = true;
            this.lblSecondScore.Location = new System.Drawing.Point(129, 79);
            this.lblSecondScore.Name = "lblSecondScore";
            this.lblSecondScore.Size = new System.Drawing.Size(0, 13);
            this.lblSecondScore.TabIndex = 6;
            // 
            // lblThirdScore
            // 
            this.lblThirdScore.AutoSize = true;
            this.lblThirdScore.Location = new System.Drawing.Point(129, 101);
            this.lblThirdScore.Name = "lblThirdScore";
            this.lblThirdScore.Size = new System.Drawing.Size(0, 13);
            this.lblThirdScore.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(90, 128);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.bntClose_Click);
            // 
            // HighScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 163);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblThirdScore);
            this.Controls.Add(this.lblSecondScore);
            this.Controls.Add(this.lblFirstScore);
            this.Controls.Add(this.lblNames);
            this.Controls.Add(this.lblScores);
            this.Controls.Add(this.lblThird);
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblFirst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HighScoresForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HighScores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblThird;
        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.Label lblNames;
        private System.Windows.Forms.Label lblFirstScore;
        private System.Windows.Forms.Label lblSecondScore;
        private System.Windows.Forms.Label lblThirdScore;
        private System.Windows.Forms.Button btnClose;
    }
}