using System;
using System.Text;

/* 11. Implement the data structure linked list. Define a class ListItem<T>
* that has two fields: value (of type T) and NextItem (of type ListItem<T>).
* Define additionally a class LinkedList<T> with a single
* field FirstElement (of type ListItem<T>).
*/
public class MyLinkedList<T>
{
    private class ListItem<T>
    {
        public ListItem<T> Next { get; set; }
        public T Value { get; set; }

        public ListItem(ListItem<T> next, T value)
        {
            this.Next = next;
            this.Value = value;
        }
    }

    private ListItem<T> first;
    private ListItem<T> last;

    public MyLinkedList()
    {
        this.first = null;
        this.last = null;
    }

    public bool IsEmpty
    {
        get
        {
            return this.first == null;
        }
    }

    public T RemoveFirst()
    {
        if(this.first == null)
        {
            throw new InvalidOperationException("List is empty");
        }
        T first = this.first.Value;

        Remove(first);

        return first;
    }

    public void Clear()
    {
        this.first = null;
        this.last = null;
    }

    public void Add(T value)
    {
        ListItem<T> current = new ListItem<T>(null, value);
        if (this.first == null)
        {
            this.first = current;
            this.last = current;
        }
        else
        {
            this.last.Next = current;
            this.last = current;
        }
    }

    public bool Remove(T value)
    {
        ListItem<T> current = this.first;
        ListItem<T> prev = null;

        while (current != null && !current.Value.Equals(value))
        {
            prev = current;
            current = current.Next;
        }

        if (current != null)
        {
            //element found
            if (prev != null)
            {
                //found element is not the first element
                prev.Next = current.Next;
            }
            else
            {
                //found element is the first one
                this.first = current.Next;
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        ListItem<T> current = this.first;

        result.Append("{ ");
        while (current != null)
        {
            if (current.Value != null)
            {
                result.AppendFormat("{0}, ", current.Value);
            }

            current = current.Next;
        }

        result.Length -= 2;
        result.Append(" }");

        return result.ToString();
    }
}