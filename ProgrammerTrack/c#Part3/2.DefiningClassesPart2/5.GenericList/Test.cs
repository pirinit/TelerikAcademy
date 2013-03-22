using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Test
{
    static void Main(string[] args)
    {
        GenericList<int> list = new GenericList<int>(10);

        List<int> test = new List<int>();

        list.Add(5);
        list.Add(11);
        list.Add(88);
        list.Add(-54646);
        list.Add(77577575);

        PrintList(list);
        Console.WriteLine("Min is: {0}", list.Min());
        Console.WriteLine("Max is: {0}", list.Max());
        list.Remove(2);
        PrintList(list);
        list.Insert(666, 1);
        PrintList(list);
        Console.WriteLine(list.Find(666));
        Console.WriteLine(list);
        list.Clear();
        PrintList(list);
        Console.WriteLine(list);
    }

    static void PrintList(GenericList<int> list)
    {
        for (int i = 0; i < list.Count; i++)
		{
            Console.WriteLine(list[i]);
		}
    }
}