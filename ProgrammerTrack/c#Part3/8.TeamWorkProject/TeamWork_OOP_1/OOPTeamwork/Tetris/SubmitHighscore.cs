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
    public partial class SubmitHighscoreForm : Form
    {
        ScoreEntry newEntry;
        public SubmitHighscoreForm(ScoreEntry entry)
        {
            InitializeComponent();
            newEntry = entry;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
            {
                newEntry.Name = txtName.Text;
                ScoreManager.AddScore(newEntry);
                this.Close();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnSubmit_Click(this, new EventArgs());
        }


    }
}
