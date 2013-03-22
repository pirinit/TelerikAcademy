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
        }

        private void InitializeGame()
        {
            grid = new Grid(30, 15);
            GridManager.GetGrid(grid);
            shapeQueue = new ShapeQueue();
            shape = shapeQueue.NextShape();
            shape = shapeQueue.NextShape();
            
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
            if (e.KeyData == Keys.Down)
            {
                shape.MoveAtBottom();
            }

            if (e.KeyData == Keys.Right)
            {
                shape.MoveRight();
            }

            if (e.KeyData == Keys.Left)
            {
                shape.MoveLeft();
            }

            if (e.KeyData == Keys.Space || e.KeyData == Keys.Up)
            {
                shape.Rotate();
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
        
        private void btnRestart_Click(object sender, EventArgs e)
        {
            InitializeGame();
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            if (!highScoreForm.IsDisposed)
            {
                highScoreForm.Show();
                highScoreForm.Focus();
            }
            else
            {
                highScoreForm = new HighScoresForm();
                highScoreForm.Show();
                highScoreForm.Focus();
            }
        }
    }
}
