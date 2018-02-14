using System;
using System.Collections.Generic;
using System.Text;


public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string departament;
    private string email;
    private int age;
    public Employee(string name, decimal salary, string position, string departament)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.departament = departament;
    }
    public Employee(string name, decimal salary, string position, string departament, string email, int age) : this(name, salary, position, departament)
    {
        this.email = email;
        this.age = age;
    }
    public string Name
    {
        get
        {
            return this.name;
        }
    }
    public decimal Salary
    {
        get
        {
            return this.salary;
        }
    }
    public string Position
    {
        get
        {
            return this.position;
        }
    }
    public string Departament
    {
        get
        {
            return this.departament;
        }
    }
    public string Email
    {
        get
        {
            return this.email;
        }
    }
    public int Age
    {
        get
        {
            return this.age;
        }
    }
}