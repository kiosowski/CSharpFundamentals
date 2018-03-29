using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Lake : IEnumerable<int>
{
    public List<int> Stones { get; set; }
    public Lake(IEnumerable<int> stones)
    {
        this.Stones = new List<int>(stones);
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.Stones.Count; i+=2)
        {
            yield return this.Stones[i];
        }
        for (int i = this.Stones.Count - 1; i > 0; i--)
        {
            if (i%2 == 0)
            {
                continue;
            }
            yield return this.Stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
