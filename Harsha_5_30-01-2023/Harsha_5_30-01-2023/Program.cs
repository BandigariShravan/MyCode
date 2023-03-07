// See https://aka.ms/new-console-template for more information
using Harsha_5_30_01_2023;


string mealname = "";
int[] nextmeal = CalculateNextMealTime.calculate( out mealname);
Console.WriteLine(nextmeal[0] + " hours and " + nextmeal[1] + " Minutes" + " for Your " + mealname);