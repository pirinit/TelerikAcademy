using System;

public class SimpleMathExam : Exam
{
    public const int MinProblemSolved = 0;
    public const int MaxProblemSolved = 2;

    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < MinProblemSolved || MaxProblemSolved < problemsSolved)
        {
            string message = string.Format("ProblemSolved{0} should be in range [{1}-{2}].",
                problemsSolved, MinProblemSolved, MaxProblemSolved);
            throw new ArgumentOutOfRangeException(message);
        }

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }
        else
        {
            //when we extend the range for problemSolved property and forget to update if-else-if statement
            string message = string.Format("Unknown problemSolved value.");
            throw new ArgumentOutOfRangeException(message);
        }
    }
}
