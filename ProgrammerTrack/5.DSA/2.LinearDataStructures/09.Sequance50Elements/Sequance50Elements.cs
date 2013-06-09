using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 9. We are given the following sequence:
 * S1 = N;
 * S2 = S1 + 1;
 * S3 = 2*S1 + 1;
 * S4 = S1 + 2;
 * S5 = S2 + 1;
 * S6 = 2*S2 + 1;
 * S7 = S2 + 2;
 * ...
 * Using the Queue<T> class write a program to print its first 50 members for given N.
 * Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
 */
class Sequance50Elements
{
    static void Main()
    {
        string input = Console.ReadLine();
        int n = int.Parse(input);

        PrintFirstSequanceElements(n, 50);
    }

    private static void PrintFirstSequanceElements(int sequanceStart, int elementsToPrint)
    {
        Queue<int> elements = new Queue<int>(50);

        elements.Enqueue(sequanceStart);
        int elementsToAdd = elementsToPrint;
        while (elementsToPrint > 0)
        {
            elementsToPrint--;
            int currentElement = elements.Dequeue();
            Console.WriteLine(currentElement);

            //add next elements until we calculate enough sequence members
            if (elementsToAdd > 0)
            {
                elements.Enqueue(currentElement + 1);
                elements.Enqueue(currentElement * 2 + 1);
                elements.Enqueue(currentElement + 2);
                elementsToAdd -= 3;
            }
        }
    }
}