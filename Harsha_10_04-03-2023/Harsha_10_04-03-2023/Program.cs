// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");
Stopwatch stopwatch= Stopwatch.StartNew();
try
{
    Console.WriteLine("Enter a non decimal number to get its before and after  factor value of its squareroot ");
    int number = int.Parse(Console.ReadLine());
    int factor = 1;
   
    float squreroot= (float)Math.Sqrt(number);
    Console.WriteLine("SquareRoot of "+number+" is : "+squreroot+"\n");
    //int lcut=0 ;
    //int uppecut=0;
    //if (Math.Pow(squreroot,2) == number)
    //{
    //    lcut=(int)squreroot-1;
    //    uppecut=(int)squreroot+1;
    //}
    //else
    //{
    //    lcut=(int)squreroot;
    //    uppecut=(int)squreroot+1;
    //}
    //int lcut = (int)squreroot-1;
    //int uppecut=(int)squreroot+1;
    //for(int i = lcut; i>0; i--)
        for (int i = (int)squreroot-1; i>0; i--)
        {
        if (number%i==0 && i!=squreroot)
        {
            factor=i;
            Console.WriteLine("Factor before of "+squreroot+" : "+factor);// +"\n");
            //Console.WriteLine("Factors   : "+factor);
            break;
        }
        //else
        //{
        //    Console.WriteLine("before "+squreroot+" No more factors are found...");
            
        //}
    }
    Console.WriteLine();
    for(int j= (int)squreroot+1; j<number; j++)
    {
        if (number%j==0 && j!=(int)squreroot)
        {
            factor=j;
            Console.WriteLine("Factors after of "+squreroot+" : "+factor);
            //Console.WriteLine("Factors   : "+factor);
            break;
        }
        //else
        //{
        //    Console.WriteLine("After "+squreroot+" No more factors are found...");
            
        //}
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);