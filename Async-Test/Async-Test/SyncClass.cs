using System.Diagnostics;

namespace Async_Test
{
    public class SyncClass
    {
        public static void Main()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            Console.WriteLine("Statting to make Biryani.....");
            CookRice();
            MarinateChicken();
            Dum();
            Console.WriteLine("Biryani is Ready......");
            s.Stop();
            Console.WriteLine("Time Taken:"+s.Elapsed);
        }
        static void CookRice()
        {
            Console.WriteLine("Boiling Water....");
            Console.WriteLine("Water boiled....");
            Console.WriteLine("Putting Rice into Boiled Water....");
            Console.WriteLine("Rice Cooked....");
        }
        static void MarinateChicken()
        {
            Console.WriteLine("Cleaning Chicken...");
            Console.WriteLine("Chicken marinating...");
            Console.WriteLine("Chicken Marinated...");
        }
        static void Dum()
        {
            Console.WriteLine("Taking Pan And putting Rice And Chicken in layers...");
            Console.WriteLine("1st Layer is Completed...");
            Console.WriteLine("2st Layer is Completed...");
            Console.WriteLine("Final Layer is Completed...");
            Console.WriteLine("Closed lid And Started Dum");
            Console.WriteLine("Dum Completed...");
        }
    }
}

