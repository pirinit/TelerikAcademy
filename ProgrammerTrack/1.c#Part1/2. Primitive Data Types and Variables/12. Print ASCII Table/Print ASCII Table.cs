using System;

class PrintASCIITable
{
    static void Main()
    {
        for (int i = 0; i < 256; i++)
        {
            Console.Write( (char) i + " ");
            if (i % 16 == 0)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}