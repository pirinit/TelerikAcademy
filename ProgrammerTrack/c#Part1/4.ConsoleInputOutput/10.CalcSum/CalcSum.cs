using System;

class CalcSum
{
    static void Main()
    {
        decimal sum = 1;
        int i = 2;
        decimal currentMember;
        do
        {
            currentMember = (decimal) 1 / i;
            if (i % 2 == 0)
            {
                sum += currentMember;
            }
            else
            {
                sum += -currentMember;
            }
            Console.WriteLine("{2}. Sum: {0:f5} + {1,10} ", sum, currentMember, i);
            i++;
        } while (currentMember > 0.001m);
        Console.WriteLine("The sum is: {0}.",sum);
    }
}