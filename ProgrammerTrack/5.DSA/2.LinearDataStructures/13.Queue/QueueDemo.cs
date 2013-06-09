using System;

class QueueDemo
{
    static void Main()
    {
        MyQueue<int> queue = new MyQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(88);
        queue.Enqueue(-156);

        while (!queue.IsEmpty)
        {
            Console.WriteLine(queue.Dequeue());
        }

        // throws exception
        queue.Dequeue();
    }
}