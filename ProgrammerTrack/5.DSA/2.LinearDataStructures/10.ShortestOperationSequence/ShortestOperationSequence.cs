using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 10. * We are given numbers N and M and the following operations:
 * N = N+1
 * N = N+2
 * N = N*2
 * Write a program that finds the shortest sequence of operations
 * from the list above that starts from N and finishes in M.
 * Hint: use a queue.
 * Example: N = 5, M = 16
 * Sequence: 5  7  8  16
 */
public class ShortestOperationSequence
{
    public static void Main()
    {
        int n = 5;
        int m = 1000;

        var result = PrintShortestOperationsSequence(n, m);

        Console.WriteLine(string.Join(" ", result));
    }

    private static List<int> PrintShortestOperationsSequence(int start, int end)
    {
        Queue<SequenceElement> operations = new Queue<SequenceElement>();

        SequenceElement currentElement = new SequenceElement(null, start);
        while (currentElement.Number != end)
        {
            AddNextOperations(currentElement, operations, end);

            currentElement = operations.Dequeue();
        }

        List<int> result = new List<int>();

        while (currentElement != null)
        {
            result.Add(currentElement.Number);

            currentElement = currentElement.Previous;
        }

        result.Reverse();

        return result;
    }
  
    private static void AddNextOperations(SequenceElement currentElement, Queue<SequenceElement> operations, int end)
    {
        if (currentElement.Number + 1 <= end)
        {
            operations.Enqueue(new SequenceElement(currentElement, currentElement.Number + 1));
        }

        if (currentElement.Number + 2 <= end)
        {
            operations.Enqueue(new SequenceElement(currentElement, currentElement.Number + 2));
        }

        if (currentElement.Number * 2 <= end)
        {
            operations.Enqueue(new SequenceElement(currentElement, currentElement.Number * 2));
        }
    }

    private class SequenceElement
    {
        public SequenceElement Previous { get; private set; }
        public int Number { get; private set; }

        public SequenceElement(SequenceElement previous, int currentNumber)
        {
            this.Previous = previous;
            this.Number = currentNumber;
        }
    }
}