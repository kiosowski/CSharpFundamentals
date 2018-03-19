using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dog : Animal
{
    private int commands;

    public Dog(string name, int age,int commands,string adoptionCenterName) : base(name, age,adoptionCenterName)
    {
    }

    public int Commands
    {
        get
        {
            return this.commands;
        }
        private set
        {
            this.commands = value;
        }
    }
}
