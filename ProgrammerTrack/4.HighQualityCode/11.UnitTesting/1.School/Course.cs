using System;
using System.Collections.Generic;

public class Course
{
    private IList<Student> students;
    private string name;

	public string Name
    {
        get 
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name can not be null or contain only white spaces.");
            }
            this.name = value;
        }
    }

    public int StudentsCount
    {
        get
        {
            return this.students.Count;
        }
    }

    public IEnumerable<Student> Students
    {
        get
        {
            return this.students;
        }
    }

    internal Course(string name)
    {
        this.students = new List<Student>();
        this.Name = name;
    }

    internal bool AddStudent(Student student)
    {
        if (this.students.Count == Constants.MaxStudentsInCourse)
        {
            string message = string.Format("Max student count({0}) reached. Can not add any more.", Constants.MaxStudentsInCourse);
            throw new InvalidOperationException(message);
        }

        if (HasStudent(student) || HasStudent(student.Id))
        {
            string message = string.Format("Student with id {0} is already added to this course.", student.Id);
            throw new InvalidOperationException(message);
        }

        this.students.Add(student);
        return true;
    }

    internal bool RemoveStudent(Student student)
    {
        return this.students.Remove(student);
    }

    internal bool RemoveStudent(int id)
    {
        for (int i = 0; i < this.students.Count; i++)
        {
            if (this.students[i].Id == id)
            {
                this.students.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    public bool HasStudent(Student student)
    {
        return this.students.Contains(student);
    }

    public bool HasStudent(int id)
    {
        foreach (var student in this.students)
        {
            if (student.Id == id)
            {
                return true;
            }
        }

        return false;
    }
}