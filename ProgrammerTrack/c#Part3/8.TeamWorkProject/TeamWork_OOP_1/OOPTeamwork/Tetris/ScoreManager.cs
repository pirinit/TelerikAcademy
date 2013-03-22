using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tetris
{
    public static class ScoreManager
    {
        const string FileName = @"Scores.dnt";
        static private string cipher = "!@#$ads%^&*()werrw-=+12345kjggjliu6789~<>?";
        static private List<ScoreEntry> scores;
        static int currentScore = 0;
        static public int LinesDestroyed { get; set; }
        static public int CurrentScore { get { return currentScore; } set { currentScore = value; } }

        public delegate void NewHighscore(ScoreEntry entry);
        static public event NewHighscore newHighscore;

        static public void LoadScores()
        {
            LoadFile();
        }

        static public void CheckIfHighscore()
        {
            foreach (var item in scores)
            {
                if (currentScore > item.Score)
                {
                    newHighscore(new ScoreEntry(currentScore));
                    break;
                }
            }
        }

        static public void Update(Label scoreLabel)
        {
            currentScore += LinesDestroyed * GridManager.Width;
            LinesDestroyed = 0;
            scoreLabel.Text = currentScore.ToString();
        }

        static public List<ScoreEntry> GetScores()
        {
            return scores;
        }

        static void LoadFile()
        {
            string textFromFile = null;
            try
            {
                StreamReader reader = new StreamReader(FileName);
                using (reader)
                {
                    textFromFile = reader.ReadToEnd();
                }

            }
            catch (FileNotFoundException)
            {
                scores = Reset();
            }

            string decodedText = DecodeString(textFromFile);

            scores = ExtractScoreEntriesFromString(decodedText);
        }

        static internal void AddScore(ScoreEntry score)
        {
            scores.Add(score);
            var sortedScores = scores.OrderByDescending(x => x.Score);
            List<ScoreEntry> temp = new List<ScoreEntry>();

            foreach (var element in sortedScores)
            {
                temp.Add(element);
            }
            if (temp.Count > 3)
            {
                temp.RemoveAt(temp.Count - 1);
            }
            Save(temp);
        }

        static private void Save(List<ScoreEntry> scores)
        {
            StringBuilder output = new StringBuilder();

            foreach (var score in scores)
            {
                output.AppendFormat("{0};{1};{2}\n", score.Name, score.Score, score.DemolishedRows);
            }


            string textToFile = output.ToString();
            textToFile = String.Format("{0}\n{1}", textToFile, textToFile.GetHashCode());

            textToFile = CodeString(textToFile);

            StreamWriter writer = new StreamWriter(FileName, false, Encoding.UTF8);
            using (writer)
            {
                writer.Write(textToFile);
            }
        }

        static internal List<ScoreEntry> Reset()
        {
            List<ScoreEntry> dummyScores = new List<ScoreEntry>();
            for (int i = 0; i < 3; i++)
            {
                dummyScores.Add(new ScoreEntry("Empty", 0, 0));
            }
            Save(dummyScores);
            return dummyScores;
        }

        static private List<ScoreEntry> ExtractScoreEntriesFromString(string input)
        {
            List<ScoreEntry> result = new List<ScoreEntry>();

            //check input for a valid hashCode
            int lastNewLineIndex = input.LastIndexOf('\n');
            string hashCodeStr = input.Substring(lastNewLineIndex + 1);
            int hasCode = 0;
            if (!int.TryParse(hashCodeStr, out hasCode))
            {
                return Reset();
            }

            //extracting scoreEntries from text
            string mainText = input.Substring(0, lastNewLineIndex - 1);
            string[] lines = mainText.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string[] tokens = lines[i].Split(';');
                string name = tokens[0];
                int score = int.Parse(tokens[1]);
                int demolishedRows = int.Parse(tokens[2]);
                result.Add(new ScoreEntry(name, score, demolishedRows));
            }
            return result;
        }

        static private string CodeString(string text)
        {
            char[] result = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                result[i] = (char)(text[i] ^ cipher[i % cipher.Length]);
            }
            return new string(result);
        }

        static private string DecodeString(string text)
        {
            return CodeString(text);
        }
    }
}