﻿using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IPerson,IIdentifiable,IBirthable
{
    private string name;
    private int age;
    private string id;
    private string birthdate;
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }
    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }
    public string Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }
    public string Birthdate
    {
        get
        {
            return this.birthdate;
        }
        set
        {
            this.birthdate = value;
        }
    }
    public Citizen(string name,int age)
    {
        this.Name = name;
        this.Age = age;
    }
    public Citizen(string name,int age,string id,string birthdate) : this(name, age)
    {
        this.Id = id;
        this.Birthdate = birthdate;
    }
}

