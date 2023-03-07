using PassByValue_Reference;

internal class Program
{
    public static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        
        var Shravan = new Person("Kumar", "Shravan");
        DoSomething(Shravan);
        Console.WriteLine(Shravan.FName);
        Console.WriteLine(Shravan.LName);
    }
}