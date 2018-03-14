using System;
using System.Collections.Generic;
using System.Text;

public abstract class Machine
{
    private string id;

    protected Machine(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }
}