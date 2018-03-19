using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CleansingCenter : Center
{
    public CleansingCenter(string name) : base(name)
    {
    }
    public List<Animal> Cleanse()
    {
        this.Animals.ForEach(a => a.CleansingStatus = true);
        var animals = new List<Animal>(this.Animals);
        this.Animals.Clear();
        return animals;
    }
}
