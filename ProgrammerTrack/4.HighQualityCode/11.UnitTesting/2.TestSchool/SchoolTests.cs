using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SchoolTests
{
    [TestMethod]
    public void CreateSchoolCheckName()
    {
        School school = new School("some school");

        Assert.AreEqual("some school", school.Name);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CreateSchoolWithInvalidName()
    {
        School school = new School(null);
    }

    [TestMethod]
    public void CreateStudentCheckExistanceBySelf()
    {
        School school = new School("some name");
        Student pesho = school.EnrollStudent("pesho");

        Assert.IsTrue(school.HasStudent(pesho));
    }

    [TestMethod]
    public void CreateStudentCheckExistanceById()
    {
        School school = new School("some name");
        Student pesho = school.EnrollStudent("pesho");

        Assert.IsTrue(school.HasStudent(pesho.Id));
    }

    [TestMethod]
    public void CheckNonExistingStudentById()
    {
        School school = new School("some name");

        Assert.IsFalse(school.HasStudent(1000));
    }

    [TestMethod]
    public void AddCourseCheckExistanceByName()
    {
        School school = new School("Telerik Academy");
        Course highQualityCode = school.AddCourse("High quality code");

        Assert.IsTrue(school.HasCourse(highQualityCode.Name));
    }

    [TestMethod]
    public void AddCourseCheckExistanceBySelf()
    {
        School school = new School("Telerik Academy");
        Course highQualityCode = school.AddCourse("High quality code");

        Assert.IsTrue(school.HasCourse(highQualityCode));
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AddExistingCourse()
    {
        School school = new School("Telerik Academy");
        Course highQualityCode = school.AddCourse("High quality code");
        highQualityCode = school.AddCourse("High quality code");
    }
}