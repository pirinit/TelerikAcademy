using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public struct ScoreEntry
    {
        private string name;
        private int score;
        private int demolishedRows;

        internal string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        internal int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                this.score = value;
            }
        }

        internal int DemolishedRows
        {
            get
            {
                return this.demolishedRows;
            }

            set
            {
                this.demolishedRows = value;
            }
        }

        internal ScoreEntry(string name, int score, int demolishedRows)
        {
            this.name = name;
            this.score = score;
            this.demolishedRows = demolishedRows;
        }
    }
}