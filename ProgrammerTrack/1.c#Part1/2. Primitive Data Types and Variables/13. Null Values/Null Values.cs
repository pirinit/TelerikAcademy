using System;

class NullValues
{
    static void Main()
    {
        int? nullInt = null;
        double? nullDouble = null;
        Console.WriteLine("This is null integer: {0}\nThis is null double: {1}", nullInt, nullDouble);
        nullInt += 5;
        nullDouble += null;
        Console.WriteLine("This is null integer: {0}\nThis is null double: {1}", nullInt, nullDouble);
    }
}