using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class HighScoresForm : Form
    {
        Label[] names;
        Label[] scores;
        public HighScoresForm()
        {
            InitializeComponent();
            names = new Label[3];
            scores = new Label[3];
        }

        public void LoadScores()
        {
            names[0] = lblFirst;
            names[1] = lblSecond;
            names[2] = lblThird;

            scores[0] = lblFirstScore;
            scores[1] = lblSecondScore;
            scores[2] = lblThirdScore;

            List<ScoreEntry> orderedScore = ScoreManager.GetScores();
            orderedScore.Sort(new Comparer());
            for (int i = 0; i < orderedScore.Count && i < 3; i++)
            {
                names[i].Text = orderedScore[i].Name;
                scores[i].Text = orderedScore[i].Score.ToString();
            }
        }

        class Comparer : IComparer<ScoreEntry>
        {
            public int Compare(ScoreEntry x, ScoreEntry y)
            {
                if (x.Score < y.Score)
                {
                    return 1;
                }
                else if (x.Score > y.Score)
                {
                    return -1;
                }
                return 0;
            }
        }

        private void bntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
