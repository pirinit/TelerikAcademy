using System;

public class CSharpExam : Exam
{
    public const int MinScore = 0;
    public const int MaxScore = 100;

    public int Score { get; private set; }

    public CSharpExam(int score)
    {
        if (score < MinScore || MaxScore < score)
        {
            string message = string.Format("Score should be greater than {0} and less than {1}.", MinScore, MaxScore);
            throw new ArgumentOutOfRangeException(message);
        }

        this.Score = score;
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, MinScore, MaxScore, "Exam results calculated by score.");
    }
}