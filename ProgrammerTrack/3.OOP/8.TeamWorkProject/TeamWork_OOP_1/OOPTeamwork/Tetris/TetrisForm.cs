using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Tetris
{
    public partial class TetrisForm : Form
    {
        Grid grid;
        Shape shape; //current shape that is moving
        ShapeQueue shapeQueue;
        HighScoresForm highScoreForm;
        public TetrisForm()
        {
            InitializeComponent();
            InitializeGame();
            highScoreForm = new HighScoresForm();
            SubscribeForNewHighscore();
        }

        private void InitializeGame()
        {
            
            grid = new Grid(30, 15);
            GridManager.GetGrid(grid);
            shapeQueue = new ShapeQueue();
            shape = shapeQueue.NextShape();
            shape = shapeQueue.NextShape();
            ScoreManager.LoadScores();
            ScoreManager.CurrentScore = 0;//50;

            lblScoreAmount.Text = "0";
            btnRestart.Visible = false;
            btnHighScores.Visible = false;
            timer1.Start();
            this.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!shape.MoveDown())
            {
                grid.PlaceShapeBlocksInGrid(shape.GetBlocks);
                shape = shapeQueue.NextShape();
                if (!shape.IsShapePossible())
                {
                    timer1.Stop();
                    ScoreManager.CheckIfHighscore();
                    btnRestart.Visible = true;
                    btnHighScores.Visible = true;
                }
                ScoreManager.Update(lblScoreAmount);
                QueuePanel.Refresh();
            }

            this.Refresh(); //forces repaint
        }

        private void TetrisForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down && timer1.Enabled)
            {
                shape.MoveAtBottom();
            }
            else if (e.KeyData == Keys.Right && timer1.Enabled)
            {
                shape.MoveRight();
            }
            else if (e.KeyData == Keys.Left && timer1.Enabled)
            {
                shape.MoveLeft();
            }
            else if (e.KeyData == Keys.Space && timer1.Enabled)
            {
                shape.Rotate();
            }
            else if (e.KeyData == Keys.P)
            {
                timer1.Enabled = !timer1.Enabled;
            }

            this.Refresh();
        }

        private void TetrisForm_Paint(object sender, PaintEventArgs e)
        {
            shape.Draw(e.Graphics);
            grid.Draw(e.Graphics);
        }

        private void QueuePanel_Paint(object sender, PaintEventArgs e)
        {
            shapeQueue.Draw(e.Graphics);
        }

        
        public void SubscribeForNewHighscore()
        {
            ScoreManager.newHighscore += new ScoreManager.NewHighscore(SubmitHighscore);
        }

        private void SubmitHighscore(ScoreEntry entry)
        {
            SubmitHighscoreForm newSubmit = new SubmitHighscoreForm(entry);
            newSubmit.Show();
            newSubmit.Focus();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            InitializeGame();
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            if (!highScoreForm.IsDisposed)
            {
                highScoreForm.LoadScores();
                highScoreForm.Show();
                highScoreForm.Focus();
            }
            else
            {
                highScoreForm = new HighScoresForm();
                highScoreForm.LoadScores();
                highScoreForm.Show();
                highScoreForm.Focus();
            }
        }
    }
}
