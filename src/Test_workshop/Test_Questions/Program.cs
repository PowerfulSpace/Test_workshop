﻿


using System;

Console.ReadLine();

abstract class TestClass
{
    Person[] personal;
    private int IdA;

    public int MyPropertyA { get; set; }
    abstract public int MyPropertyB { get; set; }


    public TestClass(Person[] people) => personal = people;



    public Person this[int index]
    {
        get => personal[index];
        set => personal[index] = value;
    }

    
   

    public void MethodA()
    {

    }

    abstract public void MethodB();
}

class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}