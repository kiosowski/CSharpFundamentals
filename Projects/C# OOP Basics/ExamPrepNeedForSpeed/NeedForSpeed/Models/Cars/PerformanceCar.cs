using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PerformanceCar : Car
{
    private List<string> addOns;
    public PerformanceCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, (horsePower * 150) / 100, acceleration, suspension, (durability * 75) / 100)
    {
        this.AddOns = addOns;
    }
    public List<string> AddOns
    {
        get
        {
            return this.addOns;
        }
        set
        {
            this.addOns = value;
        }
    }
}
