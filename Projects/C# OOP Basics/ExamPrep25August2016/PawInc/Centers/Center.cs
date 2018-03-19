using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Center
{
    private string name;
    private List<Animal> animals;
    public Center(string name)
    {
        this.Name = name;
        this.Animals = new List<Animal>();
    }
    public string Name
    {
        get
        {
            return this.name;
        }
        protected set
        {
            this.name = value;
        }
    }
    public List<Animal> Animals
    {
        get
        {
            return this.animals;
        }
        protected set
        {
            this.animals = value;
        }
    }
}

