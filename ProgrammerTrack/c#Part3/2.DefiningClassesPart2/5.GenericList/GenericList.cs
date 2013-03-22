using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  5. Write a generic class GenericList<T> that keeps a list of elements
* of some parametric type T. Keep the elements of the list in an array
* with fixed capacity which is given as parameter in the class constructor.
* Implement methods for adding element, accessing element by index,
* removing element by index, inserting element at given position, clearing the list,
* finding element by its value and ToString(). Check all input parameters
* to avoid accessing elements at invalid positions.
*/

class GenericList<T> where T:IComparable<T>, IComparable
{
    private T[] array;
    private int nextEmptyindex;

    public int Count
    {
        get
        {
            return this.nextEmptyindex;
        }
    }

    public T this[int index]
    {
        get
        {
            IsIndexInRange(index);
            return this.array[index];
        }
        set
        {
            IsIndexInRange(index);
            this.array[index] = value;
        }
    }

    public GenericList(int size)
    {
        this.array = new T[size];
        this.nextEmptyindex = 0;
    }

    public void Add(T element)
    {
        if (nextEmptyindex >= this.array.Length)
        {
            //throw new Exception("Array capacity reached.");
            Grow();
        }
        this.array[nextEmptyindex] = element;
        nextEmptyindex++;
    }

    public void Remove(int elementIndex)
    {
        IsIndexInRange(elementIndex);
        for (int i = elementIndex; i < this.nextEmptyindex; i++)
        {
            this.array[i] = this.array[i + 1];
        }
        this.nextEmptyindex--;
    }

    public void Insert(T element, int index)
    {
        IsIndexInRange(index);
        if (nextEmptyindex >= this.array.Length)
        {
            //throw new Exception("Array capacity reached.");
            Grow();
        }
        for (int i = this.nextEmptyindex; i > index ; i--)
        {
            this.array[i] = this.array[i - 1];
        }
        this.array[index] = element;
        this.nextEmptyindex++;
    }

    public void Clear()
    {
        this.array = new T[this.array.Length];
        this.nextEmptyindex = 0;
    }

    public int Find(T element)
    {
        int index = -1;

        for (int i = 0; i < this.nextEmptyindex; i++)
        {
            if (element == (dynamic)this.array[i])
            {
                index = i;
                break;
            }
        }
        return index;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append("{");
        for (int i = 0; i < this.nextEmptyindex; i++)
        {
            result.AppendFormat(" {0},", this.array[i]);
        }
        if (result.Length == 1)
        {
            result.Append("}");
        }
        else
        {
            result.Append("\x0008 }");
        }
        return result.ToString();
    }

    private void Grow()
    {
        T[] tempArr = new T[this.array.Length * 2];
        for (int i = 0; i < this.nextEmptyindex; i++)
        {
            tempArr[i] = this.array[i];
        }
        this.array = tempArr;
    }

    public T Min()
    {
        T min = this.array[0];
        for (int i = 0; i < this.nextEmptyindex; i++)
        {
            if (min.CompareTo(this.array[i])>0)
            {
                min = this.array[i];
            }
        }

        return min;
    }

    public T Max()
    {
        T max = this.array[0];
        for (int i = 0; i < this.nextEmptyindex; i++)
        {
            if (max.CompareTo(this.array[i]) < 0)
            {
                max = this.array[i];
            }
        }

        return max;
    }

    private void IsIndexInRange(int index)
    {
        if (!(0 <= index && index < nextEmptyindex))
        {
            string message = String.Format("Index should be equal to or greather than 0 and less than or equal to last's element index({0})", this.nextEmptyindex - 1);
            throw new ArgumentOutOfRangeException(message);
        }
    }
}