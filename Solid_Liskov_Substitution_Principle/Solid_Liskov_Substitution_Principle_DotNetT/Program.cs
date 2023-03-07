// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Solid_Liskov_Substitution_Principle_DotNetT;

//Apple apple = new Orange()
//Console.WriteLine(apple.GetColor());//we are getting the color of the Orange not the color of Apple


Fruit fruit = new Apple();
Console.WriteLine(fruit.GetColor());
fruit = new Orange();
Console.WriteLine(fruit.GetColor());
