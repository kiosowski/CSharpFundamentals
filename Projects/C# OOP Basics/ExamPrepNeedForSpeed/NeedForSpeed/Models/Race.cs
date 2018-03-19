using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private List<Car> participants;
    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>();
    }
    public List<Car> Participants
    {
        get { return participants; }
        set { participants = value; }
    }

    public int PrizePool
    {
        get { return prizePool; }
        set { prizePool = value; }
    }

    public string Route
    {
        get { return route; }
        set { route = value; }
    }

    public int Length
    {
        get { return length; }
        set { length = value; }
    }

}
