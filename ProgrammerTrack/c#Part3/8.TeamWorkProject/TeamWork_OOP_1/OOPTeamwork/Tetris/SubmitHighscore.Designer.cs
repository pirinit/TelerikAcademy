namespace Tetris
{
    partial class SubmitHighscoreForm
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
            this.lblCongr = new System.Windows.Forms.Label();
            this.lblYourScore = new System.Windows.Forms.Label();
            this.lblScoreAmount = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCongr
            // 
            this.lblCongr.AutoSize = true;
            this.lblCongr.Location = new System.Drawing.Point(87, 21);
            this.lblCongr.Name = "lblCongr";
            this.lblCongr.Size = new System.Drawing.Size(83, 13);
            this.lblCongr.TabIndex = 0;
            this.lblCongr.Text = "Congratulations!";
            // 
            // lblYourScore
            // 
            this.lblYourScore.AutoSize = true;
            this.lblYourScore.Location = new System.Drawing.Point(63, 53);
            this.lblYourScore.Name = "lblYourScore";
            this.lblYourScore.Size = new System.Drawing.Size(60, 13);
            this.lblYourScore.TabIndex = 1;
            this.lblYourScore.Text = "YourScore:";
            // 
            // lblScoreAmount
            // 
            this.lblScoreAmount.AutoSize = true;
            this.lblScoreAmount.Location = new System.Drawing.Point(129, 53);
            this.lblScoreAmount.Name = "lblScoreAmount";
            this.lblScoreAmount.Size = new System.Drawing.Size(0, 13);
            this.lblScoreAmount.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(40, 101);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Enter name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 98);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 4;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(90, 128);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // SubmitHighscoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 163);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblScoreAmount);
            this.Controls.Add(this.lblYourScore);
            this.Controls.Add(this.lblCongr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SubmitHighscoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubmitHighscore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCongr;
        private System.Windows.Forms.Label lblYourScore;
        private System.Windows.Forms.Label lblScoreAmount;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSubmit;
    }
}