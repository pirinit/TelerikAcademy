using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void EnrollStudent()
    {
        School school = new School("Telerik Academy");
        Student pesho = school.EnrollStudent("Pesho");

        IEnumerable<Student> allStudents = school.Students;

        bool studentExist = false;
        foreach (var student in allStudents)
        {
            if (student == pesho)
            {
                studentExist = true;
                break;
            }
        }

        Assert.IsTrue(studentExist);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EnrollStudentWithInvalidName()
    {
        School school = new School("Telerik Academy");
        Student pesho = school.EnrollStudent(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EnrollStudentWithInvalidId()
    {
        School school = new School("Telerik Academy");

        for (int i = 0; i < 99000; i++)
        {
            school.EnrollStudent("someName");
        }
    }
}
