using System;

class PrintFirst10Members
{
    static void Main()
    {
        int members = 10;
        for (int i = 2; i < members+2; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write("{0}, ",i);
            }
            else
            {
                Console.Write("{0}, ", i*-1);
            }
        }
        Console.WriteLine("\u0008\u0008 \n");
    }
}