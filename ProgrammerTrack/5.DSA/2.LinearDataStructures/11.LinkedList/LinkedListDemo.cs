using System;

class LinkedListDemo
{
    static void Main()
    {
        MyLinkedList<int> list = new MyLinkedList<int>();

        list.Add(5);
        list.Add(5);
        list.Add(3);
        list.Add(19);
        list.Add(-1564);
        Console.WriteLine(list);

        Console.WriteLine("Remove 19, success: {0}", list.Remove(19));
        Console.WriteLine(list);

        Console.WriteLine("Remove 55, success: {0}", list.Remove(55));
        Console.WriteLine(list);

        list.Add(55);
        Console.WriteLine(list);
        Console.WriteLine("Remove 55, success: {0}", list.Remove(55));
        Console.WriteLine(list);

        Console.WriteLine("Remove first element: {0}", list.RemoveFirst());
        Console.WriteLine(list);

        list.Clear();
        Console.WriteLine("Is list empty: {0}", list.IsEmpty);
        //throws exception
        list.RemoveFirst();
    }
}
