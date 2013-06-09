using System;

/* 12. Implement the ADT stack as auto-resizable array.
* Resize the capacity on demand (when no space is available
* to add / insert a new element).
*/
public class MyStack<T>
{
    private T[] array;
    private int topElementIndex;

    public int Count
    {
        get
        {
            return this.topElementIndex + 1;
        }
    }

    public MyStack()
    {
        this.array = new T[4];
        this.topElementIndex = -1;
    }

    public void Push(T element)
    {
        topElementIndex++;
        if (topElementIndex == array.Length - 1)
        {
            Grow();
        }

        array[topElementIndex] = element;
    }

    public T Pop()
    {
        if (topElementIndex < 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        T topElement = this.array[topElementIndex];
        
        // deleting the refference to the top element in the array so the garbage collector can free its memory
        this.array[topElementIndex] = default(T);
        topElementIndex--;
        return topElement;
    }

    private void Grow()
    {
        T[] newArray = new T[this.array.Length * 2];

        for (int i = 0; i < this.array.Length; i++)
        {
            newArray[i] = this.array[i];
        }

        this.array = newArray;
    }
}