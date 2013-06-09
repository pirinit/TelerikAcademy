using System;
using System.Collections.Generic;

public class School
{
    private IList<Student> students;
    private IList<Course> courses;
    private string name;
    private int nextFreeStudentID = 10000;

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

    public IEnumerable<Student> Students
    {
        get
        {
            return this.students;
        }
    }

    public IEnumerable<Course> Courses
    {
        get
        {
            return this.courses;
        }
    }

    public School(string name)
    {
        this.Name = name;
        this.courses = new List<Course>();
        this.students = new List<Student>();
    }

    /// <summary>
    /// Creates course in the school.
    /// </summary>
    /// <param name="name">The name of the course.</param>
    /// <returns>New course.</returns>
    public Course AddCourse(string name)
    {
        if (HasCourse(name))
        {
            string message = string.Format("There is already a course with the same name({0}).", name);
            throw new InvalidOperationException(message);
        }

        Course newCourse = new Course(name);
        this.courses.Add(newCourse);

        return newCourse;
    }

    /// <summary>
    /// Enrolls new student in the school.
    /// </summary>
    /// <param name="name">The name of the student.</param>
    /// <returns>New student.</returns>
    public Student EnrollStudent(string name)
    {
        Student newStudent = new Student(name, this.nextFreeStudentID++);
        this.students.Add(newStudent);

        return newStudent;
    }

    /// <summary>
    /// Add student to a specified course.
    /// </summary>
    /// <param name="student">Student object.</param>
    /// <param name="course">Course object.</param>
    /// <returns>True if student is added successfully.</returns>
    /// <exception cref="InvalidOperationException">If the student is already
    /// enrolled in the course or max students count is reached.</exception>
    public bool AddStudentToCourse(Student student, Course course)
    {
        return course.AddStudent(student);
    }

    /// <summary>
    /// Removes student from a specified course.
    /// </summary>
    /// <param name="student">Student object.</param>
    /// <param name="course">Course object.</param>
    /// <returns>True if such student exist in the course and is removed successfully.</returns>
    public bool RemoveStudentFromCourse(Student student, Course course)
    {
        return course.RemoveStudent(student);
    }

    /// <summary>
    /// Removes student from a specified course by student id.
    /// </summary>
    /// <param name="studentId">Student id.</param>
    /// <param name="course">Course object.</param>
    /// <returns>True if such student exist in the course and is removed successfully.</returns>
    public bool RemoveStudentFromCourse(int studentId, Course course)
    {
        return course.RemoveStudent(studentId);
    }

    /// <summary>
    /// Checks if given course exist in the school.
    /// </summary>
    /// <param name="name">Name of the course.</param>
    /// <returns>True if the course exist.</returns>
    public bool HasCourse(string name)
    {
        foreach (var course in this.courses)
        {
            if (course.Name == name)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Checks if given course exist in the school.
    /// </summary>
    /// <param name="name">Course object.</param>
    /// <returns>True if the course exists.</returns>
    public bool HasCourse(Course course)
    {
        return this.courses.Contains(course);
    }

    /// <summary>
    /// Checks if given student is enrolled in the school.
    /// </summary>
    /// <param name="id">Student's id.</param>
    /// <returns>True if the student exists.</returns>
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

    /// <summary>
    /// Checks if given student is enrolled in the school.
    /// </summary>
    /// <param name="student">Student object.</param>
    /// <returns>True if the student exists.</returns>
    public bool HasStudent(Student student)
    {
        return this.students.Contains(student);
    }
}