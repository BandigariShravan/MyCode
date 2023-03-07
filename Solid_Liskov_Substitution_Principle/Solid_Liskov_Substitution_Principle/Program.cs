// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Solid_Liskov_Substitution_Principle;

var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };
SumCalculator sum=new SumCalculator(numbers);
Console.WriteLine($"The Sum of all the numbers: {sum.Calculate()}");

Console.WriteLine();

EvenNumberSumCalculation EvenSum = new EvenNumberSumCalculation(numbers);
Console.WriteLine($"The Sum of all the even numbers: {EvenSum.Calculate()}");

SumCalculator sum1=new EvenNumberSumCalculation(numbers);
Console.WriteLine($"The sum of all the even numbers:{sum1.Calculate()}");