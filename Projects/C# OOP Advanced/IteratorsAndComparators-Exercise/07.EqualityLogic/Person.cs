using System;
using System.Collections.Generic;
using System.Text;

public class Person:IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Person(string name,int age)
    {
        this.Name = name;
        this.Age = age;
    }
    public int CompareTo(Person other)
    {
        var result = this.Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }
        return result;
    }
    public override bool Equals(object obj)
    {
        var otherPerson = (Person)obj;
        if (this.Name == otherPerson.Name && this.Age == otherPerson.Age)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override int GetHashCode()
    {
        return (this.Name + this.Age.ToString()).GetHashCode();
    }

}

