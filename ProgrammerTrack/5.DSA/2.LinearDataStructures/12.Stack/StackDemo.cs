using System;

public class StackDemo
{
    public static void Main()
    {
        MyStack<int> stack = new MyStack<int>();
        
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);

        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }

        stack.Pop();
    }
}
