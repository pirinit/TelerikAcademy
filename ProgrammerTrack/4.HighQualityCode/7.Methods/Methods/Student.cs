using System;

class Student
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime Birthday { get; private set; }
    public string HomeTown { get; private set; }
    public string OtherInfo { get; set; }

    public Student(string firstName, string lastName, DateTime birthday, string homeTown)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Birthday = birthday;
        this.HomeTown = homeTown;
    }

    public bool IsOlderThan(Student other)
    {
        return this.Birthday<other.Birthday;
    }
}