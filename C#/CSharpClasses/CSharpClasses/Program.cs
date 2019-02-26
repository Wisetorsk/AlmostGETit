using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Car[] cars =
            {
                new Car(),
                new Car("Mazda", "6", 2005), 
                new Car("Volkswagen", "Golf 5k", 2010), 
            };

            foreach (var car in cars)
            {
                car.WhatAmI();
            }
        }
    }
}


internal class Car
{
    private readonly int _age;
    private readonly string _model;
    private readonly string _make;

    public Car()
    {
        _age = 0;
        _model = "N/A";
        _make = "N/A";
    }

    public Car(string make, string model, int age)
    {
        this._make = make;
        this._model = model;
        this._age = age;
    }

    public void WhatAmI()
    {
        Console.WriteLine("Make: {0}\nModel: {1}\nModel Year: {2}",this._make, this._model, this._age);
    }
}