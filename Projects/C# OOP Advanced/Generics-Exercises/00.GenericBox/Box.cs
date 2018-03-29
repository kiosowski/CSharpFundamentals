using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Box<T> where T : IComparable
{
    private T value;
    private readonly List<T> list;
    public Box(T value)
    {
        this.value = value;
    }
    public Box()
    {
        list = new List<T>();
    }
    public void Add(T item)
    {
        list.Add(item);
    }
    public void Swap(int index1, int index2)
    {
        var oldIndex = list[index1];

        list[index1] = list[index2];
        list[index2] = oldIndex;
    }
    public int EqualsCount(T element)
    {
        return list.Count(x => x.CompareTo(element) > 0);
    }

}



