﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomStack<T> : IEnumerable<T>
{
    public List<T> StackData { get; set; }
    public CustomStack()
    {
        this.StackData = new List<T>();
    }

    public void Push(T item)
    {
        this.StackData.Add(item);
    }
    public T Pop()
    {
        if (this.StackData.Count>0)
        {
            T last = this.StackData.Last();
            this.StackData.Remove(last);
            return last;
        }
        else
        {
            throw new InvalidOperationException("No elements");
        }
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = StackData.Count - 1; i >= 0; i--)
        {
            yield return this.StackData[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
