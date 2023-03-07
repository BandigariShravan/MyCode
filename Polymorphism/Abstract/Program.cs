using System;
abstract class Animal
{
    public abstract void animalSound();
    public void sleep()
    {
        Console.WriteLine("Zzz");
    }
}
class Pig : Animal
{
    public override void animalSound()
    {
        Console.WriteLine("The pig says:wee wee"); 
    }
}
class horse : Animal
{
    public override void animalSound()
    {
        Console.WriteLine("The horse says: neighhh!!!");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Pig myPig = new Pig();
        myPig.animalSound();
        myPig.sleep();
        horse myHorse = new horse();
        myHorse.animalSound();
        myHorse.sleep();
    }
}