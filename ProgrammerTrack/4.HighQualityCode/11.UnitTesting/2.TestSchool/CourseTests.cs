using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class CourseTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CreateCourseWithInvalidName()
    {
        School school = new School("Telerik Academy");
        Course highQualityCode = school.AddCourse(null);
    }

    [TestMethod]
    public void AddStudentToCourseCheckByStudent()
    {
        School school = new School("Telerik Academy");
        Student pesho = school.EnrollStudent("Pesho");
        Course highQualityCode = school.AddCourse("High quality code");

        school.AddStudentToCourse(pesho, highQualityCode);

        Assert.IsTrue(highQualityCode.HasStudent(pesho));
    }

    [TestMethod]
    public void AddStudentToCourseCheckByStudentId()
    {
        School school = new School("Telerik Academy");
        Student pesho = school.EnrollStudent("Pesho");
        Course highQualityCode = school.AddCourse("High quality code");

        school.AddStudentToCourse(pesho, highQualityCode);

        Assert.IsTrue(highQualityCode.HasStudent(pesho.Id));
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AddMoreThanMaxStudentsToCourse()
    {
        School school = new School("Telerik Academy");
        Course highQualityCode = school.AddCourse("High quality code");

        for (int i = 0; i < 1000; i++)
        {
            school.AddStudentToCourse(school.EnrollStudent("some name"), highQualityCode);
        }
    }

    [TestMethod]
    public void AddTenStudentsToCourseCheckCount()
    {
        School school = new School("Telerik Academy");
        Course highQualityCode = school.AddCourse("High quality code");

        for (int i = 0; i < 10; i++)
        {
            school.AddStudentToCourse(school.EnrollStudent("some name"), highQualityCode);
        }

        Assert.AreEqual(10, highQualityCode.StudentsCount);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AddStudentToCourseTwoTimes()
    {
        School school = new School("Telerik Academy");
        Student pesho = school.EnrollStudent("Pesho");
        Course highQualityCode = school.AddCourse("High quality code");

        school.AddStudentToCourse(pesho, highQualityCode);
        school.AddStudentToCourse(pesho, highQualityCode);
    }

    [TestMethod]
    public void RemoveStudentFromCourseBySelf()
    {
        School school = new School("Telerik Academy");
        Student pesho = school.EnrollStudent("Pesho");
        Course highQualityCode = school.AddCourse("High quality code");

        school.AddStudentToCourse(pesho, highQualityCode);
        bool result = school.RemoveStudentFromCourse(pesho, highQualityCode);

        Assert.IsFalse(result && highQualityCode.HasStudent(pesho));
    }

    [TestMethod]
    public void RemoveStudentFromCourseById()
    {
        School school = new School("Telerik Academy");
        Student pesho = school.EnrollStudent("Pesho");
        Student gosho = school.EnrollStudent("Gosho");
        Course highQualityCode = school.AddCourse("High quality code");

        school.AddStudentToCourse(gosho, highQualityCode);
        school.AddStudentToCourse(pesho, highQualityCode);
        bool result = school.RemoveStudentFromCourse(pesho.Id, highQualityCode);

        Assert.IsFalse(result && highQualityCode.HasStudent(pesho));
    }

    [TestMethod]
    public void RemoveNonExistingStudentFromCourseBySelf()
    {
        School school = new School("Telerik Academy");
        Student pesho = school.EnrollStudent("Pesho");
        Course highQualityCode = school.AddCourse("High quality code");

        bool result = school.RemoveStudentFromCourse(pesho, highQualityCode);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void RemoveNonExistingStudentFromCourseById()
    {
        School school = new School("Telerik Academy");
        Student pesho = school.EnrollStudent("Pesho");
        Course highQualityCode = school.AddCourse("High quality code");

        bool result = school.RemoveStudentFromCourse(pesho.Id, highQualityCode);
        Assert.IsFalse(result);
    }
}