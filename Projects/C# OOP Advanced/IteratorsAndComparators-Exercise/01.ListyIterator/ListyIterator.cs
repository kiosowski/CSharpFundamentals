using System;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T>
{
    public List<T> Collection { get; private set; }
    private int index;
    public ListyIterator(IEnumerable<T> items)
    {
        this.Collection = new List<T>(items);

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
}