using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class RandomList:ArrayList
{
    private Random rnd;
    public RandomList()
    {
        this.rnd = new Random();
    }
    public int RandomInteger()
    {
        return this.rnd.Next();
    }
    public int RandomString() => this.RandomInteger();
}
