﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AirBender : Bender
{
    private double aerialIntegrity;

    public AirBender(string name, int power,double aerialIntegirty) : base(name, power)
    {
        this.AerialIntegrity = aerialIntegirty;
    }

    public double AerialIntegrity
    {
        get { return aerialIntegrity; }
        set { aerialIntegrity = value; }
    }
    public override double GetBenderTotalPower()
    {
        return this.Power * this.AerialIntegrity;
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Air Bender: {this.Name}, Power: {this.Power}, Aerial Integrity: {this.AerialIntegrity:F2}");
        return sb.ToString();
    }
}

