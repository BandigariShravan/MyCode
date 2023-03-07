// See https://aka.ms/new-console-template for more information
using Harsha_6_04_02_2023;

public class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        CFugeFunction objCFugeFunction = new CFugeFunction();
        Console.WriteLine(objCFugeFunction.CFugeBalance(6, 4));
        Console.WriteLine(objCFugeFunction.CFugeBalance(2, 1));
        Console.WriteLine(objCFugeFunction.CFugeBalance(3, 3));
        Console.WriteLine(objCFugeFunction.CFugeBalance(6, 2));
        Console.WriteLine(objCFugeFunction.CFugeBalance(6, 3));
        Console.WriteLine(objCFugeFunction.CFugeBalance(6, 4));
        Console.WriteLine(objCFugeFunction.CFugeBalance(6, 6));
        //Console.WriteLine(objCFugeFunction.CFugeBalance(2, 1));
        //Console.WriteLine(objCFugeFunction.CFugeBalance(3, 3));


    }
}
//Console.WriteLine(objCFugeFunction.CFuge(6, 4));
