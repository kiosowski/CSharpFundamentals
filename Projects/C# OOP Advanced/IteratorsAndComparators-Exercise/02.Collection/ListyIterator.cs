using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
{
    public List<T> Collection { get; private set; }
    private int index;
    public ListyIterator(IEnumerable<T> items)
    {
        this.Collection = new List<T>(items);

    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Collection.Count; i++)
        {
            yield return this.Collection[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public bool HasNext()
    {
        if (this.index + 1 < this.Collection.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Move()
    {
        if (HasNext())
        {
            this.index++;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Print()
    {
        if (this.Collection.Count > 0)
        {
            Console.WriteLine(this.Collection[this.index]);
        }
        else
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }
    public void PrintAll()
    {
        if (this.Collection.Count > 0)
        {
            Console.WriteLine(string.Join(" ", Collection));
        }
        else
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }
}

