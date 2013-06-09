using System;

/* 13. Implement the ADT queue as dynamic linked list.
 * Use generics (LinkedQueue<T>) to allow storing
 * different data types in the queue.
 */
public class MyQueue<T>
{
    private MyLinkedList<T> list;

    public MyQueue()
    {
        this.list = new MyLinkedList<T>();
    }

    public bool IsEmpty
    {
        get
        {
            return this.list.IsEmpty;
        }
    }

    public void Enqueue(T element)
    {
        list.Add(element);
    }

    public T Dequeue()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        T first = this.list.RemoveFirst();
        return first;
    }

    public void Clear()
    {
        this.list.Clear();
    }
}