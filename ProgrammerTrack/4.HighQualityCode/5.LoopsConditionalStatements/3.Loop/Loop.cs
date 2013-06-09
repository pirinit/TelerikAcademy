using System;

public class Loop
{
    public static void Main(string[] args)
    {
        int[] array = new int[100];
        int expected = 5;
        bool found = false;

        for (int i = 0; i < array.Length; i++)
        {
            if (i % 10 == 0)
            {
                Console.WriteLine(array[i]);
                if (array[i] == expected)
                {
                    found = true;
                }
            }
            else
            {
                Console.WriteLine(array[i]);
            }
        }

        // More code here
        if (found)
        {
            Console.WriteLine("Value Found");
        }
    }
}