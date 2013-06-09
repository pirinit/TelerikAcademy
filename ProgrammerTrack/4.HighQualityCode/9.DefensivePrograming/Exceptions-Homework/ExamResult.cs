using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            string message = string.Format("Grade can not be negative. Actual value {0}.", grade);
            throw new ArgumentException(message);
        }
        if (minGrade < 0)
        {
            string message = string.Format("MinGrade can not be negative. Actual value {0}.", minGrade);
            throw new ArgumentException(message);
        }
        if (maxGrade <= minGrade)
        {
            string message = string.Format("MaxGrade({0}) should be greater than minGrade({1}).", maxGrade, minGrade);
            throw new ArgumentException(message);
        }
        if (comments == null || comments == "")
        {
            string message = string.Format("Comments can not be null or empty.");
            throw new ArgumentException(message);
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
