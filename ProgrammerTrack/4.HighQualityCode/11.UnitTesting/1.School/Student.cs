using System;

public class Student
{
    private string name;
    private int id;

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

    public int Id
    {
        get
        { 
            return this.id; 
        }
        set 
        {
            if (value < 10000 || 99999 < value)
            {
                throw new ArgumentException("Id can not be less than 10000 or greather than 99999");
            }
            this.id = value; 
        }
    }

    internal Student(string name, int id)
    {
        this.Name = name;
        this.Id = id;
    }
}