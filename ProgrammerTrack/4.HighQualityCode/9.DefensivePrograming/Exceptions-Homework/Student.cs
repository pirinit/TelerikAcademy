using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;
    private string lastName;

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("First name can not be null or contain only white space.");
            }
        }
    }
    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Last name can not be null or contain only white space.");
            }
        }
    }

    public IList<Exam> Exams { get; set; }

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException("Student.Exams is null. Can not checkExams.");
        }

        if (this.Exams.Count == 0)
        {
            throw new ArgumentException("Student.Exams is empty. Can not checkExams.");
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        // I know that the followong code is duplicated, but if it is possible to have empty or null Student.Exams IList
        // when initializing the object Student (and we have a public setter) we have to check for this every time we use Student.Exams.
        if (this.Exams == null)
        {
            throw new ArgumentNullException("Student.Exams is null. Can not checkExams.");
        }

        if (this.Exams.Count == 0)
        {
            throw new ArgumentException("Student.Exams is empty. Can not checkExams.");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
