using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Animal
{
    private string name;
    private int age;
    private bool cleansingStatus;
    private string adoptionCenterName;
    private bool castrationStatus;
    
    public Animal(string name,int age,string adoptionCenterName)
    {
        this.Name = name;
        this.Age = age;
        this.CleansingStatus = false;
        this.CastrationStatus = false;
        this.AdoptionCenterName = adoptionCenterName;
    }
    public bool CastrationStatus
    {
        get
        {
            return this.castrationStatus;
        }
        set
        {
            this.castrationStatus = value;
        }
    }
    public bool CleansingStatus
    {
        get { return cleansingStatus; }
        set { cleansingStatus = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string AdoptionCenterName
    {
        get
        {
            return this.adoptionCenterName;
        }
        protected set
        {
            this.adoptionCenterName = value;
        }
    }
}

