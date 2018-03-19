using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CastrationCenter : Center
{
    public CastrationCenter(string name) : base(name)
    {
    }
    public List<Animal> Castrate()
    {
        this.Animals.ForEach(a => a.CastrationStatus = true);
        var animals = new List<Animal>(this.Animals);
        this.Animals.Clear();
        return animals;
    }
}
